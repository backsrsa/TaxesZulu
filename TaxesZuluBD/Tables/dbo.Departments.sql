CREATE TABLE [dbo].[Departments]
(
[DepartmentId] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Departments] ADD CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED  ([DepartmentId]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Department_Name_Index] ON [dbo].[Departments] ([Name]) ON [PRIMARY]
GO
