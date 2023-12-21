using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class bankaKarti : kart
    {

        //##  ALANLAR  ----------  ----------  ----------  ----------
        int _bakiye = 0;
        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public int Bakiye { get { return _bakiye; } }
        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------

        protected bankaKarti (DateTime sonKullanmaTarihi, int cvc) : base(sonKullanmaTarihi,cvc) {  }  
        //  kalıtılan asıl oluşturucu



        //##  METOD  ----------  ----------  ----------  ----------
        public override bool harcamaYap (string kalem, int miktar)
        {
            paraHarca(miktar, out _);
            base.harcamaYap(kalem,miktar);
            return true;
        }


        public static bankaKarti yarat(DateTime sonKullanmaTarihi, int cvc)
        {
            return new bankaKarti(sonKullanmaTarihi, cvc);
        }

        public void paraYukle (int yuklenecekMiktar)
        {
            this._bakiye += yuklenecekMiktar;
        }

        public bool paraHarca(int harcanacakMiktar, out int aktarilanMiktar) 
        {
            if (Bakiye > harcanacakMiktar) { 
                _bakiye -= harcanacakMiktar;
                aktarilanMiktar = harcanacakMiktar;
                return true; 
            }
            aktarilanMiktar = 0;
            return false;
        }

        public void hesapDokumu ()
        {
            Console.WriteLine($"bakiye: {Bakiye}");
            Console.WriteLine($"----------------");
            yapılanHarcamalar();
        }

    }
}
