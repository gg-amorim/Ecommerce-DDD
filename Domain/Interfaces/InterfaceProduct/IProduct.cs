using Domain.Interfaces.Generics;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceProduct
{
    public class IProduct : IGeneric<Produto>
    {
        public Task Add(Produto Obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Produto Obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Produto> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Produto>> List()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Produto Obj)
        {
            throw new System.NotImplementedException();
        }
    }
}