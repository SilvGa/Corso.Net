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

        private ITransactionFactory Factory { get; } // <-- metodo privato!!!!! non accessibile da esterno
        private List<ITransazione> Transazioni { get; }

        public TransactionManager(): this(new TransactionFactory()) { }

        public TransactionManager(ITransactionFactory factory)
        {//costruttore
            Factory = factory;
            Transazioni = new List<ITransazione>();
        }

        public ITransazione CreateTransaction() //ha bisogno del factory
        {
            return Factory.Create();
        }

        public void SaveTransaction(ITransazione transazione)
        {
            Transazioni.Add(transazione);
        }

        public void Delete(int index)
        {
            Transazioni.RemoveAt(index);
        }

        public IEnumerable<ITransazione> GetTransazione()
        {
            return Transazioni;
        }

        public ITransazione OttieniTransazione(int index) //il programma può richiedere un singolo oggetto dando un indice
        {
            return Transazioni.ElementAt(index);
        }

        public int OttieniIndice(ITransazione t)
        {
            return Transazioni.IndexOf(t);
        }

    }
}
