# 🎓 LearnerProject Online Eğitim Platformu (Admin - Eğitmen - Öğrenci Panelli)

![C#](https://img.shields.io/badge/Language-C%23-239120)
![ASP.NET](https://img.shields.io/badge/Framework-ASP.NET%20MVC%205-512BD4)
![Database](https://img.shields.io/badge/Database-SQL%20Server-CC2927)
![Status](https://img.shields.io/badge/Status-Completed-success)

Bu proje, ASP.NET MVC 5 mimarisi kullanılarak geliştirilmiş, çoklu kullanıcı rolüne (Admin, Eğitmen, Öğrenci) sahip kapsamlı bir uzaktan eğitim sistemidir.

---

## 📖 Proje Hakkında

Bu sistem, sıradan bir içerik sitesinden farklı olarak **3 farklı yönetim panelini** tek bir çatı altında toplar. Admin, Eğitmen ve Öğrenci rolleri için ayrı giriş (Login) ve oturum (Session) mekanizmaları kurgulanmıştır.

Tüm işlemler veritabanına anlık olarak yansır. Örneğin; Admin'in atadığı bir eğitmen sisteme girip kurs açtığında, öğrenci anında bu kursu panelinde görebilir ve kaydolabilir.

---

## 🚀 Modüller ve Özellikler

### 👨‍🎓 1. Öğrenci Paneli (Student)
* **Kayıt ve Giriş:** "Kayıt Ol" veya "Giriş Yap" seçenekleri. Mevcut hesabı varsa doğrudan yönlendirme.
* **Kişiselleştirme:** Session ile öğrenci ismi ve bilgileri panelde görüntülenir.
* **Kurs Etkileşimi:** * Kursları listeleme ve detaylarını görüntüleme.
  * Kurslara kaydolma.
  * Ders videolarını izleme.
  * Kurslara puan verme ve yorum yapma.

### 👨‍🏫 2. Eğitmen Paneli (Teacher)
* **Kurs Yönetimi:** Kendi kurslarını oluşturma, düzenleme ve silme (CRUD).
* **İçerik Yönetimi:** Kurslara yeni ders videoları ve içerik ekleme.
* **Öğrenci Etkileşimi:** Kurslarına gelen yorumları görüntüleme ve yönetme.
* **Profil:** Eğitmen bilgilerini düzenleme.

### 🛠 3. Admin Paneli (Yönetici)
* **Tam Yetki (God Mode):** Sistemdeki her veriye erişim ve düzenleme yetkisi.
* **Atama İşlemleri:** Kurslara eğitmen atama veya değiştirme.
* **Kullanıcı Yönetimi:** Eğitmen ve öğrenci bilgilerini düzenleme/silme.
* **Genel Yönetim:** Yeni kurs kategorileri oluşturma ve site genel ayarları.

---

## 🛠 Teknik Detaylar ve Kullanılan Teknolojiler

Proje geliştirilirken **SOLID** prensiplerine ve **Katmanlı Mimari** yapısına dikkat edilmiştir.

| Alan | Teknoloji / Yöntem | Açıklama |
| :--- | :--- | :--- |
| **Mimari** | MVC 5 | Model-View-Controller yapısı |
| **Veri Tabanı** | Entity Framework | Code First yaklaşımı |
| **Sorgulama** | LINQ | Veri tabanı sorgu işlemleri |
| **Güvenlik** | Authorize & Session | Rol bazlı yetkilendirme ve oturum yönetimi |
| **Sayfalama** | PagedList | Verilerin sayfalara bölünerek listelenmesi |
| **UI** | PartialView | Tekrar eden yapıların modüler kullanımı |
| **Frontend** | HTML5, CSS3, Bootstrap | Responsive tasarım |

---

## 👏 Teşekkür
Bu projenin geliştirilmesindeki katkıları ve rehberliği için **Murat Yücedağ** ve **Erhan Gündüz** hocama teşekkür ederim.

---

## 📺 Proje Tanıtım Videosu

https://github.com/user-attachments/assets/f08ad7bb-715c-4e76-a9dd-03e65600d867


*Projenin tüm fonksiyonlarını ve paneller arası geçişleri yukarıdaki videodan izleyebilirsiniz.*

---
