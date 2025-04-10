using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    // Amca ilişkisini temsil eden ara tablo (baba tarafı erkek kardeşler)
    public class UserPaternalUncle
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int UncleId { get; set; }
        public User Uncle { get; set; }
    }
} 