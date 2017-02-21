namespace DataLayer.MedicalDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [Key]
        public int account_id { get; set; }

        [Required]
        [StringLength(15)]
        public string phone_number { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string password_hash { get; set; }
    }
}
