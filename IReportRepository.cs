using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  interface IReportRepository
    {
        Model.Report GetByDate(DateTime _date);
        void AddReport(Model.Report _report);
        void DeleteReport(DateTime _date);
    }
}
