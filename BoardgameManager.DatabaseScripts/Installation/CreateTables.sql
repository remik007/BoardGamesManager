CREATE TABLE [dbo].[BoardgameCall] (
    [Id]           INT     IDENTITY (1, 1) NOT NULL,
    [Boardgame_Id] INT     NOT NULL,
    [CallType]     INT NOT NULL,
    [CallDate] DATETIME2 NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BoardgameCall_Boardgame] FOREIGN KEY ([Boardgame_Id]) REFERENCES [dbo].[Boardgame] ([Id]) ON DELETE CASCADE
);



CREATE TABLE [dbo].[Boardgame]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(500) NOT NULL, 
    [MinAge] INT NULL, 
    [BoardGameType_Id] INT NULL, 
    [CreatedDate] DATETIME2 NULL, 
    [CreatedBy] NVARCHAR(200) NULL, 
    [ModifiedDate] DATETIME2 NULL, 
    [ModifiedBy] NVARCHAR(200) NULL, 
    CONSTRAINT [FK_Boardgame_Type] FOREIGN KEY ([BoardGameType_Id]) REFERENCES [BoardGameType]([Id])
)

CREATE TABLE [dbo].[BoardGameType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(200) NOT NULL, 
    [CreatedDate] DATETIME2 NULL, 
    [CreatedBy] NVARCHAR(200) NULL, 
    [ModifiedDate] DATETIME2 NULL, 
    [ModifiedBy] NVARCHAR(200) NULL
)

