﻿CREATE TABLE [dbo].[dolist]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Work] NVARCHAR(MAX) NOT NULL, 
    [From] NVARCHAR(MAX) NOT NULL 
)