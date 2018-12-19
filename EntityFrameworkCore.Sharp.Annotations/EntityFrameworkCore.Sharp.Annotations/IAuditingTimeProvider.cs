using System;

namespace CnSharp.Data
{
    public interface IAuditingTimeProvider
    {
        DateTimeOffset Now();
    }
}
