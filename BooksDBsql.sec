SET DATEFORMAT dmy;
SET LANGUAGE German;

USE master
GO
-- BooksDB
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'BooksDB'
)
DROP DATABASE [BooksDB]
GO

CREATE DATABASE [BooksDB]
GO
USE [BooksDB]
GO
CREATE TABLE Categories
(
	[CategoryID]			INT				PRIMARY KEY,
	[CategoryName]			NVARCHAR(50)	NOT NULL
);
INSERT INTO Categories VALUES 
(1, 'Programmierung'),
(2, 'Datenbanken'),
(3, 'HTML'),
(4, 'Roman');
GO
CREATE TABLE Books 
(
	[ISBN]				NVARCHAR(15)	PRIMARY KEY,
	[Title]				NVARCHAR(150)	NOT NULL,
	[Year]				DATE			NOT NULL DEFAULT(GETDATE()),
	[CategoryID]		INT				NOT NULL,
	FOREIGN KEY([CategoryID]) 
	REFERENCES Categories([CategoryID])
);
GO
INSERT INTO Books VALUES
('10101010101', 'CLR via C#', '23.3.2012', 1),
('10101010102', 'Programming in C#', '13.5.2011', 1),
('10101010103', 'Developing Windows Store Apps in C#', '1.2.2013', 1),
('10101010104', '.NET Framework 4.0', '22.7.2012', 1),
('10101010105', 'ADO.NET in C#', '16.9.2010', 1);
GO
INSERT INTO Books VALUES
('10101010111', 'SQL für Profis', '3.8.2009', 2),
('10101010112', 'Einstieg in MySQL', '13.5.2011', 2),
('10101010113', 'Orcale 10i', '11.2.2013', 2),
('10101010114', 'DB2 für Java-Entwickler', '7.4.2002', 2),
('10101010115', 'Datenbanken mit MS Access', '16.2.2007', 2);
GO
INSERT INTO Books VALUES
('10101011111', 'Web-Seiten mit HTML', '3.1.1997', 3),
('10101011112', 'HTML + PHP + MySQL', '13.7.1999', 3),
('10101011113', '(X)HTML 1.1', '11.2.2005', 3),
('10101011114', 'Interactive Web-Seiten mit JavaScript', '7.7.2002', 3),
('10101011115', 'HTML + CSS', '6.11.2007', 3);
GO
INSERT INTO Books VALUES
('10101211111', 'Fahrenheit 451', '3.1.1954', 4),
('10101211112', 'Brave New World', '13.7.1928', 4),
('10101211113', '1984', '11.2.1937', 4),
('10101211114', 'Die Mars-Chroniken', '7.7.1946', 4),
('10101211115', 'The Moon Is a Harsh Mistress', '6.11.1966', 4);
GO


CREATE PROCEDURE usp_show_all_books
AS
SELECT 
	B.ISBN,
	B.Title,
	B.[Year],
	C.CategoryName 
FROM 
	Books B INNER JOIN Categories C 
	ON 
	B.CategoryID = C.CategoryID;
GO

CREATE PROCEDURE usp_filter_books
	@filter	NVARCHAR(100)
AS
SELECT 
	B.ISBN,
	B.Title,
	B.[Year],
	C.CategoryName 
FROM 
	Books B INNER JOIN Categories C 
	ON 
	B.CategoryID = C.CategoryID
	AND B.Title LIKE '%' + @filter + '%';
GO

CREATE PROCEDURE usp_books_by_categoryid
	@CategoryID	INT
AS
SELECT 
	B.ISBN,
	B.Title,
	B.[Year],
	C.CategoryName 
FROM 
	Books B INNER JOIN Categories C 
	ON 
	B.CategoryID = C.CategoryID
	AND C.CategoryID = @CategoryID
GO
