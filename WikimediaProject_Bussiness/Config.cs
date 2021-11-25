using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaProject_Bussiness.Model
{
    public class Config
    {
        public const int LastHours = 5;
        public DateTime currentStandardTime = DateTime.Now.ToUniversalTime();

                   
        public static string TempFolderPath = "c:/tempWikimedia/";
        public static string PageUrl = "https://dumps.wikimedia.org/other/pageviews/{0}/{1}-{2}/pageviews-{3}-{4}.gz";
        public static string FileName = "pageviews-{0}-{1}.gz";
        public static string FileNameUnZip = "pageviews-{0}-{1}";

        public static string ExtensionFile = "*.gz";




    }
}
