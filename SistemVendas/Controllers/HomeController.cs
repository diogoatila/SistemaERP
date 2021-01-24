using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Models;
using SistemaERP.Uteis;

namespace SistemaERP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
         
            return View();
        }

        public IActionResult Menu()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
           
            return View();
        }
        public IActionResult Login(int? id)
        {
            //Realizar logout
            if(id != null)
            {
                if(id == 0)
                {
                    HttpContext.Session.SetString("IDUsuarioLogado", String.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", String.Empty);
                }
            }

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = login.ValidarLogin();
                if (loginOk)
                {
                    HttpContext.Session.SetString("IDUsuarioLogado", login.ID);
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                    return RedirectToAction("Menu", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "E-mail ou Senha inválidos!";
                }
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
