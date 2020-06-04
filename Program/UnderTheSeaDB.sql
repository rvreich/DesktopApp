GO
USE UnderTheSeaDB

GO
CREATE TABLE Tickets(
	ID BIGINT IDENTITY PRIMARY KEY,
	DATE_CREATED DATE
)

GO
SELECT * FROM Tickets

GO
CREATE TABLE Workers(
	ID BIGINT IDENTITY PRIMARY KEY,
	WORKERUSERNAME VARCHAR(50),
	WORKERPASSWORD VARCHAR(50),
	WORKERNAME VARCHAR(100),
	WORKERGENDER VARCHAR(10),
	WORKERSALARY INT,
	WORKERDOB DATE,
	WORKERPOSITION VARCHAR(20),
	ACTIVEWORKER INT,
	PERFORMANCEINDEX INT
)
/*
	WORKERPOSITION
	ATTR - Attraction Department
	MAIN - Maintenance Department
	RIAC - Ride & Attraction Creative Department
	CONS - Construction Department
	DIRO - Dining Room Division
	KITC - Kitchen Division
	PURC - Purhasing Department
	ACFI - Accounting & Finance Department
	FROF - Front Office Division
	HOKE - House Keeping Division
	SAMA - Sales Marketing Department
	HURD - Human Resource Department
	MANA - Manager
*/
GO
SELECT * FROM Workers

GO
CREATE TABLE Audits(
	ID INT IDENTITY,
	AUDITDATE DATE,
	DEPARTMENT VARCHAR(20),
	AMOUNT INT
)

GO
SELECT * FROM Audits