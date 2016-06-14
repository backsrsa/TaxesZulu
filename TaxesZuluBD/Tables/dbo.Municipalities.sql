CREATE TABLE [dbo].[Municipalities]
(
[MunicipalityId] [int] NOT NULL IDENTITY(1, 1),
[DepartmentId] [int] NOT NULL,
[Name] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Municipalities] ADD CONSTRAINT [PK_dbo.Municipalities] PRIMARY KEY CLUSTERED  ([MunicipalityId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Municipalities] ([DepartmentId]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Municipality_Name_Index] ON [dbo].[Municipalities] ([Name]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Municipalities] ADD CONSTRAINT [FK_dbo.Municipalities_dbo.Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]) ON DELETE CASCADE
GO
