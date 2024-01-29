using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entidades
{
    public class Fornecedor
    {
        public Fornecedor(string id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
    }
}
