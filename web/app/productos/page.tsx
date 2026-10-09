import { Producto, obtener } from "@/lib/api";

export default async function Productos() {
  const productos = await obtener<Producto>("productos");

  return (
    <>
      <h1>Productos</h1>
      {productos === null ? (
        <p className="error">No se pudo conectar con la API.</p>
      ) : (
        <table>
          <thead>
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
      )}
    </>
  );
}
