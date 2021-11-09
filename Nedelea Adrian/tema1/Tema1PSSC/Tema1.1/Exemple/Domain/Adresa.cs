using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exemple.Domain
{
    public record Adresa
    {
        private static readonly Regex AdresaOk = new("{strada,numar}");

        public string adresaa { get; }
        private Adresa(string adresa)
        {
            if (AdresaOk.IsMatch(adresa))
            {
                adresaa = adresa;
            }
            else
            {
                throw new AdresaInvalida("");
            }
        }
        public override string ToString()
        {
            return adresaa;
        }
    }
 }