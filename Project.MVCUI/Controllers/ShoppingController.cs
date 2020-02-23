using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.COMMON.MailSender;
using Project.MODEL.Entities;
using Project.MVCUI.Filters;
using Project.MVCUI.Models;
using Project.VIEWMODEL.ViewModels;

namespace Project.MVCUI.Controllers
{
    [ActFilter]
    public class ShoppingController : Controller
    {
        OrderRepository oRep;
        ProductRepository pRep;
        CategoryRepository cRep;
        OrderDetailRepository odRep;

        public ShoppingController()
        {
            odRep = new OrderDetailRepository();
            oRep = new OrderRepository();
            pRep = new ProductRepository();
            cRep = new CategoryRepository();
        }

        // GET: Shopping
        public ActionResult ShoppingList(int? page)
        {
            PAVM pavm = new PAVM();
            pavm.PagedProduct = pRep.GetActives().ToPagedList(page ?? 1, 9);
            pavm.Categories = cRep.GetActives();
            return View(pavm);
        }


        public ActionResult AddToCart(int id)
        {


            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product eklenecekUrun = pRep.Find(id);

            CartItem ci = new CartItem()
            {
                ID = eklenecekUrun.ID,
                Name = eklenecekUrun.ProductName,
                Price = eklenecekUrun.UnitPrice,
                ImagePath = eklenecekUrun.ImagePath,

            };
            c.SepeteEkle(ci);

            Session["scart"] = c;
            return RedirectToAction("ShoppingList");



        }


        public ActionResult CartPage()
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                return View(c);
            }
            TempData["sepetBos"] = "Sepetinizde ürün bulunmamaktadır";
            return RedirectToAction("ShoppingList");
        }


        public ActionResult DeleteFromCart(int id)
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                c.SepettenSil(id);

                if (c.Sepetim.Count == 0)
                {
                    Session.Remove("scart");
                    TempData["sepetBos"] = "Sepetinizde ürün bulunmamaktadır";
                    return RedirectToAction("ShoppingList");
                }

                return RedirectToAction("CartPage");

            }
            return RedirectToAction("ShoppingList");
        }

        //http://localhost:49606/api/Payment/GetAll


        public ActionResult SiparisiOnayla()
        {
            AppUser mevcutKullanici;

            if (Session["member"] != null)
            {
                mevcutKullanici = Session["member"] as AppUser;

            }
            else
            {
                TempData["anonim"] = "Kullanıcı üye degil";
            }



            return View();
        }

        [HttpPost]

        public ActionResult SiparisiOnayla(OrderVM ovm)
        {
            //Burada artık bir client olarak API'a istek göndermemiz gerekir..(Api consume)..Bunun icin  WebApiClient package'ini Nuget'tan indirmeniz gerekir. Eger dogru kütüphaneyi indirip indirmediginiz görmek istiyorsanız HttpClient sınıfının gelip gelmedigine bakın...

            //Bir Api consume etme sürecinde actıgımız degişkenleri veya nesneleri veya sürecleri ram'de cok uzun süre tutmamalıyız...

            bool result;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49606/api/");

                var postTask = client.PostAsJsonAsync("Payment/ReceivePayment", ovm.PaymentVM);
                //BUrada PAymentVM nesnesi Json olarak Asymc bicimde gönderilir. 

                var sonuc = postTask.Result;

                if (sonuc.IsSuccessStatusCode)
                {
                    result = true;

                }
                else
                {
                    result = false;
                }


            }


            if (result)
            {
                ovm.Order.ShipperID = 1;
                

                if (Session["member"] != null)
                {
                    AppUser kullanici = Session["member"] as AppUser;
                    ovm.Order.AppUserID = kullanici.ID;
                    ovm.Order.UserName = kullanici.UserName;
                }
                else
                {
                    string userName = TempData["anonim"].ToString();
                    ovm.Order.AppUserID = null;
                    ovm.Order.UserName = "Kayıtlı olmayan kullanıcı";
                }

                Cart sepet = Session["scart"] as Cart;
                ovm.Order.TotalPrice = sepet.TotalPrice.Value;
                oRep.Add(ovm.Order); //tam bu noktada ilgili Order'imiz kaydedildiginde Order'imizin ID'si olusacak..
               

                foreach (CartItem item in sepet.Sepetim)
                {
                    OrderDetail od = new OrderDetail();
                    od.OrderID = ovm.Order.ID;
                    od.ProductID = item.ID;
                    od.TotalPrice = item.SubTotal;
                    od.Quantity = item.Amount;
                    odRep.Add(od);
                }
                TempData["odeme"] = "Siparişiniz bize ulasmıstır...Tesekkür ederiz";
                MailSender.Send(ovm.Order.Email, body: $"Siparisiniz basarıyla alındı.{ovm.Order.TotalPrice}");
                return RedirectToAction("ShoppingList");

            }
            else
            {
                TempData["sorun"] = "Odeme ile ilgili bir sorun olustu. Lütfen bankanızla iletişime geciniz";
                return RedirectToAction("ShoppingList");
            }
         
        }





    }
}