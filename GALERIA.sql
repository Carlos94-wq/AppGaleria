USE master 
GO

CREATE DATABASE GALERIA
GO

USE GALERIA
GO

CREATE TABLE [dbo].[Fotos](
	IdFoto INT IDENTITY (1,1) NOT NULL,
	Foto   VARCHAR (MAX) NOT NULL,
	FechaCarga DATE NOT NULL,

	CONSTRAINT PK_FOTO_IdFoto PRIMARY KEY (IdFoto)
)

CREATE PROCEDURE [dbo].[spFotos](
	@Accion     INT           = NULL,
	@IdFoto     INT           = NULL,
	@Foto       VARCHAR (MAX) = NULL,
	@FechaCarga DATE          = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT * FROM Fotos
	END

	IF @Accion = 2
	BEGIN
		SELECT * FROM Fotos
		WHERE IdFoto = @IdFoto
	END

	IF @Accion = 3
	BEGIN
		INSERT INTO Fotos
		VALUES (@Foto, GETDATE())
	END
END

DELETE FROM Fotos