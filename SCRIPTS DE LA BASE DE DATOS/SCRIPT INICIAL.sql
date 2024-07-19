-- Crear la base de datos
CREATE DATABASE PurisFlashDB;
GO

-- Usar la base de datos creada
USE PurisFlashDB;
GO

-- Tabla Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    Contrasena NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(15),
    Direccion NVARCHAR(200),
    MetodoPago NVARCHAR(50)
);
GO

-- Tabla Conductores
CREATE TABLE Conductores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(15),
    Vehiculo NVARCHAR(50)
);
GO

-- Tabla Categorias
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TipoCategoria NVARCHAR(50) NOT NULL
);
GO

-- Tabla Comidas
CREATE TABLE Comidas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(200),
    Precio DECIMAL(10, 2),
    CategoriaId INT,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);
GO

-- Tabla Pedidos
CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    Direccion NVARCHAR(200) NOT NULL,
    MetodoPago NVARCHAR(50),
    Total DECIMAL(10, 2) NOT NULL,
    UsuarioId INT,
    ConductorId INT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (ConductorId) REFERENCES Conductores(Id)
);
GO
