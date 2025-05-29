using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GERAL.models
{
    // Atributos da classe Despesas.
    public class Despesas
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public DateTime data { get; set; }
        public double valor { get; set; }
        public string formaPagamento { get; set; }
        public string categoria { get; set; }

        // Método construtor.
        public Despesas(
            int id,
            string titulo,
            DateTime data,
            double valor,
            string formaPagamento,
            string categoria
        )
        {
            this.id = id;
            this.titulo = titulo;
            this.data = data;
            this.valor = valor;
            this.formaPagamento = formaPagamento;
            this.categoria = categoria;
        }
    }
}
