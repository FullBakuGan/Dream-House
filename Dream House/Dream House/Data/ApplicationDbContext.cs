using Dream_House.Models;
using Microsoft.EntityFrameworkCore;

namespace Dream_House.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "public"); // Явно указываем схему и имя таблицы

                entity.HasKey(e => e.Id).HasName("user_pkey");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20);

                entity.Property(e => e.HashPassword)
                    .IsRequired()
                    .HasColumnName("hash_password")
                    .HasMaxLength(255);

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasDatabaseName("unique_email");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role", "public");

                entity.HasKey(e => e.Id).HasName("role_pkey");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50);

                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasDatabaseName("unique_role_name");
            });

        }
    }
}
