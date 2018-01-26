USE [master]
GO
/****** Object:  Database [bitstampService]    Script Date: 1/26/2018 2:07:13 PM ******/
CREATE DATABASE [bitstampService]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bitstampService', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\bitstampService.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bitstampService_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\bitstampService_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bitstampService] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bitstampService].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bitstampService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bitstampService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bitstampService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bitstampService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bitstampService] SET ARITHABORT OFF 
GO
ALTER DATABASE [bitstampService] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bitstampService] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [bitstampService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bitstampService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bitstampService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bitstampService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bitstampService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bitstampService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bitstampService] SET QUOTED_IDENTIFIER OFF 
Create Database [bitstampService]
Go
USE [bitstampService]
GO
/****** Object:  Table [dbo].[BTC_USD]    Script Date: 1/26/2018 2:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BTC_USD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Open] [varchar](50) NULL,
	[Last] [varchar](50) NULL,
	[Hight] [varchar](50) NULL,
	[Low] [varchar](50) NULL,
	[Volume] [varchar](50) NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_BTC_USD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ETH_BTC]    Script Date: 1/26/2018 2:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ETH_BTC](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Open] [varchar](50) NULL,
	[Last] [varchar](50) NULL,
	[Hight] [varchar](50) NULL,
	[Low] [varchar](50) NULL,
	[Volume] [varchar](50) NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_ETH_BTC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ETH_USD]    Script Date: 1/26/2018 2:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ETH_USD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Open] [varchar](50) NULL,
	[Last] [varchar](50) NULL,
	[Hight] [varchar](50) NULL,
	[Low] [varchar](50) NULL,
	[Volume] [varchar](50) NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_ETH_USD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER DATABASE [bitstampService] SET  READ_WRITE 
GO
