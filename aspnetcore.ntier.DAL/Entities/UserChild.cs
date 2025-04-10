using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    // Ebeveyn-çocuk ilişkisini temsil eden ara tablo
    public class UserChild
    {
        public int ParentId { get; set; }
        public User Parent { get; set; }

        public int ChildId { get; set; }
        public User Child { get; set; }
    }
} 