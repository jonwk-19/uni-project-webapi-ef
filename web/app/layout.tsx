import type { Metadata } from "next";
import Link from "next/link";
import "./globals.css";

export const metadata: Metadata = {
  title: "Tienda",
  description: "Frontend de la Web API de la tienda",
};

export default function RootLayout({
  children,
}: Readonly<{ children: React.ReactNode }>) {
  return (
    <html lang="es">
      <body>
        <nav>
          <Link href="/">Inicio</Link>
          <Link href="/clientes">Clientes</Link>
          <Link href="/productos">Productos</Link>
          <Link href="/empleados">Empleados</Link>
        </nav>
        <main>{children}</main>
      </body>
    </html>
  );
}
