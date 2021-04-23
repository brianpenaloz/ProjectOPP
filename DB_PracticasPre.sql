
--DROP DATABASE DB_PracticasPre;

--CREATE DATABASE DB_PracticasPre;

USE DB_PracticasPre;

--ALTER TABLE TB_ ADD ID_ int;
--ALTER TABLE TB_ ADD FOREIGN KEY (ID_) REFERENCES TB_(ID);
--ALTER TABLE TB_ DROP COLUMN ;
--UPDATE TB_ SET  =  WHERE ID in ();
--SELECT  FROM TB_;
--DELETE FROM TB_ WHERE ID in ();
--SELECT TOP 1 ID FROM TB_ ORDER BY ID DESC





--CREATE TABLE TB_Estado (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255),
--    Tabla varchar(255)
--);

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

--CREATE TABLE TB_Facultad (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_Escuela (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255),
--	  ID_Facultad int FOREIGN KEY REFERENCES TB_Facultad(ID)
--);

--CREATE TABLE TB_Departamento (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_Provincia (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255),
--	  ID_Departamento int FOREIGN KEY REFERENCES TB_Departamento(ID)
--);

--CREATE TABLE TB_Distrito (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255),
--	  ID_Provincia int FOREIGN KEY REFERENCES TB_Provincia(ID)
--);

--CREATE TABLE TB_TipoDocumento (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_CicloAlumno (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_Usuario (
--    ID int PRIMARY KEY IDENTITY(1,1),
--	  NumeroDocumento varchar(255),
--    Nombres varchar(255),
--    ApellidoPaterno varchar(255),
--    ApellidoMaterno varchar(255),
--    FecNacimiento date,
--    Direccion varchar(255),
--    NumeroDireccion varchar(255),
--    TelefonoFijo varchar(255),
--    Celular varchar(255),
--    Codigo varchar(255),
--    Correo varchar(255),
--    Clave varchar(255),
--    ID_TipoDocumento int FOREIGN KEY REFERENCES TB_TipoDocumento(ID),
--    ID_Distrito int FOREIGN KEY REFERENCES TB_Distrito(ID),
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID),
--    ID_Escuela int FOREIGN KEY REFERENCES TB_Escuela(ID)
--);

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
--	  AdjuntoUno varchar(255),
--	  AdjuntoDos varchar(255),
--    ID_Usuario int FOREIGN KEY REFERENCES TB_Usuario(ID),
--    ID_CicloAlumno int FOREIGN KEY REFERENCES TB_CicloAlumno(ID),
--    ID_Estado int FOREIGN KEY REFERENCES TB_Estado(ID)
--);





--INSERT INTO TB_Estado
--  ( Nombre, Tabla)
--VALUES
--  ('Pendiente', 'TB_Tramite'), 
--  ('Tramitado', 'TB_Tramite');

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

--INSERT INTO TB_Facultad
--  ( Nombre)
--VALUES
--  ('(FIIS) INGENIERIA INDUSTRIAL Y DE SISTEMAS'), 
--  ('(FA) DE ADMINISTRACION'), 
--  ('(FAPS) PSICOLOGIA'), 
--  ('(FAU) ARQUITECTURA Y URBANISMO');

--INSERT INTO TB_Escuela
--  ( Nombre, ID_Facultad)
--VALUES
--  ('ESCUELA PROFESIONAL DE INGENIERIA AGROINDUSTRIAL', 1), 
--  ('ESCUELA PROFESIONAL DE INGENIERIA DE SISTEMAS', 1), 
--  ('ESCUELA PROFESIONAL DE INGENIERIA DE TRANSPORTES', 1), 
--  ('ESCUELA PROFESIONAL DE INGENIERIA INDUSTRIAL', 1);

--INSERT INTO TB_Departamento
--  ( Nombre)
--VALUES
--  ('CALLAO'), 
--  ('LIMA');

--INSERT INTO TB_Provincia
--  ( Nombre, ID_Departamento)
--VALUES
--  ('CALLAO', 1), 
--  ('BARRANCA', 2), 
--  ('CAJATAMBO', 2), 
--  ('CANTA', 2), 
--  ('CAÑETE', 2), 
--  ('HUARAL', 2), 
--  ('HUAROCHIRI', 2), 
--  ('HUAURA', 2), 
--  ('LIMA', 2), 
--  ('OYON', 2), 
--  ('YAUYOS', 2);

--INSERT INTO TB_Distrito
--  ( Nombre, ID_Provincia)
--VALUES
--  ('BELLAVISTA', 1), 
--  ('CALLAO', 1), 
--  ('CARMEN DE LA LEGUA-REYNOSO', 1), 
--  ('LA PERLA', 1), 
--  ('LA PUNTA', 1), 
--  ('VENTANILLA', 1);

--INSERT INTO TB_TipoDocumento
--  ( Nombre)
--VALUES
--  ('DNI'), 
--  ('PASAPORTE'), 
--  ('CARNE DE EXTRANJERIA'), 
--  ('RUC');

--INSERT INTO TB_CicloAlumno
--  ( Nombre)
--VALUES
--  ('1er'), 
--  ('2do'), 
--  ('3er'), 
--  ('4to'), 
--  ('5to'), 
--  ('6to'), 
--  ('7mo'), 
--  ('8vo'), 
--  ('9no'),  
--  ('10mo');

--INSERT INTO TB_Usuario
--  ( NumeroDocumento, Nombres, ApellidoPaterno, ApellidoMaterno, FecNacimiento, Direccion, NumeroDireccion, TelefonoFijo, Celular, Codigo, Correo, Clave, ID_TipoDocumento, ID_Distrito, ID_Rol, ID_Escuela)
--VALUES
--  ( '12345678', 'Martin', 'Gavino', 'Ramos', '1995-04-17', 'AV Colonial', '123', '555-5555', '999999999', '1234456', 'martin@unfv.edu.pe', '123', 1, 6, 1, 2),
--  ( '12345678', 'Brian', 'Peñaloza', 'Ortega', '1995-04-17', 'AV Colonial', '123', '555-5555', '999999999', '1234456', '2013016328@unfv.edu.pe', '123', 1, 6, 2, 2),
--  ( '12345678', 'Axel', 'Carhuatocto'. Carhuatocto, '1995-04-17', 'AV Colonial', '123', '555-5555', '999999999', '1234456', '2014123456@unfv.edu.pe', '123', 1, 6, 2, 2),
--  ( '12345678', 'Isabelle', 'Cabrejos', 'Caldas', '1995-04-17', 'AV Colonial', '123', '555-5555', '999999999', '1234456', '2014987147@unfv.edu.pe', '123', 1, 6, 2, 2);

--INSERT INTO TB_Tramite
--  ( Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, EmpresaNombre, EmpresaRuc, EmpresaDireccion, EmpresaJefe, EmpresaCargo, AdjuntoUno, AdjuntoDos, ID_Usuario, ID_CicloAlumno, ID_Estado)
--VALUES
--  ('CARTA DE PRESENTACION - PRACTICA PRE PROFESIONAL', 'ESPECIALIDAD DE INGENIERIA DE SISTEMAS', '1', GETDATE(), 'A razon de realizar mis practicas pre profesionales en la empresa BCP', 'BCP', '12345678901', 'AV La Molina 123', 'Carlos Paredes', 'Gerente General', 'AdjuntoUno', 'AdjuntoDos', 2, 10, 1),
--  ('CARTA DE PRESENTACION - PRACTICA PRE PROFESIONAL', 'ESPECIALIDAD DE INGENIERIA DE SISTEMAS', '2', CURRENT_TIMESTAMP, 'A razon de realizar mis practicas pre profesionales en la empresa',  'BCP', '12345678901', 'AV La Molina 123', 'Carlos Paredes', 'Gerente General', 'AdjuntoUno', 'AdjuntoDos', 3, 10, 1);





SELECT TOP (1000) [ID]
      ,[Nombre]
	  ,[Tabla]
  FROM [DB_PracticasPre].[dbo].[TB_Estado];

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
      ,[Nombre]
  FROM [DB_PracticasPre].[dbo].[TB_Facultad];

SELECT TOP (1000) [ID]
      ,[Nombre]
      ,[ID_Facultad]
  FROM [DB_PracticasPre].[dbo].[TB_Escuela];

SELECT TOP (1000) [ID]
      ,[Nombre]
  FROM [DB_PracticasPre].[dbo].[TB_Departamento];

SELECT TOP (1000) [ID]
      ,[Nombre]
      ,[ID_Departamento]
  FROM [DB_PracticasPre].[dbo].[TB_Provincia];

SELECT TOP (1000) [ID]
      ,[Nombre]
      ,[ID_Provincia]
  FROM [DB_PracticasPre].[dbo].[TB_Distrito];

SELECT TOP (1000) [ID]
      ,[Nombre]
  FROM [DB_PracticasPre].[dbo].[TB_TipoDocumento];

SELECT TOP (1000) [ID]
      ,[Nombre]
  FROM [DB_PracticasPre].[dbo].[TB_CicloAlumno];

SELECT TOP (1000) [ID]
	  ,[NumeroDocumento]
      ,[Nombres]
      ,[ApellidoPaterno]
	  ,[ApellidoMaterno]
      ,[FecNacimiento]
	  ,[Direccion]
	  ,[NumeroDireccion]
	  ,[TelefonoFijo]
	  ,[Celular]
	  ,[Codigo]
	  ,[Correo]
      ,[Clave]
	  ,[ID_TipoDocumento]
	  ,[ID_Distrito]
      ,[ID_Rol]
	  ,[ID_Escuela]
  FROM [DB_PracticasPre].[dbo].[TB_Usuario];

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
      ,[AdjuntoUno]
      ,[AdjuntoDos]
	  ,[ID_Usuario]
	  ,[ID_CicloAlumno]
	  ,[ID_Estado]
  FROM [DB_PracticasPre].[dbo].[TB_Tramite];



SELECT 
T.ID, T.Tramite, T.DependenciaReferencia, T.NumeroTramite, T.FecCreacion, T.FundamentoSolicitud, T.EmpresaNombre, T.EmpresaRuc, T.EmpresaDireccion, T.EmpresaJefe, T.EmpresaCargo, T.AdjuntoUno, T.AdjuntoDos, T.ID_Usuario, T.ID_CicloAlumno, T.ID_Estado,
U.ID, U.NumeroDocumento, U.Nombres, U.ApellidoPaterno, U.ApellidoMaterno, U.FecNacimiento, U.Direccion, U.NumeroDireccion, U.TelefonoFijo, U.Celular, U.Codigo, U.Correo, U.Clave, U.ID_TipoDocumento, U.ID_Distrito, U.ID_Rol, U.ID_Escuela,
CA.ID, CA.Nombre
FROM TB_Tramite T
INNER JOIN TB_Usuario U ON T.ID_Usuario = U.ID
INNER JOIN TB_CicloAlumno CA ON T.ID_CicloAlumno = CA.ID
WHERE T.ID = 16

