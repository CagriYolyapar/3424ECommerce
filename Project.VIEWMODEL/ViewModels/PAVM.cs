using PagedList;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VIEWMODEL.ViewModels
{
    public class PAVM
    {
        public Product Product { get; set; }

        public ProductAttribute ProductAttribute { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public IPagedList<Product> PagedProduct { get; set; } //sayfalama(Pagination) icin tutulan Property'dir...

    }
}
