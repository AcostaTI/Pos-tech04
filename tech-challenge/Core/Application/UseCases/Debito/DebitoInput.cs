using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.UseCases.Debito
{
    public class DebitoInput
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Descricao { get; set; }
        public string NomeFornecedor { get; set; }
    }
}
