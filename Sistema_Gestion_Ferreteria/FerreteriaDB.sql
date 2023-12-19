CREATE DATABASE db_ferreteria
GO
use db_ferreteria
GO
create table t_productos(
id_producto int identity(1,1),
n_producto varchar(150),
precio decimal(12,2),
activo bit,
constraint pk_t_produc primary key(id_producto)
)
GO
create table t_presupuestos(
presupuesto_nro int identity(1,1),
fecha date, 
cliente varchar(150),
costoTotal decimal(12,2),
descuento int,
fecha_pago date,
constraint p_t_presu primary key(presupuesto_nro)
)
GO
create table t_detalles_presupuesto(
presupuesto_nro int not null,
detalle_nro int not null,
id_producto int not null, 
cantidad int not null, 
constraint pk_presu_nro primary key(presupuesto_nro,detalle_nro),
constraint fk_presu foreign key(presupuesto_nro) references t_presupuestos(presupuesto_nro),
constraint fk_produc foreign key(id_producto) references t_productos(id_producto)
)
GO
--STORED PRODEDURES
CREATE  PROCEDURE pa_insertar_productos
@nombre varchar(150),
@precio decimal(12,2),
@activo bit
AS
BEGIN 
	INSERT INTO t_productos(n_producto,precio,activo)
	VALUES(@nombre,@precio,@activo)
END
GO

SELECT * FROM  T_PRODUCTOS

