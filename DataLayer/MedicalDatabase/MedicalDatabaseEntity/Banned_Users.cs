namespace DataLayer.MedicalDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Banned_Users
    {
        [Key]
        public int banned_id { get; set; }

        public Guid doctor_id { get; set; }

        public Guid client_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date_banned { get; set; }

        public virtual Client Client { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
