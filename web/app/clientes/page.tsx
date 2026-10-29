import FormCliente from "@/components/FormCliente";
import { Cliente, obtener } from "@/lib/api";

export default async function Clientes() {
  const clientes = await obtener<Cliente>("clientes");

  return (
    <>
      <h1 className="mb-3">Clientes</h1>
      <FormCliente />
      {clientes === null ? (
        <div className="alert alert-danger">No se pudo conectar con la API.</div>
      ) : (
        <div className="table-responsive">
          <table className="table table-striped table-hover bg-white">
            <thead className="table-dark">
              <tr>
                <th>ID</th>
                <th>NIT</th>
                <th>Nombre</th>
                <th>Apellidos</th>
                <th>Email</th>
              </tr>
            </thead>
            <tbody>
              {clientes.map((c) => (
                <tr key={c.idCliente}>
                  <td>{c.idCliente}</td>
                  <td>{c.nit}</td>
                  <td>{c.nombre}</td>
                  <td>{c.apellidos}</td>
                  <td>{c.email}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </>
  );
}
