using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBO.MVC03.CircloidTemplate.App_Classes
{
    public class Sepet
    {
        private  List<Products> _sepetim = new List<Products>();

        public  List<Products> sepetim
        {
            get { return _sepetim;  }
            set { _sepetim =  value; }
        }

    }
}