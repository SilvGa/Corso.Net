using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public abstract class Transazione : ITransazione
    {
        private string _tipo;
        public string Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                if (value == "Spesa" || value == "Ricavo")
                {
                    _tipo = value;
                }
            }
        }

        public DateTime DataTransazione { get; set; }

        public string Categoria { get; set; }

        public string Descrizione { get; set; }

        public abstract decimal Importo { get; set; }

        public override string ToString()
        {
            string result = string.Empty;
            result += "Data transazione: " + DataTransazione + ",\n";
            result += "Categoria: " + Categoria + ",\n";
            result += "Descrizione: " + Descrizione + ",\n";
            result += "Importo: " + Importo + ".\n";

            return result;
        }
    }
}
