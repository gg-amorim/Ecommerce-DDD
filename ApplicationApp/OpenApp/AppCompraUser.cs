using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceCompraUser;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppCompraUser : InterfaceCompraUserApp
    {
        private readonly ICompraUser _ICompraUser;
        public AppCompraUser(ICompraUser ICompraUser)
        {
            _ICompraUser = ICompraUser;

        }

        public async Task<int> QuantidadeProdutoCarUser(string userId)
        {
            return await _ICompraUser.QuantidadeProdutoCarUser(userId);
        }

        public async Task Add(CompraUser Obj)
        {
            await _ICompraUser.Add(Obj);
        }

        public async Task Delete(CompraUser Obj)
        {
            await _ICompraUser.Delete(Obj);
        }

        public async Task<CompraUser> GetById(int Id)
        {
           return await _ICompraUser.GetById(Id);
        }

        public async Task<List<CompraUser>> List()
        {
            return await _ICompraUser.List();
        }

        public async Task Update(CompraUser Obj)
        {
            await _ICompraUser.Update(Obj);
        }
    }
}