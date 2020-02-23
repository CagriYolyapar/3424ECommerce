using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VIEWMODEL.ViewModels
{
    public class OrderVM
    {
        public PaymentVM PaymentVM { get; set; }

        public Order Order { get; set; }
    }
}
