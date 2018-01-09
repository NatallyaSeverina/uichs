using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Xml.Linq;

namespace Repository
{
    public class EmergencySituationRepository : IEmergencySituationRepositiry
    {
        DAL.ModelDB context = new DAL.ModelDB();
        public void AddNewEmergency(EmergencySituation _emergencySituation, IEnumerable<SuperiorOfficer> _superiorOfficers,
            IEnumerable<Vechicle2Emergency> _vechicles2Emergency, ReceivedMessage _receivedMessage, Victim _victim, Model.DutyOfficer _dutyOfficer)
        {
           
                DAL.EmergencySituation emergencySituation = new DAL.EmergencySituation
            {
                dateOfEmergency=_emergencySituation.DateOfEmergency,
                region=_emergencySituation.Region,
                neighborhood=_emergencySituation.Neighborhood,
                popylatedLocality=_emergencySituation.PopylatedLocality,
                adress=_emergencySituation.Adress,
                kind=_emergencySituation.Kind,
                checkOutTime=_emergencySituation.CheckOutTime,
                arrivalTime=_emergencySituation.ArrivalTime,
                descriptionOfEmergency=_emergencySituation.DescriptionOfEmergency,
                timeLocalisation=_emergencySituation.TimeLocalisation,
                timeLiquidation=_emergencySituation.TimeLiquidation,
                toRegistration=_emergencySituation.ToRegistration,
                toReport=_emergencySituation.ToReport,
                problematicIssues=_emergencySituation.ProblematicIssues,
                specialReport=_emergencySituation.SpecialReport,
                extraReportSuperiorOfficer=_emergencySituation.ExtraReportSuperiorOfficer,
                editLog=_emergencySituation.EditLog,
                ReceivedMessage=new DAL.ReceivedMessage
                {
                    timeMessageInROCHS=_receivedMessage.TimeMessageInROCHS,
                    timeOfReceive=_receivedMessage.TimeOfReceive,
                    dutyOfficerID=_dutyOfficer.DutyOfficerID
                },
                Victim=new DAL.Victim
                {
                    perished=_victim.Perished,
                    perishedChildren=_victim.PerishedChildren,
                    injured=_victim.Injured,
                    injuredChildren=_victim.InjuredChildren,
                    evacuated=_victim.Evacuated,
                    evacuatedChildren=_victim.EvacuatedChildren,
                    rescued=_victim.Rescued,
                    rescuedChildren=_victim.RescuedChildren,
                }
                

            };
            
            foreach(Model.SuperiorOfficer s in _superiorOfficers)
            {
                emergencySituation.SuperiorOfficers.Add(
                    new DAL.SuperiorOfficer
                    {
                        position = s.Position,
                        statusOfReport = s.StatusOfReport,
                        timeReport = s.TimeReport
                    });
                
            }
            context.EmergencySituations.Add(emergencySituation);
            
                context.SaveChanges();
            

            foreach (var v in _vechicles2Emergency)
                context.AddVechicle2Emergency(emergencySituation.emergencyID, v.VechicleName.ToUpper(), v.CountVechicle);
            context.SaveChanges();
            
            
}

        public void DeleteEmergencySituation(int _id)
        {
           
            context.EmergencySituations.Remove(context.EmergencySituations.Find(_id));
            context.ReceivedMessages.Remove(context.ReceivedMessages.Find(_id));
            context.Victims.Remove(context.Victims.Find(_id));
            foreach(var v in context.Vechicle2Emergency.Where(cl => (cl.emergencyID == _id)))
            {
                context.Vechicle2Emergency.Remove(v);
            }
            foreach (var v in context.SuperiorOfficers.Where(cl => (cl.emergencyID == _id)))
            {
                context.SuperiorOfficers.Remove(v);
            }
           context.SaveChanges();
        }

        public void EditEmergency(EmergencySituation _emergencySituation, IEnumerable<SuperiorOfficer> _superiorOfficers, IEnumerable<Vechicle2Emergency> _vechicles2Emergency, ReceivedMessage _receivedMessage, Victim _victim)
        {
            DAL.EmergencySituation em = context.EmergencySituations.Find(_emergencySituation.EmergencyID);
            em.dateOfEmergency = _emergencySituation.DateOfEmergency;
            em.region = _emergencySituation.Region;
            em.neighborhood = _emergencySituation.Neighborhood;
            em.popylatedLocality = _emergencySituation.PopylatedLocality;
            em.adress = _emergencySituation.Adress;
            em.kind = _emergencySituation.Kind;
            em.checkOutTime = _emergencySituation.CheckOutTime;
            em.arrivalTime = _emergencySituation.ArrivalTime;
            em.descriptionOfEmergency = _emergencySituation.DescriptionOfEmergency;
            em.timeLocalisation = _emergencySituation.TimeLocalisation;
            em.timeLiquidation = _emergencySituation.TimeLiquidation;
            em.toRegistration = _emergencySituation.ToRegistration;
            em.toReport = _emergencySituation.ToReport;
            em.problematicIssues = _emergencySituation.ProblematicIssues;
            em.specialReport = _emergencySituation.SpecialReport;
            em.extraReportSuperiorOfficer = _emergencySituation.ExtraReportSuperiorOfficer;
            em.editLog = _emergencySituation.EditLog;

            DAL.ReceivedMessage m = context.ReceivedMessages.Find(_emergencySituation.EmergencyID);
            m.timeMessageInROCHS = _receivedMessage.TimeMessageInROCHS;
            m.timeOfReceive = _receivedMessage.TimeOfReceive;
            

            DAL.Victim v= context.Victims.Find(_emergencySituation.EmergencyID);
            v.perished = _victim.Perished;
            v.perishedChildren = _victim.PerishedChildren;
            v.injured = _victim.Injured;
            v.injuredChildren = _victim.InjuredChildren;
            v.evacuated = _victim.Evacuated;
            v.evacuatedChildren = _victim.EvacuatedChildren;
            v.rescued = _victim.Rescued;
            v.rescuedChildren = _victim.RescuedChildren;
                        
            foreach (var s in context.SuperiorOfficers.Where(cl => (cl.emergencyID == _emergencySituation.EmergencyID)))
            {
                context.SuperiorOfficers.Remove(s);
            }

            foreach (Model.SuperiorOfficer s in _superiorOfficers)
            {
                context.SuperiorOfficers.Add(
                    new DAL.SuperiorOfficer
                    {
                        emergencyID = s.EmergencyID,
                        position = s.Position,
                        statusOfReport = s.StatusOfReport,
                        timeReport = s.TimeReport
                    });

            }

            foreach (var ve in context.Vechicle2Emergency.Where(cl => (cl.emergencyID == _emergencySituation.EmergencyID)))
            {
                context.Vechicle2Emergency.Remove(ve);
            }
            context.SaveChanges();
            foreach (var vec in _vechicles2Emergency)
            {
                context.AddVechicle2Emergency(_emergencySituation.EmergencyID, vec.VechicleName.ToUpper(), vec.CountVechicle);
            }
            
             context.SaveChanges();
        }

        public int GetCountEmergenciesByRegion(string _region)
        {

            return context.EmergencySituations.Where(cl => (cl.region == _region && cl.toRegistration == true&&cl.dateOfEmergency.Year==DateTime.Now.Year)).Count();
        }

        public IEnumerable<EmergencySituation>  GetEmergencyByDate(DateTime _date)
        {
            
            return  context.EmergencySituations.ToArray().Where(cl => (cl.dateOfEmergency == _date || cl.dateOfEmergency == _date.AddDays(1))).Select((DAL.EmergencySituation em) =>
                    {
                        
                        return new Model.EmergencySituation
                        {
                            EmergencyID = em.emergencyID,
                            DateOfEmergency = em.dateOfEmergency,
                            Region = em.region,
                            Neighborhood = em.neighborhood,
                            PopylatedLocality = em.popylatedLocality,
                            Adress = em.adress,
                            Kind = em.kind,
                            CheckOutTime = em.checkOutTime,
                            RegistrationTime =em.ReceivedMessage.timeOfReceive,
                            ArrivalTime = em.arrivalTime,
                            DescriptionOfEmergency = em.descriptionOfEmergency,
                            TimeLocalisation = em.timeLocalisation,
                            TimeLiquidation = em.timeLiquidation,
                            ToRegistration = em.toRegistration,
                            ToReport = em.toReport,
                            SpecialReport = em.specialReport,
                            ExtraReportSuperiorOfficer = em.extraReportSuperiorOfficer,
                            EditLog = em.editLog,
                            ProblematicIssues = em.problematicIssues,
                            

                        };


                    }).Where(cl => ((cl.DateOfEmergency == _date && cl.RegistrationTime >= new TimeSpan(06, 00, 00)) || (cl.DateOfEmergency == _date.AddDays(1) && cl.RegistrationTime < new TimeSpan(06, 00, 00))));




        }

        public EmergencySituation GetEmergencySituationByID(int _id)
        {
            var em = context.EmergencySituations.Find(_id);
            return new Model.EmergencySituation
            {
                EmergencyID = em.emergencyID,
                DateOfEmergency = em.dateOfEmergency,
                Region = em.region,
                Neighborhood = em.neighborhood,
                PopylatedLocality = em.popylatedLocality,
                Adress = em.adress,
                Kind = em.kind,
                CheckOutTime = em.checkOutTime,
                ArrivalTime = em.arrivalTime,
                DescriptionOfEmergency = em.descriptionOfEmergency,
                TimeLiquidation = em.timeLiquidation,
                TimeLocalisation = em.timeLocalisation,
                ToRegistration = em.toRegistration,
                ToReport = em.toReport,
                ProblematicIssues = em.problematicIssues,
                SpecialReport = em.specialReport,
                ExtraReportSuperiorOfficer = em.extraReportSuperiorOfficer,
                EditLog = em.editLog


            };
        }

        public int GetPerishedByID(int _id)
        {
           var victim=context.Victims.Find(_id);

            if (victim == null) return 0;
            else if ((victim.perished) == null) return 0;
            else return (int)victim.perished;
        }

        public int GetPerishedChildrenByID(int _id)
        {
            var victim = context.Victims.Find(_id);
            if (victim == null) return 0;
            else if ((victim.perishedChildren) == null) return 0;
            else return (int)victim.perishedChildren;
        }

        public ReceivedMessage GetReceivedMessageByID(int _id)
        {
            var mes = context.EmergencySituations.Find(_id).ReceivedMessage;
            return new Model.ReceivedMessage
            {
                TimeMessageInROCHS = mes.timeMessageInROCHS,
                TimeOfReceive = mes.timeOfReceive,
                DutyOfficerID = mes.dutyOfficerID,
                EmergencyID = mes.emergencyID
            };
        }

        public IEnumerable<SuperiorOfficer> GetSuperiorOfficerByEmergencyID(int _id)
        {
            List<Model.SuperiorOfficer> list = new List<SuperiorOfficer>();
            foreach(var s in context.EmergencySituations.Find(_id).SuperiorOfficers)
            {
                list.Add(new Model.SuperiorOfficer
                {
                    Position =s.position,
                EmergencyID=s.emergencyID,
                StatusOfReport=s.statusOfReport,
                TimeReport=s.timeReport
                });

            }
            return list;
        }

        public IEnumerable<Vechicle2Emergency> GetVechicle2EmergencyByEmergencyID(int _id)
        {
            List<Model.Vechicle2Emergency> list = new List<Vechicle2Emergency>();
           foreach (var v in context.Vechicle2Emergency.Where(cl=>(cl.emergencyID==_id)))
            {
                list.Add(new Model.Vechicle2Emergency
                {
                    CountVechicle = v.countVechicle,
                    EmergencyID = v.emergencyID,
                    VechicleID = v.vechicleID


                });

            }
            return list;

        }

        public Victim GetVictimByID(int _id)
        {
            var vic = context.EmergencySituations.Find(_id).Victim;
            return new Model.Victim
            {
                Perished=vic.perished,
                PerishedChildren=vic.perishedChildren,
                Injured=vic.injured,
                InjuredChildren=vic.injuredChildren,
                Evacuated=vic.evacuated,
                EvacuatedChildren=vic.evacuatedChildren,
                EmergencyID=vic.emergencyID,
                Rescued=vic.rescued,
                RescuedChildren=vic.rescuedChildren
            };
        }

        public string ReadXMLDoc()
        {
            XDocument xDoc = XDocument.Load("EmergencySituations.xml",
                LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            return xDoc.ToString();
        }

        public void WriteXMLDoc()
        {

            XElement xDoc = new XElement("EmergencySituations",
                    context.EmergencySituations.ToArray().Select(em =>
                        new XElement("EmergencySituation",
                            new XElement("dateOfEmergency", em.dateOfEmergency),
                            new XElement("region", em.region),
                            new XElement("neighborhood", em.neighborhood),
                            new XElement("descriptionOfEmergency", em.descriptionOfEmergency),
                            new XElement("checkOutTime", em.checkOutTime),
                            new XElement("arrivalTime", em.arrivalTime),
                            new XElement("timeLocalisation", em.timeLocalisation),
                            new XElement("timeLiquidation", em.timeLiquidation),
                             new XElement("kind", em.kind),
                            new XElement("problematicIssues", em.problematicIssues))));
            xDoc.Save("EmergencySituations.xml");
        }
    }
}
