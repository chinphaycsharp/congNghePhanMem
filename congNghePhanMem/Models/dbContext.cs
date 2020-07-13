namespace congNghePhanMem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext1")
        {
        }

        public virtual DbSet<check> checks { get; set; }
        public virtual DbSet<departcode> departcodes { get; set; }
        public virtual DbSet<employee_account> employee_account { get; set; }
        public virtual DbSet<register> registers { get; set; }
        public virtual DbSet<work> works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<departcode>()
                .Property(e => e.nameDepartment)
                .IsUnicode(false);

            modelBuilder.Entity<departcode>()
                .Property(e => e.nameEmployee)
                .IsUnicode(false);

            modelBuilder.Entity<departcode>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<departcode>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<departcode>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.department)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.birthday)
                .IsUnicode(false);

            modelBuilder.Entity<work>()
                .Property(e => e.Leader)
                .IsUnicode(false);

            modelBuilder.Entity<work>()
                .Property(e => e.numJoin)
                .IsUnicode(false);

            modelBuilder.Entity<work>()
                .Property(e => e.nameProject)
                .IsUnicode(false);
        }
    }
}
