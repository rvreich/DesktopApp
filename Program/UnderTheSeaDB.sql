GO
USE UnderTheSeaDB

GO
CREATE TABLE Tickets(
	ID BIGINT IDENTITY PRIMARY KEY,
	DATE_CREATED DATE
)

GO
SELECT * FROM Tickets

UPDATE Tickets
SET DATE_CREATED = '2020-06-03' WHERE ID = 1

GO
SELECT COUNT(*) FROM Tickets WHERE MONTH(DATE_CREATED) = 6

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

INSERT INTO Workers (WORKERUSERNAME,WORKERPASSWORD,WORKERNAME,WORKERGENDER,WORKERSALARY,WORKERDOB,WORKERPOSITION,ACTIVEWORKER)
VALUES
('manager','manager','the manager','MALE',25000000,'1996-04-20','MANA',1),
('attr1','attr1','attraction worker female_1','FEMALE',8000000,'1997-11-07','ATTR',1),
('attr2','attr2','attraction worker female_2','FEMALE',8000000,'1997-08-13','ATTR',1),
('main1','main1','maintenance worker male_1','MALE',10000000,'1991-10-14','MAIN',1),
('main2','main2','maintenance worker male_2','MALE',10000000,'1991-10-28','MAIN',1),
('riac1','riac1','creative worker male_1','MALE',12000000,'1998-02-14','RIAC',1),
('riac2','riac2','creative worker female_1','FEMALE',12000000,'1998-04-01','RIAC',1),
('cons1','cons1','construction worker male_1','MALE',10000000,'1993-01-11','CONS',1),
('cons2','cons2','construction worker male_2','MALE',10000000,'1993-01-21','CONS',1),
('diro1','diro1','dining worker female_1','FEMALE',11000000,'1997-05-13','DIRO',1),
('diro2','diro2','dining worker female_2','FEMALE',11000000,'1997-09-29','DIRO',1),
('kitc1','kitc1','kitchen worker male_1','MALE',14000000,'1989-11-05','KITC',1),
('kitc2','kitc2','kitchen worker male_2','MALE',14000000,'1986-10-20','KITC',1),
('purc1','purc1','purchasing worker male_1','MALE',14000000,'1991-08-07','PURC',1),
('purc2','purc2','purchasing worker female_1','FEMALE',14000000,'1993-08-11','PURC',1),
('acfi1','acfi1','accounting worker female_1','FEMALE',16000000,'1991-04-06','ACFI',1),
('acfi2','acfi2','accounting worker female_2','FEMALE',16000000,'1991-06-14','ACFI',1),
('frof1','frof1','front office worker female_1','FEMALE',13000000,'1997-07-07','FROF',1),
('frof2','frof2','front office worker female_2','FEMALE',13000000,'1996-06-06','FROF',1),
('hoke1','hoke1','house worker female_1','FEMALE',13000000,'1989-02-27','HOKE',1),
('hoke2','hoke2','house worker female_2','FEMALE',13000000,'1994-04-26','HOKE',1),
('sama1','sama1','marketing worker male_1','MALE',17000000,'1991-02-13','SAMA',1),
('sama2','sama2','marketing worker female_1','FEMALE',17000000,'1998-12-21','SAMA',1),
('hurd1','hurd1','hrd worker male_1','MALE',15000000,'1995-03-23','HURD',1),
('hurd2','hurd2','hrd worker male_2','MALE',15000000,'1994-07-07','HURD',1)

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