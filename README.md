# Web API con Entity Framework Core

Proyecto universitario: Web API en .NET 8 con controladores que exponen endpoints de consulta (SELECT), insercion (INSERT) y actualizacion (UPDATE) sobre una base de datos MySQL usando Entity Framework Core. Incluye un frontend en Next.js que muestra los datos (desafio opcional).

## Video

Enlace al video de la ejecucion (max. 3 min): **[PEGAR AQUI EL ENLACE]**

## Estructura

- `api/` Web API (.NET 8, controladores, EF Core + Pomelo MySQL)
- `web/` Frontend (Next.js con TypeScript)
- `db/script.sql` Esquema de la base de datos y datos de prueba

## Requisitos

- .NET SDK 8
- MySQL 8
- Node.js 18 o superior

## Crear la base de datos

Desde la consola de MySQL:

```bash
mysql -u root -p < db/script.sql
```

Esto crea la base `tienda_webapi` con las 7 tablas y 3 registros de prueba por tabla.

## Correr la API

1. Editar la cadena de conexion en `api/appsettings.json` (usuario y password de tu MySQL).
2. Ejecutar:

```bash
cd api
dotnet run
```

La API queda en `http://localhost:5000` y Swagger en `http://localhost:5000/swagger`.

## Correr el frontend

```bash
cd web
cp .env.local.example .env.local
npm install
npm run dev
```

Abrir `http://localhost:3000`. Muestra tablas de clientes, productos y empleados, y un formulario para crear clientes.

## Endpoints

Todos bajo `/api`. Cada recurso tiene `GET` (lista), `GET /{id}`, `POST` (insertar) y `PUT /{id}` (actualizar).

| Recurso | Ruta |
|---|---|
| Clientes | `/api/clientes` |
| Puestos | `/api/puestos` |
| Empleados | `/api/empleados` |
| Marcas | `/api/marcas` |
| Productos | `/api/productos` |
| Facturas | `/api/facturas` |

Notas:

- `POST /api/facturas` recibe la factura con su lista `detalles` (`idProducto` y `cantidad`). El precio, los subtotales y el total se calculan en la API y se descuenta el stock.
- `PUT /api/facturas/{id}` solo actualiza la cabecera (cliente, empleado y fecha).
- Ejemplo de `POST /api/clientes`:

```json
{
  "nit": "4567890-1",
  "nombre": "Pedro",
  "apellidos": "Lopez",
  "email": "pedro@correo.com"
}
```
