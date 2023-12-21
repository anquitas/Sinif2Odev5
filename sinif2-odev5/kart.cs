using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinif2_odev5
{
    internal class kart  //  ortak alanlar burada tanımlandı
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------
        protected DateTime _sonKullanmaTarihi;
        protected int _CVC;
        protected List<harcama> _harcamalar = new List<harcama>();
        protected int _harcanan = 0;



        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public DateTime SonKullanmaTarihi { get { return _sonKullanmaTarihi; } }
        public int CVC { get { return _CVC; } }



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        protected kart (DateTime sonKullanmaTarihi, int cvc) {
            _sonKullanmaTarihi = sonKullanmaTarihi; 
            _CVC = cvc;
        }



        //##  METOD  ----------  ----------  ----------  ----------

        public virtual bool harcamaYap (string kalem, int miktar) {  //  kartların ihtiyaca göre yeniden yazması için  // polymorphism
            _harcanan += miktar;
            _harcamalar.Add(harcama.yarat(kalem, miktar)); 
            return true;
        }

        protected harcama sonHarcama { get { return _harcamalar[_harcamalar.Count - 1]; } }

        protected void yapılanHarcamalar () { foreach (harcama harcama in _harcamalar) harcama.yazdir(); }


    }
}


