using Microsoft.EntityFrameworkCore;

namespace TP5.Models.RestosModel
{
    public class RestosDbContext : DbContext
    {
        public RestosDbContext(DbContextOptions<RestosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Avis> Avis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasDefaultSchema("resto");

            
            modelBuilder.Entity<Proprietaire>(entity =>
            {
                entity.HasKey(p => p.Numero);

                entity.Property(p => p.Nom)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("NomProp");

                entity.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EmailProp");

                entity.Property(p => p.Gsm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("GsmProp");
            });

            
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("TRestaurant", "resto");

                entity.HasKey(r => r.CodeResto);

                entity.Property(r => r.NomResto)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(r => r.Specialite)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("SpecResto")
                    .HasDefaultValue("Tunisienne");

                entity.Property(r => r.Ville)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("VilleResto");

                entity.Property(r => r.Tel)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("TelResto");

                entity.Property(r => r.NumProp)
                    .IsRequired();

               
                entity.HasOne(r => r.LeProprio)
                    .WithMany(p => p.LesRestos)
                    .HasForeignKey(r => r.NumProp)
                    .HasConstraintName("Relation_Proprio_Restos")
                    .OnDelete(DeleteBehavior.Cascade); 
            });


            modelBuilder.Entity<Avis>(entity =>
            {
                entity.ToTable("TAvis", "admin");

                entity.HasKey(e => e.CodeAvis);

                entity.Property(e => e.NomPersonne)
                      .HasMaxLength(30)
                      .IsRequired();

                entity.Property(e => e.Note)
                      .IsRequired();

                entity.Property(e => e.Commentaire)
                      .HasMaxLength(256);

                entity.HasOne(e => e.LeResto)
                      .WithMany(r => r.LesAvis)
                      .HasForeignKey(e => e.NumResto)
                      .HasConstraintName("Relation_Resto_Avis");
            });
        }
    }
}
