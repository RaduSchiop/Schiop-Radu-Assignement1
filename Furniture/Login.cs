using BankCredit.BL;
//using WindowsFormsApp1;
using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace BankCredit
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserOperations bl = new UserOperations();

            User user = bl.Login(txtUser.Text, txtPassword.Text);

            if (user.IsAdmin)
            {
                Admin adminForm = new Admin();
                adminForm.Show();
            }
            else if(!(user.IsAdmin))
            {

                idProduct1 fereastra = new idProduct1();
                fereastra.Show();

                // Accounts accountsForm = new Accounts();
                //accountsForm.user = user;
                //fereastra.Show();
                //accountsForm.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
