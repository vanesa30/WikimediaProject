using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaProject_Bussiness.Interface;
using WikimediaProject_Bussiness.Model;

namespace WikimediaProject_Bussiness.Service
{
    public class DownLoadsData
    {
        private  IFileService _fileService;
        private int curentNumber=0;

        //method that allows call another method for downloading each period of the last hours

        public DownLoadsData(IFileService fileService)
        {
            this._fileService = fileService;
        }
 
              public void DownloadAllPeriodsData(DateTime startTime, int numberHours, string TemporalPath)
            {
                               
                    

                    for (int currentNumber=0; currentNumber< numberHours; currentNumber++)
                    {
                            DownloadByPeriod(startTime, TemporalPath);

                            startTime = startTime.AddHours(-1);
                            curentNumber++;
                     }
            
                    Console.WriteLine("All files from wikimedia has been downloaded.");
            }



        //DownLoad each period of the last 5 hours
        private void DownloadByPeriod(DateTime period, string directoryName)
        {
            _fileService.ConfigurateByPeriod(period, directoryName);
            _fileService.VerifyTempPath();
            _fileService.DownloadFile();
        }

        public void UnZipFiles(string folderPath)
        {
            DirectoryInfo PathTemp = new DirectoryInfo(folderPath); // Location of the Directory where the files has been downloaded
            foreach (FileInfo fileToDecompress in PathTemp.GetFiles(Config.ExtensionFile))
                _fileService.DecompressZipFile(fileToDecompress);
            Console.WriteLine("Files has just been downloaded...");
        }


    }
}
