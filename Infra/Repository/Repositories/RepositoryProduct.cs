using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Entities.Entities.Enums;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var banco = new BaseContext(_optionsBuilder))
            {
                return await banco.Produto.Where(exProduto).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Produto>> ListarProdutosCarUser(string userId)
        {
            using (var banco = new BaseContext(_optionsBuilder))
            {
                var produtosCarUser = await (from p in banco.Produto
                                             join c in banco.CompraUser on p.Id equals c.IdProduto
                                             where c.UserId.Equals(userId) && c.Estado == EstadoCompra.Produto_Carrinho
                                             select new Produto
                                             {
                                                 Id = p.Id,
                                                 Nome = p.Nome,
                                                 Descricao = p.Descricao,
                                                 Observacao = p.Observacao,
                                                 Valor = p.Valor,
                                                 QtdCompra = c.QtdCompra,
                                                 IdProdutoCar = c.Id
                                             }).AsNoTracking().ToListAsync();

                return produtosCarUser;
            }
        }

        public async Task<Produto> ObterProdutosCar(int idProdutoCar)
        {
            using (var banco = new BaseContext(_optionsBuilder))
            {
                var produtosCarUser = await (from p in banco.Produto
                                             join c in banco.CompraUser on p.Id equals c.IdProduto
                                             where c.Id.Equals(idProdutoCar) && c.Estado == EstadoCompra.Produto_Carrinho
                                             select new Produto
                                             {
                                                 Id = p.Id,
                                                 Nome = p.Nome,
                                                 Descricao = p.Descricao,
                                                 Observacao = p.Observacao,
                                                 Valor = p.Valor,
                                                 QtdCompra = c.QtdCompra,
                                                 IdProdutoCar = c.Id
                                             }).AsNoTracking().FirstOrDefaultAsync();

                return produtosCarUser;
            }
        }

        public async Task<List<Produto>> ListarProdutosUser(string idUser)
        {
            using (var banco = new BaseContext(_optionsBuilder))
            {
                return await banco.Produto.Where(x => x.UserId == idUser).AsNoTracking().ToListAsync();
            }
        }

    }
}