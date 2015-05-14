
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 01/14/2015 14:24:24
-- Generated from EDMX file: D:\develop\examTrail\TrailDeflate\ExamDB.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    DROP TABLE [TestQuestions];
GO
    DROP TABLE [TestQuestionInfos];
GO
    DROP TABLE [TQFiles];
GO
    DROP TABLE [Configs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TestQuestions'
CREATE TABLE [TestQuestions] (
    [Id] nchar(6)  NOT NULL,
    [Content] varbinary(8000)  NOT NULL,
    [Requirement] varbinary(8000)  NOT NULL,
    [ModelAnswer] varbinary(8000)  NOT NULL,
    [Comment] varbinary(8000)  NOT NULL,
    [ExamAnswer] varbinary(8000)  NOT NULL
);
GO

-- Creating table 'TestQuestionInfos'
CREATE TABLE [TestQuestionInfos] (
    [Id] nchar(6)  NOT NULL,
    [KnowlegePoint] nchar(50)  NOT NULL,
    [Difficulty] smallint  NOT NULL,
    [RigthNum] int  NOT NULL,
    [TotalNum] int  NOT NULL,
    [Redactor] ntext  NOT NULL,
    [RedactDate] datetime  NOT NULL
);
GO

-- Creating table 'TQFiles'
CREATE TABLE [TQFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(50)  NOT NULL,
    [Stream] varbinary(8000)  NOT NULL
);
GO

-- Creating table 'Configs'
CREATE TABLE [Configs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Setting] varbinary(8000)  NOT NULL,
    [Strategy] varbinary(8000)  NOT NULL,
    [Modules] varbinary(8000)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TestQuestions'
ALTER TABLE [TestQuestions]
ADD CONSTRAINT [PK_TestQuestions]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'TestQuestionInfos'
ALTER TABLE [TestQuestionInfos]
ADD CONSTRAINT [PK_TestQuestionInfos]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'TQFiles'
ALTER TABLE [TQFiles]
ADD CONSTRAINT [PK_TQFiles]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'Configs'
ALTER TABLE [Configs]
ADD CONSTRAINT [PK_Configs]
    PRIMARY KEY ([Id] );
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------