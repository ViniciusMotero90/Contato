using Contato.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contato.Data
{
    public class ContatosContext : DbContext
    {
        public ContatosContext(DbContextOptions<ContatosContext> options) : base(options) { }

        public DbSet<Contatos> Contatos { get; set; }
    }
}