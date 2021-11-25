using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaProject_Bussiness.Model
{
   public class PageView
    {
        public string DomainCode { get; set; }
 
        public string PageTitle { get; set; }

        public uint ViewCount { get; set; }
    }
}
