using Domain.Interfaces.InterfaceCompraUser;
using Entities.Entities;
using Entities.Entities.Enums;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Repository.Repositories
{
    public class RepositoryCompraUser : RepositoryGenerics<CompraUser>, ICompraUser
    {
        private readonly DbContextOptions<BaseContext> _optionsBuilder;
        public RepositoryCompraUser()
        {
            _optionsBuilder = new DbContextOptions<BaseContext>();
        }

        public async Task<int> QuantidadeProdutoCarUser(string userId)
        {
            using(var banco = new BaseContext(_optionsBuilder))
            {
                return await banco.CompraUser.CountAsync(x => x.UserId.Equals(userId) && x.Estado.Equals(EstadoCompra.Produto_Carrinho));
            }
        }
    }
}