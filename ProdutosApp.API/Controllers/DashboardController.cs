using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Dtos;
using ProdutosApp.Data.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet("{dataMin}/{dataMax}")]
        public IActionResult Get(DateTime dataMin, DateTime dataMax)
        {
            //ajustar a hora do campo dataMax
            dataMax = dataMax.AddDays(1).AddSeconds(-1);

            var categoriaRepository = new CategoriaRepository();

            var response = new DashboardResponseDto
            {
                CategoriaSomatorioQuantidade = categoriaRepository.ObterSomatorioQuantidade(dataMin, dataMax),
                CategoriaMediaPreco = categoriaRepository.ObterMediaPreco(dataMin, dataMax)
            };

            return Ok(response);
        }
    }
}
