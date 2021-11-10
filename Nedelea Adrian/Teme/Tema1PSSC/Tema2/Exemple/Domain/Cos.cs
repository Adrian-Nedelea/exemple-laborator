using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Choices;


namespace Exemple.Domain
{
    [AsChoice]
    public static partial class Cos
    {
        public interface ICos { }
        public record CosGoll(IReadOnlyCollection<CosGol> Cos) : ICos
        {
            public CosGoll(IReadOnlyCollection<CosGol> shoppingCartList)
            {
                ShoppingCartList = shoppingCartList;
            }

            public IReadOnlyCollection<CosGol> ShoppingCartList { get; }
        }


        public record CosInvalidat(IReadOnlyCollection<CosInvalid> Cos, string cauza) : ICos
        {
            internal CosInvalidat(IReadOnlyCollection<CosGol> shoppingCartList, string reason)
            {
                ShoppingCartList = shoppingCartList;
                Reason = reason;
            }

            public IReadOnlyCollection<CosGol> ShoppingCartList { get; }
            public string Reason { get; }
        }

        public record CosValidat(IReadOnlyCollection<CosValid> Cos) : ICos
        { 
            internal CosValidat(IReadOnlyCollection<CosValid> shoppingCartList)
            {
                ShoppingCartList = shoppingCartList;
            }

            public IReadOnlyCollection<CosValid> ShoppingCartList { get; }
        }
        public record PlatesteCoss(IReadOnlyCollection<CosValid> Cos ,DateTime Data) : ICos
        {
            internal PlatesteCoss(IReadOnlyCollection<CalculCos> shoppingCartsList, string csv, DateTime publishedDate)
            {
                ShoppingCartList = shoppingCartsList;
                PublishedDate = publishedDate;
                Csv = csv;
            }

            public IReadOnlyCollection<CalculCos> ShoppingCartList { get; }
            public DateTime PublishedDate { get; }
            public string Csv { get; }
        }

        public record CalculCoss(IReadOnlyCollection<CosValid> Cos ) :ICos
        {
            internal CalculCoss(IReadOnlyCollection<CalculCos> shoppingCartList)
            {
                ShoppingCartList = shoppingCartList;
            }

            public IReadOnlyCollection<CalculCos> ShoppingCartList { get; }
        }
    }
}
