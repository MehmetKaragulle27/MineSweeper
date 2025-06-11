🧨 Mayın Tarlası (Minesweeper) Oyunu
Bu proje, Fırat Üniversitesi Bilgisayar Mühendisliği Nesne Tabanlı Programlama (OOP) dersi kapsamında C# Windows Forms kullanılarak geliştirilmiş bir konsol dışı Mayın Tarlası oyunudur. Kullanıcının mayınlara basmadan tüm güvenli hücreleri açması hedeflenmiştir.

🎯 Amaç
Kullanıcının, rastgele yerleştirilmiş mayınlara basmadan güvenli hücreleri açmasını sağlamak

Nesne yönelimli programlama ilkelerini uygulayarak temiz, genişletilebilir bir yapı kurmak

Farklı zorluk seviyelerine göre esnek bir oyun altyapısı geliştirmek

🧠 OOP (Nesne Tabanlı Programlama) Kavramları
Kavram	Açıklama
Sınıflar ve Nesneler	Tahta, Hucre, KolaySeviye, OrtaSeviye, ZorSeviye gibi sınıflar oluşturulmuştur.
Kapsülleme (Encapsulation)	Hucre sınıfında açılma durumu, bayrak bilgisi ve mayın kontrolü gibi değişkenlere doğrudan erişim yerine metodlarla işlem yapılır.
Polimorfizm	IOyunSeviyesi arayüzü sayesinde farklı zorluk seviyeleri (Kolay, Orta, Zor) tek bir yapı üzerinden yönetilir.
Arayüz (Interface)	IOyunSeviyesi arayüzü, zorluk seviyelerine ait ortak özellikleri tanımlar (Satir, Sutun, MayinSayisi).

🧩 Modüller
Modül	Açıklama
Oyun Alanı Oluşturma	Seçilen zorluk seviyesine göre satır, sütun ve mayın sayısına sahip butonlardan oluşan bir tahta hazırlanır.
Mayın Yerleştirme	Oyun başladığında rastgele hücrelere mayın yerleştirilir.
Kullanıcı Etkileşimi	Sol tık ile hücre açma, sağ tık ile bayrak bırakma veya kaldırma işlemleri gerçekleştirilir.
Kazanma / Kaybetme Kontrolü	Oyuncu ya tüm güvenli hücreleri açar ve kazanır ya da mayına basarsa oyun sona erer.
Zorluk Seviyeleri	Kolay, Orta, Zor seviyeleri için ayrı sınıflar oluşturulmuştur; bu sınıflar IOyunSeviyesi arayüzünü uygular.

Mehmet Karagülle 
