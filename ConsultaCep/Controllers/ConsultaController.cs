using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConsultaCep.DAL;
using ConsultaCep.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//Alexandra Naomi Sakaguchi

namespace ConsultaCep.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly ConsultaDAO _consultaDAO;
        public ConsultaController(ConsultaDAO consultaDAO)
        {
            _consultaDAO = consultaDAO; 
        }
        public IActionResult Index()
        {
            if(TempData["Cep"] != null)
            {
                string resultado = TempData["Cep"].ToString();
                Root consulta = JsonConvert.DeserializeObject<Root>(resultado);
                _consultaDAO.Cadastrar(consulta);
                return View(consulta);
            }
            return View();
        }

        [HttpPost]
        public IActionResult PesquisarCep(string txtCep)
        {
            string url = $@"https://viacep.com.br/ws/{txtCep}/json/";
            WebClient cliente = new WebClient();
            TempData["Cep"] = cliente.DownloadString(url);
            return RedirectToAction("Index");
        }
    }
}
