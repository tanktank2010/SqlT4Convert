using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConvert.Model
{
    public class Columns
    {
        public string CSharpName { get; set; }
        public string JsonName { get; set; }
        public string ColumnName { get; set; }
        public string Type { get; set; }       
        public string SQLType { get; set; }
        public int Length { get; set; }
        public int PointLength { get; set; }
        public string CSharpType { get; set; }
        public bool Check { get; set; }
        public bool PK { get; set; }
        public bool Null { get; set; }

    }
}
