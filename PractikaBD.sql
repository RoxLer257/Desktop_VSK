USE [Practika]
GO
/****** Object:  Table [dbo].[Policy]    Script Date: 25.04.2024 10:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[PolicyNumber] [nvarchar](50) NOT NULL,
	[ReceiptsNumber] [nvarchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[Roles]    Script Date: 25.04.2024 10:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Role] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserActions]    Script Date: 25.04.2024 10:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActions](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[ActionType] [nvarchar](50) NULL,
	[TableName] [nvarchar](50) NULL,
	[ActionDate] [datetime] NULL,
	[UserName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.04.2024 10:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Policy] ON 

INSERT [dbo].[Policy] ([ID], [FIO], [PolicyNumber], [ReceiptsNumber], [Date_of_issue], [Price], [Phone_number], [Address]) VALUES (1, N'Иванов', N'ТТТ8005453270', N'ТТТ8005453270', N'12.12.2023', 384.54, 89775391620, N'МО, г. Электрогорск')
INSERT [dbo].[Policy] ([ID], [FIO], [PolicyNumber], [ReceiptsNumber], [Date_of_issue], [Price], [Phone_number], [Address]) VALUES (2, N'Сидоров', N'ТТТ6877268728', N'ТТТ6877268728', N'11.12.2023', 6871.48, 87775311520, N'Ленина')
INSERT [dbo].[Policy] ([ID], [FIO], [PolicyNumber], [ReceiptsNumber], [Date_of_issue], [Price], [Phone_number], [Address]) VALUES (20, N'Григорьев', N'TTT8045321658', N'TTT8045321658', N'12.12.2023', 687.65, 89775162515, N'Ленина')
SET IDENTITY_INSERT [dbo].[Policy] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID_Role], [Role_Name]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([ID_Role], [Role_Name]) VALUES (2, N'Пользователь')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserActions] ON 

INSERT [dbo].[UserActions] ([ActionID], [ActionType], [TableName], [ActionDate], [UserName]) VALUES (1, N'Insert', N'Users', CAST(N'2024-04-24T20:48:57.537' AS DateTime), N'DESKTOP-EQRGKTH\sereb')
INSERT [dbo].[UserActions] ([ActionID], [ActionType], [TableName], [ActionDate], [UserName]) VALUES (2, N'Delete', N'Users', CAST(N'2024-04-24T20:49:36.237' AS DateTime), N'DESKTOP-EQRGKTH\sereb')
INSERT [dbo].[UserActions] ([ActionID], [ActionType], [TableName], [ActionDate], [UserName]) VALUES (3, N'Delete', N'Users', CAST(N'2024-04-24T20:49:38.593' AS DateTime), N'DESKTOP-EQRGKTH\sereb')
INSERT [dbo].[UserActions] ([ActionID], [ActionType], [TableName], [ActionDate], [UserName]) VALUES (4, N'Delete', N'Users', CAST(N'2024-04-24T20:49:39.990' AS DateTime), N'DESKTOP-EQRGKTH\sereb')
SET IDENTITY_INSERT [dbo].[UserActions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [Login], [Password], [Role]) VALUES (1, N'admin', N'admin', 1)
INSERT [dbo].[Users] ([id], [Login], [Password], [Role]) VALUES (2, N'practika', N'123', 2)
INSERT [dbo].[Users] ([id], [Login], [Password], [Role]) VALUES (9, N'12', N'12', 2)
INSERT [dbo].[Users] ([id], [Login], [Password], [Role]) VALUES (14, N'1', N'vlad', 2)
INSERT [dbo].[Users] ([id], [Login], [Password], [Role]) VALUES (15, N'2', N'test', 2)
INSERT [dbo].[Users] ([id], [Login], [Password], [Role]) VALUES (16, N'test', N'test', 2)
INSERT [dbo].[Users] ([id], [Login], [Password], [Role]) VALUES (24, N'16', N'16', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Role]  DEFAULT ((2)) FOR [Role]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([ID_Role])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[policyadd]    Script Date: 25.04.2024 10:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[policyadd] as
insert dbo.Policy (FIO, [№_Policy], [№_Receipts], Date_of_issue, Price, 
Phone_number, Address)
values ('Григорьев', 'TTT8045321658', 'TTT8045321658','12.12.2023', 687.65, 89775162515, 'Ленина')
GO
/****** Object:  StoredProcedure [dbo].[policydel]    Script Date: 25.04.2024 10:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[policydel] as
delete from Policy
where FIO = 'Григорьев'
GO
/****** Object:  StoredProcedure [dbo].[policysum]    Script Date: 25.04.2024 10:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[policysum] as
select FIO, [№_Policy], [№_Receipts], Date_of_issue, Price, 
Phone_number, Address
from Policy
GO
