using System.Collections.Generic;

namespace ApiProdutos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}