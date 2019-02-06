using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public class CategoryFactory : ICategoryFactory
    {
        public ICategory Create()
        {
            return new Categoria();
        }
    }
}
