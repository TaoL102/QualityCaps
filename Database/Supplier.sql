CREATE TABLE [dbo].[Supplier]
(
	[Supplier_Id] INT NOT NULL PRIMARY KEY, 
    [Supplier_Name] NVARCHAR(50) NOT NULL, 
    [Phone_Home] NVARCHAR(50) NULL, 
    [Phone_Work] NVARCHAR(50) NULL, 
    [Phone_Mobile] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NOT NULL
)
