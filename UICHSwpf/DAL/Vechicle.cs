namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vechicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vechicle()
        {
            Vechicle2Emergency = new HashSet<Vechicle2Emergency>();
        }

        public int vechicleID { get; set; }

        [Required]
        [StringLength(40)]
        public string nameVechicle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vechicle2Emergency> Vechicle2Emergency { get; set; }
    }
}
