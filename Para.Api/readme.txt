create migration SQL Server
     dotnet ef migrations add CustomerDetail -s ../Para.Api/ --context ParaDbContext
create migration PostgreSQL Server
     dotnet ef migrations add InitialCreate -s ../Para.Api/ --context ParaDbContext    
  
db guncelleme SQL 
     dotnet ef database update --project "./Para.Data" --startup-project "Para.Api/" --context ParaDbContext
db guncelleme Postgre
     dotnet ef database update --project "./Para.Data" --startup-project "Para.Api/" --context ParaDbContext

 # Para API

## Proje A��klamas�

Bu proje, .NET 8 kullan�larak geli�tirilmi� bir API uygulamas�d�r. CQRS (Command Query Responsibility Segregation) mimarisi ve MediatR k�t�phanesi kullan�larak, CRUD (Create, Read, Update, Delete) i�lemleri ve sorgular (queries) i�in command ve query handler'lar olu�turulmu�tur. Proje, m��teri, m��teri adresi, m��teri telefonu ve m��teri detaylar� gibi domainleri y�netmek amac�yla tasarlanm��t�r.

## Proje Yap�s�

- **Domain Modelleri:** `Customer`, `CustomerAddress`, `CustomerPhone`, `CustomerDetail`
- **CQRS Command ve Query Handler'lar:** Command ve Query i�lemlerini y�netir.
- **Generic Repository:** Temel CRUD i�lemlerini sa�lar.
- **AutoMapper:** Domain modelleri ile DTO'lar aras�nda d�n���m yapar.
- **MediatR:** CQRS ve Mediator desenlerini uygular.
- **API Controller'lar:** CRUD i�lemleri ve veri sorgular� i�in API u� noktalar�n� sa�lar.

## Kurulum

1. **Proje Dosyalar�n� �ndirin:**

   ```bash
   git clone https://github.com/<kullan�c�_ad�>/<repo_ad�>.git
   cd <repo_ad�>
