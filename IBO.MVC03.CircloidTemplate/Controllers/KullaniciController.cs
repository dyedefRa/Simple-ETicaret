using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IBO.MVC03.CircloidTemplate.App_Classes;

namespace IBO.MVC03.CircloidTemplate.Controllers
{
    //[Authorize]
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
            //Membership ayarları yoksa hata verir
            MembershipUserCollection users = Membership.GetAllUsers();
            return View(users);
        }

        [AllowAnonymous]
        public ActionResult Ekle()
        {
            return View();
        }

       
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Ekle(Kullanici temp)
        {
            MembershipCreateStatus durum;

            Membership.CreateUser(temp.kullaniciAdi, temp.parola, temp.email, temp.gizliSoru, temp.gizliCevap, true, out durum);
            string mesaj = "";
            switch (durum)
            {
                case MembershipCreateStatus.Success:
                    break;

                case MembershipCreateStatus.InvalidUserName:
                    mesaj += " 'Geçersiz kullanici adi girildi' ,";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += " 'Kullanılmış kullanıcı adi girildi' ,";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += " 'Kullanılmış mail adresi girildi' ,";
                    break;
                case MembershipCreateStatus.UserRejected:
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    break;
                case MembershipCreateStatus.ProviderError:
                    break;
                default:
                    break;
            }
            ViewBag.mesaj = mesaj;
            if (durum == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult RolAta()
        {
            ViewBag.roller = Roles.GetAllRoles().ToList();
            ViewBag.kullanici = Membership.GetAllUsers();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RolAta(string kullaniciAdi, string rolAdi)
        {
            Roles.AddUserToRole(kullaniciAdi, rolAdi);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string UyeRolleri(string ka)
        {
            List<string> rolleri = Roles.GetRolesForUser(ka).ToList();
            string rol = "";
            foreach (string roller in rolleri)
            {
                rol += roller + "-";
            }
            rol = rol.Substring(0, rol.Length - 1);
            return rol;
        }
    }
}