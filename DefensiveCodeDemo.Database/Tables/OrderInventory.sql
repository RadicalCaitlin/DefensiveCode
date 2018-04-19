CREATE TABLE [dbo].[OrderInventory]
(
	 [Id]			INT		IDENTITY(1,1) NOT NULL
	,[OrderId]		INT		NOT NULL
	,[InventoryId]	INT		NOT NULL
	,[Quantity]		INT		NOT NULL, 
    CONSTRAINT [PK_OrderInventory] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_OrderInventory_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id]), 
    CONSTRAINT [FK_OrderInventory_Inventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([Id])
)
