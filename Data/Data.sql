CREATE TABLE Autor (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL
);

CREATE TABLE Generos (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL
);

CREATE TABLE Documento (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL
);

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    Apellido VARCHAR(255) NOT NULL,
    DocumentoId INT,
    Numero_de_documento VARCHAR(255) UNIQUE NOT NULL,
    Dirección VARCHAR(255) NOT NULL,
    Telefono VARCHAR(255) NOT NULL,
    Correo VARCHAR(255) NOT NULL,
    FOREIGN KEY (DocumentoId) REFERENCES Documento(Id)
);

CREATE TABLE Libro (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    AutorId INT,
    Fecha_de_publicación DATE NOT NULL,
    Numero_de_copias INT NOT NULL,
    GeneroId INT,
    Estatus VARCHAR(100),
    FOREIGN KEY (AutorId) REFERENCES Autor(Id),
    FOREIGN KEY (GeneroId) REFERENCES Generos(Id)
);

CREATE TABLE Prestamo (
    Id INT PRIMARY KEY,
    UsuarioId INT,
    LibroId INT,
    Fecha_de_prestamo DATE NOT NULL,
    Fecha_limite DATE NOT NULL,
    Estatus VARCHAR(100),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (LibroId) REFERENCES Libro(Id)
);

CREATE TABLE Historial (
    Id INT PRIMARY KEY,
    UsuarioId INT,
    LibroId INT,
    Fecha_de_prestamo DATE NOT NULL,
    Fecha_entrega DATE NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (LibroId) REFERENCES Libro(Id)
);
