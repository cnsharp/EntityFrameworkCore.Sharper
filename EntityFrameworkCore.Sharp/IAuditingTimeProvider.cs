using System;

namespace CnSharp.EntityFrameworkCore
{
    public interface IAuditingTimeProvider
    {
        DateTimeOffset Now { get; }
    }
}
