using Entities.Entities;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceProductApp : InterfaceGenericApp<Produto>
    {
        Task AddProduct(Produto produto);

        Task UpdadeProduct(Produto produto);
    }
}