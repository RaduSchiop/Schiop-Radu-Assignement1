using System;
using System.Collections.Generic;
using System.Text;
using BankCredit.Models;

namespace Factory1
{
   public abstract class WriteGeneral
    {
       public  abstract void write(IList<Raport> raport);
    }
}

