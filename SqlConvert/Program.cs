using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertHelper helper = new ConvertHelper();
            helper.Build("MX_", (p) =>
            {
                return p.Where(item =>
                    true
                    //  !item.Contains("LOG") &&
                    //!item.Contains("SYSTEM_USER") &&
                    //!item.Contains("MENU") &&
                    //!item.Contains("PUBLIC_ACCOUNT")
                ).ToList();
            });


        }
    }
}
