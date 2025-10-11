import "./Home.css";
import logo from "../assets/logo.png";

export default function Home({ onStart }) {
  return (
    <main className="home">
      <img src={logo} alt="Logo Hitori Sushi" className="home__logo" />
      <h1 className="home__title">Seja bem-vindo</h1>
      <button className="home__btn" onClick={onStart}>
        Iniciar reserva de mesa
      </button>
    </main>
  );
}
