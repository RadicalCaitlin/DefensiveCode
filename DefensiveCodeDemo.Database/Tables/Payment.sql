CREATE TABLE [dbo].[Payment]
(
	 [Id]			INT		IDENTITY(1,1) NOT NULL
	,[CustomerId]	INT		NOT NULL
	,[OrderId]		INT		NOT NULL
	,[Total]		INT		NOT NULL, 
    CONSTRAINT [PK_Payment] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Payment_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]), 
    CONSTRAINT [FK_Payment_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id])
)
