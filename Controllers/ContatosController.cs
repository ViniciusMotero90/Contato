using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contato.Data;
using Contato.Models;
using Contato.Services;
using Contato.Interfaces;

namespace Contato.Controllers
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatosController : Controller
    {
        private readonly ContatosContext _context;
        private readonly IContatosRepository _contatosRepository;

        public ContatosController(ContatosContext context, IContatosRepository contatosRepository)
        {
            _context = context;
            _contatosRepository = contatosRepository;
        }

        // GET: api/Contatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contatos>>> GetContatos()
        {
            var get = await _contatosRepository.GetAll();
            return Ok(get);
        }

        // GET: api/Contatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contatos>> GetContatos(int id)
        {
            var contatos = await _contatosRepository.GetById(id);

            if (contatos == null)
            {
                return NotFound();
            }

            return Ok(contatos);
        }

        // PUT: api/Contatos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatos(int id, Contatos contatos)
        {
            if (id != contatos.IdContato)
            {
                return BadRequest();
            }

            _context.Entry(contatos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contatos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contatos>> PostContatos(Contatos contatos)
        {
            await _contatosRepository.Add(contatos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContatos", new { id = contatos.IdContato }, contatos);
        }

        // DELETE: api/Contatos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contatos>> DeleteContatos(int id)
        {
            var contatos = await _contatosRepository.GetById(id);
            if (contatos == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatos);
            await _context.SaveChangesAsync();

            return contatos;
        }

        private bool ContatosExists(int id)
        {
            return _context.Contatos.Any(e => e.IdContato == id);
        }
    }
}
