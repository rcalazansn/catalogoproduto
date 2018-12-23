using System;

namespace API.ViewModels
{


    public class InserirProdutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }

    public class EditarProdutoViewModel : InserirProdutoViewModel
    {
        public Guid Id { get; set; }
    }

    public class ObterProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }

    public class ObterTodosProdutosViewModel : ObterProdutoViewModel
    {
        public DateTime DataCriacao { get; set; }
    }
}
