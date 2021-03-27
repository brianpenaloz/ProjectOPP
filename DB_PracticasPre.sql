
--DROP DATABASE DB_PracticasPre;

--CREATE DATABASE DB_PracticasPre;

USE DB_PracticasPre;

--CREATE TABLE TB_Persona (
--    ID int NOT NULL PRIMARY KEY,
--    Nombres varchar(255) NOT NULL,
--    Apellidos varchar(255),
--    Correo varchar(255),
--    FecNacimiento date
--);

--CREATE TABLE TB_Rol (
--    ID int NOT NULL PRIMARY KEY,
--    Nombre varchar(255) NOT NULL
--);

--CREATE TABLE TB_Modulo (
--    ID int NOT NULL PRIMARY KEY,
--    Nombre varchar(255) NOT NULL
--);

--CREATE TABLE TB_Operacion (
--    ID int NOT NULL PRIMARY KEY,
--    Nombre varchar(255) NOT NULL
--);

--CREATE TABLE TB_Detalle_Rol_Modulo_Operacion (
--    ID int NOT NULL PRIMARY KEY,
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID),
--    ID_Modulo int FOREIGN KEY REFERENCES TB_Modulo(ID),
--    ID_Operacion int FOREIGN KEY REFERENCES TB_Operacion(ID)
--);

--CREATE TABLE TB_Usuario (
--    ID int NOT NULL PRIMARY KEY,
--    Usuario varchar(255) NOT NULL,
--    Clave varchar(255),
--    ID_Persona int FOREIGN KEY REFERENCES TB_Persona(ID),
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID)
--);

--CREATE TABLE TB_Tramite (
--    ID int NOT NULL PRIMARY KEY,
--    Numero varchar(255) NOT NULL,
--    FecCreacion datetime,
--    ID_Persona int FOREIGN KEY REFERENCES TB_Persona(ID)
--);




--INSERT INTO TB_Persona
--  ( ID, Nombres, Apellidos, Correo, FecNacimiento)
--VALUES
--  (1, 'Brian', 'Peñaloza', 'Peñaloza', '1995-04-17'), 
--  (2, 'Axel', 'Carhuatocto', 'Carhuatocto', '1995-04-17'), 
--  (3, 'Isabelle', 'Cabrejos', 'Cabrejos', '1995-04-17');

--INSERT INTO TB_Rol
--  ( ID, Nombre)
--VALUES
--  (1, 'Usuario'), 
--  (2, 'Administrador'), 
--  (3, 'Super Administrador');

--INSERT INTO TB_Modulo
--  ( ID, Nombre)
--VALUES
--  (1, 'Modulo 1'), 
--  (2, 'Modulo 2'), 
--  (3, 'Modulo 3');

--INSERT INTO TB_Operacion
--  ( ID, Nombre)
--VALUES
--  (1, 'Listar'), 
--  (2, 'Agregar'), 
--  (3, 'Editar'), 
--  (4, 'Eliminar');

--INSERT INTO TB_Detalle_Rol_Modulo_Operacion
--  ( ID, ID_Rol, ID_Modulo, ID_Operacion)
--VALUES
--  (1, 1, 1, 1), 
--  (2, 1, 1, 2), 
--  (3, 1, 1, 3), 
--  (4, 1, 1, 4);

--INSERT INTO TB_Usuario
--  ( ID, Usuario, Clave, ID_Persona, ID_Rol)
--VALUES
--  (1, 'brian', '123', 1, 1), 
--  (2, 'axel', '123', 2, 2), 
--  (3, 'isabelle', '123', 3, 3);




SELECT TOP (1000) [ID]
      ,[Nombres]
      ,[Apellidos]
	  ,[Correo]
      ,[FecNacimiento]
  FROM [DB_PracticasPre].[dbo].[TB_Persona];

  --DELETE FROM TB_Persona WHERE ID = 4

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
      ,[Usuario]
      ,[Clave]
      ,[ID_Persona]
      ,[ID_Rol]
  FROM [DB_PracticasPre].[dbo].[TB_Usuario];