CREATE TABLE [dbo].[Order]
(
	[Order_Id] INT NOT NULL PRIMARY KEY, 
    [Customer_Id] INT NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    [SubTotal] MONEY NOT NULL, 
    [Gst] MONEY NOT NULL, 
    [GrandTotal] MONEY NOT NULL
)
