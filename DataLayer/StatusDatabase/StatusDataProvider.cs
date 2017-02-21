namespace DataLayer.StatusDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatusDataProvider : DbContext
    {
        public StatusDataProvider()
            : base("name=StatusDataProviderConnectionString")
        {
        }

        public virtual DbSet<OnlineUser> OnlineUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
