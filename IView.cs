using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankCredit.BL;
namespace Furniture
{
    interface IView
    {
         User informatiiUser();
        Order RetrieveOrderInformation();
         Product RetriveProductINformation();
        IPresenter ob { get; set; }
    }
}
