using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entidades
{
    public class Debito
    {
        public Debito(string id, decimal valor, DateTime data, DateTime dataVencimento, string descricao, Fornecedor fornecedor)
        {
            Id = id;
            Valor = valor;
            Data = data;
            DataVencimento = dataVencimento;
            Descricao = descricao;
            Fornecedor = fornecedor;
        }

        public string Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Descricao { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public override string ToString()
        {
            return $"Id do Debito: {Id}, Valor: R$ {Valor}, Data do Debíto: {Data}, Data Vencimento: {DataVencimento}" +
                $", Descrição: {Descricao}, Fornecedor: {Fornecedor.Nome}";
        }
    }
}
