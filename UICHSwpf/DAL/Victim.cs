namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Victim
    {
        [Key]
        public int emergencyID { get; set; }

        public int? perished { get; set; }

        public int? injured { get; set; }

        public int? evacuated { get; set; }

        public int? rescued { get; set; }

        public int? perishedChildren { get; set; }

        public int? injuredChildren { get; set; }

        public int? evacuatedChildren { get; set; }

        public int? rescuedChildren { get; set; }

        public virtual EmergencySituation EmergencySituation { get; set; }
    }
}
