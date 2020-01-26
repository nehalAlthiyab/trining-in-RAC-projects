CREATE TABLE [dbo].[Employees]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Gender] NVARCHAR(50) NULL, 
    [Salary] INT NULL
)
