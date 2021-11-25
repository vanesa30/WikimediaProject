using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WikimediaProject_Bussiness.Model
{
    class LanguageDomainReport
    {

        /// <summary>
        /// List Language domain count.
        /// </summary>
        public List<LanguageDomain> Data { get; set; }
        public string IdentifierProcess { get; set; }
        public LanguageDomainReport() => Data = new List<LanguageDomain>();
        public void AddLanguageDomain(LanguageDomain item)
        {
            if (Data != null)
                Data.Add(item);
        }
    }
}

