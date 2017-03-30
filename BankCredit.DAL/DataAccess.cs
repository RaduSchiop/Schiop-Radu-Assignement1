using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using BankCredit.Models;
using MySql.Data.MySqlClient;

namespace BankCredit.DAL
{
    public class DataAccess
    {
        private string connString;

        public DataAccess()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public User GetUser(string userName)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Users where UserName=\""+ userName +"\";";
                
                MySqlCommand cmd = new MySqlCommand(statement,conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    {
                        User user = new User();
                        user.ID = reader.GetInt32("Id");
                        user.UserName = reader.GetString("UserName");
                        user.Password = reader.GetString("Password");
                        user.firstName = reader.GetString("FirstName");
                        user.lastName = reader.GetString("LastName");
                        user.IsAdmin = reader.GetBoolean("isAdmin");
                        user.DateOfBirth = reader.GetDateTime("DateOfBirth");

                        return user;
                    }
                }
            }

            return null;
        }

        public void AddUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Users(UserName, Password, FirstName, LastName, IsAdmin, DateOfBirth) VALUES(@username, @password, @firstname, @lastname, @isadmin, @dateofbirth)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.firstName);
                cmd.Parameters.AddWithValue("@lastname", user.lastName);
                cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@dateofbirth", user.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM  Users Where UserName=@name";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@name", user.UserName);


                cmd.ExecuteNonQuery();
            }

        }
        // UPDATE USER
        public void UpDateUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE  Users SET  FirstName=@firstname, LastName=@lastname, IsAdmin=@isadmin, DateOfBirth=dateofbirth WHERE UserName=@UserName";
             

                cmd.Parameters.AddWithValue("@username", user.UserName);
               // cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.firstName);
                cmd.Parameters.AddWithValue("@lastname", user.lastName);
                cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@dateofbirth", user.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public Product verif(Order ord) {

            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string statement = "SELECT * FROM product WHERE title = @titleProduct";

                    MySqlCommand cmd = new MySqlCommand(statement, conn);
                    cmd.Parameters.AddWithValue("@titleProduct", ord.titleProduct);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Product prod = new Product();

                    if (reader.Read())
                    {
                        prod.ID = reader.GetInt32("id");
                        prod.title = reader.GetString("title");
                        prod.description = reader.GetString("description");
                        prod.color = reader.GetString("color");
                        prod.size = reader.GetString("size");
                        prod.price = reader.GetInt32("price");
                        prod.stok = reader.GetInt32("stok");
                    }
                    return prod;
                }
            }


            
        }

        public void AddOrder(Order ord)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                



                        // ADAUGAREA COMENZII
                        conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

      cmd.CommandText = "INSERT INTO bankcredit.order(id, costumer, adress,delivery, status,titleProduct,nrBucati,pretulTotal) VALUES(@id, @costumer, @adress,@delivery, @status,@titleProduct,@nrBucati,@pretulTotal)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", ord.Id);
                cmd.Parameters.AddWithValue("@costumer", ord.Costumer);
                cmd.Parameters.AddWithValue("@adress", ord.Address);
                cmd.Parameters.AddWithValue("@delivery", ord.delivery);
               
                cmd.Parameters.AddWithValue("@status", ord.Status);

                cmd.Parameters.AddWithValue("@nrBucati", ord.nrBucati);

                cmd.Parameters.AddWithValue("@titleProduct", ord.titleProduct);
                cmd.Parameters.AddWithValue("@pretulTotal", ord.pretulTotal);
                cmd.ExecuteNonQuery();
            }


        }
        public void UpDateOrder(Order ord)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {


                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE bankcredit.order SET  costumer=@costumer, adress=@adress,delivery=@delivery, status=@status, titleProduct=@titleProduct, nrBucati=@nrBucati, pretulTotal=@pretulTotal WHERE id=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", ord.Id);
                cmd.Parameters.AddWithValue("@costumer", ord.Costumer);
                cmd.Parameters.AddWithValue("@adress", ord.Address);
                  cmd.Parameters.AddWithValue("@delivery", ord.delivery);
              //  cmd.Parameters.AddWithValue("@delivery", null);
                cmd.Parameters.AddWithValue("@status", ord.Status);
                cmd.Parameters.AddWithValue("@titleProduct", ord.titleProduct);
                cmd.Parameters.AddWithValue("@nrBucati",ord.nrBucati);
                cmd.Parameters.AddWithValue("@pretulTotal", ord.pretulTotal);
                cmd.ExecuteNonQuery();
            }
        }
        public void AddProduct(Product prd) {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {


                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Product(id, title, description,color, size,price,stok) VALUES(@id, @title, @description,@color, @size,@price,@stok)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", prd.ID);
                cmd.Parameters.AddWithValue("@title", prd.title);
                cmd.Parameters.AddWithValue("@description", prd.description);
                cmd.Parameters.AddWithValue("@color", prd.color);
                cmd.Parameters.AddWithValue("@size", prd.size);
                cmd.Parameters.AddWithValue("@price", prd.price);
                cmd.Parameters.AddWithValue("@stok", prd.stok);
                cmd.ExecuteNonQuery();
            }



        }
        public void UpDateProduct(Product prd)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {


                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE  Product SET title= @title, description = @description, color=@color,size=@size,price=@price,stok=@stok  WHERE id=@id";
                
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", prd.ID);
                cmd.Parameters.AddWithValue("@title", prd.title);
                cmd.Parameters.AddWithValue("@description", prd.description);
                cmd.Parameters.AddWithValue("@color", prd.color);
                cmd.Parameters.AddWithValue("@size", prd.size);
                cmd.Parameters.AddWithValue("@price", prd.price);
                cmd.Parameters.AddWithValue("@stok", prd.stok);

                cmd.ExecuteNonQuery();
            }



        }
        public void DeleteProduct(Product prd)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {


                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                 cmd.CommandText = "DELETE FROM product WHERE title=@title";
                cmd.Prepare();

                  cmd.Parameters.AddWithValue("@title", prd.title);
                
                 cmd.ExecuteNonQuery();
            }



        }
        public IList<Order> listOrder()
        {

            IList<Order> list = new List<Order>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM bankcredit.order";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order li = new Order();
                        li.Id = reader.GetInt32("id");
                        li.Costumer = reader.GetString("costumer");
                        li.Address = reader.GetString("adress");
                        li.delivery = reader.GetDateTime("delivery");
                        li.Status = reader.GetString("status");
                        li.titleProduct = reader.GetString("titleProduct");
                        li.nrBucati = reader.GetInt32("nrBucati");
                        li.pretulTotal = reader.GetInt32("pretulTotal");
                        list.Add(li);
                    }
                }
            }
            return list;
        }

        public IList<Product> listProduct()
        {

            IList<Product> list = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Product";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product li = new Product();
                        li.ID = reader.GetInt32("id");
                        li.title = reader.GetString("title");
                        li.description = reader.GetString("description");
                        li.color = reader.GetString("color");
                        li.size = reader.GetString("size");
                        li.price = reader.GetInt32("price");
                        li.stok = reader.GetInt32("stok");
                        list.Add(li);
                    }
                }
            }
            return list;
        }




        public IList<Account> GetAccountsForUser(int userID)
        {
            IList<Account> creditList = new List<Account>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Accounts where userid="+ userID + "; ";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Account credit = new Account();
                        credit.ID = reader.GetInt32("Id");
                        credit.Number = reader.GetString("Number");
                        credit.Value = reader.GetDouble("Value");
                        creditList.Add(credit);
                    }
                }
            }

            return creditList;
        }
    }
}
