using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record Pret
    {
        public decimal Value { get; }

        public Pret(decimal value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new PretInvalid($"{value:0.##} is an invalid price value.");
            }
        }

        public static Pret operator *(Pret a, Cantitate b) => new Pret((a.Value * b.Value));

        public Pret Round()
        {
            var roundedValue = Math.Round(Value);
            return new Pret(roundedValue);
        }

        public override string ToString()
        {
            return $"{Value:0.##}";
        }

        public static bool TryParse(string stringpret, out Pret price)
        {
            bool isValid = false;
            price = null;
            if (decimal.TryParse(stringpret, out decimal pretnumeric))
            {
                if (IsValid(pretnumeric))
                {
                    isValid = true;
                    price = new(pretnumeric);
                }
            }

            return isValid;
        }

        private static bool IsValid(decimal pretnumeric) => pretnumeric >= 0;
    }
}
