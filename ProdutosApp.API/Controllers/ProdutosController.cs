using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Dtos;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequestDto request)
        {
            var produto = new Produto()
            {
                Id = Guid.NewGuid(), 
                Nome = request.Nome, 
                Preco = request.Preco,
                Quantidade = request.Quantidade,
                DataCriacao = DateTime.Now, 
                Ativo = true, 
                CategoriaId = request.CategoriaId 
            };

            var produtoRepository = new ProdutoRepository();
            produtoRepository.Adicionar(produto);

            var produtoAdicionado = produtoRepository.ObterPorId(produto.Id.Value);

            return StatusCode(201, ToResponse(produtoAdicionado));
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoRequestDto request)
        {
            var produtoRepository = new ProdutoRepository();

            var produto = produtoRepository.ObterPorId(id);
            if (produto == null)
                return StatusCode(400, new { Mensagem = "Produto não encontrado para edição. Verifique o ID informado." });

            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Quantidade = request.Quantidade;
            produto.CategoriaId = request.CategoriaId;

            produtoRepository.Atualizar(produto);

            return StatusCode(200, ToResponse(produto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var produtoRepository = new ProdutoRepository();

            var produto = produtoRepository.ObterPorId(id);
            if (produto == null)
                return StatusCode(400, new { Mensagem = "Produto não encontrado para exclusão. Verifique o ID informado." });

            produtoRepository.Excluir(produto);

            return StatusCode(200, ToResponse(produto));
        }

        [HttpGet("{dataMin}/{dataMax}")]
        public IActionResult Get(DateTime dataMin, DateTime dataMax)
        {
            //Colocando a dataMax com hora 23:59:59
            dataMax = dataMax.Date.AddDays(1).AddSeconds(-1);

            if (DateTime.Compare(dataMin, dataMax) > 0)
                return StatusCode(400, new { Message = "O período de datas informado é inválido." });

            var produtoRepository = new ProdutoRepository();

            var produtos = produtoRepository.ObterPorPeriodo(dataMin, dataMax);
            if (!produtos.Any())
                return StatusCode(204); //HTTP No Content (204)

            var response = new List<ProdutoResponseDto>();

            foreach (var item in produtos)
            {
                response.Add(ToResponse(item));
            }

            return StatusCode(200, response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var produtoRepository = new ProdutoRepository();

            var produto = produtoRepository.ObterPorId(id);
            if (produto == null)
                return StatusCode(204); //HTTP NoContent (204)

            return StatusCode(200, ToResponse(produto));
        }

        private ProdutoResponseDto ToResponse(Produto produto)
        {
            return new ProdutoResponseDto
            {
                Id = produto?.Id,
                Nome = produto?.Nome,
                Preco = produto?.Preco,
                Quantidade = produto?.Quantidade,
                DataCriacao = produto?.DataCriacao,
                Categoria = new CategoriaResponseDto
                {
                    Id = produto?.Categoria?.Id,
                    Nome = produto?.Categoria?.Nome
                }
            };
        }
    }
}
