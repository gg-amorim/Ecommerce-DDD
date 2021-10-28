using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Produto>, IProduct
    {
        private readonly DbContextOptions<BaseContext> _optionsBuilder;
        public RepositoryProduct()
        {
            _optionsBuilder = new DbContextOptions<BaseContext>();
        }

        public async Task<List<Produto>> ListarProdutosUser(string idUser)
        {
            using(var banco = new BaseContext(_optionsBuilder))
            {
                return await banco.Produto.Where(x => x.UserId == idUser).AsNoTracking().ToListAsync();
            }
        }
    }
}