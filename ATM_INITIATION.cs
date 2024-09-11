using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ALBINDA_MAYO_PROJECT
{
    internal class ATM_INITIATION
    {
        static List<CardHolder> Cards = new List<CardHolder>();

        public static void InsertCardScreen()
        {
            Program.Logo();
            Console.Write("  Please insert your card: ");
            Console.Write("  ");
            string cardNumber = Console.ReadLine();

            bool isValidCardNumber = false;
            CardHolder cardHolder = null;

            while (!isValidCardNumber)
            {
                cardHolder = Cards.Find(c => c.Account.DebitCardNumber.ToString() == cardNumber);

                if (cardHolder != null)
                {
                    isValidCardNumber = true;
                    Console.WriteLine("  Card number accepted.");
                    ATM ATM = new ATM(cardHolder);
                    System.Threading.Thread.Sleep(2000);

                    ATM.MenuScreen();
                }
                else
                {
                    Console.WriteLine("  Invalid card number. Please try again.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    Program.Logo();
                    Console.Write("  Please insert your card: ");
                    Console.Write("  ");
                    cardNumber = Console.ReadLine();

                }
            }
        }

        public static void UpdateFile()
        {
            string path = "files/clients.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var cardHolder in Cards)
                {
                    string clientData = $"{cardHolder.GetFullName()},{cardHolder.Address},{cardHolder.City},{cardHolder.Account.Balance},{cardHolder.Account.Pin},{cardHolder.Account.BankMember},{cardHolder.Account.IsLocked}, {cardHolder.Account.AccountNumber}, {cardHolder.Account.DebitCardNumber}";
                    sw.WriteLine(clientData);
                }
            }
        }

        public static void ImportData()
        {
            
            string[] lines = File.ReadAllLines("files/clients.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                string fullName = data[0];
                string address = data[1];
                string city = data[2];
                int balance = int.Parse(data[3]);
                int pin = int.Parse(data[4]);
                bool isBankmember = bool.Parse(data[5]);
                bool islocked = bool.Parse(data[6]);
                int accountNumber = int.Parse(data[7]);
                int cardNumber = int.Parse(data[8]);

                CardHolder cardHolder = new CardHolder(fullName, address, city, balance, pin, isBankmember, islocked, accountNumber, cardNumber);
                Cards.Add(cardHolder);
            }
            Console.Write("Importing data");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
            }
            Console.Clear();
            InsertCardScreen();
        }
    }
}