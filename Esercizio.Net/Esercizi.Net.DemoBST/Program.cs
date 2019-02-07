using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.DemoBST
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<BSTNode> nodes = new BSTNode();  //usa il metodo "generico" che usa i generics, ovvero la tipizzazione
            //IEnumerator<BSTNode> enumerator = nodes.GetEnumerator();

            IEnumerable node = new BSTNode();   //
            IEnumerator enumerator = node.GetEnumerator(); //usa il metodo non generico
             


        }
    }
}
