## kart
- *alanlar*
	- _sonKullanmaTarihi: int -> 
	- _CVC: datetime ->
+ *nitelikler*
	+ SonKullanmaTarihi: datetime
	+ CVC: int ->
+ *metodlar*
	+  harcamaYap: virtual void



## bankaKarti
+ *alanlar*
	- _bakiye: int
+ *nitelikler*
	+ Bakiye: int
+ *metodlar*
	+ harcamaYap: override void ->



## kisi
- *ALANLAR*
	- _kisiSayisi: static int   ->   sýnýfa ait instance sayýsýný tutar
	- _kisiID: int   ->     
	- _isim: string   ->   
	- _soyisim: string   ->   
	- _hesap: bankaHesabi   ->   
+ *NÝTELÝKLER*
 	+ KisiSayisi:   ->   
	+ Isim: string   ->   
	+ Soyisim: string   ->
	+ KisiID: int   -> 
	+ Hesap: bankaHesabi   -> 
+ *METODLAR*
	+ yeniKisi:   ->
	+ yazdir:   ->
	+ hesapOlustur:   ->

## bankaHesabý
- *ALANLAR*
	- _kisiID: int   ->
	- _bankaKarti: bankaKarti
	- _krediKarti: krediKarti
+ *NÝTELÝKLER*
	+ KisiID: int
	+ BankaKarti: bankaKarti
	+ KrediKarti: krediKarti
+ *METODLAR*
	+ 


## krediKarti

	## nitelikler

	## metodlar

## sanalKart

	## nitelikler

	## metodlar