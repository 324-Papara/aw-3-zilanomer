create migration SQL Server
     dotnet ef migrations add CustomerDetail -s ../Para.Api/ --context ParaDbContext
create migration PostgreSQL Server
     dotnet ef migrations add InitialCreate -s ../Para.Api/ --context ParaDbContext    
  
db guncelleme SQL 
     dotnet ef database update --project "./Para.Data" --startup-project "Para.Api/" --context ParaDbContext
db guncelleme Postgre
     dotnet ef database update --project "./Para.Data" --startup-project "Para.Api/" --context ParaDbContext

 # Para API

## Proje Açýklamasý

Bu proje, .NET 8 kullanýlarak geliþtirilmiþ bir API uygulamasýdýr. CQRS (Command Query Responsibility Segregation) mimarisi ve MediatR kütüphanesi kullanýlarak, CRUD (Create, Read, Update, Delete) iþlemleri ve sorgular (queries) için command ve query handler'lar oluþturulmuþtur. Proje, müþteri, müþteri adresi, müþteri telefonu ve müþteri detaylarý gibi domainleri yönetmek amacýyla tasarlanmýþtýr.

## Proje Yapýsý

- **Domain Modelleri:** `Customer`, `CustomerAddress`, `CustomerPhone`, `CustomerDetail`
- **CQRS Command ve Query Handler'lar:** Command ve Query iþlemlerini yönetir.
- **Generic Repository:** Temel CRUD iþlemlerini saðlar.
- **AutoMapper:** Domain modelleri ile DTO'lar arasýnda dönüþüm yapar.
- **MediatR:** CQRS ve Mediator desenlerini uygular.
- **API Controller'lar:** CRUD iþlemleri ve veri sorgularý için API uç noktalarýný saðlar.

## Kurulum

1. **Proje Dosyalarýný Ýndirin:**

   ```bash
   git clone https://github.com/<kullanýcý_adý>/<repo_adý>.git
   cd <repo_adý>
