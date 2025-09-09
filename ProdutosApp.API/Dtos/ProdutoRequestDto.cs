using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.API.Dtos
{
    public class ProdutoRequestDto
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Nome { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Por favor, informe o preço entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Range(0, 9999, ErrorMessage = "Por favor, informe a quantidade entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe a categoria do produto.")]
        public Guid? CategoriaId { get; set; }
    }
}



