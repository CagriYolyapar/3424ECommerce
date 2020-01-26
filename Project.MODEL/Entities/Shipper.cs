using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Shipper:BaseEntity
    {
        public string CompanyName { get; set; }

        public string Phone { get; set; }

        //Relational Properties

        //Ilker: Kargo API entegrasyonu

        public virtual List<Order> Orders { get; set; }



    }
}
