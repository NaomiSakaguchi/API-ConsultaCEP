using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaCep.DAL;
using ConsultaCep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class ConsultaAPIController : ControllerBase
    {
        private readonly ConsultaDAO _consultaDAO;
        public ConsultaAPIController(ConsultaDAO consultaDAO)
        {
            _consultaDAO = consultaDAO;
        }

        // GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult Listar()
        {
            return Ok(_consultaDAO.Listar());
        }

        // POST: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Cadastrar(Root consulta)
        {
            _consultaDAO.Cadastrar(consulta);
            return Created("", consulta);
        }

        // PUT: api/Endereco/AlterarEndereco
        [HttpPut("{id}")]
        [Route("AlterarEndereco")]
        public IActionResult Alterar (int id, Root consulta)
        {
            if (id != consulta.ConsultaId)
            {
                return BadRequest();
            }
                _consultaDAO.Alterar(id, consulta);
                return NoContent();
        }

        // DELETE: api/DeletarEndereco/
        [HttpDelete]
        [Route("DeletarEndereco")]
        public IActionResult Deletar (int id)
        {
            _consultaDAO.Deletar(id);
            return NoContent();
        }

    }
}
