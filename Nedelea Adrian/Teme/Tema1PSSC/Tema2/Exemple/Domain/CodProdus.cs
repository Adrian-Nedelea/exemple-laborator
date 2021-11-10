using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record CodProdus
    {
        private static readonly Regex ValidPattern = new("^.*$");

        public string Code { get; }

        public CodProdus(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Code = value;
            }
            else
            {
                throw new ProdusInvalid("");
            }
        }

        public override string ToString()
        {
            return Code;
        }

        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

        public static bool TryParse(string stringCod, out CodProdus codProdus)
        {
            bool isValid = false;
           codProdus = null;
            if (IsValid(stringCod))
            {
                isValid = true;
                codProdus= new(stringCod);
            }
            return isValid;
        }
    }
}