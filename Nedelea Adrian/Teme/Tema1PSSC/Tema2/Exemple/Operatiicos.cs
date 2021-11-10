using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exemple.Domain.Cos;


namespace Exemple.Domain
{
    public static class ShoppingCartsOperations
    {
        public static ICos CosValid(Func<CodProdus, bool> checkProductExists, CosGoll shoppingCarts)
        {
            List<CosValidat> validatedShoppingCarts = new();
            bool isValidList = true;
            string invalidReson = string.Empty;
            foreach (var CosGol in shoppingCarts.ShoppingCartList)
            {
                if (!CodProdus.TryParse(CosGol.CodProdus, out CodProdus codProdus))
                {
                    invalidReson = $"Invalid product code ({CosGol.CodProdus})";
                    isValidList = false;
                    break;
                }
                if (!Cantitate.TryParse(CosGol.Cantitate, out Cantitate cantitate))
                {
                    invalidReson = $"Invalid quantity ({CosGol.CodProdus}, {CosGol.Cantitate})";
                    isValidList = false;
                    break;
                }
                if (!Adresa.TryParse(CosGol.Adresa, out Adresa adresa))
                {
                    invalidReson = $"Invalid address ({CosGol.CodProdus}, {CosGol.Adresa})";
                    isValidList = false;
                    break;
                }
                if (!Pret.TryParse(CosGol.pret , out Pret pret))
                {
                    invalidReson = $"Invalid price ({CosGol.CodProdus}, {CosGol.pret})";
                    isValidList = false;
                    break;
                }
                CosValid cosValidat = new(CodProdus, Cantitate, adresa, pret);
                cosValidat.Add(CosValid);
            }

            if (isValidList)
            {
                return new CosValidat(validatedShoppingCarts);
            }
            else
            {
                return new CosInvalidat(shoppingCarts.ShoppingCartList, invalidReson);
            }

        }

        public static ICos CalculateFinalPrice(ICos cos) => cos.Match(
            whenCosGoll: CosGol => CosGol,
            whenCosInvalidat: CosInvalid => CosInvalid,
            whenCalculCoss: CalculCos => CalculCos,
            whenPlatesteCoss: PlatesteCos => PlatesteCos,
            whenCosValid: Cosvalidat =>
            {
                var calculatedGrade = Cosvalidat.ShoppingCartList.Select(CosValid =>
                                            new CalculCos(CosValid.productCode,
                                                                      CosValid.cantitate,
                                                                     CosValid.adresa,
                                                                      CosValid.pret,
                                                                      CosValid.price * CosValid.cantitate));
                return new Calculcoss(calculatedGrade.ToList().AsReadOnly());
            }
        );

        

    }
}
