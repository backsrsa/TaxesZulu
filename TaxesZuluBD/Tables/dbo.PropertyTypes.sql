CREATE TABLE [dbo].[PropertyTypes]
(
[PropertyTypeId] [int] NOT NULL IDENTITY(1, 1),
[Description] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Notes] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
CREATE UNIQUE NONCLUSTERED INDEX [PropertyType_Description_Index] ON [dbo].[PropertyTypes] ([Description]) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PropertyTypes] ADD CONSTRAINT [PK_dbo.PropertyTypes] PRIMARY KEY CLUSTERED  ([PropertyTypeId]) ON [PRIMARY]
GO
