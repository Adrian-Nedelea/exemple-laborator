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
        public record CosGoll(IReadOnlyCollection<CosGol>Cos):ICos;

        public record CosInvalidat(IReadOnlyCollection<CosInvalid> Cos,string cauza) : ICos;

        public record CosValidat(IReadOnlyCollection<CosValid> Cos) : ICos;

        public record PlatesteCoss(IReadOnlyCollection<CosValid> Cos ,DateTime Data) : ICos;


    }
}
