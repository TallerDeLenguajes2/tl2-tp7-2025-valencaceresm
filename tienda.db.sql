--
-- Archivo generado con SQLiteStudio v3.4.17 el vie oct 24 18:44:59 2025
--
-- Codificación de texto usada: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Tabla: Presupuestos
CREATE TABLE IF NOT EXISTS Presupuestos (idPresupuesto INTEGER PRIMARY KEY UNIQUE, NombreDestinatario TEXT (100), FechaCreacion TEXT);
INSERT INTO Presupuestos (idPresupuesto, NombreDestinatario, FechaCreacion) VALUES (1, 'Carlos Ruiz', '2024-10-25');

-- Tabla: PresupuestosDetalle
CREATE TABLE IF NOT EXISTS PresupuestosDetalle (idPresupuesto INTEGER PRIMARY KEY, idProducto INTEGER, Cantidad INTEGER);

-- Tabla: Productos
CREATE TABLE IF NOT EXISTS Productos (idProducto INTEGER PRIMARY KEY UNIQUE, Descripcion TEXT (100), Precio NUMERIC (10, 2));
INSERT INTO Productos (idProducto, Descripcion, Precio) VALUES (1, 'Teclado Mecánico Logitech', 12000);
INSERT INTO Productos (idProducto, Descripcion, Precio) VALUES (2, 'Mouse inalámbrico Logitech', 5000);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
