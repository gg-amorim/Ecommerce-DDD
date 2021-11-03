using Domain.Interfaces.Generics;
using Entities.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceCompraUser
{
    public interface ICompraUser : IGeneric<CompraUser>
    {
        public Task<int> QuantidadeProdutoCarUser(string userId);

    }
}