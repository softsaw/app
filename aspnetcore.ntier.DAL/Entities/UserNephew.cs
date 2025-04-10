using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetcore.ntier.DAL.Entities
{
    public class UserNephew
    {
        public int UserId { get; set; }
        public int NephewId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("NephewId")]
        public User Nephew { get; set; }
    }
} 