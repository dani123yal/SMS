namespace SMS2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        public int att_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? att_Date { get; set; }

        [StringLength(15)]
        public string att_Status { get; set; }

        public int? st_ID { get; set; }

        public int? cl_ID { get; set; }

        public virtual Class Class { get; set; }

        public virtual Student Student { get; set; }
    }
}
