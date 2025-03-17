using aspnetcore.ntier.DAL.Enums;


namespace aspnetcore.ntier.DAL.Entities
{
    // Kullanıcı varlığı, soy ağacındaki bir bireyi temsil eder
    // Kişisel bilgileri ve aile ilişkilerini içerir
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        
        // Kullanıcının adı
        public string Name { get; set; }
        
        // Kullanıcının soyadı
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
        
        // Kullanıcının ölüm tarihi (hayatta olanlar için null)
        public DateTime? DeathDate { get; set; }
        
        // Kullanıcının doğum yeri
        public string BirthPlace { get; set; }
        
        // Kullanıcının telefon numarası
        public string Phone { get; set; }
        
        // Kullanıcının mesleği
        public string Job { get; set; }
        
        // Kullanıcının adresi
        public string Address { get; set; }
        
        // Kullanıcının bulunduğu coğrafi konum (şehir, ülke)
        public string Location { get; set; }
        
        // Kullanıcının medeni durumu (Bekar, Evli, Boşanmış, Dul)
        public MaritalStatus MaritalStatus { get; set; }
        
        // Kullanıcının cinsiyeti (Erkek, Kadın)
        public Gender Gender { get; set; }
        
        // Kullanıcının kan grubu
        public BloodType BloodType { get; set; } = BloodType.Unknown;
        
        // Kullanıcı hakkında ek notlar veya bilgiler
        public string Notes { get; set; }
        
        // Kullanıcının eğitim geçmişi veya nitelikleri
        public string Education { get; set; }
        
        // Kullanıcının sosyal medya bağlantıları (JSON string olarak saklanır)
        public string SocialMediaLinks { get; set; }
        
        // Kullanıcının profil resmi veya fotoğrafının URL'si
        public string ProfileImageUrl { get; set; }
        
        // Bu kullanıcıyı sisteme ekleyen kullanıcının ID'si
        public string UserId { get; set; }

        public UserRole Role { get; set; }

        // Aile ilişkileri
        // Anne referansı (null olabilir)
        public int? MotherId { get; set; }
        public virtual User Mother { get; set; }
        
        public int? FatherId { get; set; }
        public virtual User Father { get; set; }
        
        public int? SpouseId { get; set; }
        public virtual User Spouse { get; set; }
        
        // Evlilik tarihi (null olabilir)
        public DateTime? MarriageDate { get; set; }
        
        // Boşanma tarihi (null olabilir)
        public DateTime? DivorceDate { get; set; }
        
        // Çocuklar koleksiyonu
        public virtual ICollection<User> Children { get; set; } = new List<User>();
        
        // Kardeşler koleksiyonu
        public virtual ICollection<User> Siblings { get; set; } = new List<User>();
        
        // Amcalar koleksiyonu (babanın erkek kardeşleri)
        public virtual ICollection<User> PaternalUncles { get; set; } = new List<User>();
        
        // Halalar koleksiyonu (babanın kız kardeşleri)
        public virtual ICollection<User> PaternalAunts { get; set; } = new List<User>();
        
        // Dayılar koleksiyonu (annenin erkek kardeşleri)
        public virtual ICollection<User> MaternalUncles { get; set; } = new List<User>();
        
        // Teyzeler koleksiyonu (annenin kız kardeşleri)
        public virtual ICollection<User> MaternalAunts { get; set; } = new List<User>();
        
        // Kuzenler koleksiyonu
        public virtual ICollection<User> Cousins { get; set; } = new List<User>();
    }
}
