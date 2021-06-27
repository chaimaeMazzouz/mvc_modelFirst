
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/27/2021 19:12:16
-- Generated from EDMX file: C:\Users\user\source\repos\MVC_AT9\Models\ModelGestionArticle.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Gestion_Article];
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

-- Creating table 'TypeSet'
CREATE TABLE [dbo].[TypeSet] (
    [Num_Type] int IDENTITY(1,1) NOT NULL,
    [Nom_Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ArticleSet'
CREATE TABLE [dbo].[ArticleSet] (
    [Ref_Article] int IDENTITY(1,1) NOT NULL,
    [Designation] nvarchar(max)  NOT NULL,
    [Num_Type] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Num_Type] in table 'TypeSet'
ALTER TABLE [dbo].[TypeSet]
ADD CONSTRAINT [PK_TypeSet]
    PRIMARY KEY CLUSTERED ([Num_Type] ASC);
GO

-- Creating primary key on [Ref_Article] in table 'ArticleSet'
ALTER TABLE [dbo].[ArticleSet]
ADD CONSTRAINT [PK_ArticleSet]
    PRIMARY KEY CLUSTERED ([Ref_Article] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Num_Type] in table 'ArticleSet'
ALTER TABLE [dbo].[ArticleSet]
ADD CONSTRAINT [FK_TypeArticle]
    FOREIGN KEY ([Num_Type])
    REFERENCES [dbo].[TypeSet]
        ([Num_Type])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeArticle'
CREATE INDEX [IX_FK_TypeArticle]
ON [dbo].[ArticleSet]
    ([Num_Type]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------