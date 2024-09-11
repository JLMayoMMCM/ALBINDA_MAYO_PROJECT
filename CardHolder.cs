using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBINDA_MAYO_PROJECT
{
    internal class CardHolder
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public Account Account { get; set; }

        public CardHolder(string lastName, string firstName, string middleInitial, string address, string city, float initialDeposit, int pin, bool bankmember, bool islocked, int accountnumber, int debitcardnumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = middleInitial;
            Address = address;
            City = city;
            Account = new Account(accountnumber, debitcardnumber, initialDeposit, pin, bankmember, islocked);
        }

        public CardHolder(string lastName, string firstName, string middleInitial, string address, string city, float initialDeposit, int pin)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = middleInitial;
            Address = address;
            City = city;
            Account = new Account(initialDeposit, pin);
        }

        public CardHolder(string lastName, string firstName, string address, string city, float initialDeposit, int pin, bool bankmember, bool islocked, int accountnumber, int debitcardnumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = "";
            Address = address;
            City = city;
            Account = new Account(accountnumber, debitcardnumber, initialDeposit, pin, bankmember, islocked);
        }

        public CardHolder(string lastName, string firstName, string address, string city, float initialDeposit, int pin)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = "";
            Address = address;
            City = city;
            Account = new Account(initialDeposit, pin);
        }

        public CardHolder(string fullName, string address, string city, float initialDeposit, int pin, bool bankmember, bool islocked, int accountnumber, int debitcardnumber)
        {
            string[] names = fullName.Split(' ');
            if (names.Length == 2)
            {
                LastName = names[1];
                FirstName = names[0].Replace("_", " "); ;
                MiddleInitial = "";
            }
            else
            {
                LastName = names[2];
                FirstName = names[0].Replace("_", " "); ;
                MiddleInitial = names[1];
            }
            Address = address;
            City = city;
            Account = new Account(accountnumber, debitcardnumber, initialDeposit, pin, bankmember, islocked);
        }


        public string GetFullName()
        {
            if (MiddleInitial == null)
                return FirstName + " " + LastName;
            else
                return FirstName + " " + MiddleInitial + " " + LastName;
        }

        public string GetFullAddress()
        {
            return Address + ", " + City;
        }
    }
}
