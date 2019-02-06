using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public interface ITransazione
    {
        TipoTransazione Tipo { get; set; }
        ICategory Categoria { get; set; }
        string Descrizione { get; set; }
        DateTime DataTransazione { get; set; }
        decimal Importo { get; set; }
    }
}
