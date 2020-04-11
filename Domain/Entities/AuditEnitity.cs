using System;

namespace Domain.Entities
{
    public abstract class AuditEnitity
    {
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}