using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBO.MVC03.CircloidTemplate.Controllers
{ using IBO.MVC03.CircloidTemplate.App_Classes;
    //[Authorize]
    public class UrunController : Controller
    {
        // GET: Urun
        NORTHWNDContext ctx = new NORTHWNDContext();
        public ActionResult Index()
        {
            List<Products> urunler = ctx.Products.ToList();
           

            return View(urunler);
        }

        public ActionResult UrunEkle()
        {
            ViewBag.Categories = ctx.Categories.ToList();
            ViewBag.Suppliers = ctx.Suppliers.ToList();
            return View();
        }

        
        [HttpPost]
        public ActionResult UrunEkle(Products temp)
        {
            ctx.Products.Add(temp);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

      

        public ActionResult Sil(int id)
        {
            Products temp = ctx.Products.FirstOrDefault(x => x.ProductId == id);


            return View(temp);
        }
        [HttpPost]
        public ActionResult Sil(Products temp)
        {
            ctx.Products.Remove(temp);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult UrunDetay()
        {
           
            int idd = Convert.ToInt32(Request.QueryString["uid"]);
            Products temp = ctx.Products.FirstOrDefault(x => x.ProductId == idd);

            return View(temp);
        }
       
  [HttpPost]
        public string Sepetim(int id)
        {

            try
            {
                if (Session["sepet"] == null)
                {
                    Session["sepet"] = new Sepet();

                }
                Sepet sepetNesnem = (Sepet)Session["sepet"];
                Products sepeteatilacak = ctx.Products.FirstOrDefault(x => x.ProductId == id);
                sepetNesnem.sepetim.Add(sepeteatilacak);
                Session["sepet"] = sepetNesnem;
                return "basarili";

            }
            catch 
            {
                return "basarisiz";
                         
            }







        }

     
    }
}