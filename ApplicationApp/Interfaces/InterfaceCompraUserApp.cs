using Entities.Entities;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceCompraUserApp : InterfaceGenericApp<CompraUser>
    {
        public Task<int> QuantidadeProdutoCarUser(string userId);
    }
}