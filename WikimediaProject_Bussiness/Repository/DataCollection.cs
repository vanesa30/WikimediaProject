using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaProject_Bussiness.Model;
using WikimediaProject_Bussiness.Interface;

namespace WikimediaProject_Bussiness.Repository
{
    public class DataCollection
    {
   

        

        
        public List<LanguageDomain> GetDataGroupByDomain(PageViewData periodCollection,DateTime period)
        {
            LanguageDomain report ;
            List<LanguageDomain> listReport = new List<LanguageDomain>();

            var query = periodCollection.Data.Where(e => e.ViewCount > 0)
                  .GroupBy(x => x.DomainCode)
                  .Select(y => new PageView
                  {
                      DomainCode = y.Key,
                      ViewCount = Convert.ToUInt32(y.Sum(s => s.ViewCount)),
                  })
                  .OrderByDescending(x => x.ViewCount).Take(5);
             

            foreach(var item in query)
            {
                report = new LanguageDomain();
                report.Period = period;
                report.Domain = item.DomainCode;
                report.CountView = item.ViewCount;
                listReport.Add(report);                    
            }
            


         

            return listReport;
        }

       
    }
}
