"use client";

import { Puesto } from "@/lib/api";
import useGuardar from "./useGuardar";

export default function FormEmpleado({ puestos }: { puestos: Puesto[] }) {
  const { enviar, error } = useGuardar("empleados", "No se pudo guardar el empleado.");

  return (
    <form onSubmit={enviar} className="card card-body mb-4">
      <div className="row g-3">
        <div className="col-md-6">
          <label className="form-label">Nombre</label>
          <input name="nombre" className="form-control" required maxLength={100} />
        </div>
        <div className="col-md-6">
          <label className="form-label">Apellidos</label>
          <input name="apellidos" className="form-control" required maxLength={100} />
        </div>
        <div className="col-md-4">
          <label className="form-label">Puesto</label>
          <select name="idPuesto" className="form-select" required>
            {puestos.map((p) => (
              <option key={p.idPuesto} value={p.idPuesto}>{p.nombre}</option>
            ))}
          </select>
        </div>
        <div className="col-md-4">
          <label className="form-label">Fecha de contratacion</label>
          <input name="fechaContratacion" type="date" className="form-control" required />
        </div>
        <div className="col-md-4 d-flex align-items-end">
          <button type="submit" className="btn btn-primary w-100">Guardar</button>
        </div>
      </div>
      {error && <div className="alert alert-danger mt-3 mb-0">{error}</div>}
    </form>
  );
}
