using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.DemoBST
{
    public class BSTNode :IEnumerable<BSTNode> //per usare foreach devo implementare ienumerable
    {


        //posso mettere l'elemento di istanza private oppure rendere il set private
        public int Element { get; private set; }
        public BSTNode Left { get; private set; }//sottoalbero sx della stessa tipologia della classe
        public BSTNode Right { get; private set; }


        //QUESTA IMPLEMENTAZIONE HA UN ERRORE, PER OGNI NODO AGGIUNGE UN ENUMERATORE CHE Dà UN ULTERIORE PEZZO DI MEMORIA
        // private IEnumerator<BSTNode> Enumerator { get; }
        //public BSTNode()
        //{
        //    Enumerator = new BSTNodeBreadthEnumerator(this);
        //}

        //QUINDI CREO SOLO QUANDO CI SERVE L'ENUMERATORE
        //oggetto che visita tutto e contiene la visita dell'albero -->VISITA IN AMPIEZZA
        public IEnumerator<BSTNode> GetEnumerator()//implementazione implicita 
            //Stesso metodo dove devo esplicitare quando scrivo il metodo di che tipo sia, in modo che li prenda in seguito solo di quel tipo
        {
            return new BSTNodeBreadthEnumerator(this);
        }


        //implementazione esplicita (il modo per usare l'ereditarietà multipla)
        IEnumerator IEnumerable.GetEnumerator()//stesso metodo che gestisce oggetti ( tipo Object)
        {
            return this.GetEnumerator();
        }



        public void Insert(int item)
        {
            if (item == Element)
            {
                return;
            }
            else if (item < Element)
            {
                if (Left == null)
                {
                    BSTNode newNode = new BSTNode //come se fosse BSTNode newNode=new BSTNode(); newNode.Element=item; this.Left=newNode;
                    {
                        Element = item
                    };
                }
                else
                {
                    Left.Insert(item); //ricorsione base
                }
            }
            else
            {
                if (Right==null)
                {
                    BSTNode newNode = new BSTNode();
                    newNode.Element = item;
                    Right = newNode;
                }
                else
                {
                    Right.Insert(item);
                }
            }
        }


    }
}
