using Microsoft.EntityFrameworkCore;
using Students.Model;

#nullable disable

namespace Students.DB_Lib
{
    public partial class DbStudents : DbContext
    {
        public DbStudents() { }

        public DbStudents(DbContextOptions<DbStudents> options)
            : base(options) { }

        public virtual DbSet<Account> TabAccounts { get; set; }
        public virtual DbSet<AccountRole> TabAccountRoles { get; set; }
        public virtual DbSet<Group> TabGroups { get; set; }
        public virtual DbSet<Person> TabPersons { get; set; }
        public virtual DbSet<Role> TabRoles { get; set; }
        public virtual DbSet<Student> TabStudents { get; set; }
        public virtual DbSet<Teacher> TabTeachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseMySQL(GetConnStr());
            }
        }

        private static string GetConnStr()
        {
            var config = new DbConfig();
            return config.GetConnectionString();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("tab_accounts");

                entity.HasIndex(e => e.Login, "login")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.ToTable("tab_account_roles");

                entity.HasIndex(e => e.AccountId, "account_id");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("int(11)")
                    .HasColumnName("account_id");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("role_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TabAccountRoles)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_account_roles_ibfk_1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TabAccountRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_account_roles_ibfk_2");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("tab_groups");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("tab_persons");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("sex")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_persons_ibfk_1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("tab_roles");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("tab_students");

                entity.HasIndex(e => e.GroupId, "group_id");

                entity.HasIndex(e => e.PersonId, "person_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("group_id");

                entity.Property(e => e.IsStudy)
                    .IsRequired()
                    .HasColumnName("is_study")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("person_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TabStudents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_students_ibfk_2");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TabStudents)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_students_ibfk_1");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("tab_teachers");

                entity.HasIndex(e => e.GroupId, "group_id");

                entity.HasIndex(e => e.PersonId, "person_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("group_id");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("person_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TabTeachers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_teachers_ibfk_2");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TabTeachers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_teachers_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
