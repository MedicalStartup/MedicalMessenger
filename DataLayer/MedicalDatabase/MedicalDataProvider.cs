namespace DataLayer.MedicalDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MedicalDataProvider : DbContext
    {
        public MedicalDataProvider()
            : base("name=MedicalDataProviderConnectionString")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Banned_Users> Banned_Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Medical_Assessments> Medical_Assessments { get; set; }
        public virtual DbSet<Specialist> Specialists { get; set; }
        public virtual DbSet<AccountsToDoctorsAndClient> AccountsToDoctorsAndClients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.password_hash)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Banned_Users)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.AccountsToDoctorsAndClients)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.entity_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Banned_Users)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.AccountsToDoctorsAndClients)
                .WithRequired(e => e.Doctor)
                .HasForeignKey(e => e.entity_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Medical_Assessments)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Specialists)
                .WithMany(e => e.Doctors)
                .Map(m => m.ToTable("Specialists_to_Doctor").MapLeftKey("doctor_id").MapRightKey("specialist_id"));
        }
    }
}
