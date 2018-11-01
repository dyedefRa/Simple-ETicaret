using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBO.MVC03.CircloidTemplate.Controllers
{
    //[Authorize]
    public class TedarikciController : Controller
    {
        NORTHWNDContext ctx = new NORTHWNDContext();
            
        // GET: Tedarikci
        public ActionResult Index()
        {
            List<Suppliers> data = ctx.Suppliers.ToList();
            return View(data);
        }

        [HttpPost]
        public string Sil(int id)
        {
            Suppliers temp = ctx.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            ctx.Suppliers.Remove(temp);
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
    }
}