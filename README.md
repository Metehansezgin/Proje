# Proje
Projenin Çalıştırılması için yapılması gereken.<br>
1)MSSQL bir veri tabanı oluşturulur.<br>
2)Oluşturulan veri tabanını ConnectionString'i Proje.DataAccess/Concrete/EntityFramework/Context.cs dosyasının içindeki optionsBuilder.UseSqlServer(@""); kısmına "" içine yapıştırılır.<br>
3)PM consoluna update-migration yazıp çalıştırılarak veri tabanına gerekli tablolar olusturulur.<br>
4)Proje run edilir.<br>
