using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Sharp.Sample.Models
{
    public class Host : IAuditable
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string CreatedBy { get;set; }
        public DateTimeOffset CreatedDate { get;set; }
        public string UpdatedBy { get;set; }
        public DateTimeOffset UpdatedDate { get;set; }
    }
}
