SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DataAccessLogger](
	[DataAccessTransactionId] [uniqueidentifier] NOT NULL,
	[Operation] [nchar](10) NULL,
	[MethodName] [nvarchar](200) NULL,
	[Message] [nvarchar](max) NULL,
	[SourceMachineName] [nvarchar](200) NULL,
	[SourceApplicationDomainName] [nvarchar](200) NULL,
	[ReferralLibrary] [nvarchar](200) NULL,
 CONSTRAINT [PK_DataAccessLogger] PRIMARY KEY CLUSTERED 
(
	[DataAccessTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
