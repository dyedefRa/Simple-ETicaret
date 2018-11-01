using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IBO.MVC03.CircloidTemplate.Controllers
{
    //[Authorize]
    public class RolController : Controller
    {
     
        // GET: Rol
        public ActionResult Index()
        {
            //role manager ayarı yoksa hata verir
          List<string> roller=  Roles.GetAllRoles().ToList();


            return View(roller);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(string roladi)
        {
            Roles.CreateRole(roladi);
            return RedirectToAction("Index");
        }
    }
}