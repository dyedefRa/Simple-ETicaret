using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBO.MVC03.CircloidTemplate.Controllers
{
    //[Authorize]
    public class KategoriController : Controller
    {
        NORTHWNDContext ctx = new NORTHWNDContext();
        // GET: Kategori
        public ActionResult Index()
        {
            List<Categories> kategoriler = ctx.Categories.ToList();
            return View(kategoriler);
        }
        //KATEGORI EKLE SAYFASINI ACAN ACTION
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle( Categories temp)
        {
            ctx.Categories.Add(temp);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Sil(int id)
        {
            Categories temp = ctx.Categories.FirstOrDefault(x => x.CategoryId == id);
            ctx.Categories.Remove(temp);
            try
            {
                ctx.SaveChanges();
                return "basarili";
            }
            catch 
            {
                return "basarisiz";

            }
          
        }

       
        public ActionResult Guncelle(int id)
        {
            Categories temp = ctx.Categories.FirstOrDefault(x => x.CategoryId == id);

            return View(temp);
        }
        [HttpPost]
        public string Guncelle(int id,string cat,string acik)
        {
            Categories temp=ctx.Categories.FirstOrDefault(x => x.CategoryId==id);
            temp.CategoryName = cat;
            temp.Description = acik;

            try
            {
                ctx.SaveChanges();
                return "basarili";
                  
            }
            catch
            {
                return "hata";
    
            }

   
        }
    }
}