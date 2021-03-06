CREATE DATABASE [bitstampService]
GO
USE [bitstampService]
GO
/****** Object:  StoredProcedure [dbo].[PriceBTC_USD]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PriceBTC_USD]
@BeginDate datetime,
@EndDate datetime
as
DECLARE @tblResult Table([Day] date,[Open] numeric(36,8), [Close] numeric(36,8), [Hight] numeric(36,8), [Low] numeric(36,8))
DECLARE @OpenPrice numeric(36,8),@ClosePrice numeric(36,8), @HighPrice numeric(36,8), @LowPrice numeric(36,8)
While (@BeginDate<=@EndDate)
BEGIN
	DECLARE A CURSOR FOR 
		SELECT * FROM(
				(SELECT Top 1 Last AS OpenPrice FROM BTC_USD WHERE CAST([Time] AS DATE) = @BeginDate Order By Time )A
				JOIN  (SELECT Top 1 Last AS ClosePrice FROM BTC_USD WHERE CAST([Time] AS DATE) = @BeginDate Order By Time DESC) B ON 1=1
				JOIN (SELECT Max(Last) AS HighPrice, Min(Last) AS LowPrice FROM BTC_USD WHERE CAST([Time] AS DATE) = @BeginDate) C ON 1=1)
	OPEN A
	FETCH NEXT FROM A INTO @OpenPrice,@ClosePrice, @HighPrice, @LowPrice
		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			Insert into @tblResult VALUES(CAST(@BeginDate AS DATE),@OpenPrice,@ClosePrice,@HighPrice,@LowPrice)
			FETCH NEXT FROM A INTO @OpenPrice,@ClosePrice, @HighPrice, @LowPrice
			END   
	CLOSE A;  
	DEALLOCATE A;  
	SET @BeginDate = DATEADD(DAY,1,@BeginDate)
END
GO
/****** Object:  StoredProcedure [dbo].[PriceETH_BTC]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PriceETH_BTC]
@BeginDate datetime,
@EndDate datetime
as
DECLARE @tblResult Table([Day] date,[Open] numeric(36,8), [Close] numeric(36,8), [Hight] numeric(36,8), [Low] numeric(36,8))
DECLARE @OpenPrice numeric(36,8),@ClosePrice numeric(36,8), @HighPrice numeric(36,8), @LowPrice numeric(36,8)
While (@BeginDate<=@EndDate)
BEGIN
	DECLARE A CURSOR FOR 
		SELECT * FROM(
				(SELECT Top 1 Last AS OpenPrice FROM ETH_BTC WHERE CAST([Time] AS DATE) = @BeginDate Order By Time )A
				JOIN  (SELECT Top 1 Last AS ClosePrice FROM ETH_BTC WHERE CAST([Time] AS DATE) = @BeginDate Order By Time DESC) B ON 1=1
				JOIN (SELECT Max(Last) AS HighPrice, Min(Last) AS LowPrice FROM ETH_BTC WHERE CAST([Time] AS DATE) = @BeginDate) C ON 1=1)
	OPEN A
	FETCH NEXT FROM A INTO @OpenPrice,@ClosePrice, @HighPrice, @LowPrice
		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			Insert into @tblResult VALUES(CAST(@BeginDate AS DATE),@OpenPrice,@ClosePrice,@HighPrice,@LowPrice)
			FETCH NEXT FROM A INTO @OpenPrice,@ClosePrice, @HighPrice, @LowPrice
			END   
	CLOSE A;  
	DEALLOCATE A;  
	SET @BeginDate = DATEADD(DAY,1,@BeginDate)
END


GO
/****** Object:  StoredProcedure [dbo].[PriceETH_USD]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PriceETH_USD]
@BeginDate datetime,
@EndDate datetime
as
DECLARE @tblResult Table([Day] date,[Open] numeric(36,8), [Close] numeric(36,8), [Hight] numeric(36,8), [Low] numeric(36,8))
DECLARE @OpenPrice numeric(36,8),@ClosePrice numeric(36,8), @HighPrice numeric(36,8), @LowPrice numeric(36,8)
While (@BeginDate<=@EndDate)
BEGIN
	DECLARE A CURSOR FOR 
		SELECT * FROM(
				(SELECT Top 1 Last AS OpenPrice FROM ETH_USD WHERE CAST([Time] AS DATE) = @BeginDate Order By Time )A
				JOIN  (SELECT Top 1 Last AS ClosePrice FROM ETH_USD WHERE CAST([Time] AS DATE) = @BeginDate Order By Time DESC) B ON 1=1
				JOIN (SELECT Max(Last) AS HighPrice, Min(Last) AS LowPrice FROM ETH_USD WHERE CAST([Time] AS DATE) = @BeginDate) C ON 1=1)
	OPEN A
	FETCH NEXT FROM A INTO @OpenPrice,@ClosePrice, @HighPrice, @LowPrice
		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			Insert into @tblResult VALUES(CAST(@BeginDate AS DATE),@OpenPrice,@ClosePrice,@HighPrice,@LowPrice)
			FETCH NEXT FROM A INTO @OpenPrice,@ClosePrice, @HighPrice, @LowPrice
			END   
	CLOSE A;  
	DEALLOCATE A;  
	SET @BeginDate = DATEADD(DAY,1,@BeginDate)
END
GO
/****** Object:  StoredProcedure [dbo].[proc_BTCUSD_CoinPrice]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_BTCUSD_CoinPrice] 
	@lastprice [numeric](36, 8)
AS
BEgin
	Insert into CoinPrice(ExchangeID,TickerID,Price)
	values(1,4,@lastprice)
End
GO
/****** Object:  StoredProcedure [dbo].[proc_ETHBTC_CoinPrice]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_ETHBTC_CoinPrice] 
	@lastprice [numeric](36, 8)
AS
BEgin
	Insert into CoinPrice(ExchangeID,TickerID,Price)
	values(1,6,@lastprice)
End
GO
/****** Object:  StoredProcedure [dbo].[proc_ETHUSD_CoinPrice]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_ETHUSD_CoinPrice] 
	@lastprice [numeric](36, 8)
AS
BEgin
	Insert into CoinPrice(ExchangeID,TickerID,Price)
	values(1,5,@lastprice)
End
GO
/****** Object:  Table [dbo].[BTC_USD]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTC_USD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Open] [numeric](36, 8) NULL,
	[Last] [numeric](36, 8) NULL,
	[Hight] [numeric](36, 8) NULL,
	[Low] [numeric](36, 8) NULL,
	[Volume] [numeric](36, 8) NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_BTC_USD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoinPrice]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoinPrice](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ExchangeID] [int] NOT NULL,
	[TickerID] [int] NOT NULL,
	[Price] [numeric](36, 8) NOT NULL,
	[Time] [datetime] NOT NULL CONSTRAINT [DF_CoinPrice_Time]  DEFAULT (getdate()),
 CONSTRAINT [PK_CoinPrice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ETH_BTC]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ETH_BTC](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Open] [numeric](36, 8) NULL,
	[Last] [numeric](36, 8) NULL,
	[Hight] [numeric](36, 8) NULL,
	[Low] [numeric](36, 8) NULL,
	[Volume] [numeric](36, 8) NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_ETH_BTC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ETH_USD]    Script Date: 1/28/2018 11:54:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ETH_USD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Open] [numeric](36, 8) NULL,
	[Last] [numeric](36, 8) NULL,
	[Hight] [numeric](36, 8) NULL,
	[Low] [numeric](36, 8) NULL,
	[Volume] [numeric](36, 8) NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_ETH_USD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER DATABASE [bitstampService] SET  READ_WRITE 
GO
