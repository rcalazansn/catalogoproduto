using System;
using System.Collections.Generic;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        [Route("v1/produtos")]
        [ResponseCache(Duration = 60)]
        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IEnumerable<ListaProdutosViewModel> Get()
        {
            return _produtoRepository.Get();
        }

        [HttpGet]
        [Route("v1/produtos/{id}")]
        public ListaProdutosViewModel Get(int id)
        {
            return _produtoRepository.Get(id);
        }

        [HttpPost]
        [Route("v1/produtos")]
        public ResultViewModel Post([FromBody] EditorProdutoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel()
                {
                    Sucesso = false,
                    Mensagem = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };
            }

            Produto produto = new Produto();
            produto.Descricao = model.Descricao;
            produto.CategoriaId = model.CategoriaId;
            produto.Nome = model.Nome;
            produto.Preco = model.Preco;
            produto.Quantidade = model.Quantidade;
            produto.Criacao = DateTime.Now;
            produto.Alteracao = DateTime.Now;

            _produtoRepository.Insert(produto);

            return new ResultViewModel()
            {
                Sucesso = true,
                Mensagem = "Produto cadastrado com sucesso",
                Data = produto
            };
        }

        [HttpPut]
        [Route("v1/produtos")]
        public ResultViewModel Put([FromBody] EditorProdutoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel()
                {
                    Sucesso = false,
                    Mensagem = "Não foi possível alterar o produto",
                    Data = model.Notifications
                };
            }

            Produto produto = _produtoRepository.Find(model.Id);
            produto.Descricao = model.Descricao;
            produto.CategoriaId = model.CategoriaId;
            produto.Nome = model.Nome;
            produto.Preco = model.Preco;
            produto.Quantidade = model.Quantidade;
            produto.Alteracao = DateTime.Now;

            _produtoRepository.Update(produto);

            return new ResultViewModel()
            {
                Sucesso = true,
                Mensagem = "Produto alterado com sucesso",
                Data = produto
            };
        }

        [HttpDelete]
        [Route("v1/produtos")]
        public ResultViewModel Delete([FromBody] EditorProdutoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel()
                {
                    Sucesso = false,
                    Mensagem = "Não foi possível remover o produto",
                    Data = model.Notifications
                };
            }

            Produto produto = _produtoRepository.Find(model.Id);
            _produtoRepository.Delete(produto);

            return new ResultViewModel()
            {
                Sucesso = true,
                Mensagem = "Produto removido com sucesso",
                Data = produto
            };
        }
    }
}