using Microsoft.EntityFrameworkCore;
using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    public class ProdutoRepository
    {
        public void Adicionar(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges(); 
            }
        }

        public void Atualizar(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();
            }
        }

        public void Excluir(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                produto.Ativo = false; //modificando o flag ativo para falso

                dataContext.Update(produto); 
                dataContext.SaveChanges(); 
            }
        }

        public List<Produto>? ObterPorPeriodo(DateTime dataMin, DateTime dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>()
                        .Include(p => p.Categoria) 
                        .Where(p => p.DataCriacao >= dataMin 
                                 && p.DataCriacao <= dataMax
                                 && p.Ativo == true) 
                        .OrderByDescending(p => p.DataCriacao)
                        .ToList();
            }
        }

        public Produto? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>()
                        .Include(p => p.Categoria) 
                        .Where(p => p.Id == id 
                                 && p.Ativo == true)
                        .FirstOrDefault();
            }
        }
    }
}
