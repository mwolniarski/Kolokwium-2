using Microsoft.EntityFrameworkCore;
using System;

namespace Kolokwium_2.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<File>(p =>
            {
                p.HasKey(u => new
                {
                    u.FileId,
                    u.TeamId
                });

                p.Property(x => x.FileName).IsRequired().HasMaxLength(100);
                p.Property(x => x.FileExtension).IsRequired().HasMaxLength(4);
                p.Property(x => x.FileSize).IsRequired();
                p.HasOne(x => x.Team).WithMany(x => x.Files).HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.NoAction);

                p.HasData(
                       new File { FileId = 1, TeamId = 1, FileName = "Test1", FileExtension = "txt", FileSize = 20 },
                       new File { FileId = 2, TeamId = 2, FileName = "Test2", FileExtension = "wav", FileSize = 30 }
                );
            });


            modelBuilder.Entity<Member>(p =>
            {
                p.HasKey(x => x.MemberId);
                p.Property(x => x.MemberName).IsRequired().HasMaxLength(20);
                p.Property(x => x.MemberSurname).IsRequired().HasMaxLength(50);
                p.Property(x => x.MemberNickName).HasMaxLength(20);

                p.HasOne(x=>x.Organization).WithMany(x => x.Members).HasForeignKey(x => x.OrganizationId).OnDelete(DeleteBehavior.NoAction);

                p.HasData(
                        new Member { MemberId = 1, OrganizationId = 1, MemberName = "Grzegorz", MemberSurname = "Kantor", MemberNickName = "grzeKa" },
                        new Member { MemberId = 2, OrganizationId = 2, MemberName = "Michał", MemberSurname = "Suwak", MemberNickName = "MichSu" }
                        );
            });
               

            modelBuilder.Entity<MemberShip>(p =>
            {
                p.HasKey(u => new
                {
                    u.MemberId,
                    u.TeamId
                });
                p.Property(x=>x.MembershipDate).IsRequired();
                
                p.HasOne(x=>x.Member).WithMany(x=>x.Memberships).HasForeignKey(x => x.MemberId).OnDelete(DeleteBehavior.NoAction);
                p.HasOne(x=>x.Team).WithMany(x=>x.MemberShips).HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.NoAction);

                p.HasData(
                        new MemberShip { MemberId = 1, TeamId = 1, MembershipDate = DateTime.Parse("2013-09-19")},
                        new MemberShip { MemberId = 2, TeamId = 2, MembershipDate = DateTime.Parse("2011-10-19")}
                );
            });
                

            modelBuilder.Entity<Organization>(p =>
            {
                p.HasKey(x => x.OrganizationId);
                p.Property(x=>x.OrganizationName).IsRequired().HasMaxLength(100);
                p.Property(x => x.OrganizationDomain).IsRequired().HasMaxLength(50);

            p.HasData(
                   new Organization { OrganizationId = 1, OrganizationName = "Organizacja 1", OrganizationDomain = "Budowlana" },
                   new Organization { OrganizationId = 2, OrganizationName = "Organizacja 2", OrganizationDomain = "Spożywcza" }
                    );
            });
               

            modelBuilder.Entity<Team>(p =>
            {
                p.HasKey(x => x.TeamId);
                p.Property(x=>x.TeamName).IsRequired().HasMaxLength(50);
                p.Property(x => x.TeamDescription).HasMaxLength(500);

                p.HasOne(x => x.Organization).WithMany(x => x.Teams).HasForeignKey(x => x.OrganizationId).OnDelete(DeleteBehavior.NoAction);
                    p.HasData(
                        new Team { TeamId = 1, OrganizationId = 2, TeamName = "Team 1", TeamDescription = "Description 1" },
                        new Team { TeamId = 2, OrganizationId = 1, TeamName = "Team 2", TeamDescription = "Description 2" }
                    );
            });
        }
    }
}
