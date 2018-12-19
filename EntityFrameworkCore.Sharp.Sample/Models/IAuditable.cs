using System;
namespace EntityFrameworkCore.Sharp.Sample.Models
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }

        DateTimeOffset CreatedDate { get; set; }

        string UpdatedBy { get; set; }

        DateTimeOffset UpdatedDate { get; set; }
    }
}
