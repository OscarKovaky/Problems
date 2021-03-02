USE [MvcCarContext]
GO

/****** Objeto: Table [dbo].[Cars] Fecha del script: 01/03/2021 09:59:16 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cars] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Placa]       NVARCHAR (MAX) NULL,
    [Marca]       NVARCHAR (MAX) NULL,
    [NumeroSerie] NVARCHAR (MAX) NULL,
    [Modelo]      NVARCHAR (MAX) NULL
);


