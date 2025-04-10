using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetcore.ntier.DAL.Entities
{
    public class UserGrandparent
    {
        public int UserId { get; set; }
        public int GrandparentId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("GrandparentId")]
        public User Grandparent { get; set; }
    }
} 