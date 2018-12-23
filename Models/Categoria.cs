using System.Collections.Generic;

namespace ApiProdutos.Models
{
    public class Categoria :Entity
    {
        public string Descricao { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}