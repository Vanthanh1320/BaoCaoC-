USE [HoTenDB]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 06/20/2021 15:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 06/20/2021 15:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IDCategory] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCategory] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 06/20/2021 15:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[IDProduct] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UnitCost] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [varchar](max) NULL,
	[Description] [nvarchar](50) NULL,
	[Status] [nvarchar](100) NULL,
	[IDCategory] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDProduct] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertCate]    Script Date: 06/20/2021 15:57:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertCate]
	
	@name nvarchar(50),
	@des nvarchar(50)
as
begin
	insert into Category(Name,Description)
	values(@name,@des)
end
GO
/****** Object:  StoredProcedure [dbo].[CategoryListAll]    Script Date: 06/20/2021 15:57:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CategoryListAll]
as
select * from Category
GO
/****** Object:  StoredProcedure [dbo].[ProductListAll]    Script Date: 06/20/2021 15:57:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ProductListAll]
as
select * from Product
GO
/****** Object:  ForeignKey [FK__Product__IDCateg__08EA5793]    Script Date: 06/20/2021 15:57:41 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([IDCategory])
REFERENCES [dbo].[Category] ([IDCategory])
GO
