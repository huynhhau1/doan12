

create table HocSinh(
	IdHS int primary key,
	TenHS nvarchar(50),
	QuequanHS nvarchar(50),
	NgaysinhHS date,
	CmndHS nvarchar(50),
	EmailHS nvarchar(50),
	SdtHS nvarchar(10),
)
insert into HocSinh(IdHS,TenHS,QuequanHS,NgaysinhHS,CmndHS,EmailHS,SdtHS)values(1,'hau','longan','20020601','01243232','hau33@gmail.com','0387730165')
select * from HocSinh