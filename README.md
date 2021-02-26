# Proje
Projenin Çalıştırılması için yapılması gereken.
1)MSSQL bir veri tabanı oluşturulur.
2)Oluşturulan veri tabanını ConnectionString'i Proje.DataAccess/Concrete/EntityFramework/Context.cs dosyasının içindeki optionsBuilder.UseSqlServer(@""); kısmına "" içine yapıştırılır.
3)PM consoluna update-migration yazıp çalıştırılarak veri tabanına gerekli tablolar olusturulur.
4)Proje run edilir.
