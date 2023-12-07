USE [SecurityLogins]
GO

/****** Object:  Table [dbo].[UserLogIns]    Script Date: 07/12/2023 23:21:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserLogIns](
	[UserID] [int] NOT NULL,
	[userName] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[adminAccess] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


