CREATE TABLE [dbo].[Inventory]
(
	 [Id]				INT					IDENTITY(1,1) NOT NULL
	,[Name]				NVARCHAR(450)		NOT NULL
	,[PricePerUnit]		DECIMAL				NOT NULL
	,[AmountAvailable]	INT					NOT NULL, 
    CONSTRAINT [PK_Inventory] PRIMARY KEY ([Id])
)
