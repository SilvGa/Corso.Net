using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public class TransactionManager //pubblica perchè deve essere vista da fuori della solutionw e da elementi che non derivano da questa
    {
        //deve darci elenco transazioni correnti, cancellare e aggiungere

        public ITransactionFactory Factory { get; }
        public List<ITransazione> Transazioni { get; }


        public TransactionManager(ITransactionFactory factory){//costruttore
            Factory=factory;
        }

        public ITransazione CreateTransaction() //ha bisogno del factory
        {
            return Factory.Create();
        }

        public void SaveTransaction(ITransazione transazione)
        {
            Transazioni.Add(transazione);
        }

        public ITransazione Delete(int index)
        {
            return null;
        }

        public IEnumerable<ITransazione> GetTransazione(){
            return null;
        }

    }
}
