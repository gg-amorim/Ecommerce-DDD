using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Ecommerce.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly InterfaceProductApp _interfaceProductApp;

        private readonly InterfaceCompraUserApp _interfaceCompraUserApp;

        public ProdutosController(InterfaceProductApp interfaceProductApp, UserManager<ApplicationUser> userManager, InterfaceCompraUserApp interfaceCompraUserAp)
        {
            _interfaceProductApp = interfaceProductApp;
            _userManager = userManager;
            _interfaceCompraUserApp = interfaceCompraUserAp;
        }

        // GET: ProdutosController
        public async Task<IActionResult> Index()
        {
            var idUser = await RetornaIdUserLogado();

            return View(await _interfaceProductApp.ListarProdutosUser(idUser));
        }

        // GET: ProdutosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _interfaceProductApp.GetById(id));
        }

        // GET: ProdutosController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            try
            {
                var idUser = await RetornaIdUserLogado();

                produto.UserId = idUser;

                await _interfaceProductApp.AddProduct(produto);
                if (produto.Notificacoes.Any())
                {
                    foreach (var item in produto.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }
                    return View("Create", produto);
                }
            }
            catch
            {
                return View("Create", produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _interfaceProductApp.GetById(id));
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            try
            {
                await _interfaceProductApp.UpdadeProduct(produto);
                if (produto.Notificacoes.Any())
                {
                    foreach (var item in produto.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    ViewBag.Alerta = true;
                    ViewBag.Mensagem = "Verifique, ocorreu algum erro!";
                    return View("Edit", produto);
                }
            }
            catch
            {
                return View("Edit", produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _interfaceProductApp.GetById(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _interfaceProductApp.GetById(id);
                await _interfaceProductApp.Delete(produtoDeletar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<string> RetornaIdUserLogado()
        {
            var idUser = await _userManager.GetUserAsync(User);
            return idUser.Id;
        }

        [AllowAnonymous]
        [HttpGet("/api/listaprodutos")]
        public async Task<JsonResult> ListarProdutosComEstoque()
        {
            return Json(await _interfaceProductApp.ListarProdutosComEstoque());
        }

        public async Task<IActionResult> ListaProdutosCar()
        {
            var idUser = await RetornaIdUserLogado();
            return View(await _interfaceProductApp.ListarProdutosCarUser(idUser));
        }

        public async Task<IActionResult> DeleteProdutoCar(int id)
        {
            return View(await _interfaceProductApp.ObterProdutosCar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProdutoCar(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _interfaceCompraUserApp.GetById(id);
                await _interfaceCompraUserApp.Delete(produtoDeletar);
                return RedirectToAction(nameof(ListaProdutosCar));
            }
            catch
            {
                return View();
            }
        }
    }
}