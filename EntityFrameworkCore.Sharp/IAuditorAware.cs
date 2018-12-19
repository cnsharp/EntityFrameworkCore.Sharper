using System;

namespace CnSharp.EntityFrameworkCore
{
    public interface IAuditorAware<T>
    {
        T GetCurrentAuditor();
    }
}
