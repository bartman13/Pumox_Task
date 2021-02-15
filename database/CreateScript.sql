SET NOCOUNT ON
GO

USE master

GO
if exists (select * from sysdatabases where name='Pumox')
		drop database Pumox
Go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE Pumox
  ON PRIMARY (NAME = N''Pumox'', FILENAME = N''' + @device_directory + N'Pumox.mdf'')
  LOG ON (NAME = N''Pumox_log'',  FILENAME = N''' + @device_directory + N'Pumox.ldf'')')
go

GO

set quoted_identifier on
GO

SET DATEFORMAT mdy
GO

use "Pumox"
GO

drop table if exists Companies
drop table if exists Employees


GO

CREATE TABLE Companies (
	Id bigint IDENTITY (1, 1) NOT NULL ,
	"Name" nvarchar (50) NOT NULL,
	EstablishmentYear int NOT NULL,
	CONSTRAINT PK_Companies PRIMARY KEY CLUSTERED
	(
		Id
	)
)
GO

CREATE TABLE Employees(
	Id bigint IDENTITY(1, 1) NOT NULL,
	FirstName nvarchar (50) NOT NULL,
	LastName  nvarchar (50) NOT NULL,
	DateOfBirth date NOT NULL,
	JobTitle nvarchar (50) NOT NULL,
	CompanyId bigint NOT NULL,
	CONSTRAINT PK_Employees PRIMARY KEY CLUSTERED
	(
		Id
	),
	CONSTRAINT FK_Employees_Companies FOREIGN KEY
	(
		CompanyId
	) REFERENCES Companies
	(
		Id
	) ON DELETE CASCADE
)


