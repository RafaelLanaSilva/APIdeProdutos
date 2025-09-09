using Microsoft.EntityFrameworkCore;
using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Dtos;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    public class CategoriaRepository
    {
        public List<Categoria> ObterTodos()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Categoria>() 
                        .OrderBy(c => c.Nome) 
                        .ToList();                        
            }
        }

        public List<CategoriaSomatorioQuantidadeDto> ObterSomatorioQuantidade(DateTime dataMin, DateTime dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>()
                        .Include(p => p.Categoria)
                        .Where(p => p.DataCriacao >= dataMin && p.DataCriacao <= dataMax && p.Ativo.Value)
                        .GroupBy(p => p.Categoria.Nome)
                        .Select(group => new CategoriaSomatorioQuantidadeDto
                        {
                            NomeCategoria = group.Key,
                            SomatorioQuantidade = group.Sum(p => p.Quantidade.Value)
                        })
                        .OrderByDescending(dto => dto.SomatorioQuantidade) 
                        .ToList();
            }
        }

        public List<CategoriaMediaPrecoDto> ObterMediaPreco(DateTime dataMin, DateTime dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>()
                        .Include(p => p.Categoria)
                        .Where(p => p.DataCriacao >= dataMin && p.DataCriacao <= dataMax && p.Ativo.Value)
                        .GroupBy(p => p.Categoria.Nome)
                        .Select(group => new CategoriaMediaPrecoDto
                        {
                            NomeCategoria = group.Key,
                            MediaPreco = group.Average(p => p.Preco.Value)
                        })
                        .OrderByDescending(dto => dto.MediaPreco)
                        .ToList();
            }
        }
    }
}
