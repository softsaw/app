namespace AspNetCoreNTier.DTO.User
{
    public class UserGrandparentsDto
    {
        public UserBasicDto PaternalGrandfather { get; set; }
        public UserBasicDto PaternalGrandmother { get; set; }
        public UserBasicDto MaternalGrandfather { get; set; }
        public UserBasicDto MaternalGrandmother { get; set; }
    }
} 