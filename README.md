# Proje
Projenin Çalıştırılması için yapılması gereken.<br>
1)MSSQL bir veri tabanı oluşturulur.<br>
2)Oluşturulan veri tabanını ConnectionString'i Proje.DataAccess/Concrete/EntityFramework/Context.cs dosyasının içindeki optionsBuilder.UseSqlServer(@""); kısmına "" içine yapıştırılır.<br>
3)PM consoluna update-migration yazıp çalıştırılarak veri tabanına gerekli tablolar olusturulur.<br>
4)Proje run edilir.<br><br><br>

API kullanımı:<br>

GET api/Kisiler/getList                 -->Tüm kişileri getirir.  <br>
GET api/Kisiler/get/{ID}                -->Kişi bilgileri getirir. <br>
GET api/Kisiler/getUserDetial/{id}      -->Kişi detaylı bilgileri getirir.<br>
POST api/Kisiler/add                    -->Kişileri ekler.<br>
DELETE api/Kisiler/delete/{id}          -->Kişileri siler.<br>
PUT api/Kisiler/update                  -->Kişileri günceller.<br><br>

GET api/iletisim/getList                -->Tüm iletişim bilgilerini getirir.<br>
GET api/iletisim/get/{ID}               -->İstenen iletişim bilgilerini getirir.<br>
GET api/iletisim/getUserList/{id}       -->İstenen Kişinin iletişim bilgilerini getirir.<br>
POST api/iletisim/add                   -->İletişim bilgisi ekler.<br>
DELETE api/iletisim/delete/{id}         -->İletişim bilgisi siler.<br>
PUT api/iletisim/update                 -->İletişim bilgisi günceller.<br><br>

GET api/iletisim/rapor_kisi/{veri}      -->İstenen konumdaki kişi sayısı.<br>
GET api/iletisim/rapor_telefon/{veri}   -->İstenen konumdaki teledon sayısı.<br>
GET api/iletisim/rapor_konum_list       -->Tüm Konumdaki bilgileri getirir.<br><br>


Kişi eklemek için kullanılacak json post veri modeli {"ad":"","soyad":"","firma":""}<br>
Kişi güncellemek için kullanılacak json post veri modeli {"uuid":"","ad":"","soyad":"","firma":""}<br><br>
        
İletişim eklemek için kullanılacak json veri modeli {"kid":"","telefon":"","email":"","konum":""}<br>
İletişim güncellemek için kullanılacak json veri modeli {"iid":"","kid":"","telefon":"","email":"","konum":""}<br>
    
      
