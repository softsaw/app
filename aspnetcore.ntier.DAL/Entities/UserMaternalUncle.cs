using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    // Dayı ilişkisini temsil eden ara tablo (anne tarafı erkek kardeşler)
    public class UserMaternalUncle
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int UncleId { get; set; }
        public User Uncle { get; set; }
    }
} 