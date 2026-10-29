"use client";

import { Marca } from "@/lib/api";
import useGuardar from "./useGuardar";

export default function FormProducto({ marcas }: { marcas: Marca[] }) {
  const { enviar, error } = useGuardar("productos", "No se pudo guardar el producto.");

  return (
    <form onSubmit={enviar} className="card card-body mb-4">
      <div className="row g-3">
        <div className="col-md-6">
          <label className="form-label">Nombre</label>
          <input name="nombre" className="form-control" required maxLength={100} />
        </div>
        <div className="col-md-6">
          <label className="form-label">Marca</label>
          <select name="idMarca" className="form-select" required>
            {marcas.map((m) => (
              <option key={m.idMarca} value={m.idMarca}>{m.nombre}</option>
            ))}
          </select>
        </div>
        <div className="col-md-4">
          <label className="form-label">Precio</label>
          <input name="precio" type="number" step="0.01" min="0" className="form-control" required />
        </div>
        <div className="col-md-4">
          <label className="form-label">Stock</label>
          <input name="stock" type="number" min="0" className="form-control" required />
        </div>
        <div className="col-md-4 d-flex align-items-end">
          <button type="submit" className="btn btn-primary w-100">Guardar</button>
        </div>
      </div>
      {error && <div className="alert alert-danger mt-3 mb-0">{error}</div>}
    </form>
  );
}
