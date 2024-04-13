USE master
GO
	
IF EXISTS (SELECT * FROM sys.databases
		   WHERE name = 'MyDB')
	DROP DATABASE MyDB
GO


CREATE DATABASE MyDB
	ON PRIMARY
		(NAME = MyDB_data, FILENAME='D:\�������\testTaskDB\Trainer_data.mdf',
		 SIZE = 8 MB, MAXSIZE = 100, FILEGROWTH = 10)
	LOG ON
		(NAME = MyDB_log, FILENAME='D:\�������\testTaskDB\Trainer_log.ldf',
		 SIZE = 8 MB, MAXSIZE = 100, FILEGROWTH = 10)
GO

USE MyDB

GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Employee' AND TYPE = 'U')
	DROP TABLE Employee
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Organization' AND TYPE = 'U')
	DROP TABLE Organization

GO

CREATE TABLE Employee
	(Id_Employee INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Surname_Employee VARCHAR(50) NOT NULL,
	Name_Employee VARCHAR(30) NOT NULL,
	FatherName_Employee VARCHAR(50),
	Date_Of_Birth DATE NOT NULL,
	Passport_Series VARCHAR(5) NOT NULL,
	Passport_Number VARCHAR(6) NULL
);
/* �� ����������� ����������� �������� */

CREATE TABLE Organization
	(Id_Organization INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name_Organization VARCHAR(255) NOT NULL,
	ITN_Organization VARCHAR(12) NOT NULL, /* Individual Taxpayer Number */
	Legal_Address VARCHAR(255) NOT NULL,
	Actual_Address VARCHAR(255) NOT NULL
);

CREATE TABLE Worker
	(Id_Worker INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Id_Employee INT NOT NULL,
	Id_Organization INT NOT NULL,
	CONSTRAINT fk_Id_Employee FOREIGN KEY (Id_Employee) REFERENCES Employee(Id_Employee),
	CONSTRAINT fk_Id_Organization FOREIGN KEY (Id_Organization) REFERENCES Organization(Id_Organization)
);

INSERT INTO Employee (Surname_Employee, Name_Employee, FatherName_Employee, Date_Of_Birth, Passport_Series, Passport_Number)
	VALUES ('���������', '������', '�������', '2004-01-26', '12 34', '567890'),
		   ('���������', '��������', '��������', '2003-01-24', '21 43', '098765');

INSERT INTO Organization (Name_Organization, ITN_Organization, Legal_Address, Actual_Address)
	VALUES ('DEPO Computers', '7707123200', '143402, ���������� ���., �. �����������, ���. ������������ ���� �����������-������, �. 12', '�. ������, ������, ��. ����������, �. 12'),
		   ('�� ���� ������ ��. �.�. ���������', '7728816598', '117342, ����� ������, ��. �����������, �. 3 �. 1', '117342, ����� ������, ��. �����������, �. 3 �. 1');