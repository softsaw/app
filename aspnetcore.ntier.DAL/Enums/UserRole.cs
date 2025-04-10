namespace aspnetcore.ntier.DAL.Enums
{
    // Kullanıcı rollerini temsil eden enum
    // Kullanıcının sistemdeki yetkilerini belirlemek için kullanılır
    public enum UserRole
    {
        // Normal kullanıcı
        User = 0,
        
        // Sistem yöneticisi
        Admin = 1,

        Guest = 2
    }
} 