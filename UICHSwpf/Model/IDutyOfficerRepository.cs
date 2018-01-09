using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDutyOfficerRepository
    {
        Model.DutyOfficer GetByLogin(string _login);
        string GetByEmerencyID(int _id);
        void SaveDutyOfficerSettings(Model.DutyOfficer _officer);
        //string GetPasswordByLogin(string _login);
    }
}
