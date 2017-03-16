using SqlConvert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConvert.Template
{
    partial class TController
    {
        public List<Columns> Columns { get; set; }

        public List<Columns> PkColumns { get; set; }

        public List<Columns> OtherColumns { get; set; }


        public string Namespace { get; set; }

        public string ModelSpaceName { get; set; }

        public string ClassName { get; set; }

        public string JsonName { get; set; }

        public string TableName { get; set; }
        public string ShareNamespace { get; set; }
        public TController()
        {
            Columns = new List<Columns>();
        }
    }
}
