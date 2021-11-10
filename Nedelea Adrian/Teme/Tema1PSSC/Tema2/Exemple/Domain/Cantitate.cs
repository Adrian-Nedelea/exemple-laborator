using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record Cantitate
    {
        public int Value { get; }

        public Cantitate(int value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new CantitateInvalida($"{value} is an invalid quantity value.");
            }
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public static bool TryParse(string stringcantitate, out Cantitate cantitate)
        {
            bool isValid = false;
            cantitate = null;
            if (int.TryParse(stringcantitate, out int cantitatenumerica))
            {
                if (IsValid(cantitatenumerica))
                {
                    isValid = true;
                   cantitate = new(cantitatenumerica);
                }
            }

            return isValid;
        }

        private static bool IsValid(int cantitatenumerica) => cantitatenumerica > 0;
    }
}
