using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory1
{
    public class ConcretFactory
    {
        public WriteGeneral get(Boolean ok) {

          

            if (ok)
            {
               return new Xml();
            }
            else
            {
                return  new Txt();
            }

          

        }
    }
}
