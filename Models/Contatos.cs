using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contato.Models
{
    public class Contatos
    {
        [Key]
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}