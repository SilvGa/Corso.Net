using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public class TransactionFactory : ITransactionFactory
    {
        public ITransazione Create()
        {
            return new TransazioneGK();
        }
    }
}
