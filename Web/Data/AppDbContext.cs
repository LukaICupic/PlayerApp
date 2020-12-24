using Microsoft.EntityFrameworkCore;
using PlayerApp.Web.Entities;

namespace PlayerApp.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Player>(e =>
            {
                e.HasKey(k => k.Id);
                e.Property(n => n.FirstName).HasMaxLength(StringLenghts.PlayerFirstName);
                e.Property(n => n.LastName).HasMaxLength(StringLenghts.PlayerLastName);
                e.Property(n => n.FieldPosition).HasMaxLength(StringLenghts.FieldPositionName);
            });

            builder.Entity<Manager>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Name).HasMaxLength(StringLenghts.ManagerName);
                e.HasMany(p => p.Players).WithOne(m => m.Manager).HasForeignKey(m => m.ManagerId);
            });

            builder.Entity<Club>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Name).HasMaxLength(StringLenghts.ClubName);
                e.HasMany(p => p.Players).WithOne(m => m.Club).HasForeignKey(m => m.ClubId);
            });
        }
    }
}