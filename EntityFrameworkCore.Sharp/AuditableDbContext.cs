using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CnSharp.EntityFrameworkCore
{
    public class AuditableDbContext<TDbContext, TAuditor> : DbContext where TDbContext : DbContext
    {
        private readonly AuditingOptions auditingOptions;
        private readonly IAuditingTimeProvider auditingTimeProvider;
        private readonly IAuditorAware<TAuditor> auditorAware;

        public AuditableDbContext(DbContextOptions options, AuditingOptions auditingOptions,
        IAuditingTimeProvider auditingTimeProvider, IAuditorAware<TAuditor> auditorAware) : base(options)
        {
            this.auditingOptions = auditingOptions;
            this.auditingTimeProvider = auditingTimeProvider;
            this.auditorAware = auditorAware;
        }


        public override int SaveChanges()
        {
            if (this.auditingOptions == null) return base.SaveChanges();

            var addedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                AuditAddedEntry(entry);
                AuditModifiedEntry(entry);
            }


            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);
            foreach (var entry in addedEntries)
            {
                AuditModifiedEntry(entry);
            }

            return base.SaveChanges();
        }

        protected virtual void AuditAddedEntry(EntityEntry entry)
        {
            var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());

            var createdDateProperty = entityType.FindProperty(auditingOptions.CreatedDateProperty);
            var createdByProperty = entityType.FindProperty(auditingOptions.CreatedByProperty);

            if (createdDateProperty != null && auditingTimeProvider != null)
            {
                entry.Property(auditingOptions.CreatedDateProperty).CurrentValue = auditingTimeProvider.Now;
            }

            if (createdByProperty != null && auditorAware != null)
            {
                entry.Property(auditingOptions.CreatedByProperty).CurrentValue = auditorAware.GetCurrentAuditor();
            }
        }

        protected virtual void AuditModifiedEntry(EntityEntry entry)
        {
            var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());

            var modifiedDateProperty = entityType.FindProperty(auditingOptions.ModifiedDateProperty);
            var modifiedByProperty = entityType.FindProperty(auditingOptions.ModifiedByProperty);

            if (modifiedDateProperty != null && auditingTimeProvider != null)
            {
                entry.Property(auditingOptions.ModifiedDateProperty).CurrentValue = auditingTimeProvider.Now;
            }
            if (modifiedByProperty != null && auditorAware != null)
            {
                entry.Property(auditingOptions.ModifiedByProperty).CurrentValue = auditorAware.GetCurrentAuditor();
            }
        }
    }
}
