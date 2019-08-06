CREATE VIEW EmpleadoUsuarios
AS
SELECT dbo.Empleados.*, dbo.Usuarios.* FROM dbo.Empleados INNER JOIN dbo.Usuarios on dbo.Usuarios.Empleado =  dbo.Empleados.Codigo_Empleado;
GO

SELECT * FROM EmpleadoUsuarios;
GO

SELECT * FROM Empleados;

DROP PROCEDURE InsertarEmpleados;
GO

CREATE PROCEDURE InsertarEmpleados @Codigo int, @Nombre varchar(60), @Apellido varchar(60), @Edad int, @Genero varchar(60) ='Indefinido', @Telefono varchar(60), @Corre varchar(60), @Cargo varchar(60), @Direccion varchar(60) = 'Sin Direccion', @activo bit = false , @Departamentos int, @Salario money = 0.0, @Ingreso date = null, @profesor varchar(60) = null, @imagen Varbinary(MAX) = null
AS BEGIN
	INSERT INTO Empleados VALUES(@Codigo, @Nombre, @Apellido, @Edad, @Genero, @Telefono, @Corre, @Cargo, @Direccion, @activo, @Departamentos, @Salario, @Ingreso, @profesor, @imagen);
END
GO

CREATE PROCEDURE EliminarEmpleados @Codigo int
AS BEGIN
	DELETE FROM Empleados WHERE Codigo_Empleado =  @Codigo;
END
GO

CREATE PROCEDURE BuscarEmpleado @Codigo int
AS BEGIN
	SELECT * FROM Empleados WHERE Codigo_Empleado = @Codigo;
END
GO


EXEC BuscarEmpleado 16;
GO

EXEC EliminarEmpleados 15;
GO

EXEC InsertarEmpleados 16, 'Johan Alberto', 'Maldonado', 18, 'Masculino', '809-6213-3558', 'mbatistajohan@gmail.com', 'Ingeniero Software', 'Angel Severo Cabral', true, null, 45000, '12/06/2019', null, null

-- TABLA VIRTUAL DE DATOS EMPLEADOS Y USUARIOS
SELECT dbo.Empleados.*, dbo.Usuarios.* FROM dbo.Empleados INNER JOIN dbo.Usuarios on dbo.Usuarios.Empleado =  dbo.Empleados.Codigo_Empleado where dbo.Empleados.Codigo_Empleado =  16;


CREATE PROCEDURE BuscarEmpleadoPorUsuario @Usuario varchar(50)
AS BEGIN
	SELECT dbo.Empleados.*, dbo.Usuarios.* FROM dbo.Empleados INNER JOIN dbo.Usuarios on dbo.Usuarios.Empleado =  dbo.Empleados.Codigo_Empleado where dbo.Usuarios.Usuario = @Usuario;
END
GO

EXEC BuscarEmpleadoPorUsuario 'Johan'