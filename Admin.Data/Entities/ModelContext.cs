using Microsoft.EntityFrameworkCore;

namespace Admin.Data.Entities
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployee> TblEmployees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:TinkUsDatabase");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }
       
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
