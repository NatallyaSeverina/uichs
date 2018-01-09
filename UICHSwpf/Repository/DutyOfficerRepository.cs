using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class DutyOfficerRepository : IDutyOfficerRepository
    {
        DAL.ModelDB context = new DAL.ModelDB();

        public string GetByEmerencyID(int _id)
        {
          return context.ReceivedMessages.Find(_id).DutyOfficer.nameDutyOfficer;
            
        }

        public DutyOfficer GetByLogin(string _login)
        {
            DAL.DutyOfficer d = new DAL.DutyOfficer();
            d = context.DutyOfficers.SingleOrDefault(cl => cl.loginDutyOfficer == _login);
            if (d != null)
            {
                Model.DutyOfficer dutyOfficer = new DutyOfficer
                {
                    DutyOfficerID = d.dutyOfficerID,
                    LoginDutyOfficer = d.loginDutyOfficer,
                    NameDutyOfficer = d.nameDutyOfficer,
                    PasswordDutyOfficer = d.passwordDutyOfficer,
                    PositionDuty = d.positionDuty,
                    
                };
                return dutyOfficer;
            }
            else return null;
        }
       

        public void SaveDutyOfficerSettings(DutyOfficer _officer)
        {
            DAL.DutyOfficer d = new DAL.DutyOfficer();
            d = context.DutyOfficers.Find(_officer.DutyOfficerID);
            d.loginDutyOfficer = _officer.LoginDutyOfficer;
            d.nameDutyOfficer = _officer.NameDutyOfficer;
            d.positionDuty = _officer.PositionDuty;
            d.passwordDutyOfficer = _officer.PasswordDutyOfficer;
           
            context.SaveChanges();
        }
    }
}
