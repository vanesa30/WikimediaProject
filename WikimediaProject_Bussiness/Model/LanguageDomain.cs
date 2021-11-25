using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaProject_Bussiness.Model
{
   public  class LanguageDomain
    {

    public DateTime Period { get; set; }
    //    public string LanguageCode { get; set; }
        public string Domain { get; set; }
        public uint CountView { get; set; }


        public override string ToString()
        {
            return string.Concat("\t",
             //  Period.ToString("hh tt"),
               Period.ToString("dd-MM-yyyy") + " " + Period.ToString("HH tt"),           

            //"\t", LanguageCode,
            "\t\t", Domain,
              "\t\t", CountView);
        }
    }
}
