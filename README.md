Para ApiProductosMVC

Instalacion 
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
dotnet add package Swashbuckle.AspNetCore


* Creacion de la solucion

dotnet new sln -n MiniInventarioSolution

* Crear proyectos

dotnet new classlib -n MiniInventario.Domain
dotnet new classlib -n MiniInventario.Application
dotnet new classlib -n MiniInventario.Infrastructure
dotnet new webapi -n MiniInventario.API

* Agregar proyectos a la solucion

dotnet sln add src/MiniInventario.Domain
dotnet sln add src/MiniInventario.Application
dotnet sln add src/MiniInventario.Infrastructure
dotnet sln add src/MiniInventario.API

* Referencias entre capas (esto es CLAVE)

Domain           -> no referencia a nadie
Application      -> referencia Domain
Infrastructure   -> referencia Application + Domain
API              -> referencia Application + Infrastructure

* Comandos
dotnet add src/MiniInventario.Application reference src/MiniInventario.Domain
dotnet add src/MiniInventario.Infrastructure reference src/MiniInventario.Application
dotnet add src/MiniInventario.Infrastructure reference src/MiniInventario.Domain
dotnet add src/MiniInventario.API reference src/MiniInventario.Application
dotnet add src/MiniInventario.API reference src/MiniInventario.Infrastructure

* Paquetes NuGet necesarios (sí, instala esto)
Infrastructure
  dotnet add src/MiniInventario.Infrastructure package Dapper --version 2.1.35
  dotnet add src/MiniInventario.Infrastructure package Microsoft.Data.SqlClient --version 5.2.0
API
dotnet add src/MiniInventario.API package Swashbuckle.AspNetCore --version 7.0.2

Creacion de la base de datos 
CREATE DATABASE MiniInventarioDB;
GO
USE MiniInventarioDB;
GO


CREATE TABLE Productos (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Activo BIT NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);

* Creacion de insertar producto

CREATE PROCEDURE sp_InsertarProducto
    @Id UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(150),
    @Stock INT,
    @Precio DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Productos (Id, Nombre, Stock, Precio, Activo)
    VALUES (@Id, @Nombre, @Stock, @Precio, 1);
END

* Reporte Inventario
  CREATE PROCEDURE sp_ReporteInventario
AS
BEGIN
    SELECT 
        Nombre,
        Stock,
        Precio,
        (Stock * Precio) AS ValorInventario
    FROM Productos
    WHERE Activo = 1;
END





  

  



