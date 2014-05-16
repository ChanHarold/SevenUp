create table Log
(
[ID]    int identity(0,1) primary key,
[Date]  datetime,
[Thread]  varchar(50),
[Level] varchar(50),
[Logger]    varchar(255),
[Message]   varchar(4000),
[Exception] varchar(4000)
)
go