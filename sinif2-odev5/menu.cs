using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace sinif2_odev5
{
    internal class menu
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------
        string _baslik;
        List<string> _secenekler = new List<string>();  //  seçenekler string listesi
        public delegate void fonksiyonListesi(int fonksiyonNumarasi);
        public delegate void bilgiFonksiyonu();
        public bilgiFonksiyonu menuBilgisi;

        

        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        string Baslik { get { return _baslik; } }  //  menü başlığına erişim
        int secenekSayisi { get { return _secenekler.Count; } }  //  seçenek sayısını dinamik olarak verir


        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        #region oluşturucular
        private menu() { }

        private menu(string baslik) { this._baslik = baslik; }  //  
        #endregion



        //##  METODLAR  ----------  ----------  ----------  ----------
        private void secenekEkle(string[] secenekler)
        { foreach (string secenek in secenekler) _secenekler.Add(secenek); }  // bir dizi stringi seçenek listesine ekler

        public static menu yarat(string baslik, string[] secenekler) {
            menu temp = new menu(baslik);
            temp.secenekEkle(secenekler);
            return temp;
        }

        public static menu yarat(string baslik, string[] secenekler, bilgiFonksiyonu menuBilgisi)
        {
            menu temp = new menu(baslik);
            temp.secenekEkle(secenekler);
            temp.menuBilgisi = menuBilgisi;
            return temp;
        }



        public void yazdir()
        {
            Console.Clear();
            Console.WriteLine(Baslik);
            Console.WriteLine("");

            bilgiYazdir();
            int secenekNumarasi = 0;

            foreach (string secenek in _secenekler)
            {
                secenekNumarasi++;
                Console.WriteLine(secenekNumarasi + " " + secenek);
            }
        }

        public void secimYap(int secim, fonksiyonListesi fonksList) => fonksList(secim);
        



        public void bilgiYazdir() 
            { if (menuBilgisi != null) menuBilgisi(); }
        
        


    }  //  menu sınıfı sonu
}  //  namespace sonu
