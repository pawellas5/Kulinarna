CREATE USER KulinarnaApp WITH PASSWORD = '33PuPcNGxM5Tx9U'
GO
ALTER ROLE db_datareader ADD MEMBER KulinarnaApp
GO
ALTER ROLE db_datawriter ADD MEMBER KulinarnaApp
GO