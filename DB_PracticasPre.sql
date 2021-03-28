
--DROP DATABASE DB_PracticasPre;

--CREATE DATABASE DB_PracticasPre;

USE DB_PracticasPre;

--CREATE TABLE TB_Persona (
--    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    Nombres varchar(255) NOT NULL,
--    Apellidos varchar(255),
--    Correo varchar(255),
--    FecNacimiento date
--);

--CREATE TABLE TB_Rol (
--    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255) NOT NULL
--);

--CREATE TABLE TB_Modulo (
--    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255) NOT NULL
--);

--CREATE TABLE TB_Operacion (
--    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255) NOT NULL
--);

--CREATE TABLE TB_Detalle_Rol_Modulo_Operacion (
--    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID),
--    ID_Modulo int FOREIGN KEY REFERENCES TB_Modulo(ID),
--    ID_Operacion int FOREIGN KEY REFERENCES TB_Operacion(ID)
--);

--CREATE TABLE TB_Usuario (
--    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    Usuario varchar(255) NOT NULL,
--    Clave varchar(255),
--    ID_Persona int FOREIGN KEY REFERENCES TB_Persona(ID),
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID)
--);

--CREATE TABLE TB_Tramite (
--    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    Numero varchar(255) NOT NULL,
--    FecCreacion datetime,
--    ID_Persona int FOREIGN KEY REFERENCES TB_Persona(ID)
--);




--INSERT INTO TB_Persona
--  ( Nombres, Apellidos, Correo, FecNacimiento)
--VALUES
--  ('Brian', 'Peñaloza', '2013016328@unfv.edu.pe', '1995-04-17'), 
--  ('Axel', 'Carhuatocto', '2013016328@unfv.edu.pe', '1995-04-17'), 
--  ('Isabelle', 'Cabrejos', '2013016328@unfv.edu.pe', '1995-04-17');

--INSERT INTO TB_Rol
--  ( Nombre)
--VALUES
--  ('Estudiante'), 
--  ('Administrador');

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
--  ( Usuario, Clave, ID_Persona, ID_Rol)
--VALUES
--  ('2013016328@unfv.edu.pe', '2013016328', 1, 1), 
--  ('2013016328@unfv.edu.pe', '2013016328', 2, 2), 
--  ('2013016328@unfv.edu.pe', '2013016328', 3, 1);




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

  --select id, usuario, clave, id_persona, id_rol from tb_usuario where usuario = 'brian' and clave = 123 and id_rol = 1