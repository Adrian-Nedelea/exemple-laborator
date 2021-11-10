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
            var listOfGrades = ReadListOfShoppingCarts().ToArray();
            Operatiicos command = new(listOfGrades);
            var result = workflow.Execute(command, (productCode) => true);

            result.Match(
                    whenShoppingCartsPaidFailedEvent: @event =>
                    {
                        Console.WriteLine($"Pay failed: {@event.Reason}");
                        return @event;
                    },
                    whenShoppingCartsPaidScucceededEvent: @event =>
                    {
                        Console.WriteLine($"Pay succeeded.");
                        Console.WriteLine(@event.Csv);
                        return @event;
                    }
                );

            Console.WriteLine("Hello World!");
        }

        private static List<CosGol> ReadListOfShoppingCarts()
        {
            List<CosGol> listOfShoppingCarts = new();
            do
            {
                //read registration number and grade and create a list of greads
                var cantitate = ReadValue("Cantitatea produsului comandat: ");
                if (string.IsNullOrEmpty(cantitate))
                {
                    break;
                }
                var cod_produs = ReadValue("Codul produsului: ");
                if (string.IsNullOrEmpty(cod_produs))
                {
                    break;
                }

                var adresa = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(adresa))
                {
                    break;
                }

                var pret = ReadValue("Pretul: ");
                if (string.IsNullOrEmpty(pret))
                {
                    break;
                }

                listOfShoppingCarts.Add(new(cod_produs, cantitate, adresa, pret));
            } while (true);
            return listOfShoppingCarts;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
