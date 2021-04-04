# Asp.Net-Mvc5-Online-Commercial-Automation
## Online Commercial Automation

 Bu proje **Asp.Net Mvc5** ile geliştirilmiştir. Projede **Html5**, **Css3**, **Js**, **Bootstrap**, **Entity Framework** gibi teknolojilerde kullanılmıştır. Projede kullanılan eklentilerinden bazıları şunlardır: **DataTables**, **Google Chart**. Proje **Entity Framework Code First** yöntemi ile geliştirilmiştir. Ayrıca projede Linq sorguları üzerinden **Trigger**, **Procedure** gibi SQL yapıları kullanılmıştır. Veritabanı olarak MsSql kullanımıştır. Proje kurulumu ve detaylı bilgi aşağıda verilmiştir.
 
  Proje içeriğine gelecek olursak projede
  
  - Front End
  - User Panel
  - Admin Panel   olmak üzere 3 kısımdan oluşmaktadır.
  
 ## Front End
 
 ![ezgif-4-423edb4dd2f0](https://user-images.githubusercontent.com/65186980/113509359-cd12f180-955d-11eb-8197-8a1cce5144dc.gif)

Front End kısmında bulunan sayfalar şu şekildedir.

1. Home
2. Products
3. About Us
4. Help
5. Login
6. Register

Bu kısmın amacı ürünlerimizi sergileyebileceğimiz bir vitrin olmasıdır.

1. Home

 Proje açıldığında kullanıcının ilk görülen sayfa. Bu sayfada bir arama çubuğu bulunuyor buradan ürün arayabiliriz. Onun altında  bir slider bulunuyor. Bu slider Admin Panel'den değiştirlebilir, güncellenebilir ve silinebilir. Sliderın altında yeni gelen ürünler var burasıda Admin Panel'den değiştirilebilir. Ondan sonra kategoriler yer alıyor burasıda dinamik bir şekide Admin Panel'den güncellenebilir. En son olarak en çok satanlar kısmı var bu kısımda diğerleri gibi Admin Panel'den değiştirilebiliyor.

2. Products

 Ürünler sayfasında sol tarafta kategoriler var ve burasıda tamamen dinamik olarak çalışıyor. Sonra ürünlerin listesi bulunuyor. Buradan ürünlerin detaylarına gidebilir ve bilgilerini görebiliriz. Ürün sayfalarında **Paging** bulunmaktadır.

3. About Us

 Hakkımızda kısmında bir hakkımızda yazısı ve iletişim bilgileri yer almaktadır.

4. Help

 Bu kısımda iletişim bilgileri bir **Google Map** ve iletişim paneli bulunmaktadır. İletişim paneliyle istek ve şikayetlerini bildirebiliyoruz.

5. Login

 Login kısmında klasik bir şekide kayıt olduktan sonra giriş yapabiliyoruz.

6. Register

 Register bölümünde bilgilerimizi girerek kayıt olabiliyoruz.

## User Panel

![ezgif-4-a6ca6acea1d3](https://user-images.githubusercontent.com/65186980/113509842-5cb99f80-9560-11eb-82a4-d4208bcae329.gif)

Front End kısmında bulunan sayfalar şu şekildedir.

1. My Profile
2. My Orders
3. Cargo Tracking
4. Messages

 Buradaki layout ve kısımlar tema kullanılmadan bootstrap ile yapılmıştır.

1. My Profile

 Burada resimlerde de görebileceğiniz gibi sol kısımda kullanıcı bilgileri ve harcamalarına ait bilgiler vardır. Sağ tarafata ise Mesajlar, Zaman Tüneli ve Ayarlar kısımları vardır.  Mesajlar kısmında gelen mesajlar listelenmektediç. Zaman Tünelinde yapılan duyurular ve son olarak Ayarlar kısmında kullanıcı bilgilerini güncelleyebileceğiniz bir alan bulunmaktadır.
 
2. My Orders

 Siparişlerimde daha önce yaptığım siparişlerin bilgileri yer almaktadır.
 
3. Cargo Tracking

 Kargo takibi kısmında size gönderilen takip kodunu girerek kargo bilgilerinizi görebilirsiniz.

4. Messages

 User Panel'in en güzel kısmı diyebilirim. Mesajlar kısmından aynı *Gmail* gibi bir mesajlaşma kısmı var. Burada yeni mesaj yazabilir, gelen mesajları görebilir, mesajları yıldızlayarak saklayabilir. Yada bu kısımlardan soft delete yapıp Trash kısmına atabilirsiniz. Trash kısmından ise tamamen silebilir veya çöp kutusundan geri çıkarabilirsiniz.
 
## Admin Panel

![ezgif-2-4a9a1561ec0f](https://user-images.githubusercontent.com/65186980/113511881-c048ca80-956a-11eb-970a-d6304412faef.gif)

Admin Panel'de şu sayfalar vardır

1. Dashboard
2. Categories
3. Products
4. Staff
5. Departments
6. Customer
7. Admins
8. Help Messages
9. Announcement
10. Invoce
11. Sales
12. Graphics
13. Statistics
14. Simple Tables
15. Cargo
16. QR

Admin Panel'ine girmek için arama çubuğuna /admin yazıp, username ve password ile giriş yapabilirsiniz.

1. Dashboard

 Admin Dashboard'da 4 adet istatistik. Home sayfasındaki alanları güncellmek için alan ve son ve en önemlisi bir **To Do List**. To Do List kısmında klasik bir To Do List gibi
yeni To Do'lar ekleyebilir, güncelleyebilir ve yaptıklarınızı silebilirsiniz.
 
2. Categories

  Kategoriler sayfasında yeni kategoriler ekleyebilir, güncelleyebilir ve silebilirsiniz. Bu yaptığınız değişiklikler ana sayfada görünecektir. Buradaki tabloda ve gelecek tabloların genelinde **DataTables** eklentisi kullanılmıştır.
  
3. Products

 Product kısmı ikiye ayrılıyor. Birincisi ürün ekleme, silme (Soft Delete), güncelleme ve son olarak buradan bir staış girebilirsiniz. İkinci kısım ise Product gallery. Burada da ürün resimlerin bir galerisi bulunmaktadır.
 
4. Staff

 Staff kısmıda iki bölümden oluşmaktadır. Birinci kısımda elamanları ekleyebilir, güncelleyebilirsiniz ve elamanların yaptığı satışarı görüntülüyebilirsiniz. İkinci kısımda da neredeyse aynı şeyler bulunuyor ama kullanıcı bilgileri kartlar aracılığıyla listeleniyor.

5. Departments

 Bu kısımda yeni departman ekleyebilir, güncelleyebilir, ve silebilirsiniz (Soft Delete). Ayrıca hangi departmanda kim çalışıyor görüntülemeniz mümkün.
 
6. Customer

 Burada müşteri bilgilerini görebilirisini ve kullanıcıların yapmış olduğu alışveriş detaylarını bakabilirsiniz.
 
7. Admins

 Admin kısmında yeni admin ekleyebilir admin yetkisini değiştirebilir ve admimi pasif hale getirebilirsiniz. Admin kısmında 2 yetki vardır 'Super Admni' ve 'Admin'. Super Admin'in Admin'den farkı admin yetkilerini kontrol edebilmektir.
 
8. Help Messages

 Front End kısmından yapılan yardım mesajlarını görebilir, cevaplayabilir ve mesajları silebilirsiniz.
 
9. Announcement

 Duyurular kısmından yeni duyuru yayınlayabilir, duyuruyu güncelleyebilir ve silebilirsiniz.
 
10. Invoice

 Bu kısım iki bölümden oluşmaktadır. İlk kısım yeni fatura ekleyebilirsiniz. Yeni fatura ekleme işlemi **Popup** ile açılmaktadır. Bu kısım **Js** kodları ile yazılmıştır. İkinci kısımda ise faturaları çıkarabilir veya Excel, CSV, PDF şeklinde indirebilir veya çıkarabilirsiniz. Burada istediğiniz satırları çıkarıp ekleyebilirsiniz.
 
11. Sales 

 Satışlar kısmından yapılan satışları görebilirsiniz ve güncelleyebilirsiniz.
 
12. Graphics

 Bu kısımda üç adet grafik vardır. 1- Pie Chart 2- Line Chart 3- Column Chart. Bu kısımda **Google Chart** kullanılmıştır.
 
13. Simple Tables

 Tablolar sayfasında bir çok tablo mevcuttur. Bu tablolar şu şekildedir: Ürünler ve adetleri, kullanıcılar ve şehirleri, markalar ve adetleri, departmanlar ve departmanda çalışan kişi sayısı, kullanıcı detayları, ürün detayları olmak üzere 6 adet tablo vardır.

14. Cargo

 Bu sayfada kargoları ve açıklamalırını görüntüleyebilir ve yeni kargo girebilirsiniz. Ayrıca kargo'daki gelişmeleride buradan girebilirsiniz.
 
15. QR 

 QR alanından QR Code oluşturabilirsiniz.
 
## Kurulum

 Bu bölümde nasıl kurulum yapabileceğinizi anlatıcam. İlk olarak projeyi clone alıyoruz. Ardından  Database'i kurmamız gerekiyor. Database için dosyların içinde bulunan script (script.sql) dosyasını kullanarak kurabilirsiniz veya Back Up (CommercialAutomation.bak) alınmış yedeği kullanarak kurabilirsiniz.
 
 *Front End kısmı template w3layout'tan, Admin Panel template adminlte'den alınmıştır.*
 
 Herhangi bir öneri veya şikayetiniz için Mail: erkilicbedirhan@gmail.com
 
