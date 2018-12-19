using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CnSharp.EntityFrameworkCore
{
    public class MultiTenantDbContext<TDbContext, TAuditor,TTenant> : AuditableDbContext<TDbContext,TAuditor> where TDbContext : DbContext
    {
        public MultiTenantDbContext(DbContextOptions options, AuditingOptions auditingOptions,
        IAuditingTimeProvider auditingTimeProvider, IAuditorAware<TAuditor> auditorAware, MultiTenantOptions  multiTenantOptions,ITenantAware<TTenant> tenantAware)
        : base(options,auditingOptions,auditingTimeProvider,auditorAware)
        {
            this.tenantId = tenantAware.GetCurrentTenantId();
            this.multiTenantOptions = multiTenantOptions;
        }


        private readonly TTenant tenantId;
        private readonly MultiTenantOptions  multiTenantOptions;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var entity = modelBuilder.Entity(entityType.ClrType);
                entity.Property<TTenant>(multiTenantOptions.TenantIdField);

                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var body = Expression.Equal(
                    Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(TTenant) }, parameter, Expression.Constant(multiTenantOptions.TenantIdField)),
                Expression.Constant(tenantId));
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
            }
        }

        protected override void AuditAddedEntry(EntityEntry entry)
        {
            base.AuditAddedEntry(entry);

            var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
            var tenantIdProperty = entityType.FindProperty(multiTenantOptions.TenantIdField);
            if (tenantIdProperty != null)
            {
                entry.Property(multiTenantOptions.TenantIdField).CurrentValue = tenantId;
            }
        }
    }
}
