namespace DataLayer.MedicalDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            Banned_Users = new HashSet<Banned_Users>();
            AccountsToDoctorsAndClients = new HashSet<AccountsToDoctorsAndClient>();
            Medical_Assessments = new HashSet<Medical_Assessments>();
            Specialists = new HashSet<Specialist>();
        }

        [Key]
        public Guid doctor_id { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        [StringLength(12)]
        public string phone_number { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? brith_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Banned_Users> Banned_Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountsToDoctorsAndClient> AccountsToDoctorsAndClients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medical_Assessments> Medical_Assessments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specialist> Specialists { get; set; }
    }
}
