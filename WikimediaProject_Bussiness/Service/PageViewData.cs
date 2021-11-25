using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaProject_Bussiness.Model
{
    public class PageViewData : IDisposable
    {
        public List<PageView> Data;
        private DateTime? PeriodDate;
        public string StrPeriodDate;
  
        public PageViewData() => Data = new List<PageView>();

        public PageViewData(DateTime periodDate)
        {
            Data = new List<PageView>();
            PeriodDate = periodDate;
            StrPeriodDate = periodDate.ToString("yyyyMMdd");
        }
  
        public void SetPeriodDate(DateTime periodDate)
        {
            PeriodDate = periodDate;
            StrPeriodDate = periodDate.ToString("yyyyMMdd");
        }

        public string GetPeriodDate()
        {
            return StrPeriodDate;
        }

        public void AddPageView(PageView entry)
        {
            if (Data != null)
                Data.Add(entry);
        }


        public void Dispose() => Data = null;

    }
}
