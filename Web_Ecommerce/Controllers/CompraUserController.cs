using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web_Ecommerce.Controllers
{
    public class CompraUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly InterfaceCompraUserApp _InterfaceCompraUserApp;

        public CompraUserController(UserManager<ApplicationUser> userManager, InterfaceCompraUserApp InterfaceCompraUserApp)
        {
            _userManager = userManager;
            _InterfaceCompraUserApp = InterfaceCompraUserApp;
        }

        [HttpPost("api/adicionarprodutocarrinho")]
        public async Task<JsonResult> AddProdutoCarrinho(string id, string nome, string qtde)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                await _InterfaceCompraUserApp.Add(new CompraUser
                {
                    IdProduto = Convert.ToInt32(id),
                    QtdCompra = Convert.ToInt32(qtde),
                    Estado = EstadoCompra.Produto_Carrinho,
                    UserId = user.Id
                });
                return Json(new { sucesso = true });
            }
            return Json(new { sucesso = false });
        }

        [HttpGet("/api/qtdeprodutoscar")]
        public async Task<JsonResult> QtdeProdutosCar()
        {
            var user = await _userManager.GetUserAsync(User);
            var qtde = 0;
            if (user != null)
            {
               qtde = await _InterfaceCompraUserApp.QuantidadeProdutoCarUser(user.Id);

                return Json(new { sucesso = true, qtde = qtde });
            }

            return Json(new { sucesso = false, qtde = qtde });
        }
    }
}