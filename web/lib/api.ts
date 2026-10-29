export const API_URL = process.env.NEXT_PUBLIC_API_URL ?? "http://localhost:5000";

export interface Cliente {
  idCliente: number;
  nit: string;
  nombre: string;
  apellidos: string;
  email: string | null;
}

export interface Marca {
  idMarca: number;
  nombre: string;
}

export interface Puesto {
  idPuesto: number;
  nombre: string;
  salarioBase: number;
}

export interface Producto {
  idProducto: number;
  nombre: string;
  precio: number;
  stock: number;
  marca: { nombre: string } | null;
}

export interface Empleado {
  idEmpleado: number;
  nombre: string;
  apellidos: string;
  fechaContratacion: string;
  puesto: { nombre: string; salarioBase: number } | null;
}

export async function obtener<T>(ruta: string): Promise<T[] | null> {
  try {
    const res = await fetch(`${API_URL}/api/${ruta}`, { cache: "no-store" });
    if (!res.ok) return null;
    return await res.json();
  } catch {
    return null;
  }
}
