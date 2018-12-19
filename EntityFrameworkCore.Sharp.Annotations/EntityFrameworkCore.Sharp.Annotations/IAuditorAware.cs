using System;
namespace CnSharp.Data
{
    public interface IAuditorAware<T>
    {
        T GetCurrentAuditor();
    }
}
