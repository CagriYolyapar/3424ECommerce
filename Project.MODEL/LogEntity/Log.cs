using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.LogEntity
{
    public class Log:BaseEntity
    {
        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public string Information { get; set; }

        public string UserName { get; set; }


    }
}
