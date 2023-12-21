using sinif2_odev5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class Program
    {
        //  ##  ALANLAR  ----------  ----------  ---------  ---------
        static kisi kullanici = kisi.yeniKisi("oğuz", "şahingöz");  // hesap sahibi olacak kişi
        static bankaHesabi hesap = bankaHesabi.yarat(kullanici);  //  programda kullanılacak banka hesabı
        static KonsolUygulamasi uygulama = KonsolUygulamasi.yarat();  //  programı oluşturan konsol uygulaması


        //## MAIN FONKSIYONU  ----------  ----------  ---------  ---------
        static void Main(string[] args)
        {

            _init_();  //  gerekli giriş atamalarını yapar

            menuleriOlustur();  //  menüleri oluşturur, konsol uygulamasına ekler


            //  uygulamayı başlat
            uygulama.basla();
            Console.ReadKey();
            
        }

        //##  METODLAR  ----------  ----------  ---------  ---------

        public static void _init_ () 
        {
            DateTime tarih;
            tarih = new DateTime(2027,11, 1);
            hesap.krediKartiYarat(20000,tarih,330);
            hesap.bankaKartiYarat(tarih, 230);
            hesap.paraYukle(2000);
            hesap.sanalKartYarat("ulaşım",3500);
            hesap.sanalKartYarat("giyim", 3500);
            hesap.sanalKartYarat("eğlence", 3500);
            hesap.sanalKartYarat("yemek", 3500);
        }


        #region menu tanımları
        public static void menuleriOlustur ()  //  menü oluşturma
        {
            menu Temp;
            //  giriş menüsü
            Temp = menu.yarat(
                "banka hesabı",
                new string[] { "banka kartı", "kredi kartı" },
                 menu1_bilgi
            );
            uygulama.menuEkle(Temp, menu1_komutlar);


            //  banka kartı menüsü
            Temp = menu.yarat(
                "banka kartı",
                new string[] { "harcamalar", "para yatır", "para harca" }, 
                menu2_bilgi
            );
            uygulama.menuEkle(Temp, menu2_komutlar);

            //  kredi kartı menüsü
            Temp = menu.yarat(
                "kredi kartı",
                new string[] { "ekstre", "harcama" }, 
                menu3_bilgi
            );
            uygulama.menuEkle(Temp, menu3_komutlar);
        }


        // menü 0 -> ana menü
        public static void menu1_komutlar (int secimNumarasi) {  //  hesap giriş
            switch (secimNumarasi)
            {
                case 1: uygulama.menuyeGit(1);
                    break;
                case 2: uygulama.menuyeGit(2);
                    break;
            }
            Console.ReadKey();
        }

        public static void menu1_bilgi () { 
            Console.WriteLine(hesap.Sahip);
            Console.WriteLine("navigasyon :q -> çık, :geri -> geri");
        }


        // menü 1 -> banka kartı
        public static void menu2_komutlar(int secimNumarasi)  //  banka kartı
        {
            switch (secimNumarasi)
            {
                case 1:
                    hesap.hesapDokumu();
                    break;
                case 2:
                    int miktar2 = int.Parse(KonsolUygulamasi.veriAl("miktar: "));
                    hesap.paraYukle(miktar2);
                    break;
                case 3:
                    string kalem = KonsolUygulamasi.veriAl("kalem: ");
                    int miktar = int.Parse(KonsolUygulamasi.veriAl("miktar: "));
                    hesap.paraHarca("banka", kalem, miktar);
                    break;
            }
            Console.ReadKey();
        }

        public static void menu2_bilgi() { Console.WriteLine($"bakiye: {hesap.Bakiye}"); }


        // menü 3 -> kredi kartı
        public static void menu3_komutlar(int secimNumarasi)  //  kredi kartı
        {  
            switch (secimNumarasi)
            {
                case 1:
                    hesap.ekstre();
                    break;
                case 2:
                    string kalem = KonsolUygulamasi.veriAl("kalem: ");
                    int miktar = int.Parse(KonsolUygulamasi.veriAl("miktar: "));
                    hesap.paraHarca("kredi", kalem, miktar);
                    break;
            }
            Console.ReadKey();
        }

        public static void menu3_bilgi() { Console.WriteLine($"kalan limit: {hesap.kalanLimit}"); }
        #endregion
    }  //  program sınıfı sonu
}  //  namespace sonu




