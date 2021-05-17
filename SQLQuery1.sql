USE [Project]
GO
/****** Object:  Table [dbo].[HOMEWORK]    Script Date: 17.05.2021 21:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOMEWORK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TITLE] [nvarchar](250) NOT NULL,
	[CONTEXT] [nvarchar](max) NOT NULL,
	[SIMILARTYRATE] [decimal](3, 2) NOT NULL,
	[ISSCAN] [bit] NOT NULL,
	[USERID] [int] NOT NULL,
 CONSTRAINT [PK_HOMEWORK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17.05.2021 21:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HOMEWORK] ADD  CONSTRAINT [DF_HOMEWORK_ISSCAN]  DEFAULT ((0)) FOR [ISSCAN]
GO
