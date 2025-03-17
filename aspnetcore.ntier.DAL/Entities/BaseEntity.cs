using System;

namespace aspnetcore.ntier.DAL.Entities
{
    // Base entity class that contains common audit fields for all entities
    // This helps track when and by whom records were created or modified
    public abstract class BaseEntity
    {
        // Primary key for the entity
        public int Id { get; set; }
        
        // Date and time when the record was created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Date and time when the record was last updated
        public DateTime? UpdatedAt { get; set; }
        
        // ID of the user who created the record
        public string CreatedBy { get; set; }
        
        // ID of the user who last updated the record
        public string UpdatedBy { get; set; }
        
        // Flag to indicate if the record is deleted (for soft delete)
        public bool IsDeleted { get; set; } = false;
        
        // Used for concurrency control to prevent conflicting updates
        public byte[] RowVersion { get; set; }
    }
} 