using System;

namespace aspnetcore.ntier.DAL.Entities
{
    // Tüm entity'ler için temel sınıf
    // Ortak özellikleri içerir
    public abstract class BaseEntity
    {
        // Primary key for the entity
        public int Id { get; set; }
        
        // Oluşturulma tarihi
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Son güncelleme tarihi
        public DateTime? UpdatedAt { get; set; }
        
        // Oluşturan kullanıcı ID'si
        public string? CreatedBy { get; set; }
        
        // Son güncelleyen kullanıcı ID'si
        public string? UpdatedBy { get; set; }
        
        // Silindi mi?
        public bool IsDeleted { get; set; } = false;
        
        // Concurrency control için kullanılır
        public byte[]? RowVersion { get; set; }
    }
} 