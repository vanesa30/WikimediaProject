using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaProject_Bussiness.Model;

using WikimediaProject_Bussiness.Service;

namespace WikimediaProject_Bussiness.Repository
{
   public  class ProcessInformation
    {
        private FileService _fileService;
        private DateTime _startTime;

        private List<LanguageDomain> listLanguageDomain;
        private int x;
        public ProcessInformation()
        {
            _fileService = new FileService();
            _startTime = DateTime.Now.ToUniversalTime().AddHours(-2) ;         


        }
        public void ProcessAllData()
        {
            try
            {
                LanguageDomainReport firstReport = new LanguageDomainReport();
              
                string TemporalPath = _fileService.GetDataPath(_startTime); // name of the Temporal path where the files had been downloaded
                string PathFile;
                DownLoadsData objDownLoad = new DownLoadsData(_fileService);
                objDownLoad.DownloadAllPeriodsData(_startTime, Config.LastHours, TemporalPath);
                objDownLoad.UnZipFiles(TemporalPath);

                DataCollection processData = new DataCollection();


                listLanguageDomain = new List<LanguageDomain>();
                    for (int currentNumber = 0; currentNumber< Config.LastHours; currentNumber++)
                    {

                        _fileService.ConfigurateByPeriod(_startTime, TemporalPath);
                        PathFile = _fileService.GetFileNameNoExtension();


                       using (FileReader frs = new FileReader(PathFile))
                        {
                            Console.WriteLine(string.Concat("Processing Data ", PathFile, "..."));
                            PageViewData periodData = frs.GetDataToCollection();
                            Console.WriteLine("\tProcessing language and domain data for period " + _startTime.ToShortDateString());

                        List<LanguageDomain> languageDomainbyPeriod = processData.GetDataGroupByDomain(periodData, _startTime);
                        listLanguageDomain.AddRange(languageDomainbyPeriod);
           
                        }
                        _startTime = _startTime.AddHours(-1);

                   
                  
                    }

                Console.Clear();
                showDataConsole();




            }
            catch (Exception ex)
            {
                Console.WriteLine("Something was wrong.... " + ex);
            }
         
        }


        public void showDataConsole()
        {

            Console.WriteLine("\t Period \t\t Domain \t\t ViewCount");

            foreach (LanguageDomain item in listLanguageDomain)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n\n");

        }




    }
}
