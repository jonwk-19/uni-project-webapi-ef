"use client";

import useGuardar from "./useGuardar";

export default function FormCliente() {
  const { enviar, error } = useGuardar(
    "clientes",
    "No se pudo guardar el cliente (revisa que el NIT no este repetido)."
  );

  return (
    <form onSubmit={enviar} className="card card-body mb-4">
      <div className="row g-3">
        <div className="col-md-4">
          <label className="form-label">NIT</label>
          <input name="nit" className="form-control" required maxLength={20} />
        </div>
        <div className="col-md-4">
          <label className="form-label">Nombre</label>
          <input name="nombre" className="form-control" required maxLength={100} />
        </div>
        <div className="col-md-4">
          <label className="form-label">Apellidos</label>
          <input name="apellidos" className="form-control" required maxLength={100} />
        </div>
        <div className="col-md-8">
          <label className="form-label">Email</label>
          <input name="email" type="email" className="form-control" maxLength={100} />
        </div>
        <div className="col-md-4 d-flex align-items-end">
          <button type="submit" className="btn btn-primary w-100">Guardar</button>
        </div>
      </div>
      {error && <div className="alert alert-danger mt-3 mb-0">{error}</div>}
    </form>
  );
}
