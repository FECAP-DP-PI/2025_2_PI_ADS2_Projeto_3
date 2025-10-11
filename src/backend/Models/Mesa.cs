namespace OneManDev_PI.Models
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; private set; }
        public List<Pedido> Pedidos { get; set; } = new();
        public StatusMesa Status {  get; private set; }

        public Mesa()
        {
            
        }
        public Mesa(int numero)
        {
            Numero = numero;
            Status = StatusMesa.Disponivel;
        }
    }


}
