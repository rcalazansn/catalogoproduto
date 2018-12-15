using System;

namespace ApiProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime Alteracao { get; set; }
        public int CategoriaId { get; set; }        
        public Categoria Categoria { get; set; }      
    }
}