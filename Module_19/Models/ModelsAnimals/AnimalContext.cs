using Microsoft.EntityFrameworkCore;

namespace Module_19
{
    public partial class AnimalContext : DbContext
    {
        public AnimalContext()
        {
        }

        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Animal;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animal");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TypeAnimal).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
