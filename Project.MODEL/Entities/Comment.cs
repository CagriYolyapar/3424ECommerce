using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Comment:BaseEntity
    {
        public string BodyContext { get; set; }

        public int? AppUserID { get; set; }


        //Relational Properties

        public virtual AppUser AppUser { get; set; }


    }
}
