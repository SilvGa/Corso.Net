using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.DemoBST
{
    public class BSTNodeBreadthEnumerator : IEnumerator<BSTNode>
        //ci serve un punto di partenza e sapere come muoversi al prossimo (e sapere il corrente ovviamente)
    {
        public BSTNode Current { get; private set; }

        object IEnumerator.Current
        {
            get
            {
                return ToVisit.Peek(); //restituisce l'elemento all'inizio della coda senza rimuoverlo
            }
        }

        private BSTNode StartingNode { get; } //punto di partenza
        private Queue<BSTNode> ToVisit { get; }

        public BSTNodeBreadthEnumerator(BSTNode startingNode)
        {
            StartingNode = startingNode;
            ToVisit = new Queue<BSTNode>();
            ToVisit.Enqueue(startingNode); //accodare elemento alla lista
        }


        public void Dispose()
        {
            //implementazione easy non esatta e standard
            
        }

        public bool MoveNext() //true se movimento va bene, false se va male (coda vuota, ho visitato tutto)
        {
           
            BSTNode removed=ToVisit.Dequeue(); //toglie elemento lista e lo restituisce
            if (removed.Left != null)
            {
                ToVisit.Enqueue(removed.Left);
            }
            if (removed.Right != null)
            {
                ToVisit.Enqueue(removed.Right);
            }

            if (ToVisit.Count == 0)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
