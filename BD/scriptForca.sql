USE [master]
GO
/****** Object:  Database [Forca]    Script Date: 06/02/2018 00:27:20 ******/
CREATE DATABASE [Forca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Forca', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Forca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Forca_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Forca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Forca] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Forca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Forca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Forca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Forca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Forca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Forca] SET ARITHABORT OFF 
GO
ALTER DATABASE [Forca] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Forca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Forca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Forca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Forca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Forca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Forca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Forca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Forca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Forca] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Forca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Forca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Forca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Forca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Forca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Forca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Forca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Forca] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Forca] SET  MULTI_USER 
GO
ALTER DATABASE [Forca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Forca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Forca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Forca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Forca] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Forca] SET QUERY_STORE = OFF
GO
USE [Forca]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Forca]
GO
/****** Object:  Table [dbo].[Jogador]    Script Date: 06/02/2018 00:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jogador](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NULL,
	[pontuacao] [int] NULL,
 CONSTRAINT [PK_Jogador] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Palavra]    Script Date: 06/02/2018 00:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Palavra](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NULL,
	[tema_id] [int] NOT NULL,
 CONSTRAINT [PK_Palavra] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tema]    Script Date: 06/02/2018 00:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tema](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tema] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Jogador] ON 

INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (1, N'tamires', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (2, N'Dudu', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (3, N'Carlol', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (4, N'Tamires', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (5, N'cadu', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (6, N'tami', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (7, N'adf', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (8, N'asdf', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (9, N'affsdg', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (10, N'Carlsoo', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (11, N'Takires', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (12, N'asffddss', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (13, N'Carlos', 0)
INSERT [dbo].[Jogador] ([id], [nome], [pontuacao]) VALUES (14, N'Nathália', 0)
SET IDENTITY_INSERT [dbo].[Jogador] OFF
SET IDENTITY_INSERT [dbo].[Palavra] ON 

INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (2, N'MANGA', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (3, N'MAMÃO', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (4, N'GOIABA', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (5, N'BANANA', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (6, N'AMEIXA', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (7, N'AMÊNDOA', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (8, N'AÇAÍ', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (9, N'MELÃO', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (10, N'UVA', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (11, N'KIWI', 1)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (12, N'LOBO', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (13, N'BALEIA', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (14, N'ZEBRA', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (15, N'TIGRE', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (16, N'VACA', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (17, N'ANTA', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (18, N'JAVALI', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (19, N'BODE', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (20, N'BOI', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (21, N'PORCO', 2)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (22, N'BOXE', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (23, N'CICLISMO', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (24, N'PENTATLO', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (25, N'TÊNIS', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (26, N'REMO', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (27, N'NATAÇÃO', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (28, N'BASQUETE', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (29, N'VOLEIBOL', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (30, N'JUDÔ', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (31, N'ESGRIMA', 3)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (32, N'ENXOFRE', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (33, N'FLÚOR', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (34, N'ZINCO', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (35, N'IODO', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (36, N'PRATA', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (37, N'CROMO', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (38, N'CLORO', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (39, N'CARBONO', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (40, N'HÉLIO', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (41, N'MERCÚRIO', 4)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (42, N'NOZES', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (43, N'FLOCOS', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (44, N'CAFÉ', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (45, N'PISTACHE', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (46, N'CEREJA', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (47, N'MARACUJÁ', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (48, N'COCO', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (49, N'FRAMBOESA', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (50, N'AMARULA', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (51, N'CREME', 5)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (52, N'CUPIDO', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (53, N'LATONA', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (54, N'VULCANO', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (55, N'VESTA', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (56, N'PLUTÃO', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (57, N'CERES', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (58, N'JUNO', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (59, N'MARTE', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (60, N'BACO', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (61, N'JÚPITER', 6)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (62, N'JILÓ', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (63, N'CARÁ', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (64, N'REPOLHO', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (65, N'TOMATE', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (66, N'RABANETE', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (67, N'CHUCHU', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (68, N'ESPINAFRE', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (69, N'ALFACE', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (70, N'QUIABO', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (71, N'VAGEM', 7)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (72, N'CARDUME', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (73, N'NUVEM', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (74, N'PROLE', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (75, N'GRUPO', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (76, N'MANADA', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (77, N'FROTA', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (78, N'FAUNA', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (79, N'CACHO', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (80, N'ATLAS', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (81, N'JUNTA', 8)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (82, N' LARISSA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (83, N'GABRIELA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (84, N'FLÁVIA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (85, N'LUCIANA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (86, N'MARINA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (87, N'PATRÍCIA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (88, N'CAMILA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (89, N'FERNANDA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (90, N'AMANDA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (91, N'PAULA', 9)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (92, N'JOÃO', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (93, N'EDUARDO', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (94, N'VICTOR', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (95, N'PEDRO', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (96, N'FELIPE', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (97, N'LUÍZ', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (98, N'RAFAEL', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (99, N'ANDRÉ', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (100, N'RODRIGO', 10)
GO
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (101, N'MARCELO', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (102, N'JOÃO', 10)
INSERT [dbo].[Palavra] ([id], [nome], [tema_id]) VALUES (103, N'GUITARRA', 32)
SET IDENTITY_INSERT [dbo].[Palavra] OFF
SET IDENTITY_INSERT [dbo].[Tema] ON 

INSERT [dbo].[Tema] ([id], [nome]) VALUES (1, N'Frutas')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (2, N'Mamíferos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (3, N'Esportes Olímpicos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (4, N'Elementos Químicos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (5, N'Sabores de Sorvete')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (6, N'Mitologia Romana')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (7, N'Legumes')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (8, N'Substantivos Coletivos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (9, N'Nomes de Meninas')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (10, N'Nomes de Meninos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (11, N'Flores')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (12, N'Peixes')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (13, N'Aves')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (14, N'Profissões')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (15, N'Futebol')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (16, N'Verbos Irregulares do Inglês')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (17, N'Estados dos EUA')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (18, N'Capitais dos Estados Brasileiros')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (19, N'Capitais no Mundo')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (20, N'Hino Nacional Brasileiro')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (21, N'Adjetivos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (22, N'Sala de Aula')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (23, N'Açougue')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (24, N'Árvores do Brasil')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (25, N'Roupas e Acessórios')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (26, N'Fazenda')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (27, N'Cores')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (28, N'Praia')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (29, N'Salão de Beleza')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (30, N'Sabores de Pizza')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (31, N'Academia')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (32, N'Instrumentos Musicais')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (33, N'Saladas')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (34, N'Calçados')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (35, N'Matemática')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (36, N'Circo')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (37, N'Sucos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (38, N'Parque de Diversão')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (39, N'Bolsa de Mulher')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (40, N'Corpo Humano')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (41, N'Temperos e Condimentos')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (42, N'Hospital')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (43, N'Cozinha')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (44, N'Banheiro')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (45, N'Parque')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (46, N'Raças de Cachorros')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (47, N'Halloween')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (48, N'Acampamento')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (49, N'Natal')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (50, N'Churrasco')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (51, N'Chás')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (52, N'Aeroporto')
INSERT [dbo].[Tema] ([id], [nome]) VALUES (53, N'Invertebrados')
SET IDENTITY_INSERT [dbo].[Tema] OFF
ALTER TABLE [dbo].[Palavra]  WITH CHECK ADD  CONSTRAINT [FK_Palavra_Tema] FOREIGN KEY([tema_id])
REFERENCES [dbo].[Tema] ([id])
GO
ALTER TABLE [dbo].[Palavra] CHECK CONSTRAINT [FK_Palavra_Tema]
GO
USE [master]
GO
ALTER DATABASE [Forca] SET  READ_WRITE 
GO
