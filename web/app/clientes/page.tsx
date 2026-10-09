import FormCliente from "@/components/FormCliente";
import { Cliente, obtener } from "@/lib/api";

export default async function Clientes() {
  const clientes = await obtener<Cliente>("clientes");

  return (
    <>
      <h1>Clientes</h1>
      <h2>Nuevo cliente</h2>
      <FormCliente />
      {clientes === null ? (
        <p className="error">No se pudo conectar con la API.</p>
      ) : (
        <table>
          <thead>
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
      )}
    </>
  );
}
