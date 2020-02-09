using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class ProductAttributeController : Controller
    {

        //Cagri:Hata sayfası result filter
        //Cagri:Sipariş Modülü
        //İlker:Kullanıcı register işlemleri mail gonderme
        //Cagri:Muadil ürün
        //Cagri: Ürün Resim yükleme
        //Cagri:Caching mevzuları
        //Cagri:Partial View
        //Cagri:Action Filter Loglamalar
        //İlker: Yorumlar
        


        EntityAttributeRepository eaRep;
        ProductAttributeRepository paRep;

        ProductRepository pRep;

        public ActionResult ProductDetail(int id)
        {
            return View(paRep.Where(x=>x.ProductID==id));

        }


        public ProductAttributeController()
        {
            pRep = new ProductRepository();
            eaRep = new EntityAttributeRepository();
            paRep = new ProductAttributeRepository();
        }
        // GET: Admin/ProductAttribute
        public ActionResult ProductAttributeList(int id)
        {
            return View(pRep.Find(id));
        }

        public ActionResult ProductAttributeAdd(int id)
        {
            ViewBag.AttributeList = eaRep.GetAll();
            return View(pRep.Find(id));
        }

        [HttpPost]
        public ActionResult ProductAttributeAdd(ProductAttribute item,FormCollection collection)
        {

            foreach (string element in collection.GetValues("checkbox"))
            {
                int id = Convert.ToInt32(element);
                ProductAttribute pa = new ProductAttribute();
                pa.ProductID = item.ID;
                pa.AttributeID = id;
                paRep.Add(pa);
            }

            
            return RedirectToAction("ProductAttributeList",new { id=item.ID});
        }

        [HttpPost]
        public ActionResult ProductAttributeValue(int id,FormCollection collection)
        {
            List<ProductAttribute> currentData = paRep.Where(x => x.ProductID == id);
            int indexer = 0;

            foreach (ProductAttribute element in currentData)
            {
                element.Value = collection.GetValues("valueName")[indexer];
                indexer++;
                paRep.Update(element);
            }

            return RedirectToAction("ProductDetail", new { id = id });


          
        }

        public ActionResult DeleteProductAttribute(int id)
        {
            paRep.Delete(paRep.Find(id));
            return RedirectToAction("ProductAttributeList");
        }

        public ActionResult UpdateProductAttribute(int id)
        {
            return View(paRep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateProductAttribute(ProductAttribute item)
        {
            paRep.Update(item);
            return RedirectToAction("ProductAttributeList");
        }
    }
}