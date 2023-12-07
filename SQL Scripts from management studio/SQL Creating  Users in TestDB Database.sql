USE [TestDB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 07/12/2023 23:12:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[userID] [int] NOT NULL,
	[Username] [nvarchar](64) NULL,
	[Password] [nvarchar](64) NULL,
	[AdminAcess] [nvarchar](64) NULL
) ON [PRIMARY]
GO


