using System;
using CnSharp.EntityFrameworkCore;
using EntityFrameworkCore.Sharp.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Sharp.Sample
{
    public class MyDbContext : MultiTenantDbContext<MyDbContext,string, string>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options, AuditingOptions auditingOptions,
        IAuditingTimeProvider auditingTimeProvider, IAuditorAware<string> auditorAware, MultiTenantOptions multiTenantOptions,
             ITenantAware<string> tenantAware) 
        : base(options,auditingOptions,auditingTimeProvider,auditorAware,multiTenantOptions,tenantAware)
        {
            Database.EnsureCreated();
        }


        public DbSet<Host> Hosts { get; set; }
    }

    public class MyAuditingTimeProvider : IAuditingTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }

    public class MyAuditorAware : IAuditorAware<string>
    {
        public string GetCurrentAuditor()
        {
            return "bob";
        }
    }

    public class MyTenantAware : ITenantAware<string>
    {
        public string GetCurrentTenantId()
        {
            return "foo";
        }
    }
}
