using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceProduct
    {
        Task AddProduct(Produto produto);

        Task UpdadeProduct(Produto produto);

        Task<List<Produto>> ListarProdutosComEstoque();
    }
}