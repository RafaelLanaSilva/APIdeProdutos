using ProdutosApp.Data.Dtos;

namespace ProdutosApp.API.Dtos
{
    public class DashboardResponseDto
    {
        public List<CategoriaSomatorioQuantidadeDto>? CategoriaSomatorioQuantidade { get; set; }
        public List<CategoriaMediaPrecoDto>? CategoriaMediaPreco { get; set; }
    }
}