CREATE TABLE [dbo].[Customer]
(
	 [Id]				INT				IDENTITY(1,1) NOT NULL
	,[FirstName]		NVARCHAR(200)	NOT NULL
	,[LastName]			NVARCHAR(200)	NOT NULL
	,[Email]			NVARCHAR(300)	NOT NULL, 
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_Customer_Column] UNIQUE ([Email])
)
