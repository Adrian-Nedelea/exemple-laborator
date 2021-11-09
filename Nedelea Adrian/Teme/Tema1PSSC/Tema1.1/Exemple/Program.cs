using Exemple.Domain;
using System;
using System.Collections.Generic;
using static Exemple.Domain.Cos;

namespace Exemple
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfCosuri = ReadListOfCosuri().ToArray();
            CosGoll cosGoll = new(listOfCosuri);
            ICos result = CosValidat(cosGoll);
            result.Match(
                whenCosGoll: emptyResult => cosGoll,
                whenCosInvalidat: unvalitedResult => unvalitedResult,
                whenPlatesteCoss: paidResult => paidResult,
                whenCosValidat: validatedResult => PlatesteeCos(validatedResult)
            );

            Console.WriteLine("Hello World!");
        }

        private static List<CosGol> ReadListOfCosuri()
        {
            List <CosGol> listOfGrades = new();
            do
            {
                //read registration number and grade and create a list of greads
                var cantitate = ReadValue("Cantitatea produsului: ");
                if (string.IsNullOrEmpty(cantitate))
                {
                    break;
                }

                var codprodus = ReadValue("Codul produslui: ");
                if (string.IsNullOrEmpty(codprodus))
                {
                    break;
                }
                var adresa = ReadValue("Adresa:");
                if(string.IsNullOrEmpty(adresa))
                {
                    break;
                }

                listOfGrades.Add(new (cantitate ,codprodus,adresa));
            } while (true);
            return listOfGrades;
        }

        private static ICos CosValidat(CosGoll cosgol) =>
            random.Next(100) > 50 ?
            new CosInvalidat(new List<CosInvalid>(), "Random errror")
            : new CosValidat(new List<CosValid>());

        private static ICos PlatesteeCos(CosValid cosvalid) =>
            new PlatesteCoss(new List<CosValid>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
