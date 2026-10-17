using InterviewPreparator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparator.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        #region Properties
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionHistory> SessionHistories {  get; set; }
        public DbSet<SessionTask> SessionTasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProgress> UsersProgresses { get; set; }

        #endregion
        #region Constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        #endregion

        #region Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
