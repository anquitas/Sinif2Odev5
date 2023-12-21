using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static sinif2_odev5.menu;

namespace sinif2_odev5
{
    internal partial class KonsolUygulamasi
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------
        string _uygulamaIsmi;  //  uygulmanın ismi
        int aktifMenuID = 0;
        List<int> menuNavYigit = new List<int>();

        List<menu> _menuler = new List<menu>();  //  uygulamada kullanılacak menüler
        String[] _komutlar = { ":q", ":geri" };  //  navigasyon seçenekleri
        
        public delegate void fonksiyonListesi(int fonksiyonNumarasi);
        List<fonksiyonListesi> fonksList = new List<fonksiyonListesi>();

        public bilgiFonksiyonu menuBilgisi;
        List<bilgiFonksiyonu> bilgiList = new List<bilgiFonksiyonu>();




        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public string UygulamaIsmi { get { return _uygulamaIsmi; } }  
        //  uygulama ismine dışarıdan erişim  //  saltOkunu
        List<menu> Menuler { get { return _menuler; } }  
        //  menülere dışarıdan erişim  //  saltOkunur



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        private KonsolUygulamasi() { }
        private KonsolUygulamasi(string uygulamaIsmi) { this._uygulamaIsmi = uygulamaIsmi; }



        //##  METODLAR  ----------  ----------  ----------  ----------
        public void basla () => menuyeGit(0);
            
        public static KonsolUygulamasi yarat () => new KonsolUygulamasi(); 



        public void menuEkle(menu eklenecekMenu, fonksiyonListesi menuFonksiyonu)
        {
            _menuler.Add(eklenecekMenu);
            fonksList.Add(menuFonksiyonu);
        }

        public void menuEkle(
            menu eklenecekMenu, 
            fonksiyonListesi menuFonksiyonu, 
            bilgiFonksiyonu bilgiFonks
        )
        {
            _menuler.Add(eklenecekMenu);
            fonksList.Add(menuFonksiyonu);
            bilgiList.Add(bilgiFonks);
        }



        public string girdiAl (string gosterilecekMetin) { 
            Console.WriteLine(gosterilecekMetin);  
            return Console.ReadLine();
        }


        public void menuyuUygula(int menuID)
        {
            Menuler[menuID].yazdir();
            aktifMenuID = menuID;
            menuNavYigit.Add(menuID);
        }



        public bool komutAl(out string metin)
        {  
            string girdi = Console.ReadLine();
            if (girdi[0] == ':')
            {
                //int komutNo = Array.IndexOf(_komutlar, komut);
                metin = girdi.Substring(1);
                return true;
            }
            metin = girdi;
            return false;
        }



        public void menuyeGit (int menuID) { 
            menuNavYigit.Add(menuID);
            aktifMenuID = menuID;
            bool menuyuGoster = true;
            bool komutMu = false;

            while (menuyuGoster) {
                string girdi = "";
                menuyuUygula(menuID);
                komutMu = komutAl(out girdi);
                Console.Clear();
                if (komutMu == false)
                    
                    secimYap(int.Parse(girdi));
                else if (komutMu == true)
                    menuyuGoster =komutUygular(girdi);
            }
        }
    

        public bool komutUygular (string komut) 
        {
            switch (komut) {
                case "q": Environment.Exit(0);
                    break;
                case "empty":;
                    break;
                case "geri":;
                    return false;
                    
            }
            return true;
        }





        public void secimYap(int secim) => fonksList[aktifMenuID](secim);

        public static string veriAl(string istenecekBilgi) { 
            Console.WriteLine(istenecekBilgi);
            return Console.ReadLine();
        }

    }  // KonsolUygulaması sınıfı sonu
}  //namespace sonu
