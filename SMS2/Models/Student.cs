namespace SMS2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            StudentResults = new HashSet<StudentResult>();
        }

        [Key]
        public int st_ID { get; set; }

        [StringLength(100)]
        public string st_Name { get; set; }

        [StringLength(100)]
        public string st_FatherName { get; set; }

        public int? st_Age { get; set; }

        [StringLength(200)]
        public string st_Phone { get; set; }

        public int? cl_ID { get; set; }

        public int? user_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual Class Class { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentResult> StudentResults { get; set; }
    }
}
