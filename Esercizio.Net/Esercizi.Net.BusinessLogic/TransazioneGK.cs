using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.BusinessLogic
{
    public class TransazioneGK : Transazione
    {
        private decimal _avere;
        public decimal Avere
        {
            get
            {
                return _avere;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Il valore deve essere positivo.");
                }

                _avere = value;
            }
        }

        private decimal _dare;
        public decimal Dare
        {
            get
            {
                return _dare;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Il valore deve essere positivo.");
                }

                _dare = value;
            }
        }

        public override decimal Importo
        {
            get
            {
                return Avere - Dare;
            }
            set
            {
                if (value < 0)
                {
                    Dare = value * -1;
                }
                else
                {
                    Avere = value;
                }
            }
        }
    }
}
