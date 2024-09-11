using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBINDA_MAYO_PROJECT
{
    internal class Account_Creation
    {
        private static int currentOption = 0;
        public static void CreatorScreen()
        {
            Console.Clear();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Program.Logo();
                DisplayMenu();
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentOption > 0)
                        {
                            currentOption--;
                            Console.Clear();
                            Program.Logo();
                            DisplayMenu();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentOption < 1)
                        {
                            currentOption++;
                            Console.Clear();
                            Program.Logo();
                            DisplayMenu();
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (currentOption == 0)
                        {
                            CreateAccount();
                        }
                        else if (currentOption == 1)
                        {
                            exit = true;
                        }
                        break;
                }
            }
        }
        public static void DisplayMenu()
        {
            if (currentOption == 0)
            {
                Console.WriteLine("  > Create Account");
                Console.WriteLine("    Exit");
            }
            else if (currentOption == 1)
            {
                Console.WriteLine("    Create Account");
                Console.WriteLine("  > Exit");
            }
        }

        public static void CreateAccount()
        {
            string LastName, FirstName, MiddleName, Address, City;
            float InitialDeposit;
            Console.Clear();
            Program.Logo();
            Console.Write("  Create Account Loading");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
            }
            do
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter Last Name: ");
                Console.Write("  ");
                LastName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(LastName));

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter First Name: ");
                Console.Write("  ");
                FirstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    break;
                }
                Console.WriteLine("  Invalid input. First Name cannot be empty.");
                Thread.Sleep(1000);
            }

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter Middle Name (N/A if none): ");
                Console.Write("  ");
                MiddleName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(MiddleName))
                {
                    break;
                }
                Console.WriteLine("  Invalid input. Middle Name cannot be empty.");
                Thread.Sleep(1000);
            }

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter Address: ");
                Console.Write("  ");
                Address = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(Address))
                {
                    break;
                }
                Console.WriteLine("  Invalid input. Address cannot be empty.");
                Thread.Sleep(1000);
            }

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter City: ");
                Console.Write("  ");
                City = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(City))
                {
                    break;
                }
                Console.WriteLine("  Invalid input. City cannot be empty.");
                Thread.Sleep(1000);
            }

            
            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter Initial Deposit (Minimum $100): ");
                Console.Write("  ");
                InitialDeposit = float.Parse(Console.ReadLine());
                if (InitialDeposit >= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  Invalid input. Deposit must be at least $100.");
                    Thread.Sleep(1000);
                }
            }

            int pin;
            string pinInput;
            string confirmPinInput;

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter a 4-6 digit PIN: ");
                Console.Write("  ");
                pinInput = Console.ReadLine();

                if (int.TryParse(pinInput, out pin) && pinInput.Length >= 4 && pinInput.Length <= 6)
                {
                    Console.Clear();
                    Program.Logo();
                    Console.Write("  Confirm PIN: ");
                    Console.Write("  ");
                    confirmPinInput = Console.ReadLine();

                    if (int.TryParse(pinInput, out pin) && pinInput.Length >= 4 && pinInput.Length <= 6 && pinInput == confirmPinInput)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("  Invalid PIN combination or PINs do not match. Enter a 4-6 digit PIN.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("  Invalid PIN combination. Enter a 4-6 digit PIN.");
                    Thread.Sleep(1000);
                }
            }

            string membershipInput;
            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Are you a bank member? (yes/no): ");
                Console.Write("  ");
                membershipInput = Console.ReadLine().ToLower();
                if (membershipInput == "yes" || membershipInput == "no")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  Invalid input. Please enter 'yes' or 'no'.");
                    Thread.Sleep(1000);
                }
            }

            bool isBankMember = membershipInput == "yes";

            int accountNumber = Account.GenerateAccountNumber();
            int debitCardNumber = Account.GenerateDebitCardNumber();
            bool islocked = false;
            SaveAccountToFile(LastName, FirstName, MiddleName, Address, City, InitialDeposit, pin, isBankMember, islocked, accountNumber, debitCardNumber);
        }

        public static string GetFullName(string LastName, string FirstName, string MiddleName)
        {
            if (MiddleName == "N/A" || MiddleName == "n/a")
            {
                return $"{FirstName} {LastName}";
            }
            else
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
        public static void SaveAccountToFile(string lastname, string firstname, string middlename, string address, string city, float initialDeposit, int pin, bool isBankMember, bool islocked, int accountNumber, int debitCardNumber)
        {
            string path = "files/clients.txt";
            string bankMemberStr = isBankMember.ToString();
            string fullName = GetFullName(lastname,firstname, middlename);
            string clientData = $"{fullName},{address},{city},{initialDeposit},{pin},{bankMemberStr},{islocked},{accountNumber},{debitCardNumber}";

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(clientData);
                }
            }
            else
            {
                File.AppendAllText(path, clientData + Environment.NewLine, Encoding.UTF8);
            }

            Console.Clear();
            Program.Logo();
            Console.WriteLine("  Account created successfully!");
            Console.WriteLine($"  Account Name: {fullName}");
            Console.WriteLine($"  Account Address: {address}, {city}");
            Console.WriteLine($"  Initial Deposit: {initialDeposit}");
            Console.WriteLine($"  Account Number: {accountNumber}");
            Console.WriteLine($"  Debit Card Number: {debitCardNumber}");
            Console.WriteLine("  Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}