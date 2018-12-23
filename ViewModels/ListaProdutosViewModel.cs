using System;

namespace ApiProdutos.ViewModels
{
    public class ListaProdutosViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Guid CategoriaId { get; set; }
        public string Categoria { get; set; }
    }
}