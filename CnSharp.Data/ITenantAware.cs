using System;
namespace CnSharp.Data
{
    public interface ITenantAware<T>
    {
        T GetCurrentTenantId();
    }
}
