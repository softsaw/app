namespace AspNetCoreNTier.DTO.User
{
    public class UserNiecesNephewsDto
    {
        public ICollection<UserBasicDto> Nieces { get; set; }
        public ICollection<UserBasicDto> Nephews { get; set; }
    }
} 