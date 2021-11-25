using System;
using System.IO;
using System.Threading.Tasks;

namespace WikimediaProject_Bussiness.Interface
{
    public interface IFileService
    {
       // string GetFileExtensionPattern();
  

        string GetFileNameNoExtension();

        string GetTempPath(DateTime period);
        void DecompressZipFile(FileInfo UnzipFile);

        void VerifyTempPath();

        //void VerifyDataLocation();
        void ConfigurateByPeriod(DateTime period, string folderName);
        void DownloadFile();

        string GetDataPath(DateTime period);







    }
}
