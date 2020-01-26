using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Order:BaseEntity
    {
        public string ShippedAddress { get; set; }

        public int AppUserID { get; set; }

        public int ShipperID { get; set; }




        //Umut => Bize güzel bir PaymentVM sınıfı yaratacak (kredi kartı numarası , son kullanım tarihi ( Ay , yıl ), Limit, CVV Numarası) (BU farklı bir WebApi projesinde olsun dısarıya acılsın)..Deadline => (Salı 28.01.2020 )

        //Relational Properties

        public virtual AppUser AppUser { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

        public virtual Shipper Shipper { get; set; }




    }
}
