-- SELECT * FROM TOken

-- ----------------------------
-- Table structure for Token
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Token]') AND type IN ('U'))
	DROP TABLE [dbo].[Token]
GO

CREATE TABLE [dbo].[Token] (
  [Symbol] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Name] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [TotalSupply] bigint  NOT NULL,
  [ContractAddress] nvarchar(66) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [TotalHolders] int  NOT NULL,
  [Price] decimal(38,2) DEFAULT 0.00 NULL,
  [Id] int  IDENTITY(1,1) NOT NULL
)
GO

-- ----------------------------
-- Records of Token
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[Token] ON
GO

INSERT INTO [dbo].[Token] ([Symbol], [Name], [TotalSupply], [ContractAddress], [TotalHolders], [Price], [Id]) VALUES (N'VEN', N'Vechain', N'35987133', N'0xd850942ef8811f2a866692a623011bde52a462c1', N'65', N'0.00', N'1')
GO

INSERT INTO [dbo].[Token] ([Symbol], [Name], [TotalSupply], [ContractAddress], [TotalHolders], [Price], [Id]) VALUES (N'ZIR', N'Zilliqa', N'53272942', N'0x05f4a42e251f2d52b8ed15e9fedaacfcef1fad27', N'54', N'0.00', N'2')
GO

INSERT INTO [dbo].[Token] ([Symbol], [Name], [TotalSupply], [ContractAddress], [TotalHolders], [Price], [Id]) VALUES (N'MKR', N'Maker', N'45987133', N'0x9f8f72aa9304c8b593d555f12ef6589cc3a579a2', N'567', N'0.00', N'3')
GO

INSERT INTO [dbo].[Token] ([Symbol], [Name], [TotalSupply], [ContractAddress], [TotalHolders], [Price], [Id]) VALUES (N'BNB', N'Binance', N'16579517', N'0xB8c77482e45F1F44dE1745F52C74426C631bDD52', N'4234234', N'0.00', N'4')
GO

SET IDENTITY_INSERT [dbo].[Token] OFF
GO

COMMIT
GO

-- ----------------------------
-- Auto increment value for Token
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Token]', RESEED, 4)
GO

-- ----------------------------
-- Primary Key structure for table Token
-- ----------------------------
ALTER TABLE [dbo].[Token] ADD CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO