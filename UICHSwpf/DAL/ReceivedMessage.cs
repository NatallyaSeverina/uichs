namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReceivedMessage
    {
        [Key]
        public int emergencyID { get; set; }

        public TimeSpan? timeMessageInROCHS { get; set; }

        public TimeSpan timeOfReceive { get; set; }

        public int dutyOfficerID { get; set; }

        public virtual DutyOfficer DutyOfficer { get; set; }

        public virtual EmergencySituation EmergencySituation { get; set; }
    }
}
