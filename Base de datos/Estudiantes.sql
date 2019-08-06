	--ESTUDIANTES--
CREATE PROCEDURE SeleccionarEstudiantes (@Matricula varchar(20))
AS BEGIN
	SELECT * FROM Estudiantes where Matricula = @Matricula;
END
GO
CREATE PROCEDURE InsertarEstudiantes (@Matricula varchar(20), @Nombre varchar(50), @Apellido varchar(50), @FechaNacimiento DATE, @Genero varchar(20), @Grado int, @Nacionalidad varchar(50), @Tutor varchar(20), @Activo bit, @Ciudad varchar(50), @Imagen varbInary(max))
AS BEGIN
	INSERT INTO Estudiantes Values(@Matricula, @Nombre, @Apellido, @FechaNacimiento, @Genero, @Grado, @Nacionalidad, @Tutor, @Activo, @Ciudad, @Imagen)
END
GO

EXEC InsertarEstudiantes '20191047', 'Juan Luis', 'Martinez', '1997/02/01', 'Masculino', 1, 'Dominicano', '402-2995175-7', 1, 'Republica Dominicana', null
EXEC SeleccionarEstudiantes '20191046';