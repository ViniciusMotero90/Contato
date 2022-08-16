using Contato.Data;
using Contato.Interfaces;
using Contato.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contato.Services
{
    public class ContatosService : IContatosRepository
    {
        private readonly ContatosContext _contatosContext;

        public ContatosService(ContatosContext contatosContext)
        {
            _contatosContext = contatosContext;
        }

        public async Task Add(Contatos contatos)
        {
            await Task.Run(() => _contatosContext.Add(contatos));
        }

        public void Delete(int id)
        {
            var e = new Contatos() { IdContato = id };
            _contatosContext.Set<Contatos>().Remove(e);
        }

        public async Task<IEnumerable<Contatos>> GetAll()
        {
            var result = await _contatosContext.Contatos.ToListAsync();
            return result;
        }

        public async Task<Contatos> GetById(int id)
        {
            var result = await _contatosContext.Contatos.FindAsync(id);
            return result;
        }

        public Contatos Update(int id, Contatos newContatos)
        {
            var model = this._contatosContext.Contatos.Where(m => m.IdContato == newContatos.IdContato).FirstOrDefault();
            return model;
        }
    }
}