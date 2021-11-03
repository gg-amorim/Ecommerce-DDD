using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _IProduct;

        public ServiceProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }

        public async Task AddProduct(Produto produto)
        {
            var validaNome = produto.ValidaPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidaPropriedadeDecimal(produto.Valor, "Valor");

            var validaEstoque = produto.ValidaPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && validaValor && validaEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _IProduct.Add(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutosComEstoque()
        {
            return await _IProduct.ListarProdutos(x => x.QtdEstoque > 0);
        }

        public async Task UpdadeProduct(Produto produto)
        {
            var validaNome = produto.ValidaPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidaPropriedadeDecimal(produto.Valor, "Valor");

            var validaEstoque = produto.ValidaPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && validaValor && validaEstoque)
                produto.DataAlteracao = DateTime.Now;
            await _IProduct.Update(produto);
        }


    }
}