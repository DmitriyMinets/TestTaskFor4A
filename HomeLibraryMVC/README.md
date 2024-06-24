Создадим базу данных, таблицы и хранимые процедуры.

CREATE DATABASE HomeLibrary;
GO

USE HomeLibrary;
GO

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    YearOfPublication DATE,
    TableOfContents XML
);
GO

CREATE PROCEDURE InsertBook
    @Title NVARCHAR(255),
    @Author NVARCHAR(255),
    @YearOfPublication DATE,
    @TableOfContents XML
AS
BEGIN
    INSERT INTO Books (Title, Author, YearOfPublication, TableOfContents)
    VALUES (@Title, @Author, @YearOfPublication, @TableOfContents);
END;
GO

CREATE PROCEDURE UpdateBook
    @BookID INT,
    @Title NVARCHAR(255),
    @Author NVARCHAR(255),
    @YearOfPublication DATE,
    @TableOfContents XML
AS
BEGIN
    UPDATE Books
    SET Title = @Title,
        Author = @Author,
        YearOfPublication = @YearOfPublication,
        TableOfContents = @TableOfContents
    WHERE BookID = @BookID;
END;
GO

CREATE PROCEDURE DeleteBook
    @BookID INT
AS
BEGIN
    DELETE FROM Books WHERE BookID = @BookID;
END;
GO

CREATE PROCEDURE SelectBooks
AS
BEGIN
    SELECT * FROM Books;
END;
GO

CREATE PROCEDURE GetBookById
    @BookID INT
AS
BEGIN
    SELECT * FROM Books WHERE BookID = @BookID
END;