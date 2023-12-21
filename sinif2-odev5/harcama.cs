using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class harcama  //  harcamaları düzenli olarak tutmak için
    {
        string kalem;
        int miktar;

        private harcama (string kalem, int miktar)
        {
            this.kalem = kalem;
            this.miktar = miktar;
        }

        public static harcama yarat (string kalem, int miktar) => new harcama (kalem, miktar);
        
        public string bilgi () => $"{kalem}: {miktar}";

        public void yazdir () => Console.WriteLine (bilgi());


    }  // harcama sınıfı sonu
}  //  namespace sonu
