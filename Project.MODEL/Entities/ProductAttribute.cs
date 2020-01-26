using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class ProductAttribute:BaseEntity
    {
        public int AttributeID { get; set; }

        public int ProductID { get; set; }

        //Relational Properties

        public virtual EntityAttribute Attribute { get; set; }

        public virtual Product Product { get; set; }


    }
}
