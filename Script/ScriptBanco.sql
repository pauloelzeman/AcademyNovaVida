IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Professor] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Professor] PRIMARY KEY ([Id])
);

CREATE TABLE [Aluno] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    [Mensalidade] decimal(18,2) NOT NULL,
    [DataVencimento] datetime2 NOT NULL,
    [ProfessorId] int NOT NULL,
    CONSTRAINT [PK_Aluno] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Aluno_Professor_ProfessorId] FOREIGN KEY ([ProfessorId]) REFERENCES [Professor] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Aluno_ProfessorId] ON [Aluno] ([ProfessorId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241205211507_MigrationInitial', N'9.0.0');

COMMIT;
GO

