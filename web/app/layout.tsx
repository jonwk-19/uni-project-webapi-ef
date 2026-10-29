import type { Metadata } from "next";
import Link from "next/link";
import "bootstrap/dist/css/bootstrap.min.css";
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
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <div className="container">
            <Link className="navbar-brand" href="/">Tienda</Link>
            <div className="navbar-nav">
              <Link className="nav-link" href="/clientes">Clientes</Link>
              <Link className="nav-link" href="/productos">Productos</Link>
              <Link className="nav-link" href="/empleados">Empleados</Link>
            </div>
          </div>
        </nav>
        <main className="container my-4">{children}</main>
      </body>
    </html>
  );
}
