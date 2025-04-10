using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetcore.ntier.DAL.Entities
{
    public class UserGrandchild
    {
        public int GrandparentId { get; set; }
        public int GrandchildId { get; set; }

        [ForeignKey("GrandparentId")]
        public User Grandparent { get; set; }

        [ForeignKey("GrandchildId")]
        public User Grandchild { get; set; }
    }
} 