CREATE TABLE [dbo].[Contacts]
(
	[ContactId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FullName] AS [FirstName] + ' ' + [LastName],
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [DateCreated] DATETIME2 NOT NULL DEFAULT SYSDATETIME(), 
    [DateDeleted] DATETIME2 NULL
)
