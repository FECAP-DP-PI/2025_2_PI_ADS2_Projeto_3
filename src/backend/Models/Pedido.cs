namespace OneManDev_PI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; private set; }
        public Mesa Mesa { get; private set; }
        public int MesaId { get; set; }
        public StatusPedido Status {  get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Pedido()
        {
            
        }

        public Pedido(List<Produto> produtos, Mesa mesa)
        {
            Produtos = produtos;
            Mesa = mesa;
            MesaId = mesa.Id;
            Status = StatusPedido.Pendente;
            DataCriacao = DateTime.Now;
        }

        public void PreparandoPedido()
        {
            Status = StatusPedido.Preparando;
        }
        
        public void EntregarPedido()
        {
            Status = StatusPedido.Entregue;
        }



    }
}
