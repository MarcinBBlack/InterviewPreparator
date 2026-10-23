using InterviewPreparator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewPreparator.Infrastructure.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    #region Properties

    public DbSet<Session> Sessions => Set<Session>();

    public DbSet<SessionTask> SessionTasks => Set<SessionTask>();

    public DbSet<User> Users => Set<User>();

    #endregion

    #region Constructors

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    #endregion

    #region Overrides

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Session>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(session => session.UserId);

        modelBuilder.Entity<Session>()
            .HasMany(session => session.Tasks)
            .WithOne()
            .HasForeignKey(sessionTask => sessionTask.SessionId);
    }

    #endregion
}
