using EcommerceOsorioManha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ExibirController : Controller
    {
        // GET: Home
        public ActionResult Home(int? id)
        {
            ViewBag.Categorias = CategoriaDAO.RetornarCategorias();
            if (id == null)
            {
                return View(ProdutoDAO.RetornarProdutos());
            }
            return View(ProdutoDAO.BuscarProdutosPorCategoria(id));
        }

        public ActionResult Detalhes(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }
    }
}