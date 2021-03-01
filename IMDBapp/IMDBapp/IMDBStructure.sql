USE IMDBStructure;

DROP TABLE IF EXISTS MovieActorsMapping;
DROP TABLE IF EXISTS MovieGenresMapping;
DROP TABLE IF EXISTS Movies;
DROP TABLE IF EXISTS Genres;
DROP TABLE IF EXISTS Actors;
DROP TABLE IF EXISTS Producers;

CREATE TABLE Producers(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100),
	Gender VARCHAR(50),
	DOB DATE,
	Bio VARCHAR(255)
)

CREATE TABLE Actors(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100),
	Gender VARCHAR(50),
	DOB DATE,
	Bio VARCHAR(255)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100),
	YearOfRelease INT,
	Plot VARCHAR(255),
	Poster VARCHAR(255),
	ProducerId INT FOREIGN KEY REFERENCES Producers(Id)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	Name Varchar(100)
)

CREATE TABLE MovieActorsMapping(
	Id INT PRIMARY KEY IDENTITY,
	MovieId INT,
	ActorId INT,
)

CREATE TABLE MovieGenresMapping(
	Id INT PRIMARY KEY IDENTITY,
	MovieId INT,
	GenreId  INT FOREIGN KEY REFERENCES Genres(Id)
)

SELECT * FROM Movies
SELECT * FROM Actors
SELECT * FROM Producers
SELECT * FROM MovieActorsMapping
SELECT * FROM Genres
SELECT * FROM MovieGenresMapping


DROP PROCEDURE usp_insertMovie;
CREATE PROCEDURE usp_insertMovie @Name VARCHAR(500), @YearOfRelease INT, @Plot VARCHAR(500), @Poster VARCHAR(500), @ProducerId INT, @Actors VARCHAR(500), @Genres VARCHAR (500)
AS
DECLARE @MovieId INT
INSERT INTO Movies (
	Name, YearOfRelease, Plot, Poster, ProducerId
	)

VALUES (
	@Name, @YearOfRelease, @Plot, @Poster, @producerId
	)

SET @MovieId = SCOPE_IDENTITY()

INSERT INTO MovieActorsMapping (
	MovieId, ActorId
	)

SELECT (
	SELECT @MovieId
	)
,ActorsTable.Actors

FROM (
	SELECT value AS Actors
	FROM string_split(@Actors, ',')
	) ActorsTable

INSERT INTO MovieGenresMapping (
	MovieId, GenreId
	)

SELECT (
	SELECT @MovieId
	)
	,GenreTable.Genre

FROM (
	SELECT value AS Genre
	FROM string_split(@Genres, ',')
	) GenreTable

SELECT @MovieId

GO;

INSERT INTO Actors VALUES
('RDJ', 'M', '2000-01-01', 'American Actor'),
('Chris Evans', 'M', '2000-01-01', 'American Actor'),
('Chris HemsWorth', 'M', '2000-01-01', 'American Actor')

INSERT INTO Genres VALUES
('Thriller'), ('Sci-Fi'), ('Drama')

INSERT INTO Producers VALUES
('Kevin Feigi', 'M', '2000-01-01', 'American Producer'),
('James Ingold', 'M', '2000-01-01', 'American Producer'),
('Q Tarantino', 'M', '2000-01-01', 'American Producer')


DROP PROCEDURE usp_updateMovie;
CREATE PROCEDURE usp_updateMovie @Id INT, @Name VARCHAR(500), @YearOfRelease INT, @Plot VARCHAR(500), @Poster VARCHAR(500), @ProducerId INT, @Actors VARCHAR(500), @Genres VARCHAR (500)
AS
UPDATE Movies
SET Name = @Name,
	YearOfRelease = @YearOfRelease,
	Plot = @Plot,
	Poster = @Poster,
	ProducerId = @ProducerId
WHERE Movies.Id = @Id

DELETE
FROM MovieActorsMapping
WHERE MovieId = @Id 

DELETE
FROM MovieGenresMapping
WHERE MovieId = @Id 

INSERT INTO MovieActorsMapping (
	MovieId,
	ActorId
)

SELECT (
	SELECT @Id 
	)
	,ActorTable.Actors

FROM (

SELECT value AS Actors
FROM string_split(@Actors, ',')
) ActorTable

INSERT INTO MovieGenresMapping (
	MovieId,
	GenreId
	)

SELECT (
	SELECT @Id 
	)
	,GenreTable.Genre

FROM (
SELECT value AS Genre
FROM string_split(@Genres, ',')
) GenreTable

GO

EXEC dbo.usp_insertMovie @Name='Avengers', @YearOfRelease = '2012', @Plot='Super hero Sci-Fi Movie', @Poster='link', @producerId=1, @Actors='1,2', @Genres='1,2';

EXEC dbo.usp_updateMovie @Id=1, @Name='Avengers: Infiniy War', @YearOfRelease = '2018', @Plot='Super hero Sci-Fi Movie', @Poster='link', @producerId=1, @Actors='1,2', @Genres='1';

DECLARE @id AS INT = 2
DELETE
FROM MovieActorsMapping
WHERE MovieId = @id
DELETE
FROM MovieGenresMapping
WHERE MovieId = @id
DELETE
FROM Movies
WHERE Id = @id

SELECT * FROM Movies
SELECT * FROM Actors
SELECT * FROM Producers
SELECT * FROM Genres
SELECT * FROM MovieActorsMapping
SELECT * FROM MovieGenresMapping
