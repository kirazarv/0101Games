USE [master]
GO
/****** Object:  Database [games]    Script Date: 15.04.2025 13:30:30 ******/
CREATE DATABASE [games]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'games', FILENAME = N'D:\Program Files\Microsoft SQL server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\games.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'games_log', FILENAME = N'D:\Program Files\Microsoft SQL server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\games_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [games] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [games].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [games] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [games] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [games] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [games] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [games] SET ARITHABORT OFF 
GO
ALTER DATABASE [games] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [games] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [games] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [games] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [games] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [games] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [games] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [games] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [games] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [games] SET  DISABLE_BROKER 
GO
ALTER DATABASE [games] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [games] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [games] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [games] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [games] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [games] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [games] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [games] SET RECOVERY FULL 
GO
ALTER DATABASE [games] SET  MULTI_USER 
GO
ALTER DATABASE [games] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [games] SET DB_CHAINING OFF 
GO
ALTER DATABASE [games] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [games] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [games] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [games] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'games', N'ON'
GO
ALTER DATABASE [games] SET QUERY_STORE = ON
GO
ALTER DATABASE [games] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [games]
GO
/****** Object:  Table [dbo].[Developer]    Script Date: 15.04.2025 13:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Developer](
	[DeveloperId] [int] IDENTITY(1,1) NOT NULL,
	[DeveloperName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Developer] PRIMARY KEY CLUSTERED 
(
	[DeveloperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 15.04.2025 13:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[GameId] [int] IDENTITY(1,1) NOT NULL,
	[GameTitle] [nvarchar](50) NOT NULL,
	[GenreId] [int] NOT NULL,
	[DeveloperId] [int] NOT NULL,
	[GameDescription] [nvarchar](500) NULL,
	[GamePrice] [float] NOT NULL,
	[GameDiscount] [float] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 15.04.2025 13:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Developer] ON 

INSERT [dbo].[Developer] ([DeveloperId], [DeveloperName]) VALUES (1, N'Epic Games')
INSERT [dbo].[Developer] ([DeveloperId], [DeveloperName]) VALUES (2, N'Infinity Ward')
INSERT [dbo].[Developer] ([DeveloperId], [DeveloperName]) VALUES (3, N'Riot Games')
SET IDENTITY_INSERT [dbo].[Developer] OFF
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([GameId], [GameTitle], [GenreId], [DeveloperId], [GameDescription], [GamePrice], [GameDiscount]) VALUES (1, N'Fortnite', 1, 1, N'Fortnite — это многопользовательская игра, в которой игроки сражаются друг 
другом в поисках выживания на огромной карте. Постройте укрепления, соберите
ресурсы и сразитесь с другими игроками в этом захватывающем баттл-рояле.', 0, 0)
INSERT [dbo].[Game] ([GameId], [GameTitle], [GenreId], [DeveloperId], [GameDescription], [GamePrice], [GameDiscount]) VALUES (2, N'Call of Duty:Warzone', 2, 2, N'Call of Duty: Warzone — это бесплатная многопользовательская игра, в которой
игроки сражаются друг с другом в горячих боях. Выберите своего персонажа,
соберите оружие и примкните к борьбе за выживание в этом адреналиновом баттл-
рояле от известной серии Call of Duty.', 0, 0)
INSERT [dbo].[Game] ([GameId], [GameTitle], [GenreId], [DeveloperId], [GameDescription], [GamePrice], [GameDiscount]) VALUES (3, N'League of Legends', 3, 3, N'League of Legends — это многопользовательская онлайн-игра, в которой дее
команды сражаются друг с другом в захезтывающих сражениях на аренах. Выберите
своего героя, развивайте его умения и сражайтесь за победу в этой популярной 
МОВА игре.', 2000, 0)
SET IDENTITY_INSERT [dbo].[Game] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (1, N'Battle Royale')
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (2, N'Casual')
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (3, N'MOBA')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Developer] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[Developer] ([DeveloperId])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Developer]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([GenreId])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Genre]
GO
USE [master]
GO
ALTER DATABASE [games] SET  READ_WRITE 
GO
