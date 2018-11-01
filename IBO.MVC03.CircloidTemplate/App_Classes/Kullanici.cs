using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBO.MVC03.CircloidTemplate.App_Classes
{
    public class Kullanici
    {
        //BURDAKI PROP NAMELERI
        //KULLANICI/EKLE(GET) OLAN VIEW SAYFASININ
        // GIRDILERININ NAME OZELLIGIYLE AYNI ISIMDE
        public string kullaniciAdi { get; set; }
        public string parola { get; set; }
        public string email { get; set; }
        public string gizliCevap { get; set; }
        public string gizliSoru { get; set; }
    }
}