
--DROP DATABASE DB_PracticasPre;

--CREATE DATABASE DB_PracticasPre;

USE DB_PracticasPre;

--CREATE TABLE TB_Rol (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_Modulo (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_Operacion (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_Detalle_Rol_Modulo_Operacion (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID),
--    ID_Modulo int FOREIGN KEY REFERENCES TB_Modulo(ID),
--    ID_Operacion int FOREIGN KEY REFERENCES TB_Operacion(ID)
--);

--CREATE TABLE TB_Usuario (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Codigo varchar(255),
--    Nombres varchar(255),
--    Apellidos varchar(255),
--    FecNacimiento date,
--    Correo varchar(255),
--    Clave varchar(255),
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID)
--);

--ALTER TABLE TB_Usuario ADD Codigo varchar(255);

--CREATE TABLE TB_Tramite (
--    ID int PRIMARY KEY IDENTITY(1,1),
--	  Tramite varchar(255),
--	  DependenciaReferencia varchar(255),
--    NumeroTramite varchar(255),
--    FecCreacion datetime,
--	  FundamentoSolicitud varchar(255),
--	  EmpresaNombre varchar(255),
--	  EmpresaRuc varchar(255),
--	  EmpresaDireccion varchar(255),
--	  EmpresaJefe varchar(255),
--	  EmpresaCargo varchar(255),
--	  AlumnoCiclo varchar(255),
--	  AdjuntoUno varchar(255),
--	  AdjuntoDos varchar(255),
--    ID_Usuario int FOREIGN KEY REFERENCES TB_Usuario(ID)
--);

--ALTER TABLE TB_Tramite ADD Tramite varchar(255);
--ALTER TABLE TB_Tramite ADD DependenciaReferencia varchar(255);
--ALTER TABLE TB_Tramite ADD FundamentoSolicitud varchar(255);
--ALTER TABLE TB_Tramite DROP COLUMN Numero;
--ALTER TABLE TB_Tramite ADD NumeroTramite varchar(255);
--ALTER TABLE TB_Tramite ADD EmpresaNombre varchar(255);
--ALTER TABLE TB_Tramite ADD EmpresaRuc varchar(255);
--ALTER TABLE TB_Tramite ADD EmpresaDireccion varchar(255);
--ALTER TABLE TB_Tramite ADD EmpresaJefe varchar(255);
--ALTER TABLE TB_Tramite ADD EmpresaCargo varchar(255);
--ALTER TABLE TB_Tramite ADD AlumnoCiclo varchar(255);
--ALTER TABLE TB_Tramite ADD AdjuntoUno varchar(255);
--ALTER TABLE TB_Tramite ADD AdjuntoDos varchar(255);


--INSERT INTO TB_Rol
--  ( Nombre)
--VALUES
--  ('Administrador'), 
--  ('Estudiante');

--INSERT INTO TB_Modulo
--  ( Nombre)
--VALUES
--  ('Modulo 1'), 
--  ('Modulo 2'), 
--  ('Modulo 3');

--INSERT INTO TB_Operacion
--  ( Nombre)
--VALUES
--  ('Listar'), 
--  ('Agregar'), 
--  ('Editar'), 
--  ('Eliminar');

--INSERT INTO TB_Detalle_Rol_Modulo_Operacion
--  ( ID_Rol, ID_Modulo, ID_Operacion)
--VALUES
--  (1, 1, 1), 
--  (1, 1, 2), 
--  (1, 1, 3), 
--  (1, 1, 4);

--INSERT INTO TB_Usuario
--  ( Codigo, Nombres, Apellidos, FecNacimiento, Correo, Clave, ID_Rol)
--VALUES
--  ( 1999014123, 'Martin', 'Gavino', '1995-04-17', 'martin@unfv.edu.pe', 123, 1),
--  ( 2013016328, 'Brian', 'Peñaloza', '1995-04-17', '2013016328@unfv.edu.pe', 123, 2),
--  ( 2014123456, 'Axel', 'Carhuatocto', '1995-04-17', '2014123456@unfv.edu.pe', 123, 2), 
--  ( 2014987147, 'Isabelle', 'Cabrejos', '1995-04-17', '2014987147@unfv.edu.pe', 123, 2);

--INSERT INTO TB_Tramite
--  ( Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, ID_Usuario)
--VALUES
--  ('CARTA DE PRESENTACION - PRACTICA PRE PROFESIONAL', 'FIIS', '00001', CURRENT_TIMESTAMP, 'Este es el fundamento', 2),
--  ('CONSTANCIA DE PRACTICAS PRE-PROFESIONALES', 'FIIS', '00002', CURRENT_TIMESTAMP, 'Este es el fundamento', 2);





SELECT TOP (1000) [ID]
      ,[Nombre]
  FROM [DB_PracticasPre].[dbo].[TB_Rol];

SELECT TOP (1000) [ID]
      ,[Nombre]
  FROM [DB_PracticasPre].[dbo].[TB_Modulo];

SELECT TOP (1000) [ID]
      ,[Nombre]
  FROM [DB_PracticasPre].[dbo].[TB_Operacion];

SELECT TOP (1000) [ID]
      ,[ID_Rol]
      ,[ID_Modulo]
      ,[ID_Operacion]
  FROM [DB_PracticasPre].[dbo].[TB_Detalle_Rol_Modulo_Operacion];

SELECT TOP (1000) [ID]
	  ,[Codigo]
      ,[Nombres]
      ,[Apellidos]
      ,[FecNacimiento]
	  ,[Correo]
      ,[Clave]
      ,[ID_Rol]
  FROM [DB_PracticasPre].[dbo].[TB_Usuario];

SELECT TOP (1000) [ID]
      ,[Tramite]
      ,[DependenciaReferencia]
      ,[NumeroTramite]
      ,[FecCreacion]
      ,[FundamentoSolicitud]
      ,[ID_Usuario]
  FROM [DB_PracticasPre].[dbo].[TB_Tramite];

SELECT TOP (1000) [ID]
      ,[Tramite]
      ,[DependenciaReferencia]
      ,[NumeroTramite]
      ,[FecCreacion]
      ,[FundamentoSolicitud]
      ,[EmpresaNombre]
      ,[EmpresaRuc]
      ,[EmpresaDireccion]
      ,[EmpresaJefe]
      ,[EmpresaCargo]
      ,[AlumnoCiclo]
      ,[AdjuntoUno]
      ,[AdjuntoDos]
	  ,[ID_Usuario]
  FROM [DB_PracticasPre].[dbo].[TB_Tramite];
    
	
--DELETE FROM TB_Tramite WHERE ID = 4

--SELECT ID, Nombres, Apellidos, FecNacimiento, Correo, Clave, ID_Rol FROM TB_Usuario WHERE Correo = '2013016328@unfv.edu.pe' AND Clave = 123 AND ID_Rol = 1;
--SELECT TOP 1 ID FROM TB_Usuario ORDER BY ID DESC
--UPDATE TB_Usuario SET Codigo = '2013016328' WHERE ID in (2, 3, 4);