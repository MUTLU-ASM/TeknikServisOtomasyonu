USE [TeknikSevisDb]
GO
/****** Object:  Table [dbo].[İslem]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[İslem](
	[islemID] [int] IDENTITY(1,1) NOT NULL,
	[kayitID] [int] NULL,
	[islemTurID] [int] NULL,
	[kullaniciID] [int] NULL,
	[aciklama] [text] NULL,
	[islemTarihi] [date] NULL,
	[ucret] [decimal](18, 2) NULL,
 CONSTRAINT [PK_İslem] PRIMARY KEY CLUSTERED 
(
	[islemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[İslemTur]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[İslemTur](
	[islemTurID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[ucret] [decimal](18, 2) NULL,
 CONSTRAINT [PK_İslemTur] PRIMARY KEY CLUSTERED 
(
	[islemTurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kayit]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kayit](
	[kayitID] [int] IDENTITY(1,1) NOT NULL,
	[musteriID] [int] NULL,
	[kullaniciID] [int] NULL,
	[turID] [int] NULL,
	[markaID] [int] NULL,
	[model] [nvarchar](50) NULL,
	[sorun] [nvarchar](50) NULL,
	[alisTarihi] [date] NULL,
	[teslimTarihi] [date] NULL,
	[tutar] [decimal](18, 2) NULL,
	[aciklama] [text] NULL,
	[durum] [bit] NULL,
 CONSTRAINT [PK_Kayit] PRIMARY KEY CLUSTERED 
(
	[kayitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[kullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[yetkiID] [int] NULL,
	[ad] [nvarchar](30) NULL,
	[soyad] [nvarchar](30) NULL,
	[eposta] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[kullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marka]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marka](
	[markaID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_Marka] PRIMARY KEY CLUSTERED 
(
	[markaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[musteriID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[adres] [nvarchar](50) NULL,
	[telefon] [char](10) NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[musteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tur]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tur](
	[turID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tur] PRIMARY KEY CLUSTERED 
(
	[turID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yetki]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yetki](
	[yetkiID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_yetki] PRIMARY KEY CLUSTERED 
(
	[yetkiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 4.09.2022 13:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[yoneticiID] [int] IDENTITY(1,1) NOT NULL,
	[yetkiID] [int] NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
	[telefon] [char](11) NULL,
 CONSTRAINT [PK_Yonetici] PRIMARY KEY CLUSTERED 
(
	[yoneticiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[İslemTur] ON 

INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (1, N'Format', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (2, N'Ekran', CAST(360.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (3, N'Batarya', CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (4, N'Temizlik', CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (5, N'Anakart', CAST(1120.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (6, N'Ses sistemi', CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (7, N'Fan', CAST(90.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (8, N'Ram', CAST(590.00 AS Decimal(18, 2)))
INSERT [dbo].[İslemTur] ([islemTurID], [ad], [ucret]) VALUES (9, NULL, NULL)
SET IDENTITY_INSERT [dbo].[İslemTur] OFF
GO
SET IDENTITY_INSERT [dbo].[Kayit] ON 

INSERT [dbo].[Kayit] ([kayitID], [musteriID], [kullaniciID], [turID], [markaID], [model], [sorun], [alisTarihi], [teslimTarihi], [tutar], [aciklama], [durum]) VALUES (1, 5, 1, 1, 1, N'Nirvana', N'Batarya', CAST(N'2022-05-22' AS Date), CAST(N'2022-05-29' AS Date), CAST(80.00 AS Decimal(18, 2)), N'.', 1)
INSERT [dbo].[Kayit] ([kayitID], [musteriID], [kullaniciID], [turID], [markaID], [model], [sorun], [alisTarihi], [teslimTarihi], [tutar], [aciklama], [durum]) VALUES (2, 6, 3, 1, 2, N'L871', N'Ekran', CAST(N'2022-05-18' AS Date), CAST(N'2022-05-24' AS Date), CAST(360.00 AS Decimal(18, 2)), N'.', 0)
INSERT [dbo].[Kayit] ([kayitID], [musteriID], [kullaniciID], [turID], [markaID], [model], [sorun], [alisTarihi], [teslimTarihi], [tutar], [aciklama], [durum]) VALUES (3, 8, 1, 1, 2, N'ThinkPad X1', N'Ekran', CAST(N'2022-05-18' AS Date), CAST(N'2022-05-24' AS Date), CAST(400.00 AS Decimal(18, 2)), N'.', 0)
INSERT [dbo].[Kayit] ([kayitID], [musteriID], [kullaniciID], [turID], [markaID], [model], [sorun], [alisTarihi], [teslimTarihi], [tutar], [aciklama], [durum]) VALUES (6, 10, 2, 1, 1, N'X0451', N'Batarya', CAST(N'2022-05-06' AS Date), CAST(N'2022-05-09' AS Date), CAST(400.00 AS Decimal(18, 2)), N'.', 1)
INSERT [dbo].[Kayit] ([kayitID], [musteriID], [kullaniciID], [turID], [markaID], [model], [sorun], [alisTarihi], [teslimTarihi], [tutar], [aciklama], [durum]) VALUES (7, 11, 3, 1, 2, N'K15489', N'Temizlik', CAST(N'2022-05-29' AS Date), CAST(N'2022-06-05' AS Date), CAST(400.00 AS Decimal(18, 2)), N'.', 1)
SET IDENTITY_INSERT [dbo].[Kayit] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([kullaniciID], [yetkiID], [ad], [soyad], [eposta], [sifre]) VALUES (1, 2, N'Sinan', N'Kaya', N'sinan@gmail.com', N'123')
INSERT [dbo].[Kullanici] ([kullaniciID], [yetkiID], [ad], [soyad], [eposta], [sifre]) VALUES (2, 2, N'Volkan', N'Yıldırım', N'volkan@gmail.com', N'123')
INSERT [dbo].[Kullanici] ([kullaniciID], [yetkiID], [ad], [soyad], [eposta], [sifre]) VALUES (3, 2, N'Çetin', N'Yazıcı', N'cetin@gmail.com', N'1234')
INSERT [dbo].[Kullanici] ([kullaniciID], [yetkiID], [ad], [soyad], [eposta], [sifre]) VALUES (5, 1, N'Ali', N'Yeşilçiçek', N'ali@gmail.com', N'12345')
INSERT [dbo].[Kullanici] ([kullaniciID], [yetkiID], [ad], [soyad], [eposta], [sifre]) VALUES (6, 2, N'Kutay', N'Çam', N'kutay@gmail.com', N'123')
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[Marka] ON 

INSERT [dbo].[Marka] ([markaID], [ad]) VALUES (1, N'Casper')
INSERT [dbo].[Marka] ([markaID], [ad]) VALUES (2, N'Lenovo')
SET IDENTITY_INSERT [dbo].[Marka] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [adres], [telefon]) VALUES (5, N'Asım', N'Mutlu', N'İstanbul', N'5377305477')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [adres], [telefon]) VALUES (6, N'Emre', N'Yıldız', N'Trabzon', N'5376584271')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [adres], [telefon]) VALUES (7, N'Ahmet', N'Burak', N'Çorum', N'5878994511')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [adres], [telefon]) VALUES (8, N'Talha', N'Sakaoğlu', N'Ağrı', N'5487892144')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [adres], [telefon]) VALUES (9, N'Reşit', N'Sanchez', N'New York', N'5748158963')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [adres], [telefon]) VALUES (10, N'Çınar', N'Çam', N'Antalya', N'5987741256')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [adres], [telefon]) VALUES (11, N'Samet', N'Akyol', N'Gaziantep', N'5487925478')
SET IDENTITY_INSERT [dbo].[Musteri] OFF
GO
SET IDENTITY_INSERT [dbo].[Tur] ON 

INSERT [dbo].[Tur] ([turID], [ad]) VALUES (1, N'Bilgisayar')
SET IDENTITY_INSERT [dbo].[Tur] OFF
GO
SET IDENTITY_INSERT [dbo].[Yetki] ON 

INSERT [dbo].[Yetki] ([yetkiID], [ad]) VALUES (1, N'admin')
INSERT [dbo].[Yetki] ([yetkiID], [ad]) VALUES (2, N'personel')
SET IDENTITY_INSERT [dbo].[Yetki] OFF
GO
SET IDENTITY_INSERT [dbo].[Yonetici] ON 

INSERT [dbo].[Yonetici] ([yoneticiID], [yetkiID], [ad], [soyad], [email], [sifre], [telefon]) VALUES (1, 1, N'Kerem', N'Mutlu', N'kerem@gmail.com', N'123', NULL)
SET IDENTITY_INSERT [dbo].[Yonetici] OFF
GO
ALTER TABLE [dbo].[İslem]  WITH CHECK ADD  CONSTRAINT [FK_İslem_İslemTur] FOREIGN KEY([islemTurID])
REFERENCES [dbo].[İslemTur] ([islemTurID])
GO
ALTER TABLE [dbo].[İslem] CHECK CONSTRAINT [FK_İslem_İslemTur]
GO
ALTER TABLE [dbo].[İslem]  WITH CHECK ADD  CONSTRAINT [FK_İslem_Kayit] FOREIGN KEY([kayitID])
REFERENCES [dbo].[Kayit] ([kayitID])
GO
ALTER TABLE [dbo].[İslem] CHECK CONSTRAINT [FK_İslem_Kayit]
GO
ALTER TABLE [dbo].[İslem]  WITH CHECK ADD  CONSTRAINT [FK_İslem_Personel] FOREIGN KEY([kullaniciID])
REFERENCES [dbo].[Kullanici] ([kullaniciID])
GO
ALTER TABLE [dbo].[İslem] CHECK CONSTRAINT [FK_İslem_Personel]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Marka] FOREIGN KEY([markaID])
REFERENCES [dbo].[Marka] ([markaID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Marka]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Musteri] FOREIGN KEY([musteriID])
REFERENCES [dbo].[Musteri] ([musteriID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Musteri]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Personel] FOREIGN KEY([kullaniciID])
REFERENCES [dbo].[Kullanici] ([kullaniciID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Personel]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Tur] FOREIGN KEY([turID])
REFERENCES [dbo].[Tur] ([turID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Tur]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Personel_Yetki] FOREIGN KEY([yetkiID])
REFERENCES [dbo].[Yetki] ([yetkiID])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Personel_Yetki]
GO
ALTER TABLE [dbo].[Yonetici]  WITH CHECK ADD  CONSTRAINT [FK_Yonetici_Yetki] FOREIGN KEY([yetkiID])
REFERENCES [dbo].[Yetki] ([yetkiID])
GO
ALTER TABLE [dbo].[Yonetici] CHECK CONSTRAINT [FK_Yonetici_Yetki]
GO
