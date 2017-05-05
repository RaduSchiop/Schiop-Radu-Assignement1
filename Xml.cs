using System;
using System.Collections.Generic;
using System.Text;
using BankCredit.Models;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;
namespace Factory1
{
  public  class Xml: WriteGeneral
    {
        public override void write(IList<Raport> raport)
        {
            try
            {
                var xEle = new XElement("Activitati",
                            from rap in raport
                            select new XElement("Registration",
                                         new XAttribute("id", rap.id),
                                           new XElement("Nume", rap.nume),
                                           new XElement("Activitate", rap.activitate),
                                           new XElement("Data", rap.data)
                                       ));
                xEle.Save("C:\\Users\\Radu1\\Desktop\\PS\\BankCreditMaster\\XML.xml");
                Console.WriteLine("Converted to XML");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
