using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CadastrarUsuario()
        {
            return View();
        }
        public ActionResult Erro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario u)
        {
            var user = UsuarioDAO.Logar(u);

            if (user != null)
            {
                Session["Usuario"] = user;
                return RedirectToAction("Home","Exibir");
            }
            else
            {
                return RedirectToAction("Erro", "Usuario");
            }

        }
        public ActionResult CadastrarUsu(Usuario u)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioDAO.CadastrarUsu(u))
                {
                    return RedirectToAction("Logar", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("", "Já há um usuário com esse Login");
                    return View("Home");
                }
            }
            else
            {
                return View("Home");
            }
        }
    }
}