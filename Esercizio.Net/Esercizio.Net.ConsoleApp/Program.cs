using System;
using System.Collections.Generic;
using Esercizi.Net.BusinessLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio.Net.ConsoleApp
{
    class Program
    {
        private static TransactionManager _transactionManager = null; //esempio di pattern singleton--> inizializzate variabili di istanza
        public static TransactionManager TransactionManager //la dichiariamo solo una volta, poi basta
        {
            get
            {
                if(_transactionManager == null)
                {
                    _transactionManager = new TransactionManager();
                }
                return _transactionManager;
            }
        }



        private static void StampaMenu()
        {
            Console.WriteLine("Opzioni disponibili:");
            Console.WriteLine("m/menu - stampa elenco opzioni (questo elenco)");
            Console.WriteLine("a/aggiungi - aggiungi una nuova transazione");
            Console.WriteLine("c/cancella - cancella una transazione");
            Console.WriteLine("s/stampa - stampa le transazioni esistenti");
            Console.WriteLine("e/esci - esci dal programma");
        }

        //la stampa video è gestita dalla console, ma il resto no ---> gestore delle transazioni va bene con il pattern singleton (elenco transazioni dato da lui)
        public static void Main(string[] args)
        {
            string opzione = string.Empty;
            //List<ITransazione> transazioni = new List<ITransazione>();
            //ITransactionFactory factory = new TransactionFactory();

            StampaMenu();

            do
            {
                Console.WriteLine();
                Console.Write("Inserire opzione desiderata: ");
                opzione = Console.ReadLine();
                IEnumerable<ITransazione> transazioni = TransactionManager.GetTransazione(); //prendendo le transazioni dal manager mantengo la tessa logica

                switch (opzione)
                {
                    case "m":
                    case "menu":
                        StampaMenu();
                        break;
                    case "a":
                    case "aggiungi":
                        try
                        {
                            //ITransazione nuovaTransazione = factory.Create();
                            ITransazione nuovaTransazione = TransactionManager.CreateTransaction();
                            Console.WriteLine();

                            Console.Write("Data transazione (MM/gg/aaaa): ");
                            string dtTransazione = Console.ReadLine();
                            nuovaTransazione.DataTransazione = DateTime.Parse(dtTransazione);
                            Console.Write("Tipo transazione (Spesa/Ricavo): ");
                            nuovaTransazione.Tipo = Console.ReadLine();
                            Console.Write("Categoria transazione: ");
                            nuovaTransazione.Categoria = Console.ReadLine();
                            Console.Write("Descrizione transazione: ");
                            nuovaTransazione.Descrizione = Console.ReadLine();
                            Console.Write("Importo transazione: ");
                            string impTransazione = Console.ReadLine();
                            nuovaTransazione.Importo = decimal.Parse(impTransazione);

                            //transazioni.Add(nuovaTransazione);
                            TransactionManager.SaveTransaction(nuovaTransazione);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Errore durante l'inserimento della transazione.");
                        }
                        break;
                    case "c":
                    case "cancella":
                        
                        if (transazioni.Count() == 0)
                        {
                            Console.WriteLine("Questa opzione non è disponibile. La lista è vuota.");
                        }
                        else if (transazioni.Count() == 1)
                        {
                            Console.Write("Sei sicuro di voler procedere? (si/no): ");
                            opzione = Console.ReadLine();
                            if (opzione == "si")
                            {
                                //transazioni.RemoveAt(0);
                                TransactionManager.Delete(0);
                                Console.WriteLine("Elemento cancellato.");
                            }
                            else if (opzione == "no")
                            {
                                Console.WriteLine("Operazione annullata.");
                            }
                            else
                            {
                                Console.WriteLine("Opzione non valida.");
                            }
                        }
                        else
                        {
                            Console.Write("Qual è la posizione della transazione che vuoi cancellare? ");
                            opzione = Console.ReadLine();
                            try
                            {
                                int posizione = int.Parse(opzione);
                                if (posizione > 0 && posizione <= transazioni.Count())
                                {
                                    Console.Write("Sei sicuro di voler procedere? (si/no): ");
                                    opzione = Console.ReadLine();
                                    if (opzione == "si")
                                    {
                                        //transazioni.RemoveAt(posizione - 1);
                                        TransactionManager.Delete(posizione - 1);
                                        Console.WriteLine("Elemento cancellato.");
                                    }
                                    else if (opzione == "no")
                                    {
                                        Console.WriteLine("Operazione annullata.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opzione non valida.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Posizione non valida. Le posizioni valide sono da 1 a " + transazioni.Count() + ".");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Errore durante la cancellazione.");
                            }
                        }
                        break;
                    case "s":
                    case "stampa":
                        
                        if (transazioni.Count() == 0)
                        {
                            Console.WriteLine("Non ci sono transazioni.");
                        }
                        else
                        {
                            int i = 0;
                            foreach (ITransazione transazione in transazioni)
                            {
                                //ITransazione transazione = transazioni[i];

                                Console.WriteLine((i + 1) + ":");
                                Console.WriteLine(transazione);
                                Console.WriteLine();
                                i++;
                            }
                        }
                        break;
                    case "e":
                    case "esci":
                        Console.Write("Sei sicuro di voler uscire? (si/no): ");
                        opzione = Console.ReadLine();
                        if (opzione == "si")
                        {
                            return;
                        }
                        if (opzione != "no")
                        {
                            Console.WriteLine("Opzione non riconosciuta.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opzione non riconosciuta. Riprovare.");
                        break;
                }
            } while (true);
        }
    }

}
