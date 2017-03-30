using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public IList<Account> Accounts { get; set; }

        //non bindable attribute
        public string firstName;
        //non bindable attribute
        public string lastName;

        //bindable property
        public string FullName
        {
            get
            { return firstName + " " + lastName; }
        }

        public int age;

        public DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                    dateOfBirth = value;
                    age = DateTime.Today.Year - dateOfBirth.Year;
            }
        }

    }
}
