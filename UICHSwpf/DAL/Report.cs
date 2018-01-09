namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Report
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime dateOfReport { get; set; }

        [Column("report", TypeName = "image")]
        public byte[] report1 { get; set; }
    }
}
