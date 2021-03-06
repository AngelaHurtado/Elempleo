USE [master]
GO
/****** Object:  Database [ELEMPLEO]    Script Date: 24/03/2020 4:50:18 p. m. ******/
CREATE DATABASE [ELEMPLEO]

CREATE TABLE [dbo].[CIUDAD](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CIUDAD] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENDEDOR]    Script Date: 24/03/2020 4:50:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENDEDOR](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[numero_identificacion] [numeric](18, 0) NULL,
	[codigo_ciudad] [int] NULL,
 CONSTRAINT [PK_VENDEDOR] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CIUDAD] ON 
GO
INSERT [dbo].[CIUDAD] ([codigo], [descripcion]) VALUES (1, N'Bogota')
GO
INSERT [dbo].[CIUDAD] ([codigo], [descripcion]) VALUES (2, N'Cali')
GO
SET IDENTITY_INSERT [dbo].[CIUDAD] OFF
GO
SET IDENTITY_INSERT [dbo].[VENDEDOR] ON 
GO
INSERT [dbo].[VENDEDOR] ([codigo], [nombre], [apellido], [numero_identificacion], [codigo_ciudad]) VALUES (1, N'Juan', N'Polanco', CAST(1111111111 AS Numeric(18, 0)), 1)
GO
INSERT [dbo].[VENDEDOR] ([codigo], [nombre], [apellido], [numero_identificacion], [codigo_ciudad]) VALUES (2, N'Pedro', N'Reyes', CAST(222222222 AS Numeric(18, 0)), 2)
GO
INSERT [dbo].[VENDEDOR] ([codigo], [nombre], [apellido], [numero_identificacion], [codigo_ciudad]) VALUES (3, N'Maria', N'Paz', CAST(333333333 AS Numeric(18, 0)), 1)
GO
INSERT [dbo].[VENDEDOR] ([codigo], [nombre], [apellido], [numero_identificacion], [codigo_ciudad]) VALUES (4, N'Luna', N'Monroy', CAST(4444444444 AS Numeric(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[VENDEDOR] OFF
GO
ALTER TABLE [dbo].[VENDEDOR]  WITH CHECK ADD  CONSTRAINT [FK_CIUDAD_VENDEDOR] FOREIGN KEY([codigo_ciudad])
REFERENCES [dbo].[CIUDAD] ([codigo])
GO
ALTER TABLE [dbo].[VENDEDOR] CHECK CONSTRAINT [FK_CIUDAD_VENDEDOR]

