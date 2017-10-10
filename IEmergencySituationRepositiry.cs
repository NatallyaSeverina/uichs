using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IEmergencySituationRepositiry
    {
        void WriteXMLDoc();
        string ReadXMLDoc();
        Model.EmergencySituation GetEmergencySituationByID(int _id);
        int GetCountEmergenciesByRegion(string _region);
        Model.Victim GetVictimByID(int _id);
        Model.ReceivedMessage GetReceivedMessageByID(int _id);
        IEnumerable<Model.SuperiorOfficer> GetSuperiorOfficerByEmergencyID(int _id);
        IEnumerable<Model.Vechicle2Emergency> GetVechicle2EmergencyByEmergencyID(int _id);
        void DeleteEmergencySituation(int _id);
        int GetPerishedByID(int _id);
        int GetPerishedChildrenByID(int _id);
        IEnumerable<Model.EmergencySituation>  GetEmergencyByDate(DateTime _date);
        void AddNewEmergency(Model.EmergencySituation _emergencySituation, IEnumerable<Model.SuperiorOfficer> _superiorOfficers,
            IEnumerable<Model.Vechicle2Emergency> _vechicles2Emergency, Model.ReceivedMessage _receivedMessage, Model.Victim _victim, Model.DutyOfficer _dutyOfficer);
        void EditEmergency(Model.EmergencySituation _emergencySituation, IEnumerable<Model.SuperiorOfficer> _superiorOfficers,
            IEnumerable<Model.Vechicle2Emergency> _vechicles2Emergency, Model.ReceivedMessage _receivedMessage, Model.Victim _victim);
    }
}
