Projeyi çalıştırmadan önce bilgisayarınızda veya sunucunuzda RabbitMQ kurulumu yapmanız gerekiyor.  

RabbitMQ kurulum dosyalarını aşağıdaki linkden bulabilirsiniz.
https://www.rabbitmq.com/download.html

Kurulum tamamlandıktan sonra RabbitMQ ayarları için;
1-> ReportAPI/ReportRequestBGService/Worker.cs 
2-> ReportAPI/CoreLib/ReportAPI.BusinessLayer/RabbitMQService.cs
Yukarıda belirtilen dosyalar açıp Hostname,Username ve Password ayarlarını yapmalısınız.

Kurulum işlemini tamamladıktan sonra ContactAPI ve ReportAPI veritabanı ayarlarını aşağıda belirtilen dizinde bulup değiştiriniz;
1-> ContactAPI/CoreLib/ContactAPI.DataLayer/DirectoryDbContext.cs
2-> ContactAPI/ContactAPI/appsettings.json
3-> ReportAPI/CoreLib/ReportAPI.DataLayer/ReportDbContext.cs
4-> ReportAPI/ReportAPI/appsettings.json



Projeyi çalıştırmak için; Çözüm>Özellikler dedikten sonra birden fazla başlangıç projesi tıklayıp,
Contact API ve ReportAPI yukarı taşıma işlemi yapın ve daha sonra başlat olarak ayarladıktan sonra projeyi başlatabilirsiniz.
