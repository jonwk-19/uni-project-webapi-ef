DROP DATABASE IF EXISTS tienda;
CREATE DATABASE tienda CHARACTER SET utf8mb4;
USE tienda;

CREATE TABLE clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nit VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    email VARCHAR(100)
);

CREATE TABLE puestos (
    id_puesto INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    salario_base DOUBLE NOT NULL
);

CREATE TABLE empleados (
    id_empleado INT AUTO_INCREMENT PRIMARY KEY,
    id_puesto INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    fecha_contratacion DATE NOT NULL,
    FOREIGN KEY (id_puesto) REFERENCES puestos(id_puesto)
);

CREATE TABLE marcas (
    id_marca INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

CREATE TABLE productos (
    id_producto INT AUTO_INCREMENT PRIMARY KEY,
    id_marca INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    precio DOUBLE NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY (id_marca) REFERENCES marcas(id_marca)
);

CREATE TABLE facturas (
    id_factura INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL,
    id_empleado INT NOT NULL,
    fecha DATETIME NOT NULL,
    total DOUBLE NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
    FOREIGN KEY (id_empleado) REFERENCES empleados(id_empleado)
);

CREATE TABLE detalle_facturas (
    id_detalle INT AUTO_INCREMENT PRIMARY KEY,
    id_factura INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DOUBLE NOT NULL,
    subtotal DOUBLE NOT NULL,
    FOREIGN KEY (id_factura) REFERENCES facturas(id_factura),
    FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);

INSERT INTO clientes (nit, nombre, apellidos, email) VALUES
('1234567-8', 'Ana', 'Lopez Perez', 'ana.lopez@correo.com'),
('2345678-9', 'Carlos', 'Mendez Ruiz', 'carlos.mendez@correo.com'),
('3456789-0', 'Maria', 'Garcia Soto', 'maria.garcia@correo.com');

INSERT INTO puestos (nombre, salario_base) VALUES
('Cajero', 3500.00),
('Vendedor', 4200.50),
('Gerente', 8000.00);

INSERT INTO empleados (id_puesto, nombre, apellidos, fecha_contratacion) VALUES
(1, 'Luis', 'Ramirez Diaz', '2022-03-15'),
(2, 'Sofia', 'Castillo Mora', '2023-01-10'),
(3, 'Jorge', 'Herrera Lima', '2020-07-01');

INSERT INTO marcas (nombre) VALUES
('Samsung'),
('Logitech'),
('HP');

INSERT INTO productos (id_marca, nombre, precio, stock) VALUES
(1, 'Monitor 24 pulgadas', 1250.00, 15),
(2, 'Mouse inalambrico', 150.75, 40),
(3, 'Impresora multifuncional', 980.00, 8);

INSERT INTO facturas (id_cliente, id_empleado, fecha, total) VALUES
(1, 1, '2024-05-10 10:30:00', 1400.75),
(2, 2, '2024-05-11 15:45:00', 980.00),
(3, 1, '2024-05-12 09:15:00', 301.50);

INSERT INTO detalle_facturas (id_factura, id_producto, cantidad, precio_unitario, subtotal) VALUES
(1, 1, 1, 1250.00, 1250.00),
(1, 2, 1, 150.75, 150.75),
(2, 3, 1, 980.00, 980.00),
(3, 2, 2, 150.75, 301.50);
