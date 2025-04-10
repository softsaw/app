using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    // Teyze ilişkisini temsil eden ara tablo (anne tarafı kız kardeşler)
    public class UserMaternalAunt
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AuntId { get; set; }
        public User Aunt { get; set; }
    }
} 