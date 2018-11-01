using IBO.MVC03.CircloidTemplate.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBO.MVC03.CircloidTemplate.Controllers
{
   
    //[Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.aktifkullanici = HttpContext.Application["aktifKullanici"];
            ViewBag.toplamziyaretci = HttpContext.Application["toplamZiyaretci"];
            return View();
        }

        public ActionResult CookieAta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CookieAta(string cookieAdi,string cookieDegeri)
        {
            HttpCookie ck = new HttpCookie(cookieAdi);
            ck.Value = cookieDegeri;
            ck.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(ck);
            return View();
        }

        public ActionResult Sepetim()
        {
            Sepet suankiSepet = new Sepet();
            if (Session["sepet"]!=null)
            {
                 suankiSepet =(Sepet) Session["sepet"];
            }
            return View(suankiSepet);
        }

        [HttpPost]
        public string SepettenCikar(int id)
        {
            try
            {
                Sepet suankiSepet = (Sepet)Session["sepet"];
                Products cikarilan = suankiSepet.sepetim.FirstOrDefault(x => x.ProductId == id);
                suankiSepet.sepetim.Remove(cikarilan);
                Session["sepet"] = suankiSepet;
                return "basarili";

            }
            catch 
            {
                return "basarisiz";
                        
            }
        }

    }
}