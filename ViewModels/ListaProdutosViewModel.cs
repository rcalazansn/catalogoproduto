namespace ApiProdutos.ViewModels
{
    public class ListaProdutosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
    }
}