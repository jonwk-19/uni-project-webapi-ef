import { Empleado, obtener } from "@/lib/api";

export default async function Empleados() {
  const empleados = await obtener<Empleado>("empleados");

  return (
    <>
      <h1>Empleados</h1>
      {empleados === null ? (
        <p className="error">No se pudo conectar con la API.</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nombre</th>
              <th>Apellidos</th>
              <th>Puesto</th>
              <th>Contratacion</th>
            </tr>
          </thead>
          <tbody>
            {empleados.map((e) => (
              <tr key={e.idEmpleado}>
                <td>{e.idEmpleado}</td>
                <td>{e.nombre}</td>
                <td>{e.apellidos}</td>
                <td>{e.puesto?.nombre}</td>
                <td>{e.fechaContratacion.slice(0, 10)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </>
  );
}
