
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/18/2022 18:46:19
-- Generated from EDMX file: C:\Users\Leon Kranjcevic\OneDrive - Visoko uciliste Algebra\Desktop\PPPK\PPPK_Movies\MovieActor\MovieActor\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Movie];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [IDMovie] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [YearOfRelease] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Actors'
CREATE TABLE [dbo].[Actors] (
    [IDActor] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [MovieIDMovie] int  NOT NULL
);
GO

-- Creating table 'UploadedFiles'
CREATE TABLE [dbo].[UploadedFiles] (
    [IDUploadedFile] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ContentType] nvarchar(20)  NOT NULL,
    [Content] varbinary(30)  NOT NULL,
    [MovieIDMovie] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDMovie] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([IDMovie] ASC);
GO

-- Creating primary key on [IDActor] in table 'Actors'
ALTER TABLE [dbo].[Actors]
ADD CONSTRAINT [PK_Actors]
    PRIMARY KEY CLUSTERED ([IDActor] ASC);
GO

-- Creating primary key on [IDUploadedFile] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [PK_UploadedFiles]
    PRIMARY KEY CLUSTERED ([IDUploadedFile] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MovieIDMovie] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [FK_MovieUploadedFile]
    FOREIGN KEY ([MovieIDMovie])
    REFERENCES [dbo].[Movies]
        ([IDMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieUploadedFile'
CREATE INDEX [IX_FK_MovieUploadedFile]
ON [dbo].[UploadedFiles]
    ([MovieIDMovie]);
GO

-- Creating foreign key on [MovieIDMovie] in table 'Actors'
ALTER TABLE [dbo].[Actors]
ADD CONSTRAINT [FK_MovieActor]
    FOREIGN KEY ([MovieIDMovie])
    REFERENCES [dbo].[Movies]
        ([IDMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieActor'
CREATE INDEX [IX_FK_MovieActor]
ON [dbo].[Actors]
    ([MovieIDMovie]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------