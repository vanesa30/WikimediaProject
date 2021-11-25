using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaProject_Bussiness.Model;

namespace WikimediaProject_Bussiness.Service
{
    public class FileReader :  IDisposable
    {
        private PageViewData _pageViewData;
        private string _targetFileNoExt;


        public FileReader(string targetFileNoExt) => _targetFileNoExt = targetFileNoExt;




        public PageViewData GetDataToCollection()
        {
            _pageViewData = new PageViewData();
            Console.WriteLine(string.Concat("Reading file ", _targetFileNoExt, "..."));
            using (FileStream fs = File.Open(_targetFileNoExt, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    _pageViewData.AddPageView(GetRowFile(line));
            }
            return _pageViewData;
        }
       


        private PageView GetRowFile(string line)
        {
            PageView RowFile = new PageView();
            string[] data = line.Split(' ');
            RowFile.DomainCode = data[0];
            RowFile.PageTitle = data[1];
            RowFile.ViewCount = Convert.ToUInt32(data[2]);
            return RowFile;
        }

        public void Dispose() => _pageViewData.Dispose();

    }
}
