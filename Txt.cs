using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory1
{
    public class Txt : WriteGeneral
    {
        public override void write(IList<Raport> raport)
        {

            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\\Users\\Radu1\\Desktop\\PS\\BankCreditMaster\\TXT.txt"))
            {
                foreach (Raport regi in raport)
                {
                    file.Write(" " + regi.id);
                    file.Write("  " + regi.nume);
                    file.WriteLine("  " + regi.activitate);
                    file.Write("  " + regi.data);
                   

                }
            }



        }
    }
}