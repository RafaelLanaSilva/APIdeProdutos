using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Dtos
{
    /// <summary>
    /// DTO para capturar os dados obtidos da consulta que retorna
    /// a média de preços de produtos por categoria
    /// </summary>
    public class CategoriaMediaPrecoDto
    {
        public string? NomeCategoria { get; set; }
        public decimal MediaPreco { get; set; }
    }
}
