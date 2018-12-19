using System;
namespace CnSharp.EntityFrameworkCore
{
    public interface ITenantAware<T>
    {
        T GetCurrentTenantId();
    }
}
