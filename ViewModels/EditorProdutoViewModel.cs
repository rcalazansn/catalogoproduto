using Flunt.Notifications;
using Flunt.Validations;

namespace ApiProdutos.ViewModels
{
    public class EditorProdutoViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMaxLen(Descricao, 100, "Descrição", "A descrição deve conter até 100 caracteres")
                .HasMinLen(Descricao, 3, "Descrição", "A descrição deve conter pelo menos 3 caracteres")
                .IsGreaterThan(Preco, 0, "Preço", "O preço deve ser maior que zero")
            );
        }
    }
}