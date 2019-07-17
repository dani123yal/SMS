namespace SMS2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentResult")]
    public partial class StudentResult
    {
        [Key]
        public int str_ID { get; set; }

        [StringLength(100)]
        public string str_Type { get; set; }

        public int? str_MaxMarks { get; set; }

        public int? str_MarksObt { get; set; }

        public int? st_ID { get; set; }

        public int? cl_ID { get; set; }

        public int? sub_ID { get; set; }

        public virtual Class Class { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
