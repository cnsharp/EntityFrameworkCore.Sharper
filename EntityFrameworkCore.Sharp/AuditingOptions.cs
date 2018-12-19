
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CnSharp.EntityFrameworkCore
{
    public class AuditingOptions
    {
        public string CreatedByProperty { get; set; } = "CreatedBy";

        public string CreatedDateProperty { get; set; } = "CreatedDate";

        public string ModifiedByProperty { get; set; } = "ModifiedBy";

        public string ModifiedDateProperty { get; set; } = "ModifiedDate";

    }

    public class AuditingOptions<TDbContext,TAuditor> : DbContextOptions<TDbContext> where TDbContext : DbContext
    {
        public string CreatedByProperty { get; set; } = "CreatedBy";

        public string CreatedDateProperty { get; set; } = "CreatedDate";

        public string ModifiedByProperty { get; set; } = "ModifiedBy";

        public string ModifiedDateProperty { get; set; } = "ModifiedDate";

        public IAuditingTimeProvider AuditingTimeProvider { get; set; }

        public IAuditorAware<TAuditor> AuditorAware { get; set; }

        //string _logFragment;

        //private long? _serviceProviderHash;

        //public string LogFragment
        //{
        //    get
        //    {
        //        if(_logFragment == null)
        //        {
        //            var builder = new StringBuilder();

        //            if (CreatedByProperty != null)
        //            {
        //                builder.Append("CreatedByProperty=").Append(CreatedByProperty).Append(' ');
        //            }

        //            if (CreatedDateProperty != null)
        //            {
        //                builder.Append("CreatedDateProperty=").Append(CreatedDateProperty).Append(' ');
        //            }

        //            if (ModifiedByProperty != null)
        //            {
        //                builder.Append("ModifiedByProperty=").Append(ModifiedByProperty).Append(' ');
        //            }

        //            if (ModifiedDateProperty != null)
        //            {
        //                builder.Append("ModifiedDateProperty=").Append(ModifiedDateProperty).Append(' ');
        //            }

        //            if (AuditingTimeProvider != null)
        //            {
        //                builder.Append("AuditingTimeProvider=").Append(AuditingTimeProvider).Append(' ');
        //            }

        //            if (AuditorAware != null)
        //            {
        //                builder.Append("AuditorAware=").Append(AuditorAware).Append(' ');
        //            }

        //            _logFragment = builder.ToString();

        //        }
        //        return _logFragment;
        //    }
        //}

        //public bool ApplyServices(IServiceCollection services)
        //{
        //    return true;
        //}

        //public long GetServiceProviderHashCode()
        //{
        //    if (_serviceProviderHash == null)
        //    {
        //        _serviceProviderHash = this.GetHashCode();
        //    }

        //    return _serviceProviderHash.Value;
        //}

        //public void Validate(IDbContextOptions options)
        //{
        //}
    }
}
