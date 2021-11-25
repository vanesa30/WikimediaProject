using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaProject_Bussiness.Model
{
   public class LanguagePage
    {

        public DateTime Period { get; set; }
        public string Page { get; set; }
        public uint ViewCount { get; set; }

        public override string ToString()
        {
            return string.Concat("\t",
                Period.ToString("hh tt"),
                "\t",
                Page, "\t",
                ViewCount);
        }

    }
}
