# Asp.Net Core Web API N-Tier

.NET Core N-Tier architecture Web Api sample project.

## Give a Star ⭐️

If this repository helped you please consider giving a star! Thanks!

## Setup

- SQLite has been used as database
- You can change connection string from *appsettings.json* within *aspnetcore.ntier.API*
- Apply database migrations to create the tables. From a command line :

Go into aspnetcore.ntier.DAL class library. Please make sure proper versions of [.NET SDK](https://automapper.org/) and [dotnet-ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) tool has been installed
```
cd aspnetcore.ntier.DAL
```
Apply database changes.
If you are using SQLite then database file with .db extension should be created inside aspnetcore.ntier.API project
```
dotnet ef --startup-project ../aspnetcore.ntier.API database update --context AspNetCoreNTierDbContext
```
## Authentication

- Authentication has been added for version 2 endpoints.
- Non auth endpoints require JWT token to be provided otherwise 401 response will be returned
- So you have to login or register first in order to get the JWT token then add it to the header while sending a request. It can be done by:
  - Clicking lock icon next to the particular endpoint and pasting token in the textbox on swagger page
  - Adding token for the ```Authorization``` header of the request
- You can disable authentication for endpoints by removing ```Authorize``` attribute from the particular controller

## Versioning

- URL versioning has been implemented and currently there are 2 versions.
- Versions can be changed via Swagger page or by providing version number in the URL.

## Logging

- Structured logging using [Serilog](https://serilog.net/) has been implemented.
- Currently logs are being added to file and console. 
- You can change or find the settings in *appsettings.json*.
- In *UserService* there examples of formatting the log message or using different levels of logging
- Logging will be improved over time.

## Layers

- aspnetcore.ntier.API - Presentation Layer is type of *.Net Core Web API project*.
- aspnetcore.ntier.BLL - Business Logic Layer responsible for data exchange between DAL and Presentation Layer.
  - It has Services, AutoMapperProfiles and CustomExceptions in it
- aspnetcore.ntier.DAL - Data Access Layer responsible for interacting database. *Generic repositories* have been used.
  - Database context, repositories and database entity models are located in this class lib
- aspnetcore.ntier.DTO - Data transfer objects are added here
- aspnetcore.ntier.Test - Unit and Integration tests are created here

## Development process

You can follow the steps during development from the [commit list](https://github.com/aghayeffemin/aspnetcore.ntier/commits/master).

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Support

If you found this project useful or interesting and would like to support my work you can support me. Thanks!

<a href="https://www.buymeacoffee.com/aghayeffemin" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" width="200"></a>

#Proje Mimarisi

Asp.Net Core Web API N-Tier

## Setup

- SQLite has been used as database
- You can change connection string from *appsettings.json* within *aspnetcore.ntier.API*
- Apply database migrations to create the tables. From a command line :

Go into aspnetcore.ntier.DAL class library. Please make sure proper versions of [.NET SDK](https://automapper.org/) and [dotnet-ef](https://learn.microsoft.com/en-us/ef/core/cli/
dotnet) tool has been installed

cd aspnetcore.ntier.DAL

Apply database changes.
If you are using SQLite then database file with .db extension should be created inside aspnetcore.ntier.API project

dotnet ef --startup-project ../aspnetcore.ntier.API database update --context AspNetCoreNTierDbContext

## Authentication

- Authentication has been added for version 2 endpoints.
- Non auth endpoints require JWT token to be provided otherwise 401 response will be returned
- So you have to login or register first in order to get the JWT token then add it to the header while sending a request. It can be done by:
  - Clicking lock icon next to the particular endpoint and pasting token in the textbox on swagger page
  - Adding token for the ```Authorization``` header of the request
- You can disable authentication for endpoints by removing ```Authorize``` attribute from the particular controller

## Versioning

- URL versioning has been implemented and currently there are 2 versions.
- Versions can be changed via Swagger page or by providing version number in the URL.

## Logging

- Structured logging using [Serilog](https://serilog.net/) has been implemented.
- Currently logs are being added to file and console. 
- You can change or find the settings in *appsettings.json*.
- In *UserService* there examples of formatting the log message or using different levels of logging
- Logging will be improved over time.



# Proje Açıklaması 

Bu bir soyağacı programı.

# GENS PROJESİ DOKÜMANTASYONU

## 1. Proje Genel Bakış

Gens, .NET kullanılarak geliştirilmiş, katmanlı mimari yapısına sahip bir soy ağacı ve aile ilişkileri yönetim sistemidir. Kullanıcılar, aile üyelerini sisteme ekleyebilir, aile bağlarını tanımlayabilir ve soy ağaçlarını görüntüleyebilir.

## 2. Mimari Yapı

Proje, aşağıdaki katmanlardan oluşan bir N-Tier (çok katmanlı) mimari kullanmaktadır:

## Layers

- aspnetcore.ntier.API - Presentation Layer is type of *.Net Core Web API project*.
- aspnetcore.ntier.BLL - Business Logic Layer responsible for data exchange between DAL and Presentation Layer.
  - It has Services, AutoMapperProfiles and CustomExceptions in it
- aspnetcore.ntier.DAL - Data Access Layer responsible for interacting database. *Generic repositories* have been used.
  - Database context URL=aspnetcore.ntier.DAL\DataContext\AspNetCoreNTierDbContext.cs, repositories and database entity models are located in this class lib
- aspnetcore.ntier.DTO - Data transfer objects are added here
- aspnetcore.ntier.Test - Unit and Integration tests are created here

## 3. Veri Modeli ve İlişkiler

### 3.1. Temel Varlıklar (Entities)

#### User
- Aile üyelerini temsil eden ana varlık
- Özellikler:
  - Id (int): Benzersiz kişi kimliği
  - Username (string): Kullanıcı adı
  - Name (string): Kişinin adı
  - Surname (string): Kişinin soyadı
  - BirthDate (DateTime): Doğum tarihi
  - Phone (string): Telefon numarası
  - Job (string): Meslek
  - Address (string): Adres
  - Location (string): Konum
  - MaritalStatus (MaritalStatus): Medeni durum (Single, Married, Divorced, Widowed)
  - Gender (Gender): Cinsiyet (Male, Female)
  - UserId (string): Kişiyi ekleyen kullanıcının ID'si
  
- İlişkiler:
  - Mother (User): Anne
  - Father (User): Baba
  - Spouse (User): Eş
  - Children (ICollection<User>): Çocuklar
  - Siblings (ICollection<User>): Kardeşler
  - PaternalUncles (ICollection<User>): Amcalar (baba tarafı)
  - PaternalAunts (ICollection<User>): Halalar (baba tarafı)
  - MaternalUncles (ICollection<User>): Dayılar (anne tarafı)
  - MaternalAunts (ICollection<User>): Teyzeler (anne tarafı)
  - Cousins (ICollection<User>): Kuzenler
  - Nephews (ICollection<User>): Yeğenler
  - Grandparents (ICollection<User>): Dede veya dede anne veya baba tarafından
  - Grandchildren (ICollection<User>): Torunlar


#### UserRole
- Admin: Sistem yöneticisi
- User: Normal kullanıcı
- Guest: Misafir kullanıcı
#### Gender
- Male (0): Erkek
- Female (1): Kadın

#### MaritalStatus
- Single: Bekar
- Married: Evli
- Divorced: Boşanmış
- Widowed: Dul

## 4. Veritabanı İlişkileri

### 4.1. Temel İlişkiler

- **Kullanıcı-Kişi İlişkisi**: Bir kullanıcı birden çok aile üyesi ekleyebilir (1-n ilişkisi).
- **Anne-Çocuk İlişkisi**: Bir kişinin bir annesi olabilir, bir anne birden çok çocuğa sahip olabilir (1-n ilişkisi).
- **Baba-Çocuk İlişkisi**: Bir kişinin bir babası olabilir, bir baba birden çok çocuğa sahip olabilir (1-n ilişkisi).
- **Eş İlişkisi**: Bir kişinin bir eşi olabilir (1-1 ilişkisi).
- **Kardeş İlişkisi**: Bir kişinin birden çok kardeşi olabilir (n-n ilişkisi).
- **Amca/Hala/Dayı/Teyze İlişkisi**: Bir kişinin birden çok amcası, halası, dayısı veya teyzesi olabilir (n-n ilişkisi).
- **Kuzen İlişkisi**: Bir kişinin birden çok kuzeni olabilir (n-n ilişkisi).

### 4.2. Veritabanı Tabloları

- **User**: Kişi bilgilerini saklar
- **UserPaternalUncle**: Kişi-amca ilişkilerini saklar (n-n ilişki tablosu)
- **UserPaternalAunt**: Kişi-hala ilişkilerini saklar (n-n ilişki tablosu)
- **UserMaternalUncle**: Kişi-dayı ilişkilerini saklar (n-n ilişki tablosu)
- **UserMaternalAunt**: Kişi-teyze ilişkilerini saklar (n-n ilişki tablosu)
- **UserCousin**: Kişi-kuzen ilişkilerini saklar (n-n ilişki tablosu)
- **UserChild**: Kişi-çocuk ilişkilerini saklar (n-n ilişki tablosu)
- **UserSibling**: Kişi-kardeş ilişkilerini saklar (n-n ilişki tablosu)

## 5. İş Kuralları ve Kısıtlamalar



### 5.1. Kullanıcı Yönetimi

- Kullanıcı kaydı için e-posta adresi, ad, soyad ve şifre zorunludur.
- E-posta adresi benzersiz olmalıdır.
- Şifre en az 8 karakter uzunluğunda olmalıdır.
- Kullanıcı rolleri: Admin, User ve Guest olarak belirlenmiştir.
- Admin kullanıcılar, diğer kullanıcıları yönetebilir (oluşturma, güncelleme, silme).

### 5.2. Kişi ve Aile İlişkileri

- Bir kişinin yalnızca bir annesi ve bir babası olabilir.
- Bir kişinin yalnızca bir eşi olabilir.
- Bir kişi birden fazla çocuğa sahip olabilir.
- Kardeş ilişkileri çift yönlüdür (A, B'nin kardeşiyse, B de A'nın kardeşidir).
- Amca/hala ilişkileri babanın erkek/kız kardeşleridir.
- Dayı/teyze ilişkileri annenin erkek/kız kardeşleridir.
- Kuzen ilişkileri amca, hala, dayı veya teyzelerin çocuklarıdır.

### 5.3. Veri Doğrulama

- Kişi adı ve soyadı en az 2 karakter uzunluğunda olmalıdır.
- Telefon numarası geçerli bir format olmalıdır.
- E-posta adresi geçerli bir format olmalıdır.


## 7. Servis Katmanı

### 7.1. IUserService

Kişi ve aile ilişkileri yönetimi için servis arayüzü:

- **GetByIdAsync**: ID'ye göre kişi getirme
- **GetAllAsync**: Tüm kişileri getirme
- **GetFamilyMembersAsync**: Kullanıcının aile üyelerini getirme
- **CreateAsync**: Yeni kişi oluşturma
- **UpdateAsync**: Kişi bilgilerini güncelleme
- **DeleteAsync**: Kişi silme
- **AddRelationAsync**: Kişiler arası ilişki ekleme
- **RemoveRelationAsync**: Kişiler arası ilişki kaldırma
- **GetFamilyTreeAsync**: Aile ağacını getirme

### 7.2. IUserService

Kullanıcı yönetimi için servis arayüzü:

- **RegisterAsync**: Kullanıcı kaydı
- **LoginAsync**: Kullanıcı girişi
- **ExternalLoginAsync**: Harici kimlik doğrulama ile giriş
- **ChangePasswordAsync**: Şifre değiştirme
- **GetUserProfileAsync**: Kullanıcı profili getirme
- **UpdateUserProfileAsync**: Kullanıcı profili güncelleme
- **GetAllUsersAsync**: Tüm kullanıcıları getirme
- **DeleteUserAsync**: Kullanıcı silme
- **CreateUserAsync**: Yeni kullanıcı oluşturma
- **UpdateUserAsync**: Kullanıcı bilgilerini güncelleme
- **UpdateUserRoleAsync**: Kullanıcı rolünü güncelleme

## 8. DTO'lar (Data Transfer Objects)

### 8.1. Kullanıcı DTO'ları

- **RegisterDto**: Kullanıcı kaydı için veri transfer nesnesi
- **LoginDto**: Kullanıcı girişi için veri transfer nesnesi
- **ExternalLoginDto**: Harici kimlik doğrulama için veri transfer nesnesi
- **ChangePasswordDto**: Şifre değiştirme için veri transfer nesnesi
- **UserDto**: Kullanıcı bilgileri için veri transfer nesnesi
- **AdminUserDto**: Yönetici tarafından görüntülenen kullanıcı bilgileri için veri transfer nesnesi
- **CreateUserDto**: Yeni kullanıcı oluşturma için veri transfer nesnesi
- **UpdateUserDto**: Kullanıcı bilgilerini güncelleme için veri transfer nesnesi
- **UpdateRoleDto**: Kullanıcı rolünü güncelleme için veri transfer nesnesi

### 8.2. Kişi ve Aile DTO'ları

- **UserDto**: Kişi bilgileri için veri transfer nesnesi
- **UserBasicDto**: Temel kişi bilgileri için veri transfer nesnesi
- **FamilyTreeDto**: Aile ağacı için veri transfer nesnesi
- **SiblingFamilyDto**: Kardeşlerin eşleri ve çocukları için veri transfer nesnesi
- **RelationRequestDto**: Kişiler arası ilişki ekleme için veri transfer nesnesi

## 9. Özet

Gens projesi, kullanıcıların aile üyelerini ve aralarındaki ilişkileri yönetebilecekleri, soy ağaçlarını görüntüleyebilecekleri bir sistem sunmaktadır. .NET 8 ve katmanlı mimari kullanılarak geliştirilen proje, kullanıcı yönetimi, kişi yönetimi ve aile ilişkileri yönetimi gibi temel işlevleri içermektedir. Sistem, anne-baba-çocuk ilişkilerinin yanı sıra, amca, hala, dayı, teyze ve kuzen gibi geniş aile ilişkilerini de desteklemektedir.





# Web Uygulama Geliştirici Kılavuzu

NextJS, NodeJS, TailwindCSS, JavaScript ve CSS konularında uzman bir Kıdemli Geliştiricisin. Düşünceli, detaylı ve doğru yanıtlar veriyorsun. Kod yazarkenden iyi uygulamaları (best practices), DRY (Don't Repeat Yourself) prensibini vehatasız çalışma esasını dikkate alıyorsun.

## Performans

- NextJS uygulamasında sunucu tarafı render (SSR) ve gerekirse statik oluşturma (SSG) yöntemlerini kullanarak ilk yüklemeyi hızlandır
- Gereksiz kod parçalarını (unused imports, büyük kütüphaneler) dinamik import yöntemiyle böl ve sadece ihtiyaç halinde yükle
- NodeJS tarafında asenkron işlemleri (Promise.all, async/await) tercih ederekverimli I/O operasyonları sağla

## Optimizasyon

- TailwindCSS'de mümkün olduğunca JIT (Just-In-Time) özelliğini kullanarak CSS dosya boyutunu düşük tut
- Kod tekrarlarını (duplicate logic) ortadan kaldır; proje genelinde ortak fonksiyonlar veya bileşenler oluştur
- Basit bir NodeJS backend gerekiyorsa, server.js içinde erken dönüş (early return) ve minimal middleware kullanarak performanslı bir yapı kur

## UI/UX

- TailwindCSS sınıflarıyla özel "cursor" tanımları yap (cursor-pointer, cursor-wait, vb.) ve kullanıcının fareyi farklı alanlara getirdiğinde değişen efektler ekle
- Hover ve focus durumlarında görsel olarak farklı "cursor" stillerini veya animasyonlarını devreye sok (örneğin transition-all, duration-150)
- Erişilebilirlik için her interaktif öğeye tabIndex="0", aria-label vb. ekleyerek klavye navigasyonuna uygun hale getir

## Kod Uygulama Kuralları

- HTML yapısında her zaman Tailwind sınıflarını kullan; klasik CSS yazmayı veya "style" etiketini minimuma indir
- Üçlü operatör yerine "class:" kullanımını tercih et
- Etkinlik fonksiyonları (onClick, onKeyDown) "handle" ile başlasın (örneğin handleClick, handleKeyDown)
- Fonksiyon yerine "const" kullan (örn. const handleToggle = () => {}), gerekli ise tip tanımla (TypeScript kullanmıyorsan, tipleri es geçebilirsin)
- Hatasız, eksiksiz ve çalışır kod yaz; hiçbir yerde "todo" veya boş fonksiyon kalmasın

## Güvenlik

- XSS ve CSRF gibi yaygın güvenlik açıklarına karşı next/headers ve next/csrf kullanımı
- API rotalarında input validasyonu ve sanitizasyonu
- Çevresel değişkenler (environment variables) için güvenli yönetim

## State Management

- React Context API veya Zustand gibi hafif state yönetim çözümleri
- Server state için React Query veya SWR kullanımı
- Local storage ve session storage kullanım prensipleri

## Code Organization

- Feature-based veya atomic design folder yapısı
- Reusable hooks ve utilities için ayrı klasörler
- Constants ve type tanımları için merkezi yönetim

## Build ve Deployment

- Development ve production ortamları için farklı konfigürasyonlar
- Docker containerization kuralları
- CI/CD pipeline best practices




Proje Geliştirme Önerileri
1. Veritabanı İlişki Yapılandırması
Projenin en belirgin sorunu, self-referencing ilişkilerin yapılandırılmasında görünüyor. Hata mesajında belirtildiği gibi:
> Unable to determine the relationship represented by navigation 'User.Father' of type 'User'
Bu sorunu çözmek için DbContext sınıfındaki OnModelCreating metodunda tüm ilişkileri Fluent API kullanarak açıkça tanımlamak gerekiyor. Bu, projede öncelikli olarak çözülmesi gereken bir sorun.
2. Veri Doğrulama Geliştirmeleri
Validation kütüphaneleri (FluentValidation gibi) ile kapsamlı doğrulama kuralları eklenebilir
Özellikle kompleks ilişkilerde (örneğin kişinin kendisi kendi ebeveyni olamaz gibi mantıksal kurallar) business logic validasyonu yapılabilir
3. Performans İyileştirmeleri
İlişki sorgularında Include veya projection kullanımı optimize edilebilir
Karmaşık soy ağacı sorgularında lazy loading yerine eager loading yaklaşımı düşünülebilir
Geniş aile ağaçları için sayfalama (pagination) implementasyonu eklenebilir
4. API Geliştirmeleri
GraphQL desteği eklenebilir (özellikle karmaşık ilişki sorgularında faydalı olabilir)
Rate limiting ve güvenlik önlemleri güçlendirilebilir
API dokümantasyonu geliştirilebilir (Swagger açıklamaları, örnek kullanımlar)
5. Kullanıcı Deneyimi İyileştirmeleri
Aile ağacı görselleştirme API'leri eklenebilir
İlişki tanımlama işlemleri için daha kullanıcı dostu yöntemler
Toplu veri içe/dışa aktarma özellikleri (GEDCOM formatı gibi jeneoloji standartları)

6. Ek Özellikler
Aile olayları takibi (doğumlar, evlilikler, ölümler, vb.)
Tarihsel veriler ve soy ağacı zaman çizelgesi
Fotoğraf ve belge depolama
Jeolokasyon entegrasyonu (aile üyelerinin yaşadığı yerler)
Hatırlatıcılar ve önemli günler (doğum günleri, yıldönümleri)
DNA testi entegrasyonu
Öncelikli Yapılması Gerekenler
Entity İlişkilerini Düzeltme: İlk olarak, veritabanı ilişki yapılandırma sorunu çözülmelidir.
Validasyon Kurallarını Netleştirme: İş mantığı kurallarının kapsamlı şekilde uygulanması
Test Kapsamını Genişletme: Temel işlevlerin güvenilirliğini sağlamak için testlerin zenginleştirilmesi
Dokümantasyonu Geliştirme: API kullanımı ve sistem mimarisi hakkında daha detaylı dokümantasyon