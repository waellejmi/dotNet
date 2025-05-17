using Microsoft.EntityFrameworkCore;

namespace TP6.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().ToTable("School");

            modelBuilder.Entity<School>().Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<School>().Property(s => s.Sections)
                .IsRequired();

            modelBuilder.Entity<School>().Property(s => s.Director)
                .IsRequired();

            modelBuilder.Entity<School>().Property(s => s.WebSite)
                .HasMaxLength(200);

            modelBuilder.Entity<School>().HasData(
        new School
        {
            Id = 1,
            Name = "Green Valley High",
            Sections = "Science, Arts, Sports",
            Director = "Dr. Helen Moore",
            Rating = 4.5,
            WebSite = "https://greenvalley.edu"
        },
        new School
        {
            Id = 2,
            Name = "Lakeside Academy",
            Sections = "Mathematics, Humanities",
            Director = "Mr. John Ellis",
            Rating = 3.8,
            WebSite = null // Nullable
        },
        new School
        {
            Id = 3,
            Name = "Mountainview Institute",
            Sections = "Engineering, Computer Science",
            Director = "Ms. Clara Dean",
            Rating = 4.9,
            WebSite = "https://mountainview.edu"
        }
    );

        }
    }
}
