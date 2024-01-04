use Batch7
CREATE TABLE [TestDetails]
(
    [Id] [bigint] primary key identity(1,1) not null,
	[Name] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[Duration] [decimal](18, 2) NOT NULL,
	[Score] [bigint] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[LocationId] [bigint] NOT NULL
)
Insert Into TestDetails(Name,Number,Duration,Score,StartDate) 
values('Tamil',4,3.00,200,'12/08/2023')
drop table TestDetails

Update TestDetails set number = 7,score = 100 where id=1 

Delete from TestDetails Where name='tamil'
--(store procedure)
------Insert------
Create procedure InsertTeasDetails
@Name varchar(50),@Number int,@Duration decimal(18,2),@Score bigint,@StartDate datetime2(7)
as
begin
insert into TestDetails values(@Name,@Number,@Duration,@Score,@StartDate)
end
exec InsertTeasDetails'html',3,3.00,150,'12/05/2024'
drop procedure UpdateTestDetails
select * from TestDetails
------update-----
create procedure UpdateTestDetails
@Id bigint,@Name varchar(50),@Number int,@Duration decimal(18,2),@Score bigint,@StartDate datetime2(7)
as
begin
update TestDetails set name=@Name,Number=@Number,Duration=@Duration,Score=@Score,StartDate=@StartDate where Id=@Id
end
exec UpdateTestDetails 12,'lenux',43,2.30,67,'12/12/2024'
----delete-----
create procedure DeleteTestDetails
(@Id bigint)
as
begin
delete from TestDetails where Id=@Id
end
exec DeleteTestDetails 16
--------ReadAllDetails------
create procedure ReadAllTestDetails
as
begin
select * from TestDetails
end
exec ReadAllTestDetails
----------ReadByNumber------------
create procedure ReadByNumber
(@Id bigint)
as
begin
select * from TestDetails where Id=@Id
end
exec ReadByNumber 19
drop procedure ReadByNumber

create table [Locations]
(
[LocationId][bigint] primary key identity(1,1) not null,
[LocationName][nvarchar](50) not null
)

create procedure LocationDetails
(@LocationName nvarchar(50))
as
begin
insert into Locations values (@LocationName)
end
exec LocationDetails' covai'
select * from locations

create procedure LocationUpdate
(@LocationId bigint,@LocationName nvarchar(50))
as
begin
update  Locations set LocationName=@LocationName where LocationId=@LocationId
end
exec LocationUpdate 4, 'Madurai'