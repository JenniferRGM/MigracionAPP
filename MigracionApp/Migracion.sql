CREATE DATABASE Migracion;
GO

USE Migracion;
GO

CREATE TABLE GENEROS (
    id INT PRIMARY KEY, -- Clave primaria
    descripcion NVARCHAR(20) UNIQUE NOT NULL, -- Ejemplo: 'Masculino', 'Femenino'
    CONSTRAINT chk_descripcion_genero CHECK (LEN(descripcion) > 1) -- Validaci�n de longitud
);

CREATE TABLE ESTADOS (
    id INT PRIMARY KEY, -- Clave primaria
    descripcion NVARCHAR(50) UNIQUE NOT NULL, -- Breve descripci�n del estado
    CONSTRAINT chk_descripcion CHECK (LEN(descripcion) > 3) -- Validaci�n de longitud
);

CREATE TABLE PASAJEROS (
    id INT PRIMARY KEY, -- Clave primaria
    nombre NVARCHAR(50) NOT NULL, 
    segundo_nombre NVARCHAR(50), 
    apellido1 NVARCHAR(50) NOT NULL, 
    apellido2 NVARCHAR(50),
    fecha_nacimiento DATE NOT NULL, 
    nacionalidad NVARCHAR(50) NOT NULL, 
    correo_electronico NVARCHAR(100) NOT NULL, 
    genero_fk INT NOT NULL, -- Relaci�n con tabla GENEROS
    FOREIGN KEY (genero_fk) REFERENCES GENEROS(id),
    CONSTRAINT chk_fecha_nacimiento CHECK (fecha_nacimiento <= GETDATE()) -- Validaci�n de fecha
);

CREATE TABLE DOCUMENTOS (
    id INT PRIMARY KEY, -- Clave primaria
    tipo_documento NVARCHAR(20) NOT NULL, -- Ejemplo: 'Pasaporte', 'C�dula'
    numero_documento NVARCHAR(50) NOT NULL, -- Identificador �nico de documento
    fecha_expiracion DATE, -- Correcto para fechas
    id_estado INT NOT NULL, -- Relaci�n con tabla ESTADOS
    id_viajero INT NOT NULL, -- Relaci�n con tabla PASAJEROS
    FOREIGN KEY (id_estado) REFERENCES ESTADOS(id),
    FOREIGN KEY (id_viajero) REFERENCES PASAJEROS(id),
    CONSTRAINT chk_fecha_expiracion CHECK (fecha_expiracion > GETDATE() OR fecha_expiracion IS NULL) -- Validaci�n de fecha
);

CREATE TABLE USUARIOS (
    id INT PRIMARY KEY, -- Clave primaria
    nombre NVARCHAR(50) NOT NULL, -- Para caracteres especiales
    apellido1 NVARCHAR(50) NOT NULL, -- Para caracteres especiales
    apellido2 NVARCHAR(50),
    clave NVARCHAR(100) NOT NULL, -- Contrase�as encriptadas
    email NVARCHAR(30) NOT NULL, -- Para caracteres especiales en correos
    rol NVARCHAR(50) NOT NULL, -- Ejemplo: 'Administrador', 'Usuario'
    CONSTRAINT chk_email CHECK (email LIKE '%@%.%') -- Validaci�n de formato de email
);

CREATE TABLE VIAJES_TRANSITO_MIGRACION (
    id INT PRIMARY KEY, -- Clave primaria
    id_viajero INT NOT NULL, -- Relaci�n con tabla PASAJEROS
    fecha DATETIME NOT NULL, -- DATETIME para incluir fecha y hora
    destino NVARCHAR(50) NOT NULL, 
    origen NVARCHAR(50) NOT NULL, 
    tipo_solicitud NVARCHAR(50) NOT NULL, -- Ejemplo: 'Turismo', 'Negocios'
    motivo_viaje NVARCHAR(MAX), -- Texto largo para descripciones
    id_usuario INT NOT NULL, -- Relaci�n con tabla USUARIOS
    FOREIGN KEY (id_viajero) REFERENCES PASAJEROS(id),
    FOREIGN KEY (id_usuario) REFERENCES USUARIOS(id),
    CONSTRAINT chk_fecha CHECK (fecha >= GETDATE() - 365) -- Validaci�n de rango de fecha
);

CREATE TABLE LOGIN (
    id INT PRIMARY KEY, -- Clave primaria
    usuario_id INT NOT NULL, -- Relaci�n con la tabla USUARIOS
    email NVARCHAR(100) NOT NULL, -- Email del usuario
    clave NVARCHAR(100) NOT NULL, -- Contrase�a encriptada
    ultimo_acceso DATETIME NULL, -- Registro del �ltimo acceso
    FOREIGN KEY (usuario_id) REFERENCES USUARIOS(id), -- Relaci�n con tabla USUARIOS
    CONSTRAINT chk_email_formato CHECK (email LIKE '%@%.%') -- Validaci�n de formato de email
);
