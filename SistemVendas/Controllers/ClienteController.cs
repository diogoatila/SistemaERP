using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Models;

namespace SistemaERP.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaClientes = new ClienteModel().ListarTodosClientes();
            return View();
        }
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
           if(id != null)
            {
                //Carregar o registro do cliente numa ViewBag
            }
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Inserir();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Excluir(int id)
        {

            return View();
        }

    }
}
