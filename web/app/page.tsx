import Link from "next/link";

export default function Inicio() {
  return (
    <div className="p-5 bg-white rounded border">
      <h1>Tienda</h1>
      <p className="lead">Proyecto de Web API con .NET y Entity Framework Core. Usa el menu para ver y registrar datos.</p>
      <Link className="btn btn-primary me-2" href="/clientes">Clientes</Link>
      <Link className="btn btn-primary me-2" href="/productos">Productos</Link>
      <Link className="btn btn-primary" href="/empleados">Empleados</Link>
    </div>
  );
}
