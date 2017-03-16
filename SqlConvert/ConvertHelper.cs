using SqlConvert.Model;
using SqlConvert.Template;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SqlConvert
{
    public class ConvertHelper
    {
        System.Data.SqlClient.SqlConnection conn = null;

        string namespaces = @"using SH3H.MXWater.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;";

        string baseClassNamespaces = "SH3H.WAP.Mx";

        string DirectoryPath = "Build";

        public void Connecting()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            conn = new System.Data.SqlClient.SqlConnection(connection);
        }

        public void Build(string regexName, Func<List<string>, List<string>> filderFunc)
        {
            Connecting();

            List<string> tableNames = null;
            Dictionary<string, List<Columns>> tables = null;
            using (conn)
            {
                conn.Open();
                var baseNames = GetTableName(regexName);
                tableNames = filderFunc(baseNames);
                tables = Read(tableNames);

            }

            Dictionary<string, string> modeldict = GetModelList(tables);
            Dictionary<string, string> dtoModeldict = GetDtoModelList(tables);
            Dictionary<string, string> iStoragedict = GetIStorage(tables);
            Dictionary<string, string> iRepositorydict = GetIRepository(tables);
            Dictionary<string, string> repositorydict = GetRepository(tables);
            Dictionary<string, string> sqldict = GetSql(tables);

            Dictionary<string, string> iServicedict = GetIService(tables);
            Dictionary<string, string> servicedict = GetService(tables);
            Dictionary<string, string> controllerdict = GetController(tables);

            SaveDict(modeldict, "Model");
            SaveDict(dtoModeldict, "DtoModel");
            SaveDict(iStoragedict, "DataAccess");
            SaveDict(iRepositorydict, "Repo.Contact");
            SaveDict(repositorydict, "Repo");
            SaveDict(sqldict, "Sql");

            SaveDict(iServicedict, "Contracts");
            SaveDict(servicedict, "Service");
            SaveDict(controllerdict, "Controller");
        }

        public Dictionary<string, List<Columns>> Read(List<string> tableNameList)
        {
            #region command
            string command = @"
                        SELECT  CASE WHEN col.colorder = 1 THEN obj.name  
                                          ELSE ''  
                                     END AS TableName,  
                                col.colorder AS ColumnNo ,  
                                col.name AS ColumnName ,  
                                ISNULL(ep.[value], '') AS Descaption ,  
                                t.name AS [Type] ,  
                                col.length AS [Length] ,  
                                ISNULL(COLUMNPROPERTY(col.id, col.name, 'Scale'), 0) AS PointLength ,  
                                CASE WHEN COLUMNPROPERTY(col.id, col.name, 'IsIdentity') = 1 THEN '√'  
                                     ELSE ''  
                                END AS [Check] ,  
                                CASE WHEN EXISTS ( SELECT   1  
                                                   FROM     dbo.sysindexes si  
                                                            INNER JOIN dbo.sysindexkeys sik ON si.id = sik.id  
                                                                                      AND si.indid = sik.indid  
                                                            INNER JOIN dbo.syscolumns sc ON sc.id = sik.id  
                                                                                      AND sc.colid = sik.colid  
                                                            INNER JOIN dbo.sysobjects so ON so.name = si.name  
                                                                                      AND so.xtype = 'PK'  
                                                   WHERE    sc.id = col.id  
                                                            AND sc.colid = col.colid ) THEN '√'  
                                     ELSE ''  
                                END AS PK ,  
                                CASE WHEN col.isnullable = 1 THEN '√'  
                                     ELSE ''  
                                END AS [Null] ,  
                                ISNULL(comm.text, '') AS [Default]
                        FROM    dbo.syscolumns col  
                                LEFT  JOIN dbo.systypes t ON col.xtype = t.xusertype  
                                inner JOIN dbo.sysobjects obj ON col.id = obj.id  
                                                                 AND obj.xtype = 'U'  
                                                                 AND obj.status >= 0  
                                LEFT  JOIN dbo.syscomments comm ON col.cdefault = comm.id  
                                LEFT  JOIN sys.extended_properties ep ON col.id = ep.major_id  
                                                                              AND col.colid = ep.minor_id  
                                                                              AND ep.name = 'MS_Description'  
                                LEFT  JOIN sys.extended_properties epTwo ON obj.id = epTwo.major_id  
                                                                                 AND epTwo.minor_id = 0  
                                                                                 AND epTwo.name = 'MS_Description'  
                        WHERE   obj.name = '{0}'--表名  
                        ORDER BY col.colorder ;  
";
            #endregion

            Dictionary<string, List<Columns>> result = new Dictionary<string, List<Columns>>();

            foreach (var tableName in tableNameList)
            {
                List<Columns> columns = new List<Columns>();
                string cmd = string.Format(command, tableName);
                System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand(cmd, conn);
                var reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    //reader.GetOrdinal("id")是得到ID所在列的index,  
                    //reader.GetInt32(int n)这是将第n列的数据以Int32的格式返回  
                    //reader.GetString(int n)这是将第n列的数据以string 格式返回  
                    string columnName = reader.GetString(reader.GetOrdinal("ColumnName"));
                    string type = reader.GetString(reader.GetOrdinal("Type"));
                    object length = reader.GetValue(reader.GetOrdinal("Length"));
                    int pointLength = reader.GetInt32(reader.GetOrdinal("PointLength"));
                    bool check = reader.GetString(reader.GetOrdinal("Check")) == "v";
                    bool pk = reader.GetString(reader.GetOrdinal("PK")) == "v";
                    bool isnull = reader.GetString(reader.GetOrdinal("Null")) == "v";

                    var column = new Columns()
                    {
                        Check = check,
                        ColumnName = columnName,
                        Length = Convert.ToInt32(length),
                        Null = isnull,
                        PK = pk,
                        PointLength = pointLength,
                        Type = type,
                    };

                    column.CSharpName = GetCSharpNameFromSqlName(column.ColumnName);
                    column.CSharpType = GetCSharpTypeFromSqlType(column);
                    column.SQLType = GetCSharpSqlTypeFromSqlType(column);
                    column.JsonName = GetJsonNameFromSqlName(column.ColumnName);

                    columns.Add(column);
                    Console.WriteLine(tableName + "结构读取成功");
                }

                reader.Close();
                result.Add(tableName, columns);
            }

            return result;
        }

        public List<string> GetTableName(string regexName)
        {
            List<string> result = new List<string>();

            string commond = "SELECT Name FROM SYS.TABLES WHERE TYPE='U' AND NAME LIKE '%{0}%'";
            string cmd = string.Format(commond, regexName);
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand(cmd, conn);
            var reader = comm.ExecuteReader();

            while (reader.Read())
            {
                string columnName = reader.GetString(reader.GetOrdinal("Name"));
                result.Add(columnName);
            }

            reader.Close();

            return result;
        }

        public Dictionary<string, string> GetModelList(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TModel model = new TModel()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".Model",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add(model.ClassName, content);
            }
            return result;
        }

        public Dictionary<string, string> GetDtoModelList(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TDtoModel model = new TDtoModel()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".Model",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add(model.ClassName + "Dto", content);
            }
            return result;
        }

        public Dictionary<string, string> GetIStorage(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TIStorage model = new TIStorage()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".DataAccess",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add("I" + model.ClassName + "Storage", content);
            }
            return result;
        }

        public Dictionary<string, string> GetIRepository(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TIRepository model = new TIRepository()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".DataAccess.Repo.Contracts",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add("I" + model.ClassName + "Repository", content);
            }
            return result;
        }

        public Dictionary<string, string> GetRepository(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TRepository model = new TRepository()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".DataAccess.Repo",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add(model.ClassName + "Repository", content);
            }
            return result;
        }

        public Dictionary<string, string> GetSql(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TSQL model = new TSQL()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".DataAccess.SqlServer",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                   JsonName=GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add(model.ClassName + "Storage", content);
            }
            return result;
        }

        public Dictionary<string, string> GetIService(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TIService model = new TIService()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".Contracts",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add("I" + model.ClassName + "Service", content);
            }
            return result;
        }

        public Dictionary<string, string> GetService(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TService model = new TService()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".Service",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add( model.ClassName + "Service", content);
            }
            return result;
        }

        public Dictionary<string, string> GetController(Dictionary<string, List<Columns>> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var tablename in dict.Keys)
            {
                List<Columns> columns = dict[tablename];
                TController model = new TController()
                {
                    ClassName = GetCSharpNameFromSqlName(tablename),
                    Columns = columns,
                    PkColumns = columns.Where(p => p.PK).ToList(),
                    OtherColumns = columns.Where(p => !p.PK).ToList(),
                    ModelSpaceName = "Mx",
                    Namespace = baseClassNamespaces + ".Controllers",
                    TableName = tablename,
                    ShareNamespace = "MXWater",
                    JsonName = GetJsonNameFromSqlName(tablename),
                };

                string content = model.TransformText();

                result.Add(model.ClassName + "Controller", content);
            }
            return result;
        }

        public string GetCSharpNameFromSqlName(string name)
        {
            string result = "";
            var columnNames = name.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in columnNames)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }

                if (item.Length == 1)
                {
                    result += item.ToUpper();
                    continue;
                }

                result += item.Substring(0, 1).ToUpperInvariant() + item.Substring(1, item.Length - 1).ToLowerInvariant();
            }
            return result;
        }

        public string GetJsonNameFromSqlName(string name)
        {
            string result = GetCSharpNameFromSqlName(name);
            if (result.Length > 0)
            {
                result = result.Substring(0, 1).ToLower() + result.Substring(1, result.Length - 1);
            }
            return result;
        }

        public string GetCSharpTypeFromSqlType(Columns column)
        {
            switch (column.Type)
            {
                case "int":
                    return "int";
                case "nvarchar":
                case "varchar":
                case "nchar":
                case "char":
                    return "string";
                case "bit":
                    return "bool";
                case "datetime":
                case "datetime2":
                    return "DateTime";
                case "decimal":
                    return "decimal";
                default:
                    return "object";
            }
        }

        public string GetCSharpSqlTypeFromSqlType(Columns column)
        {
            switch (column.Type)
            {
                case "int":
                    return "Int32";
                case "nvarchar":
                case "varchar":
                case "nchar":
                case "char":
                case "text":
                    return "String";
                case "bit":
                    return "Boolean";
                case "datetime":
                case "datetime2":
                    return "DateTime";
                case "decimal":
                    return "Decimal";
                default:
                    return "String";
            }
        }

        public void SaveDict(Dictionary<string, string> dict, string dictpath)
        {
            if (!Directory.Exists(DirectoryPath + "/" + dictpath))
            {
                Directory.CreateDirectory(DirectoryPath + "/" + dictpath);
            }

            foreach (var key in dict.Keys)
            {
                string fileName = key + ".cs";
                string content = dict[key];
                StreamWriter sw = new StreamWriter(DirectoryPath + "/" + dictpath + "/" + fileName);
                sw.Write(content);
                sw.Close();
            }

        }
    }
}
