CREATE TABLE [dbo].[DocumentTypes]
(
[DocumentTypeId] [int] NOT NULL IDENTITY(1, 1),
[Description] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DocumentTypes] ADD CONSTRAINT [PK_dbo.DocumentTypes] PRIMARY KEY CLUSTERED  ([DocumentTypeId]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [DocumentType_Name_Index] ON [dbo].[DocumentTypes] ([Description]) ON [PRIMARY]
GO
