CREATE TABLE [dbo].[Product]
(
	[Product_Id] INT NOT NULL PRIMARY KEY, 
    [Product_Name] NCHAR(10) NOT NULL, 
    [Supplier_Id] INT NOT NULL, 
    [Color_Id] INT NOT NULL, 
    [Category_Id] INT NOT NULL, 
    [UnitPrice] MONEY NOT NULL, 
    [Discription] NVARCHAR(50) NULL, 
    [ImageUrl] NVARCHAR(MAX) NOT NULL, 
    [QuantityInStock] INT NULL, 
    CONSTRAINT [FK_Cap_ToTable] FOREIGN KEY ([Category_Id]) REFERENCES [Category]([Category_Id]), 
    CONSTRAINT [FK_Cap_ToTable_1] FOREIGN KEY ([Color_Id]) REFERENCES [Color]([Id]) 
)
