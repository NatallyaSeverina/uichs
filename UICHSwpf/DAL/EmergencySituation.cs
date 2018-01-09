namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmergencySituation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmergencySituation()
        {
            SuperiorOfficers = new HashSet<SuperiorOfficer>();
            Vechicle2Emergency = new HashSet<Vechicle2Emergency>();
        }

        [Key]
        public int emergencyID { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateOfEmergency { get; set; }

        
        [StringLength(30)]
        public string region { get; set; }

        [StringLength(30)]
        public string neighborhood { get; set; }

        [StringLength(40)]
        public string popylatedLocality { get; set; }

        [StringLength(40)]
        public string adress { get; set; }

        [StringLength(60)]
        public string kind { get; set; }

        public TimeSpan? checkOutTime { get; set; }

        public TimeSpan? arrivalTime { get; set; }

        [Required]
        public string descriptionOfEmergency { get; set; }

        public TimeSpan? timeLocalisation { get; set; }

        public TimeSpan? timeLiquidation { get; set; }

        public bool toRegistration { get; set; }

        public bool toReport { get; set; }

        public string problematicIssues { get; set; }

        [Column(TypeName = "image")]
        public byte[] specialReport { get; set; }

        public string extraReportSuperiorOfficer { get; set; }

        public string editLog { get; set; }

        public virtual ReceivedMessage ReceivedMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuperiorOfficer> SuperiorOfficers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vechicle2Emergency> Vechicle2Emergency { get; set; }

        public virtual Victim Victim { get; set; }
    }
}
