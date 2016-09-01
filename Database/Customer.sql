CREATE TABLE [dbo].[Customer]
(
	[Customer_Id] INT NOT NULL PRIMARY KEY, 
    [Customer_Name] NVARCHAR(50) NOT NULL, 
    [Phone_Home] VARCHAR(50) NULL, 
    [Phone_Work] NVARCHAR(50) NULL, 
    [Phone_Mobile] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(MAX) NOT NULL
)
