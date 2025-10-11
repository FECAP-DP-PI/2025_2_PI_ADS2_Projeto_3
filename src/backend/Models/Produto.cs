namespace OneManDev_PI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal? Preco { get; private set; }
        public string Sabor { get; private set; }

        public Produto()
        {
            
        }

        public Produto(string nome, string descricao, decimal preco, string sabor)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Sabor = sabor;
        }

    }
}
