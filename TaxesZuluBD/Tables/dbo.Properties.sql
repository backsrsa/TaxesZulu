CREATE TABLE [dbo].[Properties]
(
[PropertyId] [nvarchar] (128) COLLATE Modern_Spanish_CI_AS NOT NULL,
[TaxPaerId] [int] NOT NULL,
[Phone] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[DepartmentId] [int] NOT NULL,
[MunicipalityId] [int] NOT NULL,
[Address] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[PropertyTypeId] [int] NOT NULL,
[Stratus] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[Area] [real] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Properties] ADD CONSTRAINT [PK_dbo.Properties] PRIMARY KEY CLUSTERED  ([PropertyId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Properties] ([DepartmentId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MunicipalityId] ON [dbo].[Properties] ([MunicipalityId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PropertyTypeId] ON [dbo].[Properties] ([PropertyTypeId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TaxPaerId] ON [dbo].[Properties] ([TaxPaerId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Properties] ADD CONSTRAINT [FK_dbo.Properties_dbo.Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Properties] ADD CONSTRAINT [FK_dbo.Properties_dbo.Municipalities_MunicipalityId] FOREIGN KEY ([MunicipalityId]) REFERENCES [dbo].[Municipalities] ([MunicipalityId])
GO
ALTER TABLE [dbo].[Properties] ADD CONSTRAINT [FK_dbo.Properties_dbo.PropertyTypes_PropertyTypeId] FOREIGN KEY ([PropertyTypeId]) REFERENCES [dbo].[PropertyTypes] ([PropertyTypeId])
GO
ALTER TABLE [dbo].[Properties] ADD CONSTRAINT [FK_dbo.Properties_dbo.TaxPaers_TaxPaerId] FOREIGN KEY ([TaxPaerId]) REFERENCES [dbo].[TaxPaers] ([TaxPaerId])
GO
