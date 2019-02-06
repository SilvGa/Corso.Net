using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public enum TipoTransazione //contiene un elenco di valori come spesa e ricavo -->per settare il valore posso solo mettere uno di questi, se lo lo ignoro
        //però l'utente non lo sa!!!!!!
        //Se volessi cambiare un dato visual studio ci fa cambiare in automatico dovunque io abbia scritto il dato vecchio
    {
        Spesa,
        Ricavo
    }
}
