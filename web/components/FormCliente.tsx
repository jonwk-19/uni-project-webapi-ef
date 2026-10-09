"use client";

import { FormEvent, useState } from "react";
import { useRouter } from "next/navigation";
import { API_URL } from "@/lib/api";

export default function FormCliente() {
  const router = useRouter();
  const [error, setError] = useState("");

  async function enviar(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();
    const form = e.currentTarget;
    const datos = Object.fromEntries(new FormData(form));
    setError("");

    try {
      const res = await fetch(`${API_URL}/api/clientes`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(datos),
      });
      if (!res.ok) {
        setError("No se pudo guardar el cliente (revisa que el NIT no este repetido).");
        return;
      }
      form.reset();
      router.refresh();
    } catch {
      setError("No se pudo conectar con la API.");
    }
  }

  return (
    <form onSubmit={enviar}>
      <input name="nit" placeholder="NIT" required maxLength={20} />
      <input name="nombre" placeholder="Nombre" required maxLength={100} />
      <input name="apellidos" placeholder="Apellidos" required maxLength={100} />
      <input name="email" type="email" placeholder="Email" maxLength={100} />
      <button type="submit">Guardar</button>
      {error && <span className="error">{error}</span>}
    </form>
  );
}
