*Proje Master Branch'inde*


**TokenController:**

Login için sorgu ve Token Generate kısmı "/api/Token" çağırımında gerçekleşiyor. Bu endpoint'e yetkisiz çağrı yapılabilir.

**PersonController:**

GetAll, GetById, Post, Put, Delete action methodları tanımlı. 

Person Controller üzerindeki bütün Action'lar session üzerinden alınan AccountId değerine göre filtrelendi.

Filtreleme işlemi için PersonService kısmına 2 yeni method eklendi.(FilterByAccountId ve GetPersonById)

Bu controller üzerindeki hiçbir endpoint yetkisiz çağrıya açık değil.

**AccountController:**

GetAll, GetById, Post, Put, Delete action methodları tanımlı. 

Post isteği sadece "Admin" rolüne sahip kullanıcılara açık.

Bu controller üzerindeki hiçbir endpoint yetkisiz çağrıya açık değil.
