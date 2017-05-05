using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.BL
{
   public interface IPresenter
    {
        User Login(string userName, string password);


        void AddUser(User user);

        void DeleteUser(User user);


        void UpDateUser(User user);

        Product verif(Order ord);

        void AddOrder(Order ord, String nume);

        void UpDateOrder(Order ord, String nume);

        void AddProduct(Product prd, String nume);

        void UpDateProduct(Product prd, String nume);

        void DeleteProduct(Product prd, String nume);


        IList<Order> listOrder();


        IList<Product> listProduct();

        IList<Raport> generateRaport();

        IList<Account> GetAccountsForUser(int userId);
    }   
}
