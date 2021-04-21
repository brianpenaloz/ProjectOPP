
--DROP DATABASE DB_PracticasPre;

--CREATE DATABASE DB_PracticasPre;

USE DB_PracticasPre;

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
--	  ID_Facultad int
--);

--ALTER TABLE TB_Escuela ADD ID_Facultad int;
--ALTER TABLE TB_Escuela ADD FOREIGN KEY (ID_Facultad) REFERENCES TB_Facultad(ID);

--CREATE TABLE TB_Departamento (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--CREATE TABLE TB_Provincia (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--ALTER TABLE TB_Provincia ADD ID_Departamento int;
--ALTER TABLE TB_Provincia ADD FOREIGN KEY (ID_Departamento) REFERENCES TB_Departamento(ID);

--CREATE TABLE TB_Distrito (
--    ID int PRIMARY KEY IDENTITY(1,1),
--    Nombre varchar(255)
--);

--ALTER TABLE TB_Distrito ADD ID_Provincia int;
--ALTER TABLE TB_Distrito ADD FOREIGN KEY (ID_Provincia) REFERENCES TB_Provincia(ID);

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
--    ID_Rol int FOREIGN KEY REFERENCES TB_Rol(ID)
--    ID_Escuela int FOREIGN KEY REFERENCES TB_Escuela(ID)
--    ID_Distrito int FOREIGN KEY REFERENCES TB_Distrito(ID)
--);

--ALTER TABLE TB_Usuario ADD Codigo varchar(255);
--ALTER TABLE TB_Usuario ADD NumeroDocumento varchar(255);
--ALTER TABLE TB_Usuario ADD ApellidoPaterno varchar(255);
--ALTER TABLE TB_Usuario ADD ApellidoMaterno varchar(255);
--ALTER TABLE TB_Usuario ADD Direccion varchar(255);
--ALTER TABLE TB_Usuario ADD NumeroDireccion varchar(255);
--ALTER TABLE TB_Usuario ADD TelefonoFijo varchar(255);
--ALTER TABLE TB_Usuario ADD Celular varchar(255);
ALTER TABLE TB_Usuario ADD ID_Escuela int;
ALTER TABLE TB_Usuario ADD ID_Distrito int;
--ALTER TABLE TB_Usuario DROP COLUMN Apellidos;
--ALTER TABLE TB_Usuario DROP COLUMN Escuela;
--ALTER TABLE TB_Usuario DROP COLUMN Distrito;


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
--ALTER TABLE TB_Tramite ADD ID_Estado int;
--ALTER TABLE TB_Tramite ADD FOREIGN KEY (ID_Estado) REFERENCES TB_Estado(ID);





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
--  ( Nombre)
--VALUES
--  ('CALLAO'), 
--  ('BARRANCA'), 
--  ('CAJATAMBO'), 
--  ('CANTA'), 
--  ('CAÑETE'), 
--  ('HUARAL'), 
--  ('HUAROCHIRI'), 
--  ('HUAURA'), 
--  ('LIMA'), 
--  ('OYON'), 
--  ('YAUYOS');

--INSERT INTO TB_Distrito
--  ( Nombre)
--VALUES
--  ('BELLAVISTA'), 
--  ('CALLAO'), 
--  ('CARMEN DE LA LEGUA-REYNOSO'), 
--  ('LA PERLA'), 
--  ('LA PUNTA'), 
--  ('VENTANILLA');

--INSERT INTO TB_Usuario
--  ( NumeroDocumento, Nombres, ApellidoPaterno, ApellidoMaterno, FecNacimiento, Direccion, NumeroDireccion, TelefonoFijo, Celular, Codigo, Correo, Clave, ID_Rol, ID_Escuela, ID_Distrito)
--VALUES
--  ( '12345678', 'Martin', 'Gavino', 'Ramos', '1995-04-17', 'martin@unfv.edu.pe', 123, 1),
--  ( '12345678', 'Brian', 'Peñaloza', 'Ortega', '1995-04-17', '2013016328@unfv.edu.pe', 123, 2),
--  ( '12345678', 'Axel', 'Carhuatocto'. Carhuatocto, '1995-04-17', '2014123456@unfv.edu.pe', 123, 2), 
--  ( '12345678', 'Isabelle', 'Cabrejos', 'Caldas', '1995-04-17', '2014987147@unfv.edu.pe', 123, 2);

--UPDATE TB_Usuario SET Codigo = '2013016328' WHERE ID in (2, 3, 4);

--INSERT INTO TB_Tramite
--  ( Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, ID_Usuario)
--VALUES
--  ('CARTA DE PRESENTACION - PRACTICA PRE PROFESIONAL', 'FIIS', '00001', CURRENT_TIMESTAMP, 'Este es el fundamento', 2),
--  ('CONSTANCIA DE PRACTICAS PRE-PROFESIONALES', 'FIIS', '00002', CURRENT_TIMESTAMP, 'Este es el fundamento', 2);

--UPDATE TB_Tramite SET EmpresaNombre = 'BCP', EmpresaRuc = '1234567890', EmpresaDireccion = 'AV La Molina', EmpresaJefe = 'Gerardo', EmpresaCargo = 'Gerente', AlumnoCiclo = '9', AdjuntoUno = 'path1', AdjuntoDos = 'path2' WHERE ID in (8, 9, 10, 11, 12, 13);
--UPDATE TB_Tramite SET ID_Estado = 1;





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
      ,[EmpresaNombre]
      ,[EmpresaRuc]
      ,[EmpresaDireccion]
      ,[EmpresaJefe]
      ,[EmpresaCargo]
      ,[AlumnoCiclo]
      ,[AdjuntoUno]
      ,[AdjuntoDos]
	  ,[ID_Usuario]
	  ,[ID_Estado]
  FROM [DB_PracticasPre].[dbo].[TB_Tramite];
    
	
--DELETE FROM TB_Tramite WHERE ID = 4
--SELECT ID, Nombres, Apellidos, FecNacimiento, Correo, Clave, ID_Rol FROM TB_Usuario WHERE Correo = '2013016328@unfv.edu.pe' AND Clave = 123 AND ID_Rol = 1;
--SELECT TOP 1 ID FROM TB_Usuario ORDER BY ID DESC
--SELECT ID, Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, EmpresaNombre, EmpresaRuc, EmpresaDireccion, EmpresaJefe, EmpresaCargo, AlumnoCiclo, AdjuntoUno, AdjuntoDos, ID_Usuario FROM TB_Tramite
