namespace ProdutosApp.API.Dtos
{
    public class ProdutoResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public CategoriaResponseDto? Categoria { get; set; }
    }
}