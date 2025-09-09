using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Dtos;
using ProdutosApp.Data.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaResponseDto>), 200)]
        public IActionResult Get()
        {
            var categoriaRepository = new CategoriaRepository();
            var categorias = categoriaRepository.ObterTodos();

            var response = new List<CategoriaResponseDto>();
            foreach (var item in categorias)
            {
                response.Add(new CategoriaResponseDto
                {
                    Id = item.Id,
                    Nome = item.Nome
                });
            }

            return Ok(response);
        }
    }
}
