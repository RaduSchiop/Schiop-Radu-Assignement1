using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankCredit.DAL;
using BankCredit.Models;
using System.Configuration;
//using BankCredit;

namespace BankCredit.BL
{
    public class UserOperations
    {
        public User Login(string userName, string password)
        {
            DataAccess dal = new DataAccess();
            User user = dal.GetUser(userName);
            if (user!=null)
            {
                Security secure = new Security();
                if(secure.VerifyHash(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUser(User user)
        {
            Security secure = new Security();
            user.Password = secure.HashSHA1(user.Password);

            DataAccess dal = new DataAccess();
            dal.AddUser(user);
        }
        public void DeleteUser(User user) {
            Security secure = new Security();
            user.Password = secure.HashSHA1(user.Password);

            DataAccess dal = new DataAccess();
            dal.DeleteUser(user);

        }

        public void UpDateUser(User user)
        {
            Security secure = new Security();
            user.Password = secure.HashSHA1(user.Password);

            DataAccess dal = new DataAccess();
            dal.UpDateUser(user);

        }
        public Product verif(Order ord) {
            DataAccess dal = new DataAccess();


            return dal.verif(ord);
        }
        public void AddOrder(Order ord) {
            DataAccess dal = new DataAccess();
            dal.AddOrder(ord);
        }
        public void UpDateOrder(Order ord) {
            DataAccess dal = new DataAccess();
            dal.UpDateOrder(ord);

        }
        public void AddProduct(Product prd) {
            DataAccess dal = new DataAccess();
           dal.AddProduct(prd);


        }
        public void UpDateProduct(Product prd) {
            DataAccess dal = new DataAccess();
            dal.UpDateProduct(prd);

        }
        public void DeleteProduct(Product prd) {
            DataAccess dal = new DataAccess();
            dal.DeleteProduct(prd);
        }

        public IList<Order> listOrder()
        {
            DataAccess dal = new DataAccess();
            
            IList<Order> lista = new List<Order>();
            lista = dal.listOrder();

            return lista;
                
        }

        public IList<Product> listProduct()
        {
            DataAccess dal = new DataAccess();

            IList<Product> lista = new List<Product>();
            lista = dal.listProduct();

            return lista;

        }

        public IList<Account> GetAccountsForUser(int userId)
        {
            DataAccess dal = new DataAccess();
            return dal.GetAccountsForUser(userId);
        }
    }
}
