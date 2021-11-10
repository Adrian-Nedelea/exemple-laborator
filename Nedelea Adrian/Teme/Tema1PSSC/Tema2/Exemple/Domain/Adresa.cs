using System.Text.RegularExpressions;

namespace Exemple.Domain

{
    public record Adresa
    {
        private static readonly Regex ValidPattern = new("^.*$");

        public string adresa { get; }

        public Adresa(string adresaa)
        {
            if (ValidPattern.IsMatch(adresaa))
            {
                adresa = adresaa;
            }
            else
            {
                throw new AdresaInvalida("");
            }
        }

        public override string ToString()
        {
            return adresa;
        }
        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

        public static bool TryParse(string stringAdresa, out Adresa adresa)
        {
            bool isValid = false;
            adresa = null;
            if (IsValid(stringAdresa))
            {
                isValid = true;
               adresa = new(stringAdresa);
            }
            return isValid;
        }

    }
}
