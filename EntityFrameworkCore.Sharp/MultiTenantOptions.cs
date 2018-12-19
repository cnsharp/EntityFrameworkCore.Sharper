using System;
using Microsoft.EntityFrameworkCore;

namespace CnSharp.EntityFrameworkCore
{
    public class MultiTenantOptions// <TDbContext, TAuditor,TTenant> : AuditingOptions<TDbContext, TAuditor> where TDbContext : DbContext
    {
        public string TenantIdField { get; set; } = "TenantId";

        //public ITenantAware<TTenant> TenantAware { get; set; }
    }
}
