using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WikimediaProject_Bussiness.Interface;
using WikimediaProject_Bussiness.Model;

namespace WikimediaProject_Bussiness
{
    public class FileService : IFileService
    {

        private string UrlSourceWebPage;
        private string TargetDirectory;
        private string targetFileName;
        private string targetFileNameWithoutExt;

        public void ConfigurateByPeriod(DateTime period, string folderName)
        {
            string year = period.Year.ToString();
            string month = period.ToString("MM");
            string formatedDate = period.ToString("yyyyMMdd");
            string formatedTime = period.ToString("HH0000");
         
          

            targetFileName = String.Format(Config.FileName, formatedDate, formatedTime);
            targetFileNameWithoutExt = String.Format(Config.FileNameUnZip, formatedDate, formatedTime);

            UrlSourceWebPage = String.Format(Config.PageUrl, year, year, month, formatedDate, formatedTime);


            targetFileName = string.Concat(folderName, "\\", targetFileName);
            targetFileNameWithoutExt = string.Concat(folderName, "\\", targetFileNameWithoutExt);
            TargetDirectory = folderName;

        }

        public void DecompressZipFile(FileInfo UnzipFile)
        {

            using FileStream objFileStream = UnzipFile.OpenRead();
            string actualFileName = UnzipFile.FullName;
            Console.WriteLine(string.Concat("Descompressing file ", actualFileName, "..."));
            
            string newFileName = actualFileName.Remove(actualFileName.Length - UnzipFile.Extension.Length);
            using FileStream decompressedFileStream = File.Create(newFileName);
            using GZipStream decompressionStream = new GZipStream(objFileStream, CompressionMode.Decompress);
            decompressionStream.CopyTo(decompressedFileStream);
        }

        public void DownloadFile()
        {
            Console.WriteLine(string.Concat("Downloading file ", targetFileName, "..."));
             using WebClient wc = new WebClient();

          
            wc.DownloadFile(new Uri(UrlSourceWebPage), targetFileName);
        }


        public string GetDataPath(DateTime period)
        {
            return string.Concat(Config.TempFolderPath, period.Ticks.ToString());
        }
        public void VerifyTempPath()
        {
            if (string.IsNullOrEmpty(TargetDirectory))
                throw new ArgumentNullException("File not found.");
            if (!Directory.Exists(TargetDirectory))
                Directory.CreateDirectory(TargetDirectory);
        }

        public string GetTempPath(DateTime period)
        {
            return Config.TempFolderPath + period.Ticks.ToString();
        }

        public string GetFileNameNoExtension()
        {
            return targetFileNameWithoutExt;
        }
    }

      
    
    
}
