ALTER TABLE [Items] ADD [Barcode] varchar(13) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181009103527_AddProductBarcode', N'2.1.4-rtm-31024');

GO

