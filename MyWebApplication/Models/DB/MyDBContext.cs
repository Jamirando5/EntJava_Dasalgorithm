using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWebApplication.Models.DB
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<SystemUsers> SystemUsers { get; set; }
        public virtual DbSet<VerUsers> VerUsers { get; set; }
        public virtual DbSet<VerLists> VerLists { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // warning To protect potentially sensitive information in your connection string,
                // you should move it out of source code.See http://go.microsoft.com/fwlink/?LinkId=723263
                // for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MyDemoDB;Initial Catalog=DemoDB;Integrated Security=True;Multiple Active Result Sets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("SYSUserProfile");

                entity.Property(e => e.ProfileID)
                .HasColumnName("SYSUserProfileID")

                .HasColumnType("int");

                entity.Property(e => e.UserID)
                .HasColumnName("SYSUserID")
                .HasColumnType("int");

                entity.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Gender)
                  .HasColumnName("Gender")
                  .HasColumnType("char(1)");

                entity.Property(e => e.CreatedBy)
                  .HasColumnName("RowCreatedSYSUserID")
                  .HasColumnType("int");

                entity.Property(e => e.CreatedDateTime)
                  .HasColumnName("RowCreatedDateTime")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedBy)
                  .HasColumnName("RowModifiedSYSUserID")
                  .HasColumnType("int");

                entity.Property(e => e.ModifiedDateTime)
                  .HasColumnName("RowModifiedDateTime")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AccountImage)
                 .HasColumnName("AccountImage")
                 .HasMaxLength(8000)
                 .IsUnicode(false);


            });

            modelBuilder.Entity<SystemUsers>(entity =>
            {
                entity.ToTable("SYSUser");

                entity.Property(e => e.UserID)
                .HasColumnName("SYSUserID")
                .HasColumnType("int");

                entity.Property(e => e.LoginName)
                .HasColumnName("LoginName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                  .HasColumnName("RowCreatedSYSUserID")
                  .HasColumnType("int");

                entity.Property(e => e.CreatedDateTime)
                  .HasColumnName("RowCreatedDateTime")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedBy)
                  .HasColumnName("RowModifiedSYSUserID")
                  .HasColumnType("int");

                entity.Property(e => e.ModifiedDateTime)
                  .HasColumnName("RowModifiedDateTime")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");


            });

            modelBuilder.Entity<VerUsers>(entity =>
            {
                entity.ToTable("VervoyageUsers");

                entity.Property(e => e.user_id)
                .HasColumnName("user_id")
                .HasColumnType("int");

                entity.Property(e => e.Fullname)
                .HasColumnName("Fullname")
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Username)
                .HasColumnName("Username")
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Email)
                  .HasColumnName("Email")
                  .HasMaxLength(200)
                  .IsUnicode(false);

                entity.Property(e => e.Password)
                  .HasColumnName("Password")
                  .HasMaxLength(200)
                  .IsUnicode(false);

                entity.Property(e => e.Birthdate)
                  .HasColumnName("Birthdate")
                  .HasMaxLength(10)
                  .IsUnicode(false);

                entity.Property(e => e.Created_at)
                  .HasColumnName("Created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });
            modelBuilder.Entity<VerLists>(entity =>
            {
                entity.ToTable("VervoyageLists");

                entity.Property(e => e.list_id)
                .HasColumnName("list_id")
                .HasColumnType("int");

                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(300)
                .IsUnicode(false);

                entity.Property(e => e.Visibility)
                  .HasColumnName("Visibility")
                  .HasMaxLength(10)
                  .IsUnicode(false);

                entity.Property(e => e.Created_at)
                  .HasColumnName("Created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });
        }
    }
}
