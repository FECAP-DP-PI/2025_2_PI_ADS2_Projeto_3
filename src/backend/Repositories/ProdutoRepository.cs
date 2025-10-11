using Microsoft.EntityFrameworkCore;
using OneManDev_PI.Models;

namespace OneManDev_PI.Repositories
{
    public class ProdutoRepository(AppDbContext context)
    {
        public async Task<List<Produto>> PegarTodosProdutos()
        {
            var produtos = await context.Produtos.ToListAsync();

            return produtos;
        }

        public async Task<Produto> PegarProdutoPorId()
        {
            var produto = await context.Produtos.FirstOrDefaultAsync();

            return produto;
        }

        public async Task CriarProduto(Produto produto)
        {
            await context.Produtos.AddAsync(produto);
            await context.SaveChangesAsync();
        }
    }
}
