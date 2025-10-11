import { useEffect, useState } from "react";

function MesasReservadas() {
  const [mesas, setMesas] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5000/api/mesa/disponiveis") 
      .then((res) => res.json())
      .then((data) => setMesas(data))
      .catch(() => setMesas([]));
  }, []);

  return (
    <div>
      <h2 className="text-2xl font-bold mb-6 text-red-600 text-center">
        Mesas Reservadas
      </h2>
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        {mesas.length > 0 ? (
          mesas.map((m) => (
            <div
              key={m.id}
              className="bg-white p-4 rounded-2xl shadow hover:shadow-lg transition"
            >
              <p className="text-lg font-semibold">Mesa {m.numero}</p>
              <p className="text-sm text-green-600">Reservada</p>
            </div>
          ))
        ) : (
          <p className="col-span-3 text-center text-gray-600">
            Nenhuma mesa reservada.
          </p>
        )}
      </div>
    </div>
  );
}

export default MesasReservadas;
