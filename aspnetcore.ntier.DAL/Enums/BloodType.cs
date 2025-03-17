namespace aspnetcore.ntier.DAL.Enums
{
    // Kan grubu bilgisini temsil eden enum
    // Kişinin kan grubunu belirtmek için kullanılır
    public enum BloodType
    {
        // Bilinmeyen kan grubu
        Unknown = 0,
        
        // A pozitif kan grubu
        APositive = 1,
        
        // A negatif kan grubu
        ANegative = 2,
        
        // B pozitif kan grubu
        BPositive = 3,
        
        // B negatif kan grubu
        BNegative = 4,
        
        // AB pozitif kan grubu
        ABPositive = 5,
        
        // AB negatif kan grubu
        ABNegative = 6,
        
        // 0 pozitif kan grubu
        OPositive = 7,
        
        // 0 negatif kan grubu
        ONegative = 8
    }
} 