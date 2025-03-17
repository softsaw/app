using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.DAL.Entities
{
    // Belge varlığı, aile ile ilgili belgeleri temsil eder
    // Fotoğraflar, sertifikalar, resmi belgeler gibi dosyaları saklar
    public class Document : BaseEntity
    {
        // Belgenin başlığı veya adı
        public string Title { get; set; }
        
        // Belgenin detaylı açıklaması
        public string Description { get; set; }
        
        // Belge dosyasının URL'si veya dosya yolu
        public string FileUrl { get; set; }
        
        // Belgenin yüklenme tarihi
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
        
        // Belge türü (fotoğraf, sertifika, resmi belge vb.)
        public string DocumentType { get; set; }
        
        // Belgenin dosya boyutu (byte cinsinden)
        public long FileSize { get; set; }
        
        // Belgenin MIME türü (örn. image/jpeg, application/pdf)
        public string MimeType { get; set; }
        
        // Bu belgeyi sisteme ekleyen kullanıcının ID'si
        public string UserId { get; set; }
        
        // Belge ile ilişkili kişiler koleksiyonu
        public virtual ICollection<User> RelatedPersons { get; set; } = new List<User>();
        
        // Belgenin etiketleri (JSON string olarak saklanır)
        public string Tags { get; set; }
        
        // Belgenin oluşturulma tarihi (belgenin kendisinin tarihi, yükleme tarihi değil)
        public DateTime? DocumentDate { get; set; }
        
        // Belgenin konumu veya oluşturulduğu yer
        public string Location { get; set; }
        
        // Belge için ek notlar
        public string Notes { get; set; }
    }
} 