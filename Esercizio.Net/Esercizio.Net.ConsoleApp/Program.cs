using System;
using System.Collections.Generic;
using Esercizi.Net.BusinessLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//difficoltà 1: scegliere la categoria di transazione, aggiungerne o rimuoverne una

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

        private static CategoryManager _categoryManager = null; 
        public static CategoryManager CategoryManager 
        {
            get
            {
                if (_categoryManager == null)
                {
                    _categoryManager = new CategoryManager();
                }
                return _categoryManager;
            }
        }


        private static void StampaMenu()
        {
            Console.WriteLine("Opzioni disponibili:");
            Console.WriteLine("m/menu - stampa elenco opzioni (questo elenco)");
            Console.WriteLine("a/aggiungi - aggiungi una nuova transazione");
            Console.WriteLine("c/cancella - cancella una transazione");
            Console.WriteLine("i/inserisci - inserisci nuova categoria");
            Console.WriteLine("v/vedere - vedere le categorie esistenti");
            Console.WriteLine("r/rimuovi - rimuovere categoria");
            Console.WriteLine("s/stampa - stampa le transazioni esistenti");
            Console.WriteLine("e/esci - esci dal programma");
        }

        //la stampa video è gestita dalla console, ma il resto no ---> gestore delle transazioni va bene con il pattern singleton (elenco transazioni dato da lui)
        public static void Main(string[] args)
        {
            string opzione = string.Empty;
            //List<Categoria> categorie = new List<Categoria>();
            //List<ITransazione> transazioni = new List<ITransazione>();
            //ITransactionFactory factory = new TransactionFactory();

            StampaMenu();

            do
            {
                Console.WriteLine();
                Console.Write("Inserire opzione desiderata: ");
                opzione = Console.ReadLine();
                Console.WriteLine();
                IEnumerable<ITransazione> transazioni = TransactionManager.GetTransazione(); //prendendo le transazioni dal manager mantengo la tessa logica
                IEnumerable<ICategory> categorie = CategoryManager.GetCategoria();

                switch (opzione)
                {
                    case "m":
                    case "menu":
                        StampaMenu();
                        break;
                    case "a":
                    case "aggiungi":
                        if (categorie.Count () == 0)
                        {
                            Console.WriteLine("Non ci sono categorie inserite. Aggiungi una categoria. ");
                            break;
                        }
                        try
                        {
                            //ITransazione nuovaTransazione = factory.Create();
                            ITransazione nuovaTransazione = TransactionManager.CreateTransaction();
                            Console.WriteLine();

                            Console.Write("Data transazione (MM/gg/aaaa): ");
                            string dtTransazione = Console.ReadLine();
                            nuovaTransazione.DataTransazione = DateTime.Parse(dtTransazione);
                            Console.Write("Tipo transazione ("+TipoTransazione.Spesa+"/"+TipoTransazione.Ricavo+"): ");

                            //controllo che tipo transazione sia giusto
                            //nuovaTransazione.Tipo = Console.ReadLine();
                            string tipo = Console.ReadLine();
                            if (tipo == TipoTransazione.Spesa.ToString() )
                            {
                                nuovaTransazione.Tipo = TipoTransazione.Spesa;
                            }
                            else if (tipo == TipoTransazione.Ricavo.ToString())
                            {
                                nuovaTransazione.Tipo = TipoTransazione.Ricavo;
                            }
                            else
                            {
                                Console.WriteLine("Valore non concesso");
                                break;
                            }
                            Console.Write("Categoria transazione: ");

                            //voglio che scelga tra le categorie esistenti
                            //nuovaTransazione.Categoria = Console.ReadLine(); 
                            Console.WriteLine();
                            int index = 0;
                            foreach (ICategory cat in categorie)
                            {
                                index++;
                                Console.WriteLine(index + " " + cat.NomeCategoria);
                            }
                            int NumeroCategoria = int.Parse(Console.ReadLine()) -1;
                            nuovaTransazione.Categoria = categorie.ElementAt(NumeroCategoria);


                            Console.Write("Descrizione transazione: ");
                            nuovaTransazione.Descrizione = Console.ReadLine();
                            Console.Write("Importo transazione: ");
                            string impTransazione = Console.ReadLine();
                            nuovaTransazione.Importo = decimal.Parse(impTransazione);

                            //transazioni.Add(nuovaTransazione);
                            TransactionManager.SaveTransaction(nuovaTransazione);
                        }
                        catch(FormatException fe)
                        {
                            Console.WriteLine("inserisci un numero");
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
                            Console.Clear();
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
                                    Console.Clear();
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
                            Console.Clear();
                            Console.Write("vuoi vedere tutte le transazioni? si/no  ");
                            opzione = Console.ReadLine();
                            
                            if (opzione == "si")
                            {
                                int i = 0;
                                foreach (ITransazione transazione in transazioni)
                                {
                                    //ITransazione transazione = transazioni[i];

                                    Console.WriteLine("Transazione numero " + (i + 1));
                                    Console.WriteLine(transazione);
                                    Console.WriteLine();
                                    i++;
                                }
                            }
                            else if (opzione == "no")
                            {
                                Console.Write("Di quale categoria vuoi vedere le transazioni? scrivi il nome:  ");
                                opzione = Console.ReadLine();
                                Console.WriteLine();

                                bool flag = false;

                                foreach (ITransazione transazione in transazioni)
                                {
                                    if (transazione.Categoria.NomeCategoria == opzione)
                                    {
                                        Console.WriteLine(transazione);
                                        flag = true;

                                    }
                                }
                                 if  (flag == false)
                                {
                                    Console.WriteLine("Non c'è una categoria con quel nome");
                                }
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
                    case "i":
                    case "inserisci":
                        //Categoria c=new Categoria(;
                        ICategory nuovaCategoria = CategoryManager.CreateCategory();

                        Console.Write("Nome della categoria: ");
                        nuovaCategoria.NomeCategoria= Console.ReadLine();

                        bool controllo = false;

                        foreach (ICategory categoria in categorie)
                        {
                            if (nuovaCategoria.NomeCategoria == categoria.NomeCategoria)
                            {
                                Console.WriteLine(" \n nome categoria già presente");
                                controllo = true;
                            }
                        }
                        if (controllo == false)
                        {
                            Console.Write("\n Descrizione della categoria: ");
                            nuovaCategoria.Descrizione = Console.ReadLine();

                            CategoryManager.SaveCategory(nuovaCategoria);
                        }
                                                
                        break;
                    case "v":
                    case "vedere":
                        if (categorie.Count () == 0)
                        {
                            Console.WriteLine("Questa opzione non è disponibile. La lista è vuota.");
                            break;
                        }
                        Console.Clear();

                        int indice = 0;
                        foreach (ICategory cat in categorie)
                        {
                            indice++;                           
                            Console.WriteLine(indice+" "+cat.ToString());
                        }
                        break;
                    case "r":
                    case "rimuovi":
                        if (categorie.Count() == 0)
                        {
                            Console.WriteLine("Questa opzione non è disponibile. La lista è vuota.");
                        }
                        else if (categorie.Count() == 1)
                        {
                            foreach(ITransazione transazione in transazioni)
                            {
                                if (transazione.Categoria == categorie.ElementAt(0))
                                {
                                    Console.WriteLine(transazione);
                                }
                            }
                            Console.Write("Sei sicuro di voler procedere? (si/no): ");
                            opzione = Console.ReadLine();
                            Console.Clear();
                            if (opzione == "si")
                            {
                                CategoryManager.Delete(0);
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
                            Console.Write("Qual è la posizione della categoria che vuoi cancellare? ");
                            opzione = Console.ReadLine();
                            try
                            {
                                int posizione = int.Parse(opzione);
                                if (posizione > 0 && posizione <= categorie.Count())
                                {
                                    foreach (ITransazione transazione in transazioni)
                                    {
                                        if (transazione.Categoria == categorie.ElementAt(posizione -1))
                                        {
                                            Console.WriteLine(transazione);
                                        }
                                    }
                                    Console.Write("Sei sicuro di voler procedere? (si/no): ");
                                    opzione = Console.ReadLine();
                                    Console.Clear();
                                    if (opzione == "si")
                                    {
                                        CategoryManager.Delete(posizione - 1);
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
                                    Console.WriteLine("Posizione non valida. Le posizioni valide sono da 1 a " + categorie.Count() + ".");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Errore durante la cancellazione.");
                            }
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
