using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public interface ITransazione
    {
        string Tipo { get; set; }
        string Categoria { get; set; }
        string Descrizione { get; set; }
        DateTime DataTransazione { get; set; }
        decimal Importo { get; set; }
    }
}
