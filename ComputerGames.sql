CREATE DATABASE ComputerGames;
GO
USE ComputerGames;
GO
CREATE TABLE Publisher
(
Id INT PRIMARY KEY Identity(1, 1),
[Name] NVARCHAR(100) NOT NULL,
License INT NOT NULL
);
CREATE TABLE Genre
(
Id INT PRIMARY KEY Identity(1, 1),
[Genre] NVARCHAR(50) NOT NULL,
[Description] NVARCHAR(600) NOT NULL
);
GO
CREATE TABLE Game
(
Id INT PRIMARY KEY Identity(1, 1),
[Name] NVARCHAR(60) NOT NULL,
YearOfIssue INT NOT NULL,
Genre_Id INT NOT NULL references Genre(Id),
Publisher_Id INT NOT NULL references Publisher(Id),
CONSTRAINT NameYearOfIssue UNIQUE ([Name], YearOfIssue),
CONSTRAINT GamesYearOfIssue CHECK((YearOfIssue >= 1980) AND (YearOfIssue <= YEAR(GETDATE()))),
);
GO
insert into Genre ([Genre], [Description]) values ('RPG', 'Description');
insert into Genre ([Genre], [Description]) values ('3DAction', 'Description');
insert into Genre ([Genre], [Description]) values ('Strategy', 'Description');
GO
insert into Publisher ([Name], License) values ('Blizzard', 123456);
insert into Publisher ([Name], License) values ('Valve Corporation', 654321);
insert into Publisher ([Name], License) values ('Firaxis Games', 123654);
GO
insert into Game ([Name], YearOfIssue, Genre_Id, Publisher_Id) values ('WOW', 2015, 1, 1);
insert into Game ([Name], YearOfIssue, Genre_Id, Publisher_Id) values ('Half-Life', 2016, 2, 2);
insert into Game ([Name], YearOfIssue, Genre_Id, Publisher_Id) values ('Sid Meiers Civilization VI', 2017, 3, 3);