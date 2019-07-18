namespace SMS2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faculty")]
    public partial class Faculty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faculty()
        {
            Subjects = new HashSet<Subject>();
        }

        [Key]
        public int fac_ID { get; set; }

        [StringLength(100)]
        public string fac_Name { get; set; }

        [StringLength(200)]
        public string fac_CNIC { get; set; }

        [StringLength(200)]
        public string fac_phoneNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? fac_Salary { get; set; }

        public int? user_ID { get; set; }

        public int? classTeacherOf { get; set; }

        public virtual Class Class { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
