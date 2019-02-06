using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public abstract class Transazione : ITransazione
    {
        private TipoTransazione _tipo;
        public TipoTransazione Tipo{ get; set; }

        public DateTime DataTransazione { get; set; }

        public ICategory Categoria { get; set; }

        public string Descrizione { get; set; }

        public abstract decimal Importo { get; set; }

        public override string ToString()
        {
            string result = string.Empty;
            result += "Data transazione: " + DataTransazione + ",\n";
            result += "Tipo: " + Tipo + ",\n";
            result += "Categoria: " + Categoria.NomeCategoria + ",\n";
            result += "Descrizione: " + Descrizione + ",\n";
            result += "Importo: " + Importo + ".\n";

            return result;
        }
    }
}
