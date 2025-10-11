import { useState } from "react";

function ReservarMesa() {
  const [mesa, setMesa] = useState("");
  const [status, setStatus] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch("http://localhost:5000/api/mesa", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ mesa: parseInt(mesa) }),
      });

      const data = await response.json();
      setStatus(data.mensagem);
    } catch  {
      setStatus("Erro ao conectar com o servidor.");
    }
  };

  return (
    <div className="max-w-md mx-auto bg-white p-6 rounded-2xl shadow-lg">
      <h2 className="text-2xl font-bold mb-4 text-center text-red-600">
        Reservar Mesa
      </h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <input
          type="number"
          placeholder="Número da mesa"
          value={mesa}
          onChange={(e) => setMesa(e.target.value)}
          required
          className="w-full p-3 border rounded-lg"
        />
        <button
          type="submit"
          className="w-full bg-red-600 text-white py-2 rounded-lg hover:bg-red-700"
        >
          Reservar
        </button>
      </form>
      {status && (
        <p className="mt-4 text-center font-medium text-gray-700">{status}</p>
      )}
    </div>
  );
}

export default ReservarMesa;
