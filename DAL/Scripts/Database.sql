USE [Bills Organizer]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 18-May-22 12:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Number] [int] NOT NULL,
	[DateIssue] [date] NOT NULL,
	[ExpiringDate] [date] NOT NULL,
	[TotalPay] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[Image] [varbinary](max) NULL,
	[Folder] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Folder]    Script Date: 18-May-22 12:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folder](
	[ID] [nchar](10) NOT NULL,
	[Name] [nchar](21) NOT NULL,
	[Owner] [int] NULL,
 CONSTRAINT [PK_Folder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 18-May-22 12:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[ID] [int] NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Password] [nchar](12) NOT NULL,
	[DisplayName] [nchar](15) NOT NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Folder_Bill] FOREIGN KEY([Folder])
REFERENCES [dbo].[Folder] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Folder_Bill]
GO
ALTER TABLE [dbo].[Folder]  WITH CHECK ADD  CONSTRAINT [FK_Owner_Folder] FOREIGN KEY([Owner])
REFERENCES [dbo].[Owner] ([ID])
GO
ALTER TABLE [dbo].[Folder] CHECK CONSTRAINT [FK_Owner_Folder]
GO
