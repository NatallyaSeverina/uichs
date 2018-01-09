using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ReportRepository : IReportRepository
    {
        DAL.ModelDB context = new DAL.ModelDB();
        public void AddReport(Report _report)
        {

            DAL.Report report = new DAL.Report
            {
                dateOfReport = _report.DateOfReport,
                report1 = _report.Report1
            };
            context.Reports.Add(report);
            context.SaveChanges();
        }

        public void DeleteReport(DateTime _date)
        {
            DAL.Report r = new DAL.Report();
            r = context.Reports.SingleOrDefault(cl => cl.dateOfReport == _date);
            context.Reports.Remove(r);
            context.SaveChanges();
        }

        public Report GetByDate(DateTime _date)
        {
            DAL.Report r = new DAL.Report();
            r = context.Reports.SingleOrDefault(cl => cl.dateOfReport == _date);
            if (r != null)
            {
                Model.Report report = new Model.Report
                {
                    DateOfReport = r.dateOfReport,
                    Report1 = r.report1
                };
                return report;
            }
            else return null;
        }
    }
}
