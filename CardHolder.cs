using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBINDA_MAYO_PROJECT
{
    internal class CardHolder
    {
        // REPRESENTS THE LAST NAME OF THE CARD HOLDER
        public string LastName { get; set; }

        // REPRESENTS THE FIRST NAME OF THE CARD HOLDER
        public string FirstName { get; set; }

        // REPRESENTS THE MIDDLE INITIAL OF THE CARD HOLDER
        public string MiddleInitial { get; set; }

        // REPRESENTS THE ADDRESS OF THE CARD HOLDER
        public string Address { get; set; }

        // REPRESENTS THE CITY OF THE CARD HOLDER
        public string City { get; set; }

        // REPRESENTS THE ACCOUNT ASSOCIATED WITH THE CARD HOLDER
        public Account Account { get; set; }

        // CONSTRUCTOR FOR CARDHOLDER CLASS WITH ALL PARAMETERS
        public CardHolder(string lastName, string firstName, string middleInitial, string address, string city, float initialDeposit, int pin, bool bankmember, bool islocked, int accountnumber, int debitcardnumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = middleInitial;
            Address = address;
            City = city;
            Account = new Account(accountnumber, debitcardnumber, initialDeposit, pin, bankmember, islocked);
        }

        // CONSTRUCTOR FOR CARDHOLDER CLASS WITHOUT MIDDLE INITIAL
        public CardHolder(string lastName, string firstName, string address, string city, float initialDeposit, int pin, bool bankmember, bool islocked, int accountnumber, int debitcardnumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = "";
            Address = address;
            City = city;
            Account = new Account(accountnumber, debitcardnumber, initialDeposit, pin, bankmember, islocked);
        }

        // CONSTRUCTOR FOR CARDHOLDER CLASS WITH ONLY LAST NAME, FIRST NAME, ADDRESS, CITY, INITIAL DEPOSIT, AND PIN
        public CardHolder(string lastName, string firstName, string address, string city, float initialDeposit, int pin)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = "";
            Address = address;
            City = city;
            Account = new Account(initialDeposit, pin);
        }

        // CONSTRUCTOR FOR CARDHOLDER CLASS WITH FULL NAME AS A SINGLE STRING
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

        // RETURNS THE FULL NAME OF THE CARD HOLDER
        public string GetFullName()
        {
            if (MiddleInitial == null)
                return FirstName + " " + LastName;
            else
                return FirstName + " " + MiddleInitial + " " + LastName;
        }

        // RETURNS THE FULL ADDRESS OF THE CARD HOLDER
        public string GetFullAddress()
        {
            return Address + ", " + City;
        }
    }
}
