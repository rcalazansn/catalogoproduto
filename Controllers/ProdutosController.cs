using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Application;
using API.Models;
using API.Repositories;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        public readonly IProdutoService ProdutoService;

        public ProdutosController(IProdutoService produtoService)
        {
            ProdutoService = produtoService;
        }

        [HttpGet]
        [Route("versao")]
        public string Versao()
        {
            return "Versão: 2.0";
        }

        [HttpPost]
        [Route("novo")]
        public async Task Inserir([FromBody] InserirProdutoViewModel produtoViewModel)
        {
            var produto = new Produto(produtoViewModel.Nome, produtoViewModel.Descricao, produtoViewModel.Preco, produtoViewModel.Quantidade);

            await ProdutoService.Inserir(produto);
        }

        [HttpPut]
        [Route("editar")]
        public async Task Editar([FromBody] EditarProdutoViewModel produtoViewModel)
        {
            var produto = new Produto(produtoViewModel.Id, produtoViewModel.Nome, produtoViewModel.Descricao, produtoViewModel.Preco, produtoViewModel.Quantidade);

            await ProdutoService.Editar(produto);
        }

        [HttpDelete]
        [Route("apagar/{id}")]
        public async Task Deletar(Guid id)
        {
            var result = await ProdutoService.Obter(id);

            if (result != null)
                await ProdutoService.Apagar(id);
        }

        [HttpGet]
        [Route("obter/{id}")]
        public async Task<ObterProdutoViewModel> Obter(Guid id)
        {
            var result = await ProdutoService.Obter(id);

            return new ObterProdutoViewModel()
            {
                Id = result.Id,
                Nome = result.Nome,
                Descricao = result.Descricao,
                Preco = result.Preco,
                Quantidade = result.Quantidade
            };
        }

        [HttpGet]
        [Route("obtertodos")]
        public async Task<IEnumerable<ObterTodosProdutosViewModel>> ObterTodos()
        {
            var result = await ProdutoService.Obter();

            IList<ObterTodosProdutosViewModel> lista =
            new List<ObterTodosProdutosViewModel>();

            foreach (var item in result)
            {
                lista.Add(new ObterTodosProdutosViewModel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade,
                    DataCriacao = item.Criacao
                });
            }
            return lista;
        }
    }
}
