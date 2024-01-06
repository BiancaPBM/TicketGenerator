CREATE TABLE [dbo].[Ticket]
(
 [Id] INT IDENTITY PRIMARY KEY,
 [Name] NVARCHAR(50),
 [Superzahl] INT NULL,
 [DateCreation] DATETIME2(7) NOT NULL
)
