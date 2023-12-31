-- CREACION DE LA BASE DE DATOS
CREATE DATABASE CAMISAS_POLOS
-- USO DE LA BASE DE DATOS
USE CAMISAS_POLOS
-- CREACION DE TABLAS FUERTES
-- TABLA DE MATERIAL
CREATE TABLE MATERIALES
(
    ID_MATERIAL INT PRIMARY KEY IDENTITY,
    NOMBRE_MATERIAL VARCHAR(50),
    CANTIDAD_DISPONIBLE INT, -- Cambiado a INT para reflejar una cantidad num�rica
    CANTIDAD_MINIMA INT,
    PRECIO_UNITARIO MONEY
)
-- TABLA DE USUARIOS
CREATE TABLE USUARIOS
(
    USUARIO_ID INT PRIMARY KEY IDENTITY,
    NOMBRE_USUARIO VARCHAR(50) UNIQUE,
    CLAVE VARCHAR(255)
)
-- TABLA DE ORDEN DE PRODUCCION
CREATE TABLE ORDEN_PRODUCCION
(
    ID_ORDEN_PRODUCCION INT PRIMARY KEY IDENTITY,
    USUARIO_ID INT REFERENCES USUARIOS(USUARIO_ID),
    NUMERO_ORDEN INT,
    CANTIDAD INT,
    FECHA_INICIO DATE,
    FECHA_ENTREGA DATE,
    MODELO VARCHAR(100),
    TALLA VARCHAR(50),
    COLOR VARCHAR(50),
    ESTADO_PRODUCCION VARCHAR(100),
    ID_MATERIAL INT REFERENCES MATERIALES(ID_MATERIAL)
)
-- TABLA DE PRODUCCION
CREATE TABLE PRODUCCION
(
    ID_PRODUCCION INT PRIMARY KEY IDENTITY,
    ID_ORDEN_PRODUCCION INT REFERENCES ORDEN_PRODUCCION(ID_ORDEN_PRODUCCION),
    ETAPA_PRODUCCION VARCHAR(100),
    FECHA DATE,
    CANTIDAD_PRODUCIDA INT
)
-- TABLA DE CONTROL DE CALIDAD
CREATE TABLE CONTROL_CALIDAD
(
    ID_CONTROL_CALIDAD INT PRIMARY KEY IDENTITY,
    ID_ORDEN_PRODUCCION INT REFERENCES ORDEN_PRODUCCION(ID_ORDEN_PRODUCCION),
    ETAPA_CONTROL VARCHAR(100),
    FECHA_CONTROL DATE,
    DEFECTOS_ENCONTRADOS VARCHAR(100)
)
USE [CAMISAS_POLOS]
GO

INSERT INTO [dbo].[USUARIOS]
           ([NOMBRE_USUARIO]
           ,[CLAVE]
           )
     VALUES
           ('Victoria',
           '123456')
GO
select * from USUARIOS

-- Procedimiento para consultar credenciales, osea el usuario
CREATE PROCEDURE VERIFICAR_USUARIO
    @NOMBRE_USUARIO VARCHAR(50),
    @CLAVE VARCHAR(255)
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM [dbo].[USUARIOS] 
        WHERE NOMBRE_USUARIO = @NOMBRE_USUARIO 
        AND CLAVE = @CLAVE
    )
    BEGIN
        SELECT 1 AS [EXISTE] 
    END
    ELSE
    BEGIN
        SELECT 0 AS [EXISTE]
    END
END
GO
Execute VERIFICAR_USUARIO 'Victoria', '12456'
