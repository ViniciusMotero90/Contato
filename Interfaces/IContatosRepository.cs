using Contato.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contato.Interfaces
{
    public interface IContatosRepository
    {
        Task<IEnumerable<Contatos>> GetAll();
        Task<Contatos> GetById(int id);
        Task Add(Contatos contatos);
        Contatos Update(int id, Contatos newContatos);
        void Delete(int id);
    }
}