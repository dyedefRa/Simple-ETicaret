using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBO.MVC03.CircloidTemplate.Controllers
{
    using App_Classes;
    using System.Web.Security;
    //[Authorize]
    public class UyeController : Controller
    {

        [AllowAnonymous]
        // GET: Uye
        public ActionResult GirisYap()
        {
            return View();
        }

       
        [AllowAnonymous]
        [HttpPost]
        public ActionResult GirisYap(Kullanici temp, string hatirla)
        {
            if (Membership.ValidateUser(temp.kullaniciAdi, temp.parola))
            {
                bool hatirlabeni;
                if (hatirla == "on")
                {
                    hatirlabeni = true;
                }
                else
                {
                    hatirlabeni = false;
                }
                FormsAuthentication.RedirectFromLoginPage(temp.kullaniciAdi, hatirlabeni);
                
               
                if (Session["uye"]==null)
                {
                    Session["uye"] = "aktif bir üye var";
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mesaj = "Kullanici adı veya parola hatalı..";
                return View();
            }

        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            if (Session["sepet"]!=null)
            {
                Session["sepet"] = null;
            }
            if (Session["uye"]!=null)
            {
                Session["uye"] = null;
            }
            return RedirectToAction("GirisYap");
        }
        [AllowAnonymous]
        public ActionResult ParolaUnuttum()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ParolaUnuttum(Kullanici temp)
        {
            MembershipUser kullanicimcigim =Membership.GetUser(temp.kullaniciAdi);
            if (kullanicimcigim.PasswordQuestion==temp.gizliSoru)
            {
                string parola = kullanicimcigim.ResetPassword(temp.gizliCevap);
                kullanicimcigim.ChangePassword(parola, temp.parola);
                return RedirectToAction("GirisYap");
            }
            else
            {
                ViewBag.mesaj = "Girilen bilgiler yanlıştır";
                return View();
            }
        }
    }
}