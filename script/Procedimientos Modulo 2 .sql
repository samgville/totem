﻿------------------+ PROCEDIMIENTOS MODULO 2 ----------------------------------------------------

------------------+Verificar Cliente Juridico(ClienteJuridico cjid)------------------------------
-- Método verificarClienteJuridico(ClienteJuridico laEmpresa) verifica si el cliente existe o no  


CREATE PROCEDURE Procedure_verificarClienteJuridico
		 
		@cj_rif [nvarchar](20)	
AS 
BEGIN
		(SELECT count(cj_rif) FROM CLIENTE_JURIDICO WHERE cj_rif = @cj_rif);
END;
GO

------------------+Agregar Cliente Juridico------------------------------
-- Método Agregar Cliente Juridico inserta todos los datos pertenecientesa a la tabla Cliente_Juridico


CREATE PROCEDURE Procedure_AgregarClienteJuridico
	 
	@cj_rif [nvarchar](20),
	@nombre [nvarchar](60),
	@cj_logo [nvarchar](60),
	@Fklugar [int],
	@nombreDireccion varchar(60),
	@cedula          varchar(20),
	@nombreContacto     varchar(60),
	@apellido            varchar(60),
	@idCargo         int,
	
	@codigo               int,
	@numero               int
	
AS

DECLARE @idMaxClienteJuridico int = 0
DECLARE @idLugarDireccion int = 0
DECLARE @idMaxLugar int = 0
DECLARE @idMaxContacto  int =0
DECLARE @idMaxTelefono int=0
DECLARE @idTelefono int = 0
DECLARE @idDireccionAInsertar int = 0

 
BEGIN

select @idLugarDireccion = count(LUG_id) from lugar 
	 where  LUG_tipo = 'Direccion' and LUGAR_lug_id = @Fklugar;

select @idDireccionAInsertar = LUG_ID from lugar 
	 where  LUG_tipo = 'Direccion' and LUGAR_lug_id = @Fklugar;

/*Si la dirección es nueva o no existe*/
if (@idLugarDireccion = 0)
		begin 
			select @idMaxLugar = MAX(LUG_id) from lugar;

			set @idMaxLugar = @idMaxLugar + 1;

			INSERT INTO lugar VALUES (@idMaxLugar,@nombreDireccion,'Direccion',null,@Fklugar);

			set @idDireccionAInsertar =  @idMaxLugar; 
			
		end

/*Busco el último id del cliente insertado e inserto 
el último id + 1*/
select @idMaxClienteJuridico = Max(cj_id) from CLIENTE_JURIDICO;

    set @idMaxClienteJuridico = @idMaxClienteJuridico + 1;

    INSERT INTO CLIENTE_JURIDICO(cj_ID, cj_rif, cj_nombre, cj_logo,LUGAR_lug_id)
    VALUES(@idMaxClienteJuridico, @cj_rif, @nombre, @cj_logo,@idDireccionAInsertar);

	

SELECT @idMaxContacto = Max(con_id) FROM CONTACTO; 

	set @idMaxContacto = @idMaxContacto +1; 

	INSERT INTO CONTACTO(con_id,con_cedula,con_nombre,con_apellido,CLIENTE_JURIDICO_cj_id,CARGO_car_id,CLIENTE_NATURAL_cn_id)
	VALUES(@idMaxContacto,@cedula,@nombreContacto,@apellido,@idMaxClienteJuridico,@idCargo,null);

select @idTelefono=count(*) from telefono where tel_numero=@numero  and tel_codigo=@codigo

if (@idTelefono=0)
begin 
			select @idMaxTelefono = Max(tel_id) from TELEFONO;

			set @idMaxTelefono = @idMaxTelefono+1; 
			INSERT INTO TELEFONO VALUES (@idMaxTelefono,@codigo,@numero,null,@idMaxContacto);

			
		end

END;
GO
 
 

------------------+Modificar Cliente Juridico------------------------------
-- Método Modificar Cliente Juridico Modifica los datos de la tabla Cliente Juridico segun el id asociado

CREATE PROCEDURE Procedure_modificarClienteJuridico

	@cj_rif [nvarchar](20),
	@cj_nombre [nvarchar](60),
	@idCiudad int,
	@nombreDireccion varchar(100)

	     

	AS
	
DECLARE @idMaxLugar int = 0
DECLARE @idLugarDireccion int = 0


BEGIN

	select @idLugarDireccion = lug_id from LUGAR where lug_nombre = @nombreDireccion and lug_tipo = 'Direccion' and LUGAR_lug_id = @idCiudad;

	if (@idLugarDireccion = 0)
		begin 
			select @idMaxLugar = MAX(LUG_id) from lugar;

			set @idMaxLugar = @idMaxLugar + 1;

			INSERT INTO lugar VALUES (@idMaxLugar,@nombreDireccion,'Direccion',null,@idCiudad);

			set @idLugarDireccion = @idMaxLugar;
		end

	UPDATE CLIENTE_JURIDICO 

	SET 	
		 	
		cj_rif     = @cj_rif,
		cj_nombre  = @cj_nombre,		  
		LUGAR_lug_id  = @idLugarDireccion
	WHERE
		cj_rif = @cj_rif
END;
GO





------------------+consultar Datos Cliente Juridico------------------------------
-- Método Consultar Cliente Juridico Consulta todos los datos pertenecientesa a la tabla Cliente_Juridico según el id
 

CREATE PROCEDURE Procedure_consultarDatosClienteJuridico
@cj_rif   varchar(20) 

AS
   
SELECT  DISTINCT (cj.cj_rif ), 
		cj.cj_nombre as nombre_juridico,
		cj.LUGAR_lug_id 
	
	FROM CLIENTE_JURIDICO cj
	WHERE cj.cj_rif=@cj_rif;
GO		  

------------------+ClienteConId(string Cli_jur_id):list <cliente_juridico>------------------------------

--comentarios del grupo que pidio el metodo... 
--Para el formulario de crear proyectos, es necesario tener un método que retorne
--todos los clientes con su id o clave primaria, no importa si son naturales o jurídicos

CREATE PROCEDURE ClienteConIdJuridico				
AS 
BEGIN
		SELECT cj_rif AS RIFJURIDICO, cj_nombre AS NOMBREJURIDICO FROM CLIENTE_JURIDICO;				
END;
GO

------------------+ListarCargosPorEmpresa(ClienteJuridico cj):list<string>------------------------------
--comentarios del grupo que pidio el metodo... 
-- Metodo listarCargosPorEmpresa(ClienteJuridico laEmpresa) y devuelve una lista de strings que es el nombre de cada cargo que poseen los empleados
-- pertenecientes a esa empresa.

CREATE PROCEDURE ListarCargosPorEmpresa
		
	@cj_rif int		
AS 
BEGIN
	SELECT DISTINCT(car_nombre) 
	FROM CARGO
	WHERE car_id IN (SELECT DISTINCT (CARGO_car_id) FROM CONTACTO WHERE CLIENTE_JURIDICO_cj_id = @cj_rif)	
END;

GO

------------------+ConsultarEmpleadosEmpresaCargo():list<cliente_juridico>------------------------------
-- comentarios del grupo que pidio el metodo... 
-- Metodo consultarEmpleadosEmpresaCargo(ClienteJuridico laEmpresa, String cargo) y devuelve una lista de Contacto con el nombre, apellido y cargo
-- que son los empleados que desempe?an ese cargo en esa empresa.
CREATE PROCEDURE ConsultarEmpleadosEmpresaCargo
		
	@cj_rif int,
	@car_nombre [nvarchar](60)		
AS 
BEGIN
		(SELECT con_nombre AS NOMBRECONTACTO, con_apellido AS APELLIDOCONTACTO, car_nombre AS CARGOCONTACTO, con_id as IDCONTACTO
		 FROM CONTACTO, CARGO
		 WHERE CLIENTE_JURIDICO_cj_id = @cj_rif  
				AND CARGO_car_id = (SELECT car_id FROM CARGO WHERE car_nombre = @car_nombre)
				AND CARGO_car_id = car_id);		
END;
GO


------------------+VerificarClienteNatural(string Cli_nat_id): bool------------------------------
-- Dada la cedula verifica si existe o no el cliente natural 

CREATE PROCEDURE Procedure_verificarClienteNatural
		
	@cn_cedula [nvarchar](20)		
AS 
BEGIN
		(SELECT count(cn_cedula) FROM CLIENTE_NATURAL WHERE cn_cedula= @cn_cedula); 	
END;
GO

------------------+AgregarClienteNatural(ClienteNatural cn): bool------------------------------
-- Agrega un nuevo cliente natural
-- luego de Insertar cliente natural, inserta en contacto los mismos datos.



------------------+AgregarClienteNatural(ClienteNatural cn): bool------------------------------
-- Agrega un nuevo cliente natural
-- luego de Insertar cliente natural, inserta en contacto los mismos datos.



------------------+AgregarClienteNatural(ClienteNatural cn): bool------------------------------
-- Agrega un nuevo cliente natural
-- luego de Insertar cliente natural, inserta en contacto los mismos datos.


CREATE PROCEDURE Procedure_AgregarClienteNatural
	@cn_cedula [nvarchar](20),
	@cn_nombre [nvarchar](60),
	@cn_apellido [nvarchar](60),
	@nombreDireccion varchar(100),
	@cn_correo [nvarchar](60),
	@LUGAR_lug_id [int],
	@codigo int,
	@numero int

AS
DECLARE @idMaxClienteNatural int = 0
DECLARE @idLugarDireccion int = 0
DECLARE @idMaxContacto int = 0
DECLARE @idMaxTelefono int=0
DECLARE @idTelefono int = 0
DECLARE @idMaxLugar int = 0

BEGIN
	
	select @idLugarDireccion = count(LUG_id) from lugar 
	 where  LUG_tipo = 'Direccion' and LUGAR_lug_id = @LUGAR_lug_id;
	
	if (@idLugarDireccion = 0)
		begin 
			select @idMaxLugar = MAX(LUG_id) from lugar;

			set @idMaxLugar = @idMaxLugar + 1;

			INSERT INTO lugar VALUES (@idMaxLugar,@nombreDireccion,'Direccion',null,@LUGAR_lug_id);

			set @idLugarDireccion = @idMaxLugar;
		end

	select @idMaxClienteNatural = Max(cn_id) from CLIENTE_NATURAL;
	select @idMaxContacto = MAX(con_id) from CONTACTO;
    set @idMaxClienteNatural = @idMaxClienteNatural + 1;
	set @idMaxContacto = @idMaxContacto + 1;
	
    INSERT INTO CLIENTE_NATURAL(cn_id,cn_cedula,cn_nombre,cn_apellido,cn_correo,LUGAR_lug_id)
    VALUES(@idMaxClienteNatural, @cn_cedula,@cn_nombre,@cn_apellido,@cn_correo,@LUGAR_lug_id);
	
	INSERT INTO CONTACTO (con_id,con_cedula,con_nombre,con_apellido,CLIENTE_JURIDICO_cj_id,CARGO_car_id,CLIENTE_NATURAL_cn_id)
    VALUES(@idMaxContacto, @cn_cedula,@cn_nombre,@cn_apellido,null, null,@idMaxClienteNatural);
	
	select @idTelefono=count(*) from telefono where tel_numero=@numero  and tel_codigo=@codigo

if (@idTelefono=0)
begin 
			select @idMaxTelefono = Max(tel_id) from TELEFONO;

			set @idMaxTelefono = @idMaxTelefono+1; 
			INSERT INTO TELEFONO VALUES (@idMaxTelefono,@codigo,@numero,@idMaxClienteNatural,@idMaxContacto);

			
		end

END;
GO

------------------+ConsultarDatosDeContacto(Contacto c): list<datos>------------------------------
-- comentarios del grupo que pidio el metodo... 
-- Un método consultarDatosDeContacto(Contacto c) que devuelva nombre, apellido, cargo y nombre de la empresa en la q trabaja

CREATE PROCEDURE ConsultarDatosDeContacto
		
	@con_cedula [int]		
AS 
BEGIN
		(SELECT con_cedula as CEDULA, con_nombre AS NOMBRE, con_apellido AS APELLIDO, car_nombre AS CARGO , cj_nombre AS EMPRESATRABAJO 
		FROM CONTACTO, CLIENTE_JURIDICO, CARGO
		WHERE CLIENTE_JURIDICO_cj_id= cj_id
				AND CARGO_car_id = car_id
				AND con_cedula =@con_cedula); 	
END;
GO


/*---------Eliminar Cliente Natural-----------------------------*/

CREATE PROCEDURE Procedure_EliminarClienteNatural
@cedula varchar (20)
AS
DECLARE 
@idNatural integer 
BEGIN

select  @idNatural = t.CLIENTE_NATURAL_cn_id 
from TELEFONO t,
     CONTACTO co, 
     CLIENTE_NATURAL cn
where cn.cn_id=t.CLIENTE_NATURAL_cn_id
AND   cn.cn_id=co.CLIENTE_NATURAL_cn_id
AND   cn.cn_cedula = @cedula;


delete from TELEFONO where CLIENTE_NATURAL_cn_id=@idNatural;
delete from CONTACTO where CLIENTE_NATURAL_cn_id=@idNatural
delete from CLIENTE_NATURAL where  cn_id=@idNatural;

END;
GO


/*-------------Modificar Cliente Natural-------------------------------*/


CREATE PROCEDURE Procedure_ModificarClienteNatural

@cedula         varchar(20),
@nombre         varchar (60),
@apellido       varchar(60) ,
@correo         varchar (60),

@nombrePais     varchar(100),
@nombreEstado   varchar(100),
@nombreCiudad   varchar(100),
@nombreDireccion varchar(100),
@nombreCargo    varchar(60), 

 
@codigo         integer,
@numero         integer
as
DECLARE @idCiudad  integer
DECLARE @idNatural integer
DECLARE @idLugarDireccion integer
DECLARE @idMaxLugar  integer
DECLARE @idMaxCargo  integer
DECLARE @idCargoInsertar integer

begin

	select 
		@idCiudad=c.lug_id

	from lugar p,
		 lugar e,
		 lugar c, 
		 lugar d

	where p.lug_id = e.LUGAR_lug_id
	 and  e.lug_id = c.LUGAR_lug_id
	 and  c.lug_id = d.LUGAR_lug_id
	 and  p.lug_nombre=@nombrePais and p.lug_tipo='País'
	 and  e.lug_nombre=@nombreEstado and e.lug_tipo='Estado'
	 and  c.lug_nombre=@nombreCiudad and c.lug_tipo='Ciudad';
	 


	select @idLugarDireccion = count(LUG_id) from lugar 
	 where LUG_nombre = @nombreDireccion and LUG_tipo = 'Direccion' and LUGAR_lug_id = @idCiudad;
	
	
	if (@idLugarDireccion = 0)
		begin 
			select @idMaxLugar = MAX(LUG_id) from lugar;

			set @idMaxLugar = @idMaxLugar + 1;

			INSERT INTO lugar VALUES (@idMaxLugar,@nombreDireccion,'Direccion',null,@idCiudad);

			set @idLugarDireccion = @idMaxLugar;
		end
		
	 select @idCargoInsertar=count(car_id) from cargo where car_nombre = @nombreCargo ; 
	
	if (@idCargoInsertar = 0)
		begin 
			select @idMaxCargo = MAX(car_id) from cargo;

			set @idMaxCargo = @idMaxCargo + 1;

			INSERT INTO cargo VALUES (@idMaxCargo,@nombreCargo);

			set @idCargoInsertar = @idMaxCargo ;
		end
	
	
	select @idNatural=cn_id from CLIENTE_NATURAL where cn_cedula=@cedula;
	
	

	update TELEFONO 
		 set tel_codigo = @codigo,
		     tel_numero = @numero
		where CLIENTE_NATURAL_cn_id = @idNatural
		
 	update CONTACTO
	     set con_cedula = @cedula,
		     con_nombre = @nombre,
			 con_apellido = @apellido,
			 CARGO_car_id = @idCargoInsertar
		where con_id = @idNatural
		
	
	update CLIENTE_NATURAL
	     set cn_cedula = @cedula,
		     cn_nombre = @nombre,
			 cn_apellido = @apellido,
			 cn_correo = @correo,
			 LUGAR_lug_id = @idLugarDireccion
	where cn_id = @idNatural
end;
GO

/*-------------Consultar Todos los Clientes Naturales------------------------------------*/

CREATE PROCEDURE Procedure_ConsultarTodosClientesNaturales
AS 
SELECT cn_cedula, 
	   cn_nombre,
	   cn_apellido,
	   cn_correo 
FROM CLIENTE_NATURAL
GO

/*---------------Mostrar Datos detallados Cliente Natural----------------------------------*/

CREATE PROCEDURE Procedure_ConsultarDatosDetalladosClienteNat
@idClienteNat integer
AS 

SELECT cn.cn_cedula, 
	   cn.cn_nombre,
	   cn.cn_apellido,
	   carg.car_nombre,
	   cn.cn_correo,
	   t.tel_codigo,
	   t.tel_numero,
	   p.lug_nombre as pais,
	   e.lug_nombre as estado, 
	   c.lug_nombre as ciudad, 
	   d.lug_nombre as direccion,
	   c.lug_codigopostal as codigoPostal
	    
FROM 
	   CLIENTE_NATURAL cn, 
	   TELEFONO t,
	   LUGAR p,
	   LUGAR e,
	   LUGAR c,
	   LUGAR d,
	   CONTACTO cont,
	   CARGO carg

WHERE p.lug_id = e.LUGAR_lug_id
and   e.lug_id = c.LUGAR_lug_id
and   c.lug_id = d.LUGAR_lug_id
and   d.lug_id = cn.LUGAR_lug_id
and   cn.cn_id = cont.CLIENTE_NATURAL_cn_id
and   carg.car_id = cont.CLIENTE_NATURAL_cn_id
and   cn.cn_id = @idClienteNat
and   cn.cn_id=t.tel_id;
GO

/*-----------------Consulta Parametrizada de Clientes Naturales-----------------------------*/

CREATE PROCEDURE Procedure_ConsultarClientesNaturalesParametrizados
(
    @busqueda varchar (100)
)           
AS
SELECT	Distinct(cn_id),
        cn_cedula,
		cn_nombre,
		cn_apellido,
		cn_correo

FROM	CLIENTE_NATURAL
		
WHERE	( UPPER(cn_cedula) LIKE UPPER(@busqueda) + '%') OR
		( UPPER(cn_nombre) LIKE UPPER(@busqueda) + '%') OR
		( UPPER(cn_apellido) LIKE UPPER(@busqueda) + '%') OR
		( UPPER(cn_correo) LIKE UPPER(@busqueda) + '%') 
Group by cn_id,
		 cn_cedula,
		 cn_nombre,
		 cn_apellido,
		 cn_correo
ORDER BY cn_nombre ASC,
		 cn_apellido ASC;
GO

/*---Procedimientos de Lugar--*/

/*---------------Llenar Combo Pais-------------*/
CREATE PROCEDURE Procedure_llenarCBPais
AS
BEGIN
	   SELECT LUG_id, LUG_nombre
	   FROM LUGAR
	   WHERE LUG_tipo = 'País';
END;

go

/*---Llenar Combo Estado--*/
CREATE PROCEDURE Procedure_llenarCBEstado
@idPais integer
AS
BEGIN
SELECT E.LUG_id, E.LUG_nombre 
	   FROM LUGAR E
	   WHERE E.LUG_tipo = 'Estado' and E.LUGAR_lug_id = @idPais;
END;

go

/*-----Llenar Combo Ciudad--------------------------*/
CREATE PROCEDURE Procedure_llenarCBCiudad
@idEstado integer
AS
BEGIN
SELECT C.LUG_id, C.LUG_nombre 
	   FROM LUGAR C
	   WHERE C.LUG_tipo = 'Ciudad' and C.LUGAR_lug_id = @idEstado;
END;
go

/*---Obtener dirección dado un id--*/

CREATE PROCEDURE Procedure_obtenerDireccion
@idDireccion integer
AS
BEGIN
	   SELECT D.LUG_nombre 
	   FROM LUGAR D
	   WHERE D.LUG_tipo = 'Direccion' and D.lug_id= @idDireccion;
END;

/***------------Llena el combo box de cargo----**/
go


CREATE PROCEDURE Procedure_llenarCBCargo

AS
BEGIN
	   SELECT 
	   car_nombre
	   FROM CARGO;
	  
END;

go

/***------------Consultar todos los clientes Juridicos ----**/

CREATE PROCEDURE Procedure_ConsultarTodosClientesJuridicos
AS 
select	cj_rif, 
		cj_nombre
from CLIENTE_JURIDICO;

go

CREATE PROCEDURE Procedure_consultarDireccionCompleta
@idDireccion int
AS
BEGIN


      SELECT C.LUG_id FROM LUGAR C, LUGAR D WHERE C.LUG_id = D.LUGAR_lug_id and D.LUG_id = @idDireccion and C.LUG_tipo ='Ciudad'
       union
	   SELECT E.LUG_id FROM LUGAR E, LUGAR C WHERE E.LUG_id = C.LUGAR_lug_id and C.LUG_id = 
       (SELECT C.LUG_id FROM LUGAR C, LUGAR D WHERE C.LUG_id = D.LUGAR_lug_id and D.LUG_id = @idDireccion) and E.LUG_tipo = 'Estado'
       union
       SELECT P.LUG_id FROM LUGAR P, LUGAR E WHERE P.LUG_id = E.LUGAR_lug_id and E.LUG_id =
       (SELECT E.LUG_id FROM LUGAR E, LUGAR C WHERE E.LUG_id = C.LUGAR_lug_id and C.LUG_id = 
       (SELECT C.LUG_id FROM LUGAR C, LUGAR D WHERE C.LUG_id = D.LUGAR_lug_id and D.LUG_id = @idDireccion)) and P.LUG_tipo = 'País'


END;
go


/*---Obtener dirección dado un id--*/

CREATE PROCEDURE Procedure_obtenerDireccion
@idDireccion integer
AS
BEGIN
	   SELECT D.LUG_nombre 
	   FROM LUGAR D
	   WHERE D.LUG_tipo = 'Direccion' and D.lug_id= @idDireccion;
END;
go
/***------------Llena el combo box de cargo----**/


CREATE PROCEDURE Procedure_llenarCBCargo

AS
BEGIN
	   SELECT 
	   car_nombre
	   FROM CARGO
	   
END;
go

CREATE PROCEDURE Procedure_CargarCodigoPostal
@idCiudad int
AS
SELECT lug_codigopostal FROM LUGAR WHERE lug_id=@idCiudad;

/*------Datos del Cliente según el nombre del proyecto--*/

CREATE PROCEDURE DatosClientePorNombreProyecto
@codigo varchar(10) 
AS
SELECT 
	   cj.cj_rif  as rif, 
       cj_nombre as nombre,
	   con.con_nombre as nombreContacto,
	   con.con_apellido as nombreApellido,
	   t.tel_codigo as codigo,
	   t.tel_numero as numero, 

	   (d.lug_nombre+'.'+c.lug_nombre +'.'+e.lug_nombre+','+p.lug_nombre) as direccion 

FROM     PROYECTO PRO, 
		 CLIENTE_JURIDICO CJ, 
		 CONTACTO Con, 
		 TELEFONO t, 
		 CARGO car, 
		 LUGAR p,
	     LUGAR e,
	     LUGAR c,
	     LUGAR d

WHERE p.lug_id = e.LUGAR_lug_id
and   e.lug_id = c.LUGAR_lug_id
and   c.lug_id = d.LUGAR_lug_id
and   d.lug_id = CJ.LUGAR_lug_id
and   CJ.cj_id = PRO.CLIENTE_JURIDICO_cj_id
and   cj.cj_id = Con.CLIENTE_JURIDICO_cj_id
and   con.con_id = t.CONTACTO_con_id
and   car.car_id = con.CARGO_car_id
and   pro.pro_codigo = @codigo; 

go


CREATE PROCEDURE Procedure_ConsultarDatosContactosEmpresa
@cj_rif varchar(20)
AS
SELECT CON.con_id AS id,
       Con.con_nombre as nombre,
	   CON.con_apellido as apellido,
	   car.car_nombre as cargo, 
	   telf.tel_codigo as codigo,
	   telf.tel_numero as numero

FROM CONTACTO CON, 
     CARGO CAR, 
	 CLIENTE_JURIDICO CJ, 
	 TELEFONO TELF
WHERE CJ.cj_id = CON.CLIENTE_JURIDICO_cj_id
AND   CON.con_id = TELF.CONTACTO_con_id
AND   CAR.car_id = CON.CARGO_car_id	 
AND   CJ.cj_rif = @cj_rif;	 
 
 go