using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public class CategoryManager
    {
        public ICategoryFactory Factory { get; }
        public List<ICategory> Categorie { get; }

        public CategoryManager() : this(new CategoryFactory())// this richiama il costruttore, e quindi si passa all'altro costruttore 
            //(con parametro ICategoryFactory) il tipo CategoryFactory
        {
        }

        public CategoryManager(ICategoryFactory factory)
        {
            Factory = factory;
            Categorie = new List<ICategory>();
        }
        public ICategory CreateCategory()
        {
            return Factory.Create();
        }
        public void SaveCategory(ICategory categoria)
        {
            Categorie.Add(categoria);
        }
        public void Delete(int index)
        {
            Categorie.RemoveAt(index);
            //return null;
        }
        public IEnumerable<ICategory> GetCategoria()
        {
            return Categorie;
        }
    }
}
