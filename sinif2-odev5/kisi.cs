using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class kisi
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------
        static int _kisiSayisi = 4352;
        int _kisiID;
        string _isim;
        string _soyisim;
        



        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public string Isim { get { return _isim; } }
        public string Soyisim { get { return _soyisim; } }
        public int ID {  get { return _kisiID; } }
        public static int KisiSayisi { get {  return _kisiSayisi; } }
        
        



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        private kisi() { }
        private kisi(string isim, string soyisim)
        {
            _isim = isim;
            _soyisim = soyisim;
            _kisiID = KisiSayisi;
            _kisiSayisi++;
        }



        //##  METOD  ----------  ----------  ----------  ----------
        public static kisi yeniKisi(string isim, string soyisim) { return new kisi(isim, soyisim); }
        public string bilgi() {  return Isim + " " + Soyisim; }
        public void yazdir() { Console.WriteLine(Isim + " " + Soyisim); }
        
    }
}


//##  ALANLAR  ----------  ----------  ----------  ----------
//##  NİTELİKLER  ----------  ----------  ----------  ----------
//##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
//##  METOD  ----------  ----------  ----------  ----------