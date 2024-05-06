Create Database LoginDemoDB
Go


Create Table Users (
	Email nvarchar(100) PRIMARY KEY,
	[Password] nvarchar(20) NOT NULL,
	PhoneNumber nvarchar(20) NULL,
	BirthDate DATETIME NULL,
	[Status] int NULL,
	[Name] nvarchar(50) NOT NULL
)
Go

INSERT INTO dbo.Users VALUES ('ofer@ofer.com', '1234', '+972526344450','15-nov-1972',1,'Ofer Zadikario')
Go

create table Grades (
	Id int identity(1000, 1) Primary key,
	StudentEmail nvarchar(100) Foreign key references Users(Email),
	SubjectName nvarchar(20) NOT NULL,
	Grade int Not NULL,
	ExamDate datetime NULL,
)
Go
Insert into dbo.Grades Values ('ofer@ofer.com', 'Science', 98, NULL)
Insert into dbo.Grades Values ('ofer@ofer.com', 'Hebrew', 64, '9-nov-2007')
Insert into dbo.Grades Values ('ofer@ofer.com', 'English', 50, '9-nov-2007')
select * from Users
select * from Grades
--scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=LoginDemoDB;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context LoginDemoDbContext -DataAnnotations -force
