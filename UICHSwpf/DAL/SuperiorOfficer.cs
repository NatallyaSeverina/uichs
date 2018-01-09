namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuperiorOfficer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int emergencyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string position { get; set; }

        public bool statusOfReport { get; set; }
        public TimeSpan? timeReport { get; set; }

        public virtual EmergencySituation EmergencySituation { get; set; }
    }
}
