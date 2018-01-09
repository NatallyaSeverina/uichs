namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DutyOfficer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DutyOfficer()
        {
            ReceivedMessages = new HashSet<ReceivedMessage>();
        }

        public int dutyOfficerID { get; set; }

        [Required]
        [StringLength(60)]
        public string nameDutyOfficer { get; set; }

        [Required]
        [StringLength(60)]
        public string positionDuty { get; set; }

        [Required]
        [StringLength(40)]
        public string loginDutyOfficer { get; set; }

        [Required]
        [StringLength(40)]
        public string passwordDutyOfficer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceivedMessage> ReceivedMessages { get; set; }
    }
}
