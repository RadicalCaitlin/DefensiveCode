CREATE TABLE [dbo].[Order]
(
	 [Id]				INT					IDENTITY(1,1) NOT NULL
	,[CustomerId]		INT					NOT NULL
	,[DateCreatedUTC]	DATETIMEOFFSET		NOT NULL, 
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
