import FormProducto from "@/components/FormProducto";
import { Marca, Producto, obtener } from "@/lib/api";

export default async function Productos() {
  const productos = await obtener<Producto>("productos");
  const marcas = await obtener<Marca>("marcas");

  return (
    <>
      <h1 className="mb-3">Productos</h1>
      <FormProducto marcas={marcas ?? []} />
      {productos === null ? (
        <div className="alert alert-danger">No se pudo conectar con la API.</div>
      ) : (
        <div className="table-responsive">
          <table className="table table-striped table-hover bg-white">
            <thead className="table-dark">
              <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>Marca</th>
                <th>Precio</th>
                <th>Stock</th>
              </tr>
            </thead>
            <tbody>
              {productos.map((p) => (
                <tr key={p.idProducto}>
                  <td>{p.idProducto}</td>
                  <td>{p.nombre}</td>
                  <td>{p.marca?.nombre}</td>
                  <td>{p.precio.toFixed(2)}</td>
                  <td>{p.stock}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </>
  );
}
