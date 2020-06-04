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
	ID INT IDENTITY PRIMARY KEY,
	AUDITDATE DATE,
	DEPARTMENT VARCHAR(20),
	AMOUNT INT
)

GO
SELECT * FROM Audits

CREATE TABLE Attractions(
	ID INT IDENTITY PRIMARY KEY,
	ATTRACTIONNAME VARCHAR(50),
	CAPACITY INT,
	LASTMAINTENANCE DATE,
	UPMAINTENANCE DATE,
	ATTRACTIONSTATUS VARCHAR(10),
	CONSTRUCTIONSTATUS VARCHAR(10),
	ISACTIVE INT
)

/*
	ATTRACTIONSTATUS
	MAINTAINED
	FIXING
	BROKEN

	CONSTRUCTIONSTATUS
	ESTABLISH	-> Base - Udh Berdiri
	WORKING		-> Lagi Progress
	CONSTRUCT	-> Perlu Dibuat
	UPGRADE		-> Perlu Dimodif
	REMOVAL		-> Perlu DiHancurin
	DESTROYED	-> Dah Hancur
*/

GO
SELECT * FROM Attractions

GO
CREATE TABLE GeneralReports(
	ID INT IDENTITY PRIMARY KEY,
	REPORTDATE DATE,
	DEPARTMENT VARCHAR(20),
	CONTENT VARCHAR(1000)
)

GO
SELECT * FROM GeneralReports

GO
CREATE TABLE ConfirmationReports(
	ID INT IDENTITY PRIMARY KEY,
	REPORTDATE DATE,
	DEPARTMENT VARCHAR(20),
	CONTENT VARCHAR(1000),
	APPROVED INT,
	RECEIVER VARCHAR(20)
)

GO
SELECT * FROM ConfirmationReports

GO
CREATE TABLE OrderScripts(
	ID INT IDENTITY PRIMARY KEY,
	DATE_CREATED DATE,
	AMOUNT INT,
	ORDERSTATUS VARCHAR(20),
	ISPAY INT,
	CHAIRNUM INT
)

SELECT * FROM OrderScripts
SELECT SUM(AMOUNT * 40000) FROM OrderScripts

/*
	CHAIRNUM -> NO KURSI
	ISPAY -> UDAH BAYAR ATO BLM

	NTAR VALIDASI AJA
	YANG ISPAY = 0 DENGAN CHAIRNUM SEGINI

	ORDERSTATUS
	CREATED
	COOKED
	MADE
	DELIVERED
	FINISH
*/

