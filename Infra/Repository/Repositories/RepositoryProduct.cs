using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Produto>, IProduct
    {
    }
}