﻿CREATE TABLE [dbo].[Authors]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL UNIQUE, 
	[Age] INT ,
    [Image] NVARCHAR(300) NULL
)
