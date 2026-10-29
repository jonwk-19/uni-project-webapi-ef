import FormEmpleado from "@/components/FormEmpleado";
import { Empleado, Puesto, obtener } from "@/lib/api";

export default async function Empleados() {
  const empleados = await obtener<Empleado>("empleados");
  const puestos = await obtener<Puesto>("puestos");

  return (
    <>
      <h1 className="mb-3">Empleados</h1>
      <FormEmpleado puestos={puestos ?? []} />
      {empleados === null ? (
        <div className="alert alert-danger">No se pudo conectar con la API.</div>
      ) : (
        <div className="table-responsive">
          <table className="table table-striped table-hover bg-white">
            <thead className="table-dark">
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
        </div>
      )}
    </>
  );
}
