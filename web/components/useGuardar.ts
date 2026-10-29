"use client";

import { FormEvent, useState } from "react";
import { useRouter } from "next/navigation";
import { API_URL } from "@/lib/api";

export default function useGuardar(ruta: string, mensajeError: string) {
  const router = useRouter();
  const [error, setError] = useState("");

  async function enviar(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();
    const form = e.currentTarget;
    const datos = Object.fromEntries(new FormData(form));
    setError("");

    try {
      const res = await fetch(`${API_URL}/api/${ruta}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(datos),
      });
      if (!res.ok) {
        setError(mensajeError);
        return;
      }
      form.reset();
      router.refresh();
    } catch {
      setError("No se pudo conectar con la API.");
    }
  }

  return { enviar, error };
}
