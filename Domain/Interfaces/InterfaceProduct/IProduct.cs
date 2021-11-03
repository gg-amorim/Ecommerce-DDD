using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceProduct
{
    public interface IProduct : IGeneric<Produto>
    {
        Task<List<Produto>> ListarProdutosUser(string idUser);
        Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto);
        Task<List<Produto>> ListarProdutosCarUser(string userId);
        Task<Produto> ObterProdutosCar(int idProdutoCar);
    }
}