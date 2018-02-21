CREATE TABLE [dbo].[Books] (
    [Id]         INT           NOT NULL,
    [BookName]   NVARCHAR (15) NOT NULL,
    [NumOfPages] INT           NULL,
    [Price]      MONEY         NOT NULL,
    [Author]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([BookName] ASC),
    CONSTRAINT [AuthorToBooksFK] FOREIGN KEY ([Author]) REFERENCES [dbo].[Authors] ([Id])
);

