using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public abstract class Category : ICategory
    {
        public string NomeCategoria { get; set; }
        public string Descrizione { get; set; }

        public override string ToString()
        {
            string result = string.Empty;
            result += "Nome Categoria: " + NomeCategoria + "\n";
            result += "Descrizione della categoria: " + Descrizione + "\n";
            return result;
        }
    }
}
