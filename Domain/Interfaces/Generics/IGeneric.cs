using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T Obj);
        Task Update(T Obj);
        Task Delete(T Obj);
        Task<T> GetById(int Id);
        Task<List<T>> List();
    }
}