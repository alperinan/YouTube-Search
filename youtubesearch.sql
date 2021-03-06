USE [master]
GO
/****** Object:  Database [YoutubeSearch]    Script Date: 07/16/2017 16:10:41 ******/
CREATE DATABASE [YoutubeSearch] ON  PRIMARY 
( NAME = N'YoutubeSearch', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\YoutubeSearch.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'YoutubeSearch_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\YoutubeSearch_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [YoutubeSearch] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YoutubeSearch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YoutubeSearch] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [YoutubeSearch] SET ANSI_NULLS OFF
GO
ALTER DATABASE [YoutubeSearch] SET ANSI_PADDING OFF
GO
ALTER DATABASE [YoutubeSearch] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [YoutubeSearch] SET ARITHABORT OFF
GO
ALTER DATABASE [YoutubeSearch] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [YoutubeSearch] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [YoutubeSearch] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [YoutubeSearch] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [YoutubeSearch] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [YoutubeSearch] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [YoutubeSearch] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [YoutubeSearch] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [YoutubeSearch] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [YoutubeSearch] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [YoutubeSearch] SET  DISABLE_BROKER
GO
ALTER DATABASE [YoutubeSearch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [YoutubeSearch] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [YoutubeSearch] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [YoutubeSearch] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [YoutubeSearch] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [YoutubeSearch] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [YoutubeSearch] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [YoutubeSearch] SET  READ_WRITE
GO
ALTER DATABASE [YoutubeSearch] SET RECOVERY SIMPLE
GO
ALTER DATABASE [YoutubeSearch] SET  MULTI_USER
GO
ALTER DATABASE [YoutubeSearch] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [YoutubeSearch] SET DB_CHAINING OFF
GO
USE [YoutubeSearch]
GO
/****** Object:  Table [dbo].[searchResults]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[searchResults](
	[searchId] [int] IDENTITY(1,1) NOT NULL,
	[seachDateTime] [datetime] NULL,
 CONSTRAINT [PK_searchResults] PRIMARY KEY CLUSTERED 
(
	[searchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[searchResults] ON
INSERT [dbo].[searchResults] ([searchId], [seachDateTime]) VALUES (1, CAST(0x0000A62100037666 AS DateTime))
INSERT [dbo].[searchResults] ([searchId], [seachDateTime]) VALUES (2, CAST(0x0000A62100CCA601 AS DateTime))
INSERT [dbo].[searchResults] ([searchId], [seachDateTime]) VALUES (3, CAST(0x0000A62100E33361 AS DateTime))
SET IDENTITY_INSERT [dbo].[searchResults] OFF
/****** Object:  Table [dbo].[searchFilters]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[searchFilters](
	[filterDuration] [int] NULL,
	[channelSubsCountMin] [int] NULL,
	[channelSubsCountMax] [int] NULL,
	[channelVideoCountMin] [int] NULL,
	[channelVideoCountMax] [int] NULL,
	[maxresultCount] [int] NULL,
	[maxPageCount] [int] NULL,
	[sortBy] [int] NULL,
	[publishedAfter] [datetime] NULL,
	[publishedBefore] [datetime] NULL,
	[filterUploadDate] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[searchFilters] ([filterDuration], [channelSubsCountMin], [channelSubsCountMax], [channelVideoCountMin], [channelVideoCountMax], [maxresultCount], [maxPageCount], [sortBy], [publishedAfter], [publishedBefore], [filterUploadDate]) VALUES (1, 100, 0, 100, 0, 40, 1, 0, CAST(0xFFFF715400000000 AS DateTime), CAST(0xFFFF715400000000 AS DateTime), N'radioThisYear')
/****** Object:  Table [dbo].[searchDetails]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[searchDetails](
	[searchDetailId] [int] IDENTITY(1,1) NOT NULL,
	[searchId] [int] NOT NULL,
	[videoId] [nvarchar](100) NULL,
	[videoTitle] [nvarchar](500) NULL,
	[videoViewCount] [float] NULL,
	[videoLikeCount] [float] NULL,
	[publishedAt] [datetime] NULL,
	[channelId] [nvarchar](100) NULL,
	[totalVideoCount] [float] NULL,
	[totalViewCount] [float] NULL,
	[totalSubscriber] [float] NULL,
	[keyword] [nvarchar](300) NULL,
	[attribution] [nvarchar](300) NULL,
 CONSTRAINT [PK_searchDetails] PRIMARY KEY CLUSTERED 
(
	[searchDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_searchDetails] ON [dbo].[searchDetails] 
(
	[searchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[searchDetails] ON
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (1, 1, N'pEXmZUtzacU', N'Batman: Return to Arkham Graphics Comparison', 869672, 8832, CAST(0x0000A60D00559FEC AS DateTime), N'UCl2Ae8IzmEusR43OL9HNcKQ', 924, 179528885, 450593, N'batman arkham city', N'FullScreen')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (2, 1, N'PE3-rCeSxo8', N'Top 10 Batman Arkham Series Boss Battles', 697866, 12074, CAST(0x0000A58B01391D6C AS DateTime), N'UCaWd5_7JhbQBe4dknZhsHJg', 10912, 6147456507, 12154409, N'batman arkham city', N'watchmojo')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (3, 1, N'nPYBTPBlG30', N'Batman Arkham Asylum - Did You Know Gaming? Feat. WeeklyTubeShow', 626064, 16705, CAST(0x0000A5B100F115F8 AS DateTime), N'UCyS4xQE6DK4_p3qXQwJQAyA', 212, 271427533, 1996288, N'batman arkham city', N'screenwavemedia_managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (4, 1, N'BdG4YzVTlMU', N'BATMAN V SUPERMAN SKIN - Batman Arkham Knight Walkthrough Gameplay Part 51 (PS4)', 584615, 12897, CAST(0x0000A58B01204350 AS DateTime), N'UCpqXJOEqGS-TCnazcHCo0rA', 4484, 2176697877, 6064336, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (5, 1, N'BEFjOSqZxS0', N'BATMAN BEYOND SKIN - Batman Arkham Knight Walkthrough Gameplay Part 50 (PS4)', 568543, 12418, CAST(0x0000A589011826C0 AS DateTime), N'UCpqXJOEqGS-TCnazcHCo0rA', 4484, 2176697877, 6064336, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (6, 1, N'SF5hlj7ZadE', N'BATMAN: ARKHAM KNIGHT (Honest Game Trailers en Español)', 350666, 15683, CAST(0x0000A58D00DCD598 AS DateTime), N'UCgESfl93BM2y85abdt8BcZw', 577, 505936433, 2590469, N'batman arkham city', N'Break')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (7, 1, N'0ImIr9JRTJg', N'ROBIN - Batman Arkham Knight Complete Walkthrough Gameplay & Ending (PS4)', 344048, 8648, CAST(0x0000A58E01162C80 AS DateTime), N'UCpqXJOEqGS-TCnazcHCo0rA', 4484, 2176697877, 6064336, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (8, 1, N'cqVVV8N06Yk', N'ENDING - Season of Infamy Batman Arkham Knight Ra''s Al Ghul Walkthrough Gameplay Part 2 (PS4)', 335312, 8234, CAST(0x0000A586015A11C0 AS DateTime), N'UCpqXJOEqGS-TCnazcHCo0rA', 4484, 2176697877, 6064336, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (9, 1, N'E2mGWCeZURM', N'BATMAN: ARKHAM ASYLUM (Honest Game Trailers en Español)', 320649, 14748, CAST(0x0000A58600DA70B4 AS DateTime), N'UCgESfl93BM2y85abdt8BcZw', 577, 505936433, 2590469, N'batman arkham city', N'Break')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (10, 1, N'hUh19bOus-4', N'RA''S AL GHUL - Season of Infamy Batman Arkham Knight Walkthrough Gameplay Part 1 (PS4)', 320507, 9224, CAST(0x0000A586011DC24C AS DateTime), N'UCpqXJOEqGS-TCnazcHCo0rA', 4484, 2176697877, 6064336, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (11, 1, N'zhBz9IbuHBE', N'FINALE DI SERIE - BATMAN - Arkham Asylum !!!', 94262, 10836, CAST(0x0000A61900C5C484 AS DateTime), N'UC1jTVZboWRPpjGKAN921M5w', 2951, 319979102, 1298096, N'batman arkham city', N'TomsHardwareItalia%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (12, 1, N'zhq4LhkVMV8', N'Batman - Arkham Asylum - 8°: ma Quanto è Bona Poison iVY?', 82768, 6686, CAST(0x0000A60800C5C358 AS DateTime), N'UC1jTVZboWRPpjGKAN921M5w', 2951, 319979102, 1298096, N'batman arkham city', N'TomsHardwareItalia%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (13, 1, N'76uw_pWbdFA', N'AS GOSTOSAS DA SAGA BATMAN ARKHAM!', 77894, 5983, CAST(0x0000A60800D63BC0 AS DateTime), N'UCNKRJBAHTjnK3y0ThOg1uNw', 441, 17505911, 254862, N'batman arkham city', N'Paramaker_Affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (14, 1, N'oKDEYihSloY', N'Batman - Arkham Asylum - 11°: La Tana di Crick e Crock!', 74387, 6438, CAST(0x0000A61500C5C358 AS DateTime), N'UC1jTVZboWRPpjGKAN921M5w', 2951, 319979102, 1298096, N'batman arkham city', N'TomsHardwareItalia%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (15, 1, N'0QZmEeWuNcg', N'Batman - Arkham Asylum - 7°: Tremendi Ricordi.', 68382, 6369, CAST(0x0000A60700735B40 AS DateTime), N'UC1jTVZboWRPpjGKAN921M5w', 2951, 319979102, 1298096, N'batman arkham city', N'TomsHardwareItalia%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (16, 1, N'eiZLb5gXOt4', N'Batman - Arkham Asylum - 10°: R.I.P Bruce Wayne.', 66521, 6201, CAST(0x0000A61400C5C358 AS DateTime), N'UC1jTVZboWRPpjGKAN921M5w', 2951, 319979102, 1298096, N'batman arkham city', N'TomsHardwareItalia%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (17, 1, N'D_Gv5bjjjpc', N'DLC KILLER CROC: SOTTO LA SUPERFICIE! [Batman Arkham Knight] By GiosephTheGamer', 63612, 5055, CAST(0x0000A588007B98A0 AS DateTime), N'UCyYj7brPoaX6PNT0iUW6RhA', 1759, 55277943, 221379, N'batman arkham city', N'machinima')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (18, 1, N'Rvm8iPkdTi8', N'Batman Arkham Knight: DLC Batcave (NIGHTWING Classic)', 59128, 1293, CAST(0x0000A59A017137EC AS DateTime), N'UCmzwIHGPWtxd3SgNG9qlctg', 1592, 118464455, 273228, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (19, 1, N'Sx2Fo_XQtvs', N'$230 BATMAN: ARKHAM CITY HOT TOYS UNBOXING (that voice you hate)', 47783, 1616, CAST(0x0000A5CF015A85C4 AS DateTime), N'UCz981RxgS-A2ID99W8wXzTA', 295, 20577594, 275261, N'batman arkham city', N'Collective')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (20, 1, N'hIHX4uEPst0', N'Batman: Arkham City: Superman meets Wonder Woman and gets a Knightmare', 46713, 151, CAST(0x0000A5CE0070AEE0 AS DateTime), N'UCXrs7DLP0GCrqVF3fLqydZQ', 227, 2409641, 3082, N'batman arkham city', N'MakerCurse')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (21, 1, N'-KD0RAwY6PQ', N'Batman Arkham Knight Todos los Trajes (Skins) de Batman', 45643, 971, CAST(0x0000A59E009827F4 AS DateTime), N'UCWv-0hCp1C3g3OXkY6ssyvQ', 2743, 171808625, 351511, N'batman arkham city', N'adrevuppm')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (22, 1, N'bVV0k2pod8Q', N'SPRUKITS - BATMAN: ARKHAM CITY UNBOXING!!!', 36141, 1934, CAST(0x0000A5C7006CCBF4 AS DateTime), N'UCs95gwav7frv5HTVqAGa7uQ', 4100, 203561861, 798597, N'batman arkham city', N'Outspeak')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (23, 1, N'pXA-Hpnkf_U', N'Masa Kecil Batman - Batman Arkham Asylum - Indonesia Part 7', 34635, 619, CAST(0x0000A584008DFC0C AS DateTime), N'UC3J4Q1grz46bdJ7NJLd4DGw', 824, 29001799, 157395, N'batman arkham city', N'3J4Q1grz46bdJ7NJLd4DGw')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (24, 1, N'da3lWcu2e_4', N'SKIN; Batman; Arkham City; Batman Beyond 2039 Style', 34842, 250, CAST(0x0000A5BF008A2AB4 AS DateTime), N'UCdSTlFGJqkLceN-Gm0bckPw', 817, 9334990, 15601, N'batman arkham city', N'FOXITAL_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (25, 1, N'PCteWe963TA', N'SKIN; Batman; Arkham City; Deadpool Styled Batsuit v1', 33541, 190, CAST(0x0000A5DF00F0210C AS DateTime), N'UCdSTlFGJqkLceN-Gm0bckPw', 817, 9334990, 15601, N'batman arkham city', N'FOXITAL_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (26, 1, N'F3FRHg535z0', N'Batman Arkham Asylum: Batman v Superman Suit Mod', 27106, 256, CAST(0x0000A58800EEF3E0 AS DateTime), N'UC7CsXoSmY0NcgKem8gZylHw', 928, 14678303, 34862, N'batman arkham city', N'RPMNetworks')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (27, 1, N'uG9fhs2ftCg', N'Batman Arkham HD Remaster Leaked?!', 26916, 1146, CAST(0x0000A5EC01097508 AS DateTime), N'UCWkdg1JlFH--qu0HVN_RBow', 758, 35778897, 114070, N'batman arkham city', N'FullScreen')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (28, 1, N'KMEWUWSFByU', N'SKIN; Batman; Arkham City; Deadpool', 26917, 243, CAST(0x0000A5CF00671448 AS DateTime), N'UCdSTlFGJqkLceN-Gm0bckPw', 817, 9334990, 15601, N'batman arkham city', N'FOXITAL_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (29, 1, N'4Xdun6Qw2Z4', N'Český GamePlay | Batman: Arkham Knight - Harley Quinn Story Pack | 1080p', 25231, 1415, CAST(0x0000A58100BF32E0 AS DateTime), N'UCL0s93LjCyW3bHa5casuojQ', 929, 67594295, 360038, N'batman arkham city', N'FlyGunCZ%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (30, 1, N'nGFfagc-7jg', N'SKIN; Batman; Arkham City; Bat-Robin', 25600, 146, CAST(0x0000A59C0067A7F0 AS DateTime), N'UCdSTlFGJqkLceN-Gm0bckPw', 817, 9334990, 15601, N'batman arkham city', N'FOXITAL_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (31, 1, N'NMqnNM_WsfQ', N'How to Make Batman''s Gauntlets (based on Arkham City)', 24625, 254, CAST(0x0000A5B2009C8F4C AS DateTime), N'UC2XIaI2fGf4zPGyyRgFNJVQ', 162, 2445090, 15952, N'batman arkham city', N'2XIaI2fGf4zPGyyRgFNJVQ')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (32, 1, N'2oIqJbUpqVA', N'Batman: Arkham City: Lex Luthor Mod!', 24206, 94, CAST(0x0000A5D1009ACD4C AS DateTime), N'UCXrs7DLP0GCrqVF3fLqydZQ', 227, 2409641, 3082, N'batman arkham city', N'MakerCurse')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (33, 1, N'B77tZRCCrqw', N'Бэтман Vs Пиг - Прохождение Batman Arkham Knight на PS4 [эпизод #39]', 22553, 243, CAST(0x0000A5D700F84BAC AS DateTime), N'UCC9YwiDqKWy1rUfF1wefReQ', 805, 42073289, 68034, N'batman arkham city', N'TopBeautyBlog')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (34, 1, N'jjBfHWl9VHs', N'Batman Arkham Knight | Episodios de Arkham DLC Nightwing | Cierre Total del CPGC - Gameplay Español', 20661, 478, CAST(0x0000A580011826C0 AS DateTime), N'UCWv-0hCp1C3g3OXkY6ssyvQ', 2743, 171808625, 351511, N'batman arkham city', N'To Be Added')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (35, 1, N'baIKejXDnQE', N'MESH; Batman; Arkham Knight; Asylum Croc Vs Knight Croc', 20074, 204, CAST(0x0000A59D006260C4 AS DateTime), N'UCdSTlFGJqkLceN-Gm0bckPw', 817, 9334990, 15601, N'batman arkham city', N'FOXITAL_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (36, 1, N'E7g9LAUrO1E', N'Orijinal adana kebabi tarifi- Adana kebabi nasil yapilir? -Et-köfte ve kebab tarifleri', 8989, 212, CAST(0x0000A61B005096DC AS DateTime), N'UCLdjKcDxs6uH0emwEZrvaHw', 236, 6003084, 31034, N'adana kebab', N'Club_of_Cooks')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (37, 1, N'1A-85VqnJmE', N'En Güzel İftar Yemekleri /Adana kebap evde nasıl yapılır ?', 434, 26, CAST(0x0000A5E20042039C AS DateTime), N'UCBmIfqXpICt9DYdKFkCQZ4Q', 192, 42062, 472, N'adana kebab', N'BmIfqXpICt9DYdKFkCQZ4Q')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (38, 1, N'AZUGB4rJ5zg', N'How To Make, Cook Adana Kebab   كيف تعمل كباب تركي', 50, 2, CAST(0x0000A5E0010C6560 AS DateTime), N'UC3hEYkvM8Lh3fpHENyCAzcw', 164, 379353, 321, N'adana kebab', N'To Be Added')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (39, 1, N'O70Ww9vzjvg', N'Tape Face: Strange Act Leaves the Audience Speechless - America''s Got Talent 2016 Auditions', 22452828, 298065, CAST(0x0000A6170151D58C AS DateTime), N'UCT2X19JJaJGUN7mrYuImANQ', 917, 574603451, 2666233, N'full episodes 2016', N'fremantle')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (40, 1, N'kJMWaO5Zfy0', N'Oggy and the Cockroaches - Oggy’s Double (S03E34) Full Episode in HD', 12420294, 16246, CAST(0x0000A58B00B3649C AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (41, 1, N'rMYZx6pxJLk', N'Oggy and the Cockroaches - Inside out  (S3E16) Full Episode in HD', 9616746, 12058, CAST(0x0000A5C3003AB420 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (42, 1, N'SuPN2iGsO5k', N'Zig & Sharko - King Neptune''s court (S01E03) Full Episode in HD', 6835810, 9422, CAST(0x0000A5F00042ECD0 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (43, 1, N'4OhLE-DO5WE', N'Oggy and the Cockroaches - The Ancestor (S03E24) Full Episode in HD', 6674312, 9460, CAST(0x0000A58700AC5918 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (44, 1, N'TV-oJCjbWCQ', N'Oggy and the Cockroaches - WALLS HAVE EARS (S2E119) Full Episode in HD', 6471912, 8433, CAST(0x0000A5BC0040464C AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (45, 1, N'hsFKGAHReP0', N'blaze and the monster machines in english. Learning full Patterns episode 1 with Blaze', 4644028, 2489, CAST(0x0000A5D2009C8F4C AS DateTime), N'UCnDJuqZrVSWyuD0zKnEmnQQ', 108, 16353669, 23607, N'full episodes 2016', N'nDJuqZrVSWyuD0zKnEmnQQ')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (46, 1, N'xzx4u9jpTAM', N'Zig & Sharko - MERMAID’S PUP (S1E07) _ Full Episode in HD', 4459799, 5810, CAST(0x0000A5D4009EE878 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (47, 1, N'VorxBhRxZGo', N'Black Jeopardy with Drake - SNL', 4299143, 35496, CAST(0x0000A607002BABB0 AS DateTime), N'UCqFzWxSCi39LnW1JKFR3efg', 5598, 1245321819, 2455642, N'full episodes 2016', N'NBCU_Shows')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (48, 1, N'QPOQr1h7Sbc', N'Oggy and the Cockroaches - Nine months and counting  (S1E18) Full Episode in HD', 3817500, 5858, CAST(0x0000A5E6003CC24C AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (49, 1, N'x4-BC77FB4A', N'Oggy and the Cockroaches - Invincible (S3E13) Full Episode in HD', 3748932, 5988, CAST(0x0000A5C6004ABC08 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (50, 1, N'gj9wRHOl7ZI', N'Oggy and the Cockroaches - Happy birthday (S1E10) Full Episode in HD', 3140946, 4367, CAST(0x0000A5F000454728 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (51, 1, N'SegVnJgF6yk', N'Zig & Sharko - Bernie moves house (S01E70) _ Full Episode in HD', 3025720, 4117, CAST(0x0000A5CD005110BC AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (52, 1, N'D0h_l4XsOSo', N'Zig & Sharko - SHARKO AND HIS FOLKS (S01E50) _ Full Episode in HD', 2696318, 3965, CAST(0x0000A58E00403BC0 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (53, 1, N'lAv4oY0aYn8', N'Peppa Pig Full Episodes - Peppa Pig Injured | Peppa Pig English Episodes', 2353506, 719, CAST(0x0000A58401391C40 AS DateTime), N'UCxVvKbJveH8CK9ykW5d60nQ', 336, 32743468, 32699, N'full episodes 2016', N'Kickback')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (54, 1, N'VSr_BbvXOOk', N'Oggy and the Cockroaches - The Fugitive  (S3E18) Full Episode in HD', 2321182, 3765, CAST(0x0000A602003EC4C0 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (55, 1, N'mRrztLsWeuA', N'Oggy and the Cockroaches - Baby Doll (S1E21) Full Episode in HD', 2287015, 3568, CAST(0x0000A5DF003733A4 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (56, 1, N'Oug0tO3XVJM', N'Oggy and the Cockroaches - THE RISE AND THE FALL  (S1E8) Full Episode in HD', 2178908, 3406, CAST(0x0000A5B800419A24 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (57, 1, N'oy2Dn9mfnYs', N'Zig & Sharko - FREEDOM FOR MARINA! (S01E39) _ Full Episode in HD', 2135249, 2853, CAST(0x0000A5B10094D8B0 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (58, 1, N'82B0V75zQXI', N'Zig & Sharko - Bristlebeard''s Adventure (S1E63) _ Full episode in HD', 1873732, 2090, CAST(0x0000A605003AABEC AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (59, 1, N'uPbNSwifO8Y', N'Zig & Sharko - THE HORRIBLY HUNGRY HYENA (S01E19) _ Full Episode in HD', 1846708, 2986, CAST(0x0000A5B80095BE60 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (60, 1, N'GOwLSe8YkJE', N'Oggy and the Cockroaches - LIFE''S A BEACH  (S2E92) Full Episode in HD', 1781869, 3032, CAST(0x0000A5FF004A2860 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (61, 1, N'_lsvmj4SL9g', N'Tashan-e-Ishq - Episode 231  - May 26, 2016 - Webisode', 1768421, 2631, CAST(0x0000A612012DFEF0 AS DateTime), N'UCppHT7SZKKvar4Oc9J4oljQ', 59596, 4745940916, 3895904, N'full episodes 2016', N'dmcl')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (62, 1, N'DEeeB5nsGvU', N'Zig & Sharko - The Challengers (S01E34) Full Episode in HD', 1719011, 2329, CAST(0x0000A5E9005265C0 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 119, 142250338, 167083, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (63, 1, N'MnZA_jaMLhs', N'NAAGIN - 5th June 2016 | Full Uncut | Episode On Location | Nagin - Colors Tv New Serial News', 1635729, 1795, CAST(0x0000A5B701761474 AS DateTime), N'UCToZTtSLYLyRV5xwUcAa9Kg', 4147, 72602254, 82623, N'full episodes 2016', N'TheOnlineInc')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (64, 1, N'dXxihrlnkR8', N'Oggy and the Cockroaches - Blue Sunday (S1E66) Full Episode in HD', 1594201, 2817, CAST(0x0000A5ED00605D24 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (65, 1, N'1IPvMfiM0oo', N'Oggy and the Cockroaches - SPACE ROACHES (S01E39) Full Episode in HD', 1535146, 2685, CAST(0x0000A59500882390 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (66, 1, N'MM34Q5umO0Q', N'Oggy and the Cockroaches - PHARONUF  (S2E130) Full Episode in HD', 1531291, 2451, CAST(0x0000A5B500487EFC AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (67, 1, N'Ib0luf5fhdY', N'PAW Patrol AIR PATROLLER! English Cartoon - Paw Patrol Full Episodes [Nick Jr.]', 1371618, 676, CAST(0x0000A5C90148A7F0 AS DateTime), N'UC4tCQThd7cL8y2zgg9Wp-dQ', 563, 6199758, 5287, N'full episodes 2016', N'To Be Added')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (68, 1, N'zyCxMCU8r1A', N'Oggy and the Cockroaches - The carnival''s in town (S1E45) Full Episode in HD', 1355782, 2410, CAST(0x0000A605007F6548 AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (69, 1, N'Bs8YZRKpg4Q', N'Oggy and the Cockroaches - BITTER CHOCOLATE (S01E01) Full Episode in HD', 1319681, 2066, CAST(0x0000A58400A2BAFC AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 169, 682910806, 729606, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (70, 1, N'1v2abRgyv3Q', N'Kumkum Bhagya - Episode 464  - January 13, 2016 - Webisode', 1309748, 3016, CAST(0x0000A58C010AEADC AS DateTime), N'UCppHT7SZKKvar4Oc9J4oljQ', 59596, 4745940916, 3895904, N'full episodes 2016', N'dmcl')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (71, 1, N'tJNOYa_6Dz0', N'Vegeta versus Hit, the Legendary Hitman. Full Fight! Dragon Ball Super Episode 38', 1285179, 4928, CAST(0x0000A5E3015FB0D0 AS DateTime), N'UCtF0Rkk2zhNOkrUolkTo1yQ', 140, 18100360, 22748, N'full episodes 2016', N'Toei_Animation_JP')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (72, 2, N'PE3-rCeSxo8', N'Top 10 Batman Arkham Series Boss Battles', 698334, 12077, CAST(0x0000A58B01391D6C AS DateTime), N'UCaWd5_7JhbQBe4dknZhsHJg', 10914, 6156080277, 12159226, N'batman arkham city', N'watchmojo')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (73, 2, N'nPYBTPBlG30', N'Batman Arkham Asylum - Did You Know Gaming? Feat. WeeklyTubeShow', 626550, 16706, CAST(0x0000A5B100F115F8 AS DateTime), N'UCyS4xQE6DK4_p3qXQwJQAyA', 212, 271708408, 1996955, N'batman arkham city', N'screenwavemedia_managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (74, 2, N'BdG4YzVTlMU', N'BATMAN V SUPERMAN SKIN - Batman Arkham Knight Walkthrough Gameplay Part 51 (PS4)', 585115, 12900, CAST(0x0000A58B01204350 AS DateTime), N'UCpqXJOEqGS-TCnazcHCo0rA', 4484, 2177929160, 6066426, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (75, 2, N'SF5hlj7ZadE', N'BATMAN: ARKHAM KNIGHT (Honest Game Trailers en Español)', 350913, 15684, CAST(0x0000A58D00DCD598 AS DateTime), N'UCgESfl93BM2y85abdt8BcZw', 577, 506281557, 2590668, N'batman arkham city', N'Break')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (76, 2, N'zhBz9IbuHBE', N'FINALE DI SERIE - BATMAN - Arkham Asylum !!!', 94767, 10862, CAST(0x0000A61900C5C484 AS DateTime), N'UC1jTVZboWRPpjGKAN921M5w', 2954, 320951760, 1300134, N'batman arkham city', N'TomsHardwareItalia%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (77, 2, N'VEY7IV2mr0w', N'Batman Arkham Knight: 2016 Batman V Superman Suit in the Final Scene', 93342, 584, CAST(0x0000A5AB00883FB0 AS DateTime), N'UCGW64BzOZSVeKEgB0AZFm2w', 345, 1395117, 4407, N'batman arkham city', N'anytv_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (78, 2, N'76uw_pWbdFA', N'AS GOSTOSAS DA SAGA BATMAN ARKHAM!', 78286, 5992, CAST(0x0000A60800D63BC0 AS DateTime), N'UCNKRJBAHTjnK3y0ThOg1uNw', 441, 17658620, 255777, N'batman arkham city', N'Paramaker_Affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (79, 2, N'D_Gv5bjjjpc', N'DLC KILLER CROC: SOTTO LA SUPERFICIE! [Batman Arkham Knight] By GiosephTheGamer', 63714, 5055, CAST(0x0000A588007B98A0 AS DateTime), N'UCyYj7brPoaX6PNT0iUW6RhA', 1760, 55426779, 221908, N'batman arkham city', N'machinima')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (80, 2, N'Rvm8iPkdTi8', N'Batman Arkham Knight: DLC Batcave (NIGHTWING Classic)', 59220, 1293, CAST(0x0000A59A017137EC AS DateTime), N'UCmzwIHGPWtxd3SgNG9qlctg', 1592, 118538485, 273320, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (81, 2, N'Sx2Fo_XQtvs', N'$230 BATMAN: ARKHAM CITY HOT TOYS UNBOXING (that voice you hate)', 47816, 1620, CAST(0x0000A5CF015A85C4 AS DateTime), N'UCz981RxgS-A2ID99W8wXzTA', 295, 20595577, 275329, N'batman arkham city', N'Collective')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (82, 2, N'hIHX4uEPst0', N'Batman: Arkham City: Superman meets Wonder Woman and gets a Knightmare', 46869, 151, CAST(0x0000A5CE0070AEE0 AS DateTime), N'UCXrs7DLP0GCrqVF3fLqydZQ', 228, 2425105, 3089, N'batman arkham city', N'MakerCurse')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (83, 2, N'-KD0RAwY6PQ', N'Batman Arkham Knight Todos los Trajes (Skins) de Batman', 45800, 973, CAST(0x0000A59E009827F4 AS DateTime), N'UCWv-0hCp1C3g3OXkY6ssyvQ', 2743, 172000293, 351659, N'batman arkham city', N'adrevuppm')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (84, 2, N'bVV0k2pod8Q', N'SPRUKITS - BATMAN: ARKHAM CITY UNBOXING!!!', 36146, 1934, CAST(0x0000A5C7006CCBF4 AS DateTime), N'UCs95gwav7frv5HTVqAGa7uQ', 4100, 203955959, 798971, N'batman arkham city', N'Outspeak')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (85, 2, N'da3lWcu2e_4', N'SKIN; Batman; Arkham City; Batman Beyond 2039 Style', 34968, 250, CAST(0x0000A5BF008A2AB4 AS DateTime), N'UCdSTlFGJqkLceN-Gm0bckPw', 817, 9355674, 15617, N'batman arkham city', N'FOXITAL_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (86, 2, N'pXA-Hpnkf_U', N'Masa Kecil Batman - Batman Arkham Asylum - Indonesia Part 7', 34886, 622, CAST(0x0000A584008DFC0C AS DateTime), N'UC3J4Q1grz46bdJ7NJLd4DGw', 825, 29210600, 158094, N'batman arkham city', N'3J4Q1grz46bdJ7NJLd4DGw')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (87, 2, N'F3FRHg535z0', N'Batman Arkham Asylum: Batman v Superman Suit Mod', 27130, 256, CAST(0x0000A58800EEF3E0 AS DateTime), N'UC7CsXoSmY0NcgKem8gZylHw', 928, 14710576, 34901, N'batman arkham city', N'RPMNetworks')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (88, 2, N'uG9fhs2ftCg', N'Batman Arkham HD Remaster Leaked?!', 26923, 1146, CAST(0x0000A5EC01097508 AS DateTime), N'UCWkdg1JlFH--qu0HVN_RBow', 758, 35832276, 114144, N'batman arkham city', N'FullScreen')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (89, 2, N'4Xdun6Qw2Z4', N'Český GamePlay | Batman: Arkham Knight - Harley Quinn Story Pack | 1080p', 25234, 1415, CAST(0x0000A58100BF32E0 AS DateTime), N'UCL0s93LjCyW3bHa5casuojQ', 929, 67623684, 360274, N'batman arkham city', N'FlyGunCZ%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (90, 2, N'NMqnNM_WsfQ', N'How to Make Batman''s Gauntlets (based on Arkham City)', 24696, 254, CAST(0x0000A5B2009C8F4C AS DateTime), N'UC2XIaI2fGf4zPGyyRgFNJVQ', 162, 2452132, 15974, N'batman arkham city', N'2XIaI2fGf4zPGyyRgFNJVQ')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (91, 2, N'B77tZRCCrqw', N'Бэтман Vs Пиг - Прохождение Batman Arkham Knight на PS4 [эпизод #39]', 22581, 243, CAST(0x0000A5D700F84BAC AS DateTime), N'UCC9YwiDqKWy1rUfF1wefReQ', 805, 42104075, 68081, N'batman arkham city', N'TopBeautyBlog')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (92, 2, N'E7g9LAUrO1E', N'Orijinal adana kebabi tarifi- Adana kebabi nasil yapilir? -Et-köfte ve kebab tarifleri', 9425, 216, CAST(0x0000A61B005096DC AS DateTime), N'UCLdjKcDxs6uH0emwEZrvaHw', 238, 6092291, 31358, N'adana kebab', N'Club_of_Cooks')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (93, 2, N'1A-85VqnJmE', N'En Güzel İftar Yemekleri /Adana kebap evde nasıl yapılır ?', 441, 26, CAST(0x0000A5E20042039C AS DateTime), N'UCBmIfqXpICt9DYdKFkCQZ4Q', 192, 43292, 474, N'adana kebab', N'BmIfqXpICt9DYdKFkCQZ4Q')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (94, 2, N'AZUGB4rJ5zg', N'How To Make, Cook Adana Kebab   كيف تعمل كباب تركي', 50, 2, CAST(0x0000A5E0010C6560 AS DateTime), N'UC3hEYkvM8Lh3fpHENyCAzcw', 164, 382693, 324, N'adana kebab', N'To Be Added')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (95, 2, N'O70Ww9vzjvg', N'Tape Face: Strange Act Leaves the Audience Speechless - America''s Got Talent 2016 Auditions', 22848943, 298902, CAST(0x0000A6170151D58C AS DateTime), N'UCT2X19JJaJGUN7mrYuImANQ', 900, 584500649, 2677868, N'full episodes 2016', N'fremantle')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (96, 2, N'kJMWaO5Zfy0', N'Oggy and the Cockroaches - Oggy’s Double (S03E34) Full Episode in HD', 12446144, 16284, CAST(0x0000A58B00B3649C AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 170, 685072852, 731131, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (97, 2, N'SuPN2iGsO5k', N'Zig & Sharko - King Neptune''s court (S01E03) Full Episode in HD', 6861632, 9452, CAST(0x0000A5F00042ECD0 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 120, 142787943, 167304, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (98, 2, N'hsFKGAHReP0', N'blaze and the monster machines in english. Learning full Patterns episode 1 with Blaze', 4654596, 2501, CAST(0x0000A5D2009C8F4C AS DateTime), N'UCnDJuqZrVSWyuD0zKnEmnQQ', 109, 16490427, 23664, N'full episodes 2016', N'nDJuqZrVSWyuD0zKnEmnQQ')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (99, 2, N'VorxBhRxZGo', N'Black Jeopardy with Drake - SNL', 4319159, 35579, CAST(0x0000A607002BABB0 AS DateTime), N'UCqFzWxSCi39LnW1JKFR3efg', 5599, 1247058734, 2456556, N'full episodes 2016', N'NBCU_Shows')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (100, 2, N'lAv4oY0aYn8', N'Peppa Pig Full Episodes - Peppa Pig Injured | Peppa Pig English Episodes', 2353965, 719, CAST(0x0000A58401391C40 AS DateTime), N'UCxVvKbJveH8CK9ykW5d60nQ', 337, 32862890, 32751, N'full episodes 2016', N'Kickback')
GO
print 'Processed 100 total records'
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (101, 2, N'_lsvmj4SL9g', N'Tashan-e-Ishq - Episode 231  - May 26, 2016 - Webisode', 1812449, 2667, CAST(0x0000A612012DFEF0 AS DateTime), N'UCppHT7SZKKvar4Oc9J4oljQ', 59596, 4755063138, 3899236, N'full episodes 2016', N'dmcl')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (102, 2, N'MnZA_jaMLhs', N'NAAGIN - 5th June 2016 | Full Uncut | Episode On Location | Nagin - Colors Tv New Serial News', 1637478, 1798, CAST(0x0000A5B701761474 AS DateTime), N'UCToZTtSLYLyRV5xwUcAa9Kg', 4171, 73234858, 82973, N'full episodes 2016', N'TheOnlineInc')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (103, 2, N'Ib0luf5fhdY', N'PAW Patrol AIR PATROLLER! English Cartoon - Paw Patrol Full Episodes [Nick Jr.]', 1381894, 684, CAST(0x0000A5C90148A7F0 AS DateTime), N'UC4tCQThd7cL8y2zgg9Wp-dQ', 565, 6258397, 5327, N'full episodes 2016', N'To Be Added')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (104, 2, N'tJNOYa_6Dz0', N'Vegeta versus Hit, the Legendary Hitman. Full Fight! Dragon Ball Super Episode 38', 1289664, 4938, CAST(0x0000A5E3015FB0D0 AS DateTime), N'UCtF0Rkk2zhNOkrUolkTo1yQ', 140, 18269776, 22785, N'full episodes 2016', N'Toei_Animation_JP')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (105, 3, N'PE3-rCeSxo8', N'Top 10 Batman Arkham Series Boss Battles', 698349, 12079, CAST(0x0000A58B01391D6C AS DateTime), N'UCaWd5_7JhbQBe4dknZhsHJg', 10915, 6156080277, 12159924, N'batman arkham city', N'watchmojo')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (106, 3, N'nPYBTPBlG30', N'Batman Arkham Asylum - Did You Know Gaming? Feat. WeeklyTubeShow', 626558, 16708, CAST(0x0000A5B100F115F8 AS DateTime), N'UCyS4xQE6DK4_p3qXQwJQAyA', 212, 271708408, 1997088, N'batman arkham city', N'screenwavemedia_managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (107, 3, N'BdG4YzVTlMU', N'BATMAN V SUPERMAN SKIN - Batman Arkham Knight Walkthrough Gameplay Part 51 (PS4)', 585121, 12900, CAST(0x0000A58B01204350 AS DateTime), N'UCpqXJOEqGS-TCnazcHCo0rA', 4484, 2177929160, 6066778, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (108, 3, N'SF5hlj7ZadE', N'BATMAN: ARKHAM KNIGHT (Honest Game Trailers en Español)', 350915, 15684, CAST(0x0000A58D00DCD598 AS DateTime), N'UCgESfl93BM2y85abdt8BcZw', 577, 506281557, 2590712, N'batman arkham city', N'Break')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (109, 3, N'zhBz9IbuHBE', N'FINALE DI SERIE - BATMAN - Arkham Asylum !!!', 94811, 10864, CAST(0x0000A61900C5C484 AS DateTime), N'UC1jTVZboWRPpjGKAN921M5w', 2954, 320951760, 1300361, N'batman arkham city', N'TomsHardwareItalia%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (110, 3, N'VEY7IV2mr0w', N'Batman Arkham Knight: 2016 Batman V Superman Suit in the Final Scene', 93349, 584, CAST(0x0000A5AB00883FB0 AS DateTime), N'UCGW64BzOZSVeKEgB0AZFm2w', 345, 1395117, 4408, N'batman arkham city', N'anytv_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (111, 3, N'76uw_pWbdFA', N'AS GOSTOSAS DA SAGA BATMAN ARKHAM!', 78288, 5994, CAST(0x0000A60800D63BC0 AS DateTime), N'UCNKRJBAHTjnK3y0ThOg1uNw', 443, 17658620, 255939, N'batman arkham city', N'Paramaker_Affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (112, 3, N'D_Gv5bjjjpc', N'DLC KILLER CROC: SOTTO LA SUPERFICIE! [Batman Arkham Knight] By GiosephTheGamer', 63723, 5056, CAST(0x0000A588007B98A0 AS DateTime), N'UCyYj7brPoaX6PNT0iUW6RhA', 1760, 55426779, 221962, N'batman arkham city', N'machinima')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (113, 3, N'Rvm8iPkdTi8', N'Batman Arkham Knight: DLC Batcave (NIGHTWING Classic)', 59220, 1293, CAST(0x0000A59A017137EC AS DateTime), N'UCmzwIHGPWtxd3SgNG9qlctg', 1592, 118538485, 273353, N'batman arkham city', N'Machinima_Managed')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (114, 3, N'Sx2Fo_XQtvs', N'$230 BATMAN: ARKHAM CITY HOT TOYS UNBOXING (that voice you hate)', 47817, 1620, CAST(0x0000A5CF015A85C4 AS DateTime), N'UCz981RxgS-A2ID99W8wXzTA', 295, 20595577, 275337, N'batman arkham city', N'Collective')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (115, 3, N'hIHX4uEPst0', N'Batman: Arkham City: Superman meets Wonder Woman and gets a Knightmare', 46870, 151, CAST(0x0000A5CE0070AEE0 AS DateTime), N'UCXrs7DLP0GCrqVF3fLqydZQ', 228, 2425105, 3092, N'batman arkham city', N'MakerCurse')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (116, 3, N'-KD0RAwY6PQ', N'Batman Arkham Knight Todos los Trajes (Skins) de Batman', 45802, 973, CAST(0x0000A59E009827F4 AS DateTime), N'UCWv-0hCp1C3g3OXkY6ssyvQ', 2743, 172000293, 351705, N'batman arkham city', N'adrevuppm')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (117, 3, N'bVV0k2pod8Q', N'SPRUKITS - BATMAN: ARKHAM CITY UNBOXING!!!', 36146, 1934, CAST(0x0000A5C7006CCBF4 AS DateTime), N'UCs95gwav7frv5HTVqAGa7uQ', 4100, 203955959, 799041, N'batman arkham city', N'Outspeak')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (118, 3, N'da3lWcu2e_4', N'SKIN; Batman; Arkham City; Batman Beyond 2039 Style', 34972, 250, CAST(0x0000A5BF008A2AB4 AS DateTime), N'UCdSTlFGJqkLceN-Gm0bckPw', 817, 9355674, 15617, N'batman arkham city', N'FOXITAL_affiliate')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (119, 3, N'pXA-Hpnkf_U', N'Masa Kecil Batman - Batman Arkham Asylum - Indonesia Part 7', 34894, 622, CAST(0x0000A584008DFC0C AS DateTime), N'UC3J4Q1grz46bdJ7NJLd4DGw', 825, 29210600, 158118, N'batman arkham city', N'3J4Q1grz46bdJ7NJLd4DGw')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (120, 3, N'F3FRHg535z0', N'Batman Arkham Asylum: Batman v Superman Suit Mod', 27131, 256, CAST(0x0000A58800EEF3E0 AS DateTime), N'UC7CsXoSmY0NcgKem8gZylHw', 928, 14710576, 34905, N'batman arkham city', N'RPMNetworks')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (121, 3, N'uG9fhs2ftCg', N'Batman Arkham HD Remaster Leaked?!', 26923, 1146, CAST(0x0000A5EC01097508 AS DateTime), N'UCWkdg1JlFH--qu0HVN_RBow', 758, 35832276, 114155, N'batman arkham city', N'FullScreen')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (122, 3, N'4Xdun6Qw2Z4', N'Český GamePlay | Batman: Arkham Knight - Harley Quinn Story Pack | 1080p', 25234, 1415, CAST(0x0000A58100BF32E0 AS DateTime), N'UCL0s93LjCyW3bHa5casuojQ', 930, 67623684, 360326, N'batman arkham city', N'FlyGunCZ%2Buser')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (123, 3, N'NMqnNM_WsfQ', N'How to Make Batman''s Gauntlets (based on Arkham City)', 24698, 254, CAST(0x0000A5B2009C8F4C AS DateTime), N'UC2XIaI2fGf4zPGyyRgFNJVQ', 162, 2452132, 15975, N'batman arkham city', N'2XIaI2fGf4zPGyyRgFNJVQ')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (124, 3, N'B77tZRCCrqw', N'Бэтман Vs Пиг - Прохождение Batman Arkham Knight на PS4 [эпизод #39]', 22582, 243, CAST(0x0000A5D700F84BAC AS DateTime), N'UCC9YwiDqKWy1rUfF1wefReQ', 805, 42104075, 68091, N'batman arkham city', N'TopBeautyBlog')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (125, 3, N'E7g9LAUrO1E', N'Orijinal adana kebabi tarifi- Adana kebabi nasil yapilir? -Et-köfte ve kebab tarifleri', 9458, 216, CAST(0x0000A61B005096DC AS DateTime), N'UCLdjKcDxs6uH0emwEZrvaHw', 238, 6092291, 31372, N'adana kebab', N'Club_of_Cooks')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (126, 3, N'1A-85VqnJmE', N'En Güzel İftar Yemekleri /Adana kebap evde nasıl yapılır ?', 444, 26, CAST(0x0000A5E20042039C AS DateTime), N'UCBmIfqXpICt9DYdKFkCQZ4Q', 192, 43292, 474, N'adana kebab', N'BmIfqXpICt9DYdKFkCQZ4Q')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (127, 3, N'AZUGB4rJ5zg', N'How To Make, Cook Adana Kebab   كيف تعمل كباب تركي', 50, 2, CAST(0x0000A5E0010C6560 AS DateTime), N'UC3hEYkvM8Lh3fpHENyCAzcw', 164, 382693, 324, N'adana kebab', N'To Be Added')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (128, 3, N'O70Ww9vzjvg', N'Tape Face: Strange Act Leaves the Audience Speechless - America''s Got Talent 2016 Auditions', 22860398, 298941, CAST(0x0000A6170151D58C AS DateTime), N'UCT2X19JJaJGUN7mrYuImANQ', 901, 584500649, 2679188, N'full episodes 2016', N'fremantle')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (129, 3, N'kJMWaO5Zfy0', N'Oggy and the Cockroaches - Oggy’s Double (S03E34) Full Episode in HD', 12447521, 16286, CAST(0x0000A58B00B3649C AS DateTime), N'UCNEKMkg_DG8eAyR1BNWsSvw', 170, 685072852, 731255, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (130, 3, N'SuPN2iGsO5k', N'Zig & Sharko - King Neptune''s court (S01E03) Full Episode in HD', 6862741, 9453, CAST(0x0000A5F00042ECD0 AS DateTime), N'UCcKJJuOe2tOqgrKw0Gks-sw', 120, 142787943, 167336, N'full episodes 2016', N'ofdFZhAQtZd_PJVyRdmRhg')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (131, 3, N'hsFKGAHReP0', N'blaze and the monster machines in english. Learning full Patterns episode 1 with Blaze', 4654898, 2502, CAST(0x0000A5D2009C8F4C AS DateTime), N'UCnDJuqZrVSWyuD0zKnEmnQQ', 109, 16490427, 23681, N'full episodes 2016', N'nDJuqZrVSWyuD0zKnEmnQQ')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (132, 3, N'VorxBhRxZGo', N'Black Jeopardy with Drake - SNL', 4319406, 35590, CAST(0x0000A607002BABB0 AS DateTime), N'UCqFzWxSCi39LnW1JKFR3efg', 5599, 1247058734, 2456619, N'full episodes 2016', N'NBCU_Shows')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (133, 3, N'lAv4oY0aYn8', N'Peppa Pig Full Episodes - Peppa Pig Injured | Peppa Pig English Episodes', 2353974, 719, CAST(0x0000A58401391C40 AS DateTime), N'UCxVvKbJveH8CK9ykW5d60nQ', 337, 32862890, 32761, N'full episodes 2016', N'Kickback')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (134, 3, N'_lsvmj4SL9g', N'Tashan-e-Ishq - Episode 231  - May 26, 2016 - Webisode', 1814416, 2673, CAST(0x0000A612012DFEF0 AS DateTime), N'UCppHT7SZKKvar4Oc9J4oljQ', 59596, 4755063138, 3899642, N'full episodes 2016', N'dmcl')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (135, 3, N'MnZA_jaMLhs', N'NAAGIN - 5th June 2016 | Full Uncut | Episode On Location | Nagin - Colors Tv New Serial News', 1637563, 1798, CAST(0x0000A5B701761474 AS DateTime), N'UCToZTtSLYLyRV5xwUcAa9Kg', 4171, 73234858, 83018, N'full episodes 2016', N'TheOnlineInc')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (136, 3, N'Ib0luf5fhdY', N'PAW Patrol AIR PATROLLER! English Cartoon - Paw Patrol Full Episodes [Nick Jr.]', 1382195, 684, CAST(0x0000A5C90148A7F0 AS DateTime), N'UC4tCQThd7cL8y2zgg9Wp-dQ', 566, 6258397, 5333, N'full episodes 2016', N'To Be Added')
INSERT [dbo].[searchDetails] ([searchDetailId], [searchId], [videoId], [videoTitle], [videoViewCount], [videoLikeCount], [publishedAt], [channelId], [totalVideoCount], [totalViewCount], [totalSubscriber], [keyword], [attribution]) VALUES (137, 3, N'tJNOYa_6Dz0', N'Vegeta versus Hit, the Legendary Hitman. Full Fight! Dragon Ball Super Episode 38', 1289768, 4938, CAST(0x0000A5E3015FB0D0 AS DateTime), N'UCtF0Rkk2zhNOkrUolkTo1yQ', 140, 18269776, 22793, N'full episodes 2016', N'Toei_Animation_JP')
SET IDENTITY_INSERT [dbo].[searchDetails] OFF
/****** Object:  Table [dbo].[paramKeywords]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paramKeywords](
	[parameterText] [nvarchar](100) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[paramKeywords] ([parameterText]) VALUES (N'mimari proje çizimi')
INSERT [dbo].[paramKeywords] ([parameterText]) VALUES (N'arhitect')
INSERT [dbo].[paramKeywords] ([parameterText]) VALUES (N'internal design')
INSERT [dbo].[paramKeywords] ([parameterText]) VALUES (N'ic tasarim')
INSERT [dbo].[paramKeywords] ([parameterText]) VALUES (N'incredible buildings')
INSERT [dbo].[paramKeywords] ([parameterText]) VALUES (N'Top 10 TV Co-Stars Who Dated in Real Life')
INSERT [dbo].[paramKeywords] ([parameterText]) VALUES (N'house m.d.')
/****** Object:  Table [dbo].[blackListedChannels]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blackListedChannels](
	[youtubeChannelId] [nvarchar](255) NOT NULL,
	[addDateTime] [datetime] NOT NULL,
	[exported] [bit] NULL,
 CONSTRAINT [PK_blackListedChannels] PRIMARY KEY CLUSTERED 
(
	[youtubeChannelId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[appParams]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appParams](
	[apiKey] [nvarchar](150) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[appParams] ([apiKey]) VALUES (N'AIzaSyAg71D9wgH7nrY1VtNSJvYFf_-1oq4eMB8')
/****** Object:  StoredProcedure [dbo].[sp_updateBlackListChannel]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateBlackListChannel] (@channelId nvarchar(255), @exported bit)

AS
BEGIN

UPDATE blackListedChannels set exported = @exported where youtubeChannelId = @channelId

END
GO
/****** Object:  StoredProcedure [dbo].[sp_updateAttributionBySearchId]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE procedure [dbo].[sp_updateAttributionBySearchId](@videoId varchar(100), @attribution nvarchar(150) )

as

begin

update searchDetails set attribution = @attribution where videoId = @videoId

end
GO
/****** Object:  StoredProcedure [dbo].[sp_setApiKey]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_setApiKey] (@apiKey nvarchar(150))

AS
BEGIN

 update appParams set apiKey = @apiKey



END
GO
/****** Object:  StoredProcedure [dbo].[sp_getSearchResultsForAttribution]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE procedure [dbo].[sp_getSearchResultsForAttribution]

as

begin

select * from searchDetails where attribution = 'To Be Added'

end
GO
/****** Object:  StoredProcedure [dbo].[sp_getSearchResultsBySearchId]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE procedure [dbo].[sp_getSearchResultsBySearchId](@searchId int )

as

begin

select * from searchDetails where searchId = @searchId

end
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllSearchResults]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllSearchResults]

AS
BEGIN

select * from searchResults order by seachDateTime DESC



END
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllSearchFilters]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllSearchFilters]

AS
BEGIN

select * from searchFilters



END
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllKeywords]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllKeywords]

AS
BEGIN

select * from paramKeywords



END
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllBlackListChannels]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllBlackListChannels] 

AS
BEGIN


SELECT * FROM blackListedChannels


END
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllAppParams]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllAppParams]

AS
BEGIN

select * from appParams



END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteSearchFilter]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteSearchFilter] 

AS
BEGIN

DELETE FROM searchFilters



END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteNewBlackListChannel]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteNewBlackListChannel] (@channelId nvarchar(255))

AS
BEGIN


DELETE FROM blackListedChannels where youtubeChannelId = @channelId


END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteKeyword]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteKeyword] (@newKeyword nvarchar (100)) 

AS
BEGIN

DELETE FROM paramKeywords WHERE parameterText = @newKeyword



END
GO
/****** Object:  StoredProcedure [dbo].[sp_checkKeyword]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_checkKeyword] (@newKeyword nvarchar (100)) 

AS
BEGIN

select * FROM paramKeywords WHERE parameterText = @newKeyword



END
GO
/****** Object:  StoredProcedure [dbo].[sp_checkChannelExist]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_checkChannelExist] (@channelId nvarchar(255))

AS
BEGIN


SELECT * FROM blackListedChannels where youtubeChannelId = @channelId


END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddNewSearchDetail]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE procedure [dbo].[sp_AddNewSearchDetail](@searchId int, @videoId nvarchar(100), @videoTitle nvarchar(500), @videoViewCount float, @videoLikeCount float, @publishedAt datetime, @channelId nvarchar(100), @totalVideoCount float,
@totalViewCount float, @totalSubscriber float, @keyword nvarchar(300), @attribution nvarchar(300))

as

begin

INSERT INTO searchDetails (searchId, videoId, videoTitle, videoViewCount, videoLikeCount, publishedAt, channelId, totalVideoCount,
totalViewCount, totalSubscriber, keyword, attribution)
VALUES (@searchId, @videoId, @videoTitle, @videoViewCount, @videoLikeCount, @publishedAt, @channelId, @totalVideoCount,
@totalViewCount, @totalSubscriber, @keyword, @attribution)


end
GO
/****** Object:  StoredProcedure [dbo].[sp_AddNewSearch]    Script Date: 07/16/2017 16:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE procedure [dbo].[sp_AddNewSearch](@searchId int output, @seachDateTime Datetime)

as

begin

INSERT INTO searchResults (seachDateTime)
VALUES (@seachDateTime)

SET @searchId = SCOPE_IDENTITY()

end
GO
/****** Object:  StoredProcedure [dbo].[sp_addNewKeyword]    Script Date: 07/16/2017 16:10:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addNewKeyword] (@newKeyword nvarchar (100)) 

AS
BEGIN


INSERT INTO paramKeywords (parameterText) VALUES (@newKeyword)


END
GO
/****** Object:  StoredProcedure [dbo].[sp_addNewFilter]    Script Date: 07/16/2017 16:10:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addNewFilter] (@filterDuration int , @channelSubsCountMin int, @channelSubsCountMax int, @channelVideoCountMin int, @channelVideoCountMax int,
@maxresultCount int, @maxPageCount int, @sortBy int, @publishedAfter datetime, @publishedBefore datetime, @filterUploadDate nvarchar(50))  

AS
BEGIN


INSERT INTO searchFilters (filterDuration, channelSubsCountMin, channelSubsCountMax, channelVideoCountMin, channelVideoCountMax,
maxresultCount, maxPageCount, sortBy, publishedAfter, publishedBefore, filterUploadDate) 
VALUES (@filterDuration, @channelSubsCountMin, @channelSubsCountMax, @channelVideoCountMin, @channelVideoCountMax,
@maxresultCount, @maxPageCount, @sortBy, @publishedAfter, @publishedBefore, @filterUploadDate) 


END
GO
/****** Object:  StoredProcedure [dbo].[sp_addNewBlackListChannel]    Script Date: 07/16/2017 16:10:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addNewBlackListChannel] (@channelId nvarchar(255), @addedDateTime datetime, @exported bit)

AS
BEGIN

INSERT INTO blackListedChannels (youtubeChannelId, addDateTime, exported) VALUES (@channelId, @addedDateTime, @exported)

END
GO
/****** Object:  Default [DF_blackListedChannels_exported]    Script Date: 07/16/2017 16:10:43 ******/
ALTER TABLE [dbo].[blackListedChannels] ADD  CONSTRAINT [DF_blackListedChannels_exported]  DEFAULT ((0)) FOR [exported]
GO
