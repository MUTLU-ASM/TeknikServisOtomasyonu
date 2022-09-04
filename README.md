# TeknikServisOtomasyonu
Bu Proje Teknik Servisler Tarafından kullanılması planlanan yazılım ihtiyacı doğrultusunda hazırlanmıştır. 
Bu projedeki amaç Personellerin kolaylıkla gelen müşterinin bilgilerini ve cihazındaki arızaları sisteme kaydını oluşturabilmektir.

# YAZILIMIN GENEL ÖZELLİKLERİ
1.	Sisteme giriş yapmış olan Personelin gelen müşterilerin bilgilerini, arızalarını sisteme kaydetme, silme, güncelleme, ekleme yetkisi vardır.
2.	Sisteme giriş yapmış olan Yöneticinin personel ve marka/tür işlemlerinde ekleme, silme, güncelleme, kaydetme yetkisi vardır. Personel Sayfasına Erişim yetkisine sahiptir.
3.	Yapılan yazılımın Ara Yüzünde Geçiş, Giriş, Personel Anasayfa, Müşteri işlemleri, Arıza işlemleri, Arıza Bitirme, Arıza Listeleme, Tutar Hesaplama, Hesap Makinesi, Yönetici Sayfası, Marka/Tür İşlemleri, Gelir, Personel işlemleri ekranları bulunmaktadır.

# TEKNİK ALTYAPI
1.	Programlama dili C# kullanıldı.
2.	Yazılım veri tabanı Microsoft SQL kullanıldı.
3.	Açıklamalı yorum satırları eklendi.
4.	Yazılımın veri tabanı ilişkisel veri tabanı mimarisine uygun olarak tasarlandı.

# OLUŞTURULMUŞ ARA YÜZLER
1.	Geçiş Ekranı
2.	Giriş Ekranı
3.	Personel Anasayfa Ekranı
4.	Müşteri işlemleri Ekranı
5.	Arıza işlemleri Ekranı
6.	Arıza bitirme Ekranı
7.	Arıza listesi Ekranı
8.	Tutar hesaplama Ekranı
9.	Hesap makinesi Ekranı
10.	Yönetici sayfası Ekranı
11.	Marka/Tür işlemleri Ekranı
12.	Gelir Ekranı
13.	Personel işlemleri Ekranı

# Geçiş Ekranı
Şirket logosu ve Panelin içerisinin dolması (yaklaşık 4 saniye) sonrası giriş ekranına geçişin sağlanması. 

# Giriş Ekranı
Giriş yapacak olan kişinin E-posta ve şifre bilgileriyle doğru eşleşmesi durumunda Personel veya Yönetici anasayfasına yönlendirilmesi.

# Personel Anasayfa Ekranı
Giriş yapan personelin ad ve soyadı bilgilerinin panelde gösterilmektedir. Altı farklı işlem için butonların bulunması
. Döviz çeviricisi bulunması. Bugünün Tarih bilgisi ve Güncel arızalarının Panellerde gösterilmektedir.

# Müşteri işlemleri Ekranı
Müşterinin ad, soyadı, telefon, adres bilgilerinin kaydetme, silme, güncelleme işlemleri yapılabilmektedir.
Arama kısmı ile listeden kolaylıkla kişinin bilgilerini ulaşılabilmektedir.

# Arıza işlemleri Ekranı
Müşteri, Sorumlu Personel, Tür, Marka, Model, Alış Tarihi, Teslim Tarihi, Sorunu, Açıklama, Durumu ve tutar bilgilerinin listeye kaydetme, silme, düzenleme işlemlerinin yapılabilir.
Tutarın hesapla butonuna tıklanması durumunda tutar hesaplama ekranına yönlendirilmesi.

# Arıza Bitirme Ekranı
Seçilen cihaz arızasındaki Sorumlu Personel, Durumu ve Açıklama güncellenerek Arıza Listesinin güncellenmesi.

# Arıza Listesi Ekranı
DataGridWiev’de tamamlanmış ve tamamlanmamış Arızaların listelenmesi.

# Tutar hesaplama Ekranı
Her bir işlemin veya parçaların veritabanından fiyat bilgilerinin Ekranın sağ tarafında bulunan DataGridView’de gösterilmektedir. 
Seçilen checkboxlara göre label’da toplam tutar bilgisi gösterilmektedir. Ekstradan yapılmış olan işçilik ücretini ekle butonuna tıklanarak toplam tutara eklenebilmektedir. 
Onayla butonuna tıklanması durumunda Arıza işlem ekranındaki tutar texbox’ına aktarılmaktadır. Vazgeç butonuna tıklanmasında ise herhangi bir tutar Arıza işlem ekranındaki tutar texbox’ına aktarılmaz

# Hesap Makinesi Ekranı
Birinci ve ikinci sayılar girilerek yapılmasını istenen işlemi belirtip hesapla butonun tıklanmasıyla sonuç Texbox’ına aktarılması.
Ekle butonuna tıklanması durumunda sonuçtaki sayının birinci sayı kabul edip ikinci sayıyı girerek eklenmesini sürdürür. 

# Yönetici Sayfası Ekranı
Beş buton işlemlerinden oluşturulmuş olup bunlar; Personel işlemleri, Gelir, Marka/Tür işlemleri, Personel Anasayfası, Çıkış butonlarının tıklanması durumunda ilgili ekranlara aktarılması.

# Marka/Tür İşlemleri Ekranı
Marka/Tür ad bilgisi ile kaydetme, silme, düzenleme işlemleri yapılabilmektedir. Arama kısmı ile listeden kolaylıkla istenen bilginin ulaşılabilmektedir.
DataGridView’de veritabanında var olan Marka/Tür‘lerin listesi gösterilmektedir.

# Gelir Ekranı
Arızası Bitmiş olan arızların tutarların toplamının gösterilmesi.

# Personel İşlemleri Ekranı
Personelin ad, soyadı, E-posta, şifre bilgilerinin kaydetme, silme, güncelleme işlemleri yapılabilmektedir. Arama kısmı ile listeden kolaylıkla kişinin bilgilerini ulaşılabilmektedir. DataGridView’de 
Var olan personellerin listesi gösterilmektedir.

Temizle butonuna tıklanması durumunda ise Texbox’ların içlerinin silinmesini sağlar.
