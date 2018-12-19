using System;

namespace CnSharp.Data.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class AuditingAttribute : Attribute
    {

    }

    public class CreatedByAttribute : AuditingAttribute
    {

    }

    public class CreatedDateAttribute : AuditingAttribute
    {

    }

    public class LastModifiedByAttribute : AuditingAttribute
    {

    }

    public class LastModifiedDateAttribute : AuditingAttribute
    {

    }
}
