CREATE TABLE [dbo].[TaxPaers]
(
[TaxPaerId] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NOT NULL,
[LastName] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NOT NULL,
[UserName] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Phone] [nvarchar] (20) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DepartmentId] [int] NOT NULL,
[MunicipalityId] [int] NOT NULL,
[Address] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL,
[DocumentTypeId] [int] NOT NULL,
[Document] [nvarchar] (20) COLLATE Modern_Spanish_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TaxPaers] ADD CONSTRAINT [PK_dbo.TaxPaers] PRIMARY KEY CLUSTERED  ([TaxPaerId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[TaxPaers] ([DepartmentId]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [TaxPaer_Document_Index] ON [dbo].[TaxPaers] ([Document]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DocumentTypeId] ON [dbo].[TaxPaers] ([DocumentTypeId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MunicipalityId] ON [dbo].[TaxPaers] ([MunicipalityId]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [TaxPaer_UserName_Index] ON [dbo].[TaxPaers] ([UserName]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TaxPaers] ADD CONSTRAINT [FK_dbo.TaxPaers_dbo.Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[TaxPaers] ADD CONSTRAINT [FK_dbo.TaxPaers_dbo.DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [dbo].[DocumentTypes] ([DocumentTypeId])
GO
ALTER TABLE [dbo].[TaxPaers] ADD CONSTRAINT [FK_dbo.TaxPaers_dbo.Municipalities_MunicipalityId] FOREIGN KEY ([MunicipalityId]) REFERENCES [dbo].[Municipalities] ([MunicipalityId])
GO
