﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 12.0.0.0
//  
//     对此文件的更改可能会导致不正确的行为。此外，如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SqlConvert.Template
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class TController : TControllerBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("   \r\n");
            this.Write("using SH3H.SDK.WebApi.Controllers;\r\nusing SH3H.SDK.WebApi.Core;\r\nusing SH3H.SDK.W" +
                    "ebApi.Core.Models;\r\nusing SH3H.WAP.");
            
            #line 12 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModelSpaceName));
            
            #line default
            #line hidden
            this.Write(".Contracts;\r\nusing SH3H.WAP.");
            
            #line 13 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModelSpaceName));
            
            #line default
            #line hidden
            this.Write(".Model.Dto;\t  \r\nusing SH3H.WAP.");
            
            #line 14 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModelSpaceName));
            
            #line default
            #line hidden
            this.Write(".Model;\r\nusing SH3H.");
            
            #line 15 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ShareNamespace));
            
            #line default
            #line hidden
            this.Write(".Share;\r\nusing System.Web.Http;\r\n\r\nnamespace ");
            
            #line 18 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n     /// <summary>\r\n    ///服务控制器\r\n    /// </summary>\r\n    [Resource(\"");
            
            #line 23 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(JsonName));
            
            #line default
            #line hidden
            this.Write("ServiceRes\")]\r\n    [RoutePrefix(Consts.URL_PREFIX_WAP + \"/");
            
            #line 24 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModelSpaceName.ToLower()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n    public class ");
            
            #line 25 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Controller : BaseController<I");
            
            #line 25 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Service>\r\n    {\r\n\t\t/// <summary>\r\n        /// 新增模型\r\n        /// </summary>\r\n     " +
                    "   /// <param name=\"entity\">要增加的模型实体对象</param>\r\n        /// <returns>增加的模型实体对象</" +
                    "returns>\r\n\t\t[HttpPost]\r\n\t\t[Route(\"");
            
            #line 33 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName.ToLower()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t\t[ActionName(\"create");
            
            #line 34 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t\tpublic WapResponse<");
            
            #line 35 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto> Create");
            
            #line 35 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("([FromBody]");
            
            #line 35 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto entity){\r\n            var result = Service.Create");
            
            #line 36 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(entity);\r\n            return new WapResponse<");
            
            #line 37 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto>(result);\r\n\t\t}\r\n\r\n        /// <summary>\r\n        /// 修改模型\r\n        /// </summ" +
                    "ary>\r\n        /// <param name=\"id\">模型编号</param>\r\n        /// <param name=\"entity" +
                    "\">要修改的模型实体对象</param>\r\n        /// <returns>修改后的模型实体对象</returns>\r\n\t\t[HttpPut]\r\n\t\t" +
                    "[Route(\"");
            
            #line 47 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName.ToLower()));
            
            #line default
            #line hidden
            
            #line 47 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

			   for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            this.Write("/{");
            
            #line 51 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            this.Write("}");
            
            #line 51 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				}
		
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t\t[ActionName(\"update");
            
            #line 54 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\")]\r\n        public  WapResponse<");
            
            #line 55 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto> Update");
            
            #line 55 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("ById(");
            
            #line 55 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            
            #line 59 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 59 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            this.Write(",");
            
            #line 59 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				}
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 60 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto entity)\r\n\t\t{\r\n            return new WapResponse<");
            
            #line 62 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto>(Service.Update");
            
            #line 62 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("ById(");
            
            #line 62 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

			   for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            
            #line 66 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            this.Write(",");
            
            #line 66 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
 
				}
		
            
            #line default
            #line hidden
            this.Write(" entity));\r\n\t   }\r\n\r\n        /// <summary>\r\n        /// 删除模型\r\n        /// </summa" +
                    "ry>\r\n        /// <param name=\"id\">模型编号</param>\r\n        /// <returns>是否删除成功</ret" +
                    "urns>\r\n\t\t[HttpDelete]\r\n\t\t[Route(\"");
            
            #line 77 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName.ToLower()));
            
            #line default
            #line hidden
            
            #line 77 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

			   for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            this.Write("/{");
            
            #line 81 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            this.Write("}");
            
            #line 81 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				}
		
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t\t[ActionName(\"delete");
            
            #line 84 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\")]\r\n        public  WapBoolean Delete");
            
            #line 85 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 86 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
				for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];

            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 89 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 89 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            
            #line 89 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((i==PkColumns.Count-1)?"":","));
            
            #line default
            #line hidden
            this.Write(" \r\n");
            
            #line 90 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
				}
            
            #line default
            #line hidden
            this.Write("\t\t){\r\n\t\t\t return new WapBoolean(Service.Delete");
            
            #line 92 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 92 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

			   for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            
            #line 96 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            
            #line 96 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((i==PkColumns.Count-1)?"":","));
            
            #line default
            #line hidden
            
            #line 96 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				}
		
            
            #line default
            #line hidden
            this.Write("));\r\n\t   }\r\n\r\n        /// <summary>\r\n        /// 获取所有模型\r\n        /// </summary>\r\n" +
                    "        /// <returns>所有公告板对象集合</returns>\r\n\t\t[HttpGet]\r\n\t\t[Route(\"");
            
            #line 106 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName.ToLower()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t\t[ActionName(\"get");
            
            #line 107 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("s\")]\r\n        public WapCollection<");
            
            #line 108 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto> Get");
            
            #line 108 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("All(){\r\n            return new WapCollection<");
            
            #line 109 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto>(Service.Get");
            
            #line 109 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("All());\r\n\t\t}\r\n\r\n        /// <summary>\r\n        /// 获取指定模型\r\n        /// </summary>" +
                    "\r\n        /// <param name=\"id\">模型编号</param>\r\n        /// <returns>模型</returns>\r\n" +
                    "\t\t[HttpGet]\r\n\t\t[Route(\"");
            
            #line 118 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName.ToLower()));
            
            #line default
            #line hidden
            
            #line 118 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

			   for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            this.Write("/{");
            
            #line 122 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            this.Write("}");
            
            #line 122 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				}
		
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t\t[ActionName(\"get");
            
            #line 125 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\")]\r\n        public WapResponse<");
            
            #line 126 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto> Get");
            
            #line 126 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("ById(");
            
            #line 126 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            
            #line 130 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 130 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            
            #line 130 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((i==PkColumns.Count-1)?"":","));
            
            #line default
            #line hidden
            
            #line 130 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
 
				}
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t{\r\n\t\t\t\treturn new WapResponse<");
            
            #line 133 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Dto>(Service.Get");
            
            #line 133 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("ById(");
            
            #line 133 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

			   for (int i = 0; i < PkColumns.Count; i++)
				{
					var column = PkColumns[i];
				
            
            #line default
            #line hidden
            
            #line 137 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column.CSharpName.ToLower()));
            
            #line default
            #line hidden
            
            #line 137 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((i==PkColumns.Count-1)?"":","));
            
            #line default
            #line hidden
            
            #line 137 "D:\Project\SqlConvert\SqlConvert\Template\TController.tt"

				}
		
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t}\r\n\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class TControllerBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
