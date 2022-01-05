<h4>Projeyi çalıştırmadan önce bilgisayarınızda veya sunucunuzda RabbitMQ kurulumu yapmanız gerekiyor.  </h2>

<h5>RabbitMQ kurulum dosyalarını aşağıdaki linkden bulabilirsiniz.</h5>
https://www.rabbitmq.com/download.html
</br>
<h5>Kurulum tamamlandıktan sonra RabbitMQ ayarları için;</br></h5>
1-> ReportRequestBGService/Worker.cs </br>
2-> ReportAPI.BusinessLayer/RabbitMQService.cs</br>
Yukarıda belirtilen dosyalar açıp Hostname,Username ve Password ayarlarını yapmalısınız.</br>
</br>
<h5>Kurulum işlemini tamamladıktan sonra ContactAPI ve ReportAPI veritabanı ayarlarını aşağıda belirtilen dizinde bulup değiştiriniz;</br></h5>
1-> ContactAPI.DataLayer/DirectoryDbContext.cs</br>
2-> ContactAPI/appsettings.json</br>
3-> ReportAPI.DataLayer/ReportDbContext.cs</br>
4-> ReportAPI/appsettings.json</br>
<h5>Projeyi çalıştırmak için;</h5> Çözüm>Özellikler dedikten sonra birden fazla başlangıç projesi tıklayıp sıralamayı aşağıda belirtilen şekilde yapmanız gerekiyor.</br>
</br>
1-> ContactAPI</br>
2-> ReportAPI</br>
3-> ReportRequestBGService</br>
4-> ApiGateway</br>
</br>
yukarıda belirtilen ayarları yaptıktan sonra projeyi apigetway üzerinde <a href="https://localhost:7055"></a> belirtilen url üzerinde kullanabilirsiniz.
