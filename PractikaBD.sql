USE [Practika]
GO
/****** Object:  Table [dbo].[Policy]    Script Date: 13.12.2023 18:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[№_Policy] [nvarchar](50) NOT NULL,
	[№_Receipts] [nvarchar](50) NOT NULL,
	[Date_of_issue] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Phone_number] [bigint] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Insurance_policies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.12.2023 18:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Policy] ON 

INSERT [dbo].[Policy] ([ID], [FIO], [№_Policy], [№_Receipts], [Date_of_issue], [Price], [Phone_number], [Address]) VALUES (1, N'Иванов', N'ТТТ8005453270', N'ТТТ8005453270', N'12.12.2023', 384.54, 89775391620, N'МО, г. Электрогорск')
INSERT [dbo].[Policy] ([ID], [FIO], [№_Policy], [№_Receipts], [Date_of_issue], [Price], [Phone_number], [Address]) VALUES (2, N'Сидоров', N'ТТТ6877268728', N'ТТТ6877268728', N'11.12.2023', 6871.48, 87775311520, N'Ленина')
INSERT [dbo].[Policy] ([ID], [FIO], [№_Policy], [№_Receipts], [Date_of_issue], [Price], [Phone_number], [Address]) VALUES (5, N'Леванова', N'ТТТ3874137817', N'ТТТ3874137817', N'08.12.2023', 3875.05, 89995361520, N'Советская')
INSERT [dbo].[Policy] ([ID], [FIO], [№_Policy], [№_Receipts], [Date_of_issue], [Price], [Phone_number], [Address]) VALUES (6, N'Григорьев', N'ТТТ3873673687', N'ТТТ3873673687', N'10.12.2023', 54177.67, 89775301625, N'Ленина, 15')
SET IDENTITY_INSERT [dbo].[Policy] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [Login], [Password]) VALUES (1, N'admin', N'admin')
INSERT [dbo].[Users] ([id], [Login], [Password]) VALUES (2, N'practika', N'123')
INSERT [dbo].[Users] ([id], [Login], [Password]) VALUES (9, N'12', N'12')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
