using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    // Kuzen ilişkisini temsil eden ara tablo
    public class UserCousin
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CousinId { get; set; }
        public User Cousin { get; set; }
    }
} 