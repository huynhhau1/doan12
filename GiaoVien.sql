

create table GiaoVien(
		IdGV nvarchar(50) primary key,
		TenGV nvarchar(50),
		QuequanGV nvarchar(50),
		NgaysinhGV date,
		CmndGV nvarchar(50),
		EmailGV nvarchar(50),
		SdtGV nvarchar(10)
)
insert into GiaoVien(IdGV,TenGV,QuequanGV,NgaysinhGV,CmndGV,EmailGV,SdtGV)values('GV01','Tran long','long an','19910601','111','long01@gmail.com','0387730162')
select * from GiaoVien