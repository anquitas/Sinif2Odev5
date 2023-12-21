using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class bankaHesabi
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------
        int kisiID = 345334;
        kisi hesapSahibi;
        bankaKarti _bankaKarti;
        krediKarti _krediKarti;



        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public string Sahip { get { return $"hesap sahibi: {hesapSahibi.bilgi()}: {hesapSahibi.ID}"; } }
        public int Bakiye { get { return _bankaKarti.Bakiye; } }

        public int kalanLimit { get => _krediKarti.KalanLimit; }



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        private bankaHesabi() { }
        private bankaHesabi(kisi kisi) => hesapSahibi = kisi; 
 
         



        //##  METODLAR  ----------  ----------  ----------  ----------
        public static bankaHesabi yarat () => new bankaHesabi();

        public static bankaHesabi yarat(kisi hesapSahibi) => new bankaHesabi(hesapSahibi); 

        public void krediKartiYarat(int Limit, DateTime sonKullanmaTarihi, int cvc)
            { if (_krediKarti == null) _krediKarti = krediKarti.yarat(Limit, sonKullanmaTarihi, cvc); }

        public void bankaKartiYarat(DateTime sonKullanmaTarihi, int cvc)
            { if (_bankaKarti == null) _bankaKarti = bankaKarti.yarat(sonKullanmaTarihi, cvc); }

        public void sanalKartYarat(string kartIsmi, int limit)
            => _krediKarti.sanalKartOlustur(
                kartIsmi, limit, 
                _krediKarti.SonKullanmaTarihi, 
                _krediKarti.CVC
                ); 

        public bool devret () { return false; } 

        public void paraHarca(string tip, string kalem, int miktar)
        {
            if (tip == "banka") _bankaKarti.harcamaYap(kalem, miktar);
            if (tip == "kredi") _krediKarti.harcamaYap(kalem, miktar);
        }

        public void paraYukle(int yuklenecekMiktar) => _bankaKarti.paraYukle(yuklenecekMiktar);
        public void ekstre () => _krediKarti.ekstre();

        public void hesapDokumu () => _bankaKarti.hesapDokumu();

        
    }
}



//##  ALANLAR  ----------  ----------  ----------  ----------
//##  NİTELİKLER  ----------  ----------  ----------  ----------
//##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
//##  METOD  ----------  ----------  ----------  ----------