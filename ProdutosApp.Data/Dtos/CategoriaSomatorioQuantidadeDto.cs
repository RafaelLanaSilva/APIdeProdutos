using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Dtos
{
    /// <summary>
    /// DTO para capturar os dados obtidos da consulta que retorna
    /// o somatório da quantidade de produtos por categoria
    /// </summary>
    public class CategoriaSomatorioQuantidadeDto
    {
        public string? NomeCategoria { get; set; }
        public int SomatorioQuantidade { get; set; }
    }
}