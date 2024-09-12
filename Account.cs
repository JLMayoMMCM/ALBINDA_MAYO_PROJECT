using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBINDA_MAYO_PROJECT
{
    internal class Account
    {
        public int AccountNumber { get; set; }

        public int DebitCardNumber { get; set; }

        public float Balance { get; set; }

        public int Pin { get; set; }

        public bool IsLocked { get; set; }

        public bool BankMember { get; set; }


        //METHOD USED TO GENERATE RANDOM ACCOUNT NUMBER
        public static int GenerateAccountNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(11111111, 99999999);
            return randomNumber;
        }

        //METHOD USED TO GENERATE RANDOM DEBIT CARD NUMBER
        public static int GenerateDebitCardNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(42010000, 42019999);
            return randomNumber;
        }

        //CONSTRUCTOR FOR ACCOUNT CLASS WITH BASIC PARAMETERS
        public Account(float initialDeposit, int pin)
        {
            AccountNumber = GenerateAccountNumber();
            DebitCardNumber = GenerateDebitCardNumber();
            Balance = initialDeposit;
            Pin = pin;
            IsLocked = false;
            BankMember = true;
        }

        //CONSTRUCTOR FOR ACCOUNT CLASS WITH BASIC PARAMETERS
        public Account(int accountNumber, int debitCardNumber, float balance, int pin)
        {
            AccountNumber = accountNumber;
            DebitCardNumber = debitCardNumber;
            Balance = balance;
            Pin = pin;
            IsLocked = false;
            BankMember = true;
        }

        //CONSTRUCTOR FOR ACCOUNT CLASS WITH ALL PARAMETERS
        public Account(int accountNumber, int debitCardNumber, float balance, int pin, bool bankMember, bool islocked)
        {
            AccountNumber = accountNumber;
            DebitCardNumber = debitCardNumber;
            Balance = balance;
            Pin = pin;
            IsLocked = islocked;
            BankMember = bankMember;
        }



        //METHOD USED TO CHECK IF THE PIN ENTERED IS CORRECT
        public bool pinCheck(int pin)
        {
            if (pin == Pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //METHOD USED TO CHECK IF THE ACCOUNT IS LOCKED
        public bool lockCheck()
        {
            if (IsLocked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //METHOD USED TO LOCK AND UNLOCK THE ACCOUNT
        public void accountLock()
        {
            if (IsLocked == false)
            {
                IsLocked = true;
                ATM_INITIATION.UpdateFile();
                Console.WriteLine("  Account is locked");
            }
            else
            {
                IsLocked = false;
                ATM_INITIATION.UpdateFile();
                Console.WriteLine("  Account is unlocked");
            }
        }

        //METHOD USED TO CHECK THE BALANCE OF THE ACCOUNT
        public float checkBalance()
        {
            return Balance;
        }

        public float changePin(int newPin)
        {
            Pin = newPin;
            return Pin;
        }

        //METHOD USED TO WITHDRAW MONEY FROM THE ACCOUNT
        public bool withdraw(float amount)
        {
            bool withdraw = true;
            if (BankMember == false)
            {
                if (Balance - (amount + 18) < 0)
                {
                    withdraw = false;
                }
                else
                {
                    Balance -= amount + 18;
                }
            }
            else
            {
                if (Balance - amount < 0)
                {
                    withdraw = false;
                }
                else
                {
                    Balance -= amount;
                }
            }
            return withdraw;
        }

        //METHOD USED TO DEPOSIT MONEY TO THE ACCOUNT
        public bool deposit(float amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (BankMember)
            {
                Balance += amount;
            }
            else
            {
                Balance += (amount - 18);
            }
            return true;
        }
    }
}
