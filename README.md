# 🏨 ASP.NET Core 8.0 ile Booking.com API Entegrasyonu
Bu repository, **M&Y Yazılım Akademi** bünyesinde geliştirdiğim altıncı proje olan **Booking.com API Entegrasyonu** çalışmasını içermektedir.
## 📖 Proje Özeti
Bu projede **ASP.NET Core 8.0 Web Application (MVC)** teknolojisi ve tek katmanlı yapı kullanarak,
RapidAPI üzerinden sağlanan Booking.com API ile entegre çalışan bir **otel arama ve detay görüntüleme** uygulaması geliştirdim.

Veriler, özel hazırlanmış bir otel teması üzerinde anlamlı şekilde sunulmaktadır.

## 🔗 Kullanılan API Endpointleri
🔹 /api/v1/hotels/searchDestination – Destinasyon arama <br>
🔹 /api/v1/hotels/searchHotels – Otel arama <br>
🔹 /api/v1/hotels/getHotelDetails – Otel detay bilgileri <br>
🔹 /api/v1/hotels/getHotelPhotos – Otel fotoğrafları <br>

## 🔍 Uygulama Özellikleri
**Kullanıcılar:** <br>
📅 Seyahat tarihleri ve destinasyona göre otel arayabilir<br>
🏨 Otel detaylarını inceleyebilir<br>
🖼️ Yüksek çözünürlüklü otel fotoğraflarına ulaşabilir<br>

**API’den çekilen veriler:** <br>
🆔 Otel kimliği, adı, adresi, web sitesi <br>
🖼️ Fotoğraflar <br>
📅 Konaklama tarihleri <br>
📍 Konum bilgileri (latitude, longitude, şehir merkezi mesafesi) <br>
⭐ Yorum puanı, yorum sayısı, sınıf bilgisi <br>
🛏️ Oda bilgileri (büyüklük, yatak tipi, uygun oda sayısı) <br>
📝 Açıklama, giriş/çıkış saatleri <br>
🧳 Olanaklar ve konuşulan diller <br>

## 🛠️ Teknik Detaylar
🔹 JSON verileri LINQ yerine foreach döngüleri ile işlendi <br>
🔹 JObject tipinden veri çekimi yapıldı <br>
🔹 Lambda kullanılmadan anlaşılır ve takip edilebilir kod yapısı sağlandı <br>

## 🗂️ Proje Bölümleri
🔹Ana Sayfa – Genel tanıtım ve yönlendirme <br>
🔹Oteller – Arama sonuçlarının listelenmesi <br>
🔹Otel Detayı – Seçilen otelin tüm bilgilerinin gösterimi <br>

## 💻 Kullanılan Teknolojiler
⚙️ ASP.NET Core 8.0 (MVC) – Web uygulama geliştirme <br>
🗂️ Tek Katmanlı Yapı <br>
🚀 RapidAPI – API arayüzü <br>
🔄 HTTPClient – API istekleri <br>
📦 Newtonsoft.Json – JSON parsing <br>
🎨 Bootstrap 5 – Responsive tasarım <br>
🖼️ Carousel / Slider – Fotoğraf gösterimi <br>
🌍 Localization – Konuşulan diller <br>
🛏️ Room Details – Oda bilgileri <br>
💡 HTML5, CSS3, JavaScript <br>

## 📸 Projeden Görseller

<img width="1877" height="913" alt="Image" src="https://github.com/user-attachments/assets/f9d1766d-2b05-40d4-be35-4e9bb0ab5b64" />

<img width="1880" height="707" alt="Image" src="https://github.com/user-attachments/assets/3f653088-1ba5-44f0-929d-a65018fcb0df" />

<img width="1658" height="836" alt="Image" src="https://github.com/user-attachments/assets/d946dddd-54aa-45b7-9ced-c7dc72107f1b" />

<img width="1640" height="697" alt="Image" src="https://github.com/user-attachments/assets/4eeba2d3-a781-4cc3-a441-022257112e5b" />

<img width="1068" height="882" alt="Image" src="https://github.com/user-attachments/assets/7bad8455-6d69-4d52-9ab5-3b795a706e9f" />

<img width="433" height="857" alt="Image" src="https://github.com/user-attachments/assets/1d7e9b63-1f97-40c3-acfc-8905e15aa83d" />

<img width="492" height="901" alt="Image" src="https://github.com/user-attachments/assets/5f773881-dab4-4aa0-aa08-512c59f80828" />

<img width="502" height="773" alt="Image" src="https://github.com/user-attachments/assets/283aada5-ea4b-4b1b-bdb0-fc72e183eb7f" />

<img width="742" height="897" alt="Image" src="https://github.com/user-attachments/assets/b63415b5-2863-4ba6-a876-9fcaa980f05b" />

<img width="483" height="798" alt="Image" src="https://github.com/user-attachments/assets/8b2925d6-f250-4a86-b60f-621bcc71cb93" />

