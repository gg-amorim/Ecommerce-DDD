using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        IProduct _IProduct;
        IServiceProduct _IServiceProduct;
        public AppProduct(IProduct IProduct, IServiceProduct IServiceProduct)
        {
            _IProduct = IProduct;
            _IServiceProduct = IServiceProduct;
        }

        public async Task AddProduct(Produto produto)
        {
            await _IServiceProduct.AddProduct(produto);
        }

        public async Task UpdadeProduct(Produto produto)
        {
            await _IServiceProduct.UpdadeProduct(produto);
        }

        public async Task Add(Produto Obj)
        {
            await _IProduct.Add(Obj);
        }

        public async Task Delete(Produto Obj)
        {
            await _IProduct.Delete(Obj);
        }

        public async Task<Produto> GetById(int Id)
        {
            return await _IProduct.GetById(Id);
        }

        public async Task<List<Produto>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Produto Obj)
        {
            await _IProduct.Update(Obj);
        }

        public async Task<List<Produto>> ListarProdutosUser(string idUser)
        {
           return await _IProduct.ListarProdutosUser(idUser);
        }
    }
}