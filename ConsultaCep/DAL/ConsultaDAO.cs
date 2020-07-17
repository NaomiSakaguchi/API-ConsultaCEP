using ConsultaCep.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCep.DAL
{
    public class ConsultaDAO
    {
        private readonly Context _context;
        public ConsultaDAO(Context context)
        {
            _context = context;
        }


        public void Cadastrar(Root consulta)
        {
            _context.Roots.Add(consulta);
            _context.SaveChanges();
        }

        public List<Root> Listar()
        {
            return _context.Roots.ToList();
        }

        public void Alterar(int id, Root consulta)
        {
            var con = _context.Roots.Find(id);
            _context.Entry(con).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var con = _context.Roots.Find(id);

            _context.Roots.Remove(con);
            _context.SaveChanges();
        }
    }
}
