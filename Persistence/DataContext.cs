using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentAttendee> AssignmentAttendees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AssignmentAttendee>(x => x.HasKey(aa => new { aa.AppUserId, aa.AssignmentId }));

            builder.Entity<AssignmentAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Assignments)
                .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<AssignmentAttendee>()
                .HasOne(u => u.Assignment)
                .WithMany(a => a.Attendees)
                .HasForeignKey(aa => aa.AssignmentId);
        }
    }
}