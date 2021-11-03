using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceProductApp : InterfaceGenericApp<Produto>
    {
        Task AddProduct(Produto produto);

        Task UpdadeProduct(Produto produto);

        Task<List<Produto>> ListarProdutosUser(string idUser);

        Task<List<Produto>> ListarProdutosComEstoque();

        Task<List<Produto>> ListarProdutosCarUser(string userId);

        Task<Produto> ObterProdutosCar(int idProdutoCar);
    }
}