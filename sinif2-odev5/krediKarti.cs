using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class krediKarti : kart
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------  
        //  alanlar alt sınıflara erişim vermek için protected olarak 
        protected int _limit = 0;
                
        List<sanalKart> _sanalKartlar = new List<sanalKart>();  //yaratılan sanal kartları tutar
        


        //##  NİTELİKLER  ----------  ----------  ----------  ----------  
        

        public int Limit { get => _limit;  }
        public int Harcanan { get => _harcanan; }
        public int sanalKartSayisi { get { return _sanalKartlar.Count; } }
        public int KalanLimit { get { return _limit - _harcanan; } }

        
        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        //  oluşturucular alt sınıflara erişim vermek için protected  //  nesne oluşturulması nesne sınıf içerisinde statik olarak gerçekleştirilir

        protected krediKarti(int limit, DateTime sonKullanmaTarihi, int cvc): base(sonKullanmaTarihi, cvc) 
        { 
            this._limit = limit;
            this._sonKullanmaTarihi = sonKullanmaTarihi;
            this._CVC = cvc;
        }


        //##  METOD  ----------  ----------  ----------  ----------


        public static krediKarti yarat (int limit, DateTime sonKullanmaTarihi, int cvc) 
            => new krediKarti(limit, sonKullanmaTarihi, cvc);  //instance yaratmak için statik metod
        

        public void sanalKartOlustur(string kartIsmi, int limit, DateTime sonKullanmaTarihi, int cvc)
            => _sanalKartlar.Add(sanalKart.yarat(kartIsmi, limit, sonKullanmaTarihi, cvc));
        //  sanal kart oluşturup sanalKartlar listesine ekler



        public override bool harcamaYap(string kalem, int miktar)
        {
            int sanalKartIndex;
            //bool sanalKartUygunMu = false;
            bool sanalKartUygunMu = sanalKartAra(kalem, out sanalKartIndex);
            bool limitUygunMu = limitKontrol(miktar);

            if (sanalKartUygunMu && limitUygunMu)  
            {  //  sanal kartın varlığını ve ana kartın limitini kontrol eder
                bool olduMu = _sanalKartlar[sanalKartIndex].harcamaYap(kalem, miktar);  
                //  sanal kartla harcama yapmaya calışır ve yapıp yapmadığını kontrol eder
                if (olduMu)  
                {
                    _harcamalar.Add(_sanalKartlar[sanalKartIndex].sonHarcama);  //  yapılan harcamayı aynı zamanda ana kredi kartının limitine de ekler
                    _harcanan += miktar;
                    return true;
                }
                return false;
                    
            }
            else if (limitUygunMu) { //eğer kaleme uygun sanal kart yoksa harcamayı direk ana karttan yapar
                _harcamalar.Add(harcama.yarat(kalem, miktar));
                _harcanan += miktar;
                return true;
                
            }
            else Console.WriteLine("bakiyeniz yetersiz!!!");  //  iki durumda olmuyorsa ana kartın bakiyesi yetersizdir
            return false;
        }   



        public bool sanalKartAra (string kalem, out int bulunduguIndex)
        {
            bulunduguIndex = 0;

            foreach (sanalKart sanalKart in _sanalKartlar) {
                if (sanalKart.KartIsmi == kalem) {
                    return true; 
                }  bulunduguIndex++;
            }

            bulunduguIndex = -1;
            return false;
        }



        public void ekstre ()
        {
            Console.WriteLine($"kalan limit: {KalanLimit}");
            yapılanHarcamalar();
        }

        public virtual bool limitKontrol(int harcanacakMiktar) => KalanLimit >= harcanacakMiktar ? true : false;

        public void sanalKartOzet ()
        {
            foreach (sanalKart sanalKart in _sanalKartlar) sanalKart.ozetLimit();
        }
    }
}



//##  ALANLAR  ----------  ----------  ----------  ----------
//##  NİTELİKLER  ----------  ----------  ----------  ----------
//##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
//##  METOD  ----------  ----------  ----------  ----------