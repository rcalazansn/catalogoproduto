using System;

namespace API.Models
{
    public class Produto : Entity
    {
        public Produto(string nome, string descricao, decimal preco, int quantidade)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Produto(Guid id, string nome, string descricao, decimal preco, int quantidade)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Descricao}";
        }
    }
}
