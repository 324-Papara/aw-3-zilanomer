[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/NKa989in)

## Proje Özeti

Bu proje, .NET tabanlı bir uygulama olup, katmanlı mimari, CQRS, FluentValidation ve Bağımlılık Enjeksiyonu gibi modern yazılım desenlerini içermektedir. Aşağıda proje ile ilgili ana özellikler ve bileşenler özetlenmiştir:

### Özellikler

- **Kontroller:** Tüm domain modelleri için eksiksiz CRUD kontrolleri hazırlanmıştır. Her kontrol:
  - `GET` – Listeleme işlemi.
  - `GETBYID` – Belirli bir öğeyi ID'ye göre getirme.
  - `POST` – Yeni bir öğe oluşturma.
  - `PUT` – Mevcut bir öğeyi güncelleme.
  - `DELETE` – Bir öğeyi silme.

- **CQRS:** Her kontrol için Command ve Query handler sınıfları oluşturulmuştur, bu sayede iş mantığı ve veri erişimi ayrılmıştır.

- **FluentValidation:** Tüm modeller için doğrulama sınıfları hazırlanarak veri bütünlüğü sağlanmıştır.

- **Bağımlılık Enjeksiyonu:** Autofac kullanılarak bağımlılık yönetimi yapılmış ve modülerlik artırılmıştır.

- **Middleware Logger:** Tüm istek ve yanıtları loglayan özel bir middleware sınıfı tasarlanmıştır. Bu, uygulama etkileşimlerini takip etmeyi ve sorunları çözmeyi kolaylaştırır.

- **Dapper Rapor Metodu:** `Customer` ve alt modellerini kullanan, yalnızca okuma işlemi yapan bir rapor metodu Dapper kullanılarak geliştirilmiştir.



