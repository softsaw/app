using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetcore.ntier.DAL.Entities
{
    // Kardeş ilişkisini temsil eden ara tablo
    public class UserSibling
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int SiblingId { get; set; }
        [ForeignKey("SiblingId")]
        public virtual User Sibling { get; set; }
    }
} 