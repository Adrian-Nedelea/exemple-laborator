using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record Cantitate
    {
        public int cantitatee { get; }

        public Cantitate(int cantitate)
        {
            if(cantitate>0)
            {
                cantitatee = cantitate;
            }
            else
            {
                throw new CantitateInvalida($"{cantitate} nu se poate");
            }
        }
        public override string ToString()
        {
            return cantitatee.ToString();
        }
    }
   
}
