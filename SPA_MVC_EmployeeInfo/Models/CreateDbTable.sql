USE [master]
GO

/****** Object:  Database [SchoolManagement]    Script Date: 10/20/2015 4:43:25 PM ******/
DROP DATABASE [SchoolManagement]
GO

/****** Object:  Database [SchoolManagement]    Script Date: 10/20/2015 4:43:25 PM ******/
CREATE DATABASE [SchoolManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSQLSERVER20SERVER2012\MSSQL\DATA\SchoolManagement.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SchoolManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSQLSERVER20SERVER2012\MSSQL\DATA\SchoolManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [SchoolManagement] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SchoolManagement] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SchoolManagement] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SchoolManagement] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SchoolManagement] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SchoolManagement] SET ARITHABORT OFF 
GO

ALTER DATABASE [SchoolManagement] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SchoolManagement] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [SchoolManagement] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SchoolManagement] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SchoolManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SchoolManagement] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SchoolManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SchoolManagement] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SchoolManagement] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SchoolManagement] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SchoolManagement] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SchoolManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SchoolManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SchoolManagement] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SchoolManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SchoolManagement] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SchoolManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SchoolManagement] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SchoolManagement] SET RECOVERY FULL 
GO

ALTER DATABASE [SchoolManagement] SET  MULTI_USER 
GO

ALTER DATABASE [SchoolManagement] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SchoolManagement] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SchoolManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SchoolManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [SchoolManagement] SET  READ_WRITE 
GO

USE [SchoolManagement]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 10/20/2015 4:47:21 PM ******/
DROP TABLE [dbo].[Student]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 10/20/2015 4:47:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](500) NULL,
	[Class] [varchar](50) NULL,
	[EnrollYear] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
