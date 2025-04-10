using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    // Hala ilişkisini temsil eden ara tablo (baba tarafı kız kardeşler)
    public class UserPaternalAunt
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AuntId { get; set; }
        public User Aunt { get; set; }
    }
} 