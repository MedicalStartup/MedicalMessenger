namespace DataLayer.MedicalDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccountsToDoctorsAndClient
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int account_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid entity_id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
