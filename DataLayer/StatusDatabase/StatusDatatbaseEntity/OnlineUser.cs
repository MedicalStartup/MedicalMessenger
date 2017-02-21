namespace DataLayer.StatusDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OnlineUser
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string phone_number { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "datetime2")]
        public DateTime connection_date { get; set; }
    }
}
