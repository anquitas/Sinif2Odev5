using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class sanalKart : krediKarti
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------
        string _kartIsmi;
        protected int limitAsimi = 800;



        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public string KartIsmi { get { return _kartIsmi; } }

        


        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------

        private sanalKart (string kartIsmi, int limit, DateTime sonKullanmaTarihi, int cvc) : base (limit, sonKullanmaTarihi, cvc) 
            => this._kartIsmi = kartIsmi;
        

        //##  METOD  ----------  ----------  ----------  ----------
        public static sanalKart yarat (string kartIsmi, int limit, DateTime sonKullanmaTarihi, int cvc) 
            => new sanalKart(kartIsmi,limit,sonKullanmaTarihi,cvc); 
        


        public override bool harcamaYap(string kalem, int miktar)
            {
            if (limitKontrol(miktar)) {
                base.harcamaYap(kalem, miktar);
                return true;
            }
            else Console.WriteLine("limitiniz yetersiz!!!");
            return false;
            }

        public override bool limitKontrol(int harcanacakMiktar)  => this.KalanLimit + limitAsimi >= harcanacakMiktar ? true : false;
        //  kredi kartından farklı olarak 800 tl limit aşımına sahip

        public void ozetLimit() => Console.WriteLine($"{KartIsmi} limiti: {KalanLimit}");


    }  //  sanalKart sınıfı sonu
}



//##  ALANLAR  ----------  ----------  ----------  ----------
//##  NİTELİKLER  ----------  ----------  ----------  ----------
//##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
//##  METOD  ----------  ----------  ----------  ----------