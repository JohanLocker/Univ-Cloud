-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE InsertarUsuario
	-- Add the parameters for the stored procedure here
	(@Usuario varchar(50), @Contraseña varchar(50), @Privilegios varchar(50), @Empleado int)
AS
BEGIN
	INSERT INTO Usuarios values(@Usuario, @Contraseña, @Privilegios, @Empleado);
END
GO

EXEC InsertarUsuario 'Johan', '1234', 'Administrador', 16
GO

CREATE PROCEDURE SelecionarUsuario
	-- Add the parameters for the stored procedure here
	(@Usuario varchar(50))
AS
BEGIN
	SELECT * FROM Usuarios WHERE Usuario = @Usuario;
END
GO

EXEC SelecionarUsuario 'Johan';
GO

CREATE PROCEDURE EliminarUsuario(@Usuario varchar(50))
AS
BEGIN
	delete from Usuarios where Usuario =  @Usuario;
END
GO

Exec EliminarUsuario 'Johan';
GO

CREATE PROCEDURE ActualizarUsuario
	-- Add the parameters for the stored procedure here
	(@Usuario varchar(50), @Contraseña varchar(50), @Privilegios varchar(50), @Empleado int)
AS
BEGIN
	Update Usuarios Set Usuario=@Usuario, Contraseña=@Contraseña, Privilegios= @Privilegios,Empleado= @Empleado WHERE Usuario = @Usuario;
END
GO

EXEC ActualizarUsuario 'Johan Alberto', '1234', 'Administrador', NULL
GO

DROP Function Validar

CREATE Function ValidarUsuarioExistente(@Usuario varchar(50), @Contrasena varchar(50))
Returns bit
as
Begin
Declare @valores varchar
DECLARE @Resultado int
SELECT @valores = Usuario FROM Usuarios where Usuario = @Usuario;
if @valores = @Usuario
BEGIN
	SELECT @valores = Contraseña FROM Usuarios where Contraseña = @Contrasena;
	IF @valores = @Contrasena
		BEGIN
			@Resultado =1;
		END
	ELSE
		BEGIN
			@Resultado=0
		END
END
return @Resultado;
END
GO

SELECT dbo.ValidarUsuarioExistente('Johan', '1234');

DROP PROCEDURE
ALTER PROCEDURE ValidarUsuario 
(@Usuario varchar(50), @Contrasena VARCHAR(50))
AS BEGIN
	declare @resultado bit;
	 SELECT @resultado= COUNT(*) FROM Usuarios WHERE Usuario = @Usuario and Contraseña = @Contrasena;
	 if @resultado >=1
	 
	 select @resultado as Resultado;
END
GO

EXEC ValidarUsuario 'Johan', '1234';

SELECT dbo.ValidarUsuarioExistente('Johan', '1234');
SELECT COUNT(*) FROM Usuarios WHERE Usuario = 'Johan' and Contraseña = '1234';
return SELECT COUNT(*) FROM Usuarios WHERE Usuario = 'Johan' and Contraseña = '1234';