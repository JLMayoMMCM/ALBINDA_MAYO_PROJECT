using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBINDA_MAYO_PROJECT
{
    internal class ATM
    {
        public CardHolder CurrentUser { get; private set; }
        public CardHolder User { get; set; }
        private int PinAttempts = 0;

        string AmountInput;
        float Amount;

        public ATM(CardHolder user)
        {
            User = user;
        }

        public static void UpdateOptions(int selectedOption)
        {
            if (selectedOption == 1)
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine(" Do you want to do more Transactions?");
                Console.WriteLine("  > Yes");
                Console.WriteLine("    No");
            }
            else
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine(" Do you want to do more Transactions?");
                Console.WriteLine("    Yes");
                Console.WriteLine("  > No");
            }
        }

        public static void UpdateMenu(int selectedOption)
        {
            if (selectedOption == 1)
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│ > Check Balance                                                                 │");
                Console.WriteLine("│   Withdraw                                                                      │");
                Console.WriteLine("│   Deposit                                                                       │");
                Console.WriteLine("│   Pay Bills                                                                     │");
                Console.WriteLine("│   Change Pin                                                                    │");
                Console.WriteLine("│   Eject Card                                                                    │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────┘");
            }
            else if (selectedOption == 2)
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│   Check Balance                                                                 │");
                Console.WriteLine("│ > Withdraw                                                                      │");
                Console.WriteLine("│   Deposit                                                                       │");
                Console.WriteLine("│   Pay Bills                                                                     │");
                Console.WriteLine("│   Change Pin                                                                    │");
                Console.WriteLine("│   Eject Card                                                                    │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────┘");
            }
            else if (selectedOption == 3)
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│   Check Balance                                                                 │");
                Console.WriteLine("│   Withdraw                                                                      │");
                Console.WriteLine("│ > Deposit                                                                       │");
                Console.WriteLine("│   Pay Bills                                                                     │");
                Console.WriteLine("│   Change Pin                                                                    │");
                Console.WriteLine("│   Eject Card                                                                    │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────┘");
            }
            else if (selectedOption == 4)
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│   Check Balance                                                                 │");
                Console.WriteLine("│   Withdraw                                                                      │");
                Console.WriteLine("│   Deposit                                                                       │");
                Console.WriteLine("│ > Pay Bills                                                                     │");
                Console.WriteLine("│   Change Pin                                                                    │");
                Console.WriteLine("│   Eject Card                                                                    │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────|");
            }
            else if (selectedOption == 5)
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│   Check Balance                                                                 │");
                Console.WriteLine("│   Withdraw                                                                      │");
                Console.WriteLine("│   Deposit                                                                       │");
                Console.WriteLine("│   Pay Bills                                                                     │");
                Console.WriteLine("│ > Change Pin                                                                    │");
                Console.WriteLine("│   Eject Card                                                                    │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────|");
            }
            else
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│   Check Balance                                                                 │");
                Console.WriteLine("│   Withdraw                                                                      │");
                Console.WriteLine("│   Deposit                                                                       │");
                Console.WriteLine("│   Pay Bills                                                                     │");
                Console.WriteLine("│   Change Pin                                                                    │");
                Console.WriteLine("│ > Eject Card                                                                    │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────");
            }
        }

        public void PrintBalance()
        {
            Console.Clear();
            Program.Logo();
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("  Bank: BDOO");
            Console.WriteLine($"  Client Name\t\t: {User.GetFullName()}");
            Console.WriteLine($"  Account No\t\t: {HideSensitiveInfo(User.Account.AccountNumber.ToString())}");
            Console.WriteLine($"  Debit Card No\t\t: {HideSensitiveInfo(User.Account.DebitCardNumber.ToString())}");
            Console.WriteLine($"  Current Balance\t: ${User.Account.Balance:F2}");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
        }

        public void PrintWithdraw(float amount, float previousBalance)
        {
            Console.Clear();
            Program.Logo();
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("  Bank: BDOO");
            Console.WriteLine($"  Client Name\t\t: {User.GetFullName()}");
            Console.WriteLine($"  Account No\t\t: {HideSensitiveInfo(User.Account.AccountNumber.ToString())}");
            Console.WriteLine($"  Debit Card No\t\t: {HideSensitiveInfo(User.Account.DebitCardNumber.ToString())}");
            Console.WriteLine($"  Previous Balance\t: ${previousBalance:F2}");
            Console.WriteLine($"  Withdrawn Amount\t: ${amount:F2}");
            Console.WriteLine($"  New Balance\t\t: ${User.Account.Balance:F2}");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
        }

        public void PrintDeposit(float amount, float previousBalance)
        {
            Console.Clear();
            Program.Logo();
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("  Bank: BDOO");
            Console.WriteLine($"  Client Name\t\t: {User.GetFullName()}");
            Console.WriteLine($"  Account No\t\t: {HideSensitiveInfo(User.Account.AccountNumber.ToString())}");
            Console.WriteLine($"  Debit Card No\t\t: {HideSensitiveInfo(User.Account.DebitCardNumber.ToString())}");
            Console.WriteLine($"  Previous Balance\t: ${previousBalance - amount:F2}");
            Console.WriteLine($"  Deposited Amount\t: ${amount:F2}");
            Console.WriteLine($"  New Balance\t\t: ${User.Account.Balance:F2}");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
        }

        public void PrintPayBills(float amount, int receiver)
        {
            Random rand = new Random();
            int transactionNumber = rand.Next(10000000, 99999999);

            Console.Clear();
            Program.Logo();
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("  Bank: BDOO");
            Console.WriteLine($"  Client Name\t\t: {User.GetFullName()}");
            Console.WriteLine($"  Account No\t\t: {HideSensitiveInfo(User.Account.AccountNumber.ToString())}");
            Console.WriteLine($"  Receiver Account No\t: {receiver}");
            Console.WriteLine($"  Reference No\t: {transactionNumber}");
            Console.WriteLine($"  Payment Amount\t: ${amount:F2}");
            Console.WriteLine($"  Current Balance\t: ${User.Account.Balance:F2}");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
        }

        public void PrintDisplay(int option)
        {
            if (option == 1)
            {
                Console.Clear();
                Program.Logo();

                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("|                                                                                 |");
                Console.WriteLine("│ Do you want to to print the receipt?                                            │");
                Console.WriteLine("│ > Yes                                                                           │");
                Console.WriteLine("│   No                                                                            │");
                Console.WriteLine("|                                                                                 |");
                Console.WriteLine("|                                                                                 |");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────┘");
            }
            else
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("|                                                                                 |");
                Console.WriteLine("│ Do you want to to print the receipt?                                            │");
                Console.WriteLine("│   Yes                                                                           │");
                Console.WriteLine("│ > No                                                                            │");
                Console.WriteLine("|                                                                                 |");
                Console.WriteLine("|                                                                                 |");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────┘");
            }
        }
        public bool PinCheck()
        {
            int Attempts = 0;
            while (Attempts < 3)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Please enter your PIN: ");
                string enteredPin = Console.ReadLine();
                if (int.TryParse(enteredPin, out int pin) && User.Account.pinCheck(pin))
                {
                    Console.WriteLine("  PIN is correct.");
                    PinAttempts = 0;
                    return true;
                }
                else
                {
                    Attempts++;
                    PinAttempts++;
                    Console.WriteLine($"  Incorrect PIN. {3 - Attempts} attempts remaining.");
                    Thread.Sleep(2000);
                }
            }
            User.Account.accountLock();
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                 │");
            Console.WriteLine("│   Account is locked due to incorrect PIN attempts.                              │");
            Console.WriteLine("│   To recover, go to the nearest affiliated bank                                 │");
            Console.WriteLine("│                                                                                 │");
            Console.WriteLine("│                                                                                 │");
            Console.WriteLine("│                                                                                 │");
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────┘");
            Thread.Sleep(5000);
            return false;
        }

        public bool IsAccountLocked()
        {
            if (User.Account.lockCheck())
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                                                                                 │");
                Console.WriteLine("│   Account is locked.                                                            │");
                Console.WriteLine("│   To recover, go to the nearest affiliated bank                                 │");
                Console.WriteLine("│                                                                                 │");
                Console.WriteLine("│                                                                                 │");
                Console.WriteLine("│                                                                                 │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────┘");
                Thread.Sleep(5000);
                EjectCard();
                return true;
            }
            return false;
        }

        public bool NonBankMemberTransactionFee()
        {
            if (!User.Account.BankMember)
            {
                Console.Clear();
                Program.Logo();
                Console.WriteLine("A $18 transaction fee will apply. Proceed? (Use arrow keys to choose)");
                Console.WriteLine("> Yes");
                Console.WriteLine("  No");

                bool proceed = false;
                ConsoleKeyInfo navigationKey;
                do
                {
                    navigationKey = Console.ReadKey(true);
                    switch (navigationKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.DownArrow:
                            proceed = !proceed;
                            Console.Clear();
                            Program.Logo();
                            Console.WriteLine("A $18 transaction fee will apply. Proceed? (Use arrow keys to choose)");
                            if (proceed)
                            {
                                Console.WriteLine("  Yes");
                                Console.WriteLine("> No");
                            }
                            else
                            {
                                Console.WriteLine("> Yes");
                                Console.WriteLine("  No");
                            }
                            break;
                        case ConsoleKey.Enter:
                            return proceed;
                    }
                } while (navigationKey.Key != ConsoleKey.Enter);
            }
            return false;
        }

        private string HideSensitiveInfo(string number)
        {
            if (number.Length > 4)
            {
                return new string('*', number.Length - 4) + number[^4..];
            }
            return number;
        }
        
        public bool PrintOptions()
        {
            bool printReceipt = false;
            int options = 1;
            PrintDisplay(options);

            ConsoleKeyInfo optionKey = Console.ReadKey(true);

            do
            {
                optionKey = Console.ReadKey(true);
                switch (optionKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (options - 1 == 0)
                        {
                            options = 2;
                            PrintDisplay(options);
                        }
                        else
                        {
                            options--;
                            PrintDisplay(options);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (options + 1 == 3)
                        {
                            options = 1;
                            PrintDisplay(options);
                        }
                        else
                        {
                            options++;
                            PrintDisplay(options);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (options == 1)
                        {
                            printReceipt = true;
                        }
                        else
                        {
                            printReceipt = false;
                        }
                        break;
                }
            } while (optionKey.Key != ConsoleKey.Enter);

            return printReceipt;
        }

        public void CheckBalance()
        {
            if (IsAccountLocked()) return;

            if (PinCheck())
            {
                if (PrintOptions())
                {
                    PrintBalance();
                    Thread.Sleep(8000);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Program.Logo();
                    Console.WriteLine($"  Your current balance is: {User.Account.Balance}");
                    Thread.Sleep(8000);
                    Console.Clear();
                    
                }

                Program.Logo();
                int selectedOption = 1;
                UpdateOptions(selectedOption);

                ConsoleKeyInfo navigationKey;

                do
                {
                    navigationKey = Console.ReadKey(true);

                    switch (navigationKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedOption = Math.Max(1, selectedOption - 1);
                            UpdateOptions(selectedOption);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedOption = Math.Min(2, selectedOption + 1);
                            UpdateOptions(selectedOption);
                            break;
                        case ConsoleKey.Enter:
                            if (selectedOption == 1)
                            {
                                Console.Clear();
                                MenuScreen();
                            }
                            else
                            {
                                Console.Clear();
                                EjectCard();
                            }
                            break;
                    }
                } while (navigationKey.Key != ConsoleKey.Enter);
            }
            else
            {
                Console.Clear();
                MenuScreen();
            }
        }

        public void Withdraw()
        {
            if (IsAccountLocked()) return;

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter the amount to withdraw: ");
                AmountInput = Console.ReadLine();
                if (float.TryParse(AmountInput, out Amount))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  Invalid amount. Please enter a valid number.");
                    Thread.Sleep(2000);
                }
            }

            if (PinCheck())
            {
                if (NonBankMemberTransactionFee())
                {
                    Console.WriteLine("  Transaction canceled.");
                    Thread.Sleep(2000);
                    EjectCard();
                    return;
                }
                else
                {
                    if (User.Account.withdraw(Amount))
                    {
                        Console.Clear();
                        Program.Logo();
                        Console.WriteLine("  Successful withdrawal.");
                        Thread.Sleep(4000);
                        ATM_INITIATION.UpdateFile();
                        if (PrintOptions())
                        {
                            Console.Clear();
                            Program.Logo();
                            PrintWithdraw(Amount, User.Account.Balance + Amount);
                            Thread.Sleep(5000);
                            EjectCard();
                        }
                        else
                        {
                            Console.Clear();
                            Program.Logo();
                            Console.WriteLine($"  You withdrew {Amount}. Your new balance is: {User.Account.Balance}");
                            Thread.Sleep(5000);
                            EjectCard();
                        }
                    }
                    else
                    {
                        Console.WriteLine("  Withdrawal failed. Insuffecient Balance.");
                        Thread.Sleep(2000);
                        EjectCard();
                    }
                }
            }
        }

        public void Deposit()
        {
            if (IsAccountLocked()) return;

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter the amount to Deposit: ");
                AmountInput = Console.ReadLine();
                if (float.TryParse(AmountInput, out Amount) && Amount > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  Invalid amount. Please enter a positive number.");
                    Thread.Sleep(2000);
                }
            }

            if (PinCheck())
            {
                if (NonBankMemberTransactionFee())
                {
                    Console.WriteLine(" Transaction canceled.");
                    Thread.Sleep(2000);
                    EjectCard();
                    return;
                }
                else
                {
                    if (User.Account.deposit(Amount))
                    {
                        Console.Clear();
                        Program.Logo();
                        Console.WriteLine("  Successful Deposit.");

                        ATM_INITIATION.UpdateFile();

                        Thread.Sleep(4000);
                        if (PrintOptions())
                        {
                            PrintDeposit(Amount, User.Account.Balance);
                            Thread.Sleep(5000);
                            EjectCard();
                        }
                        else
                        {
                            Console.WriteLine($"You deposited {Amount}. Your new balance is: {User.Account.Balance}");
                            Thread.Sleep(5000);
                            EjectCard();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Deposit failed. Please try again.");
                        Thread.Sleep(2000);
                    }
                }
            }
        }

        public void PayBills()
        {
            if (IsAccountLocked()) return;
            string AccountInput;
            int AccountNumber;
            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter the amount to pay: ");
                AmountInput = Console.ReadLine();
                if (float.TryParse(AmountInput, out Amount))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  Invalid amount. Please enter a valid number.");
                    Thread.Sleep(2000);
                }
            }

            while (true)
            {
                Console.Clear();
                Program.Logo();
                Console.Write("  Enter Account Number: ");
                AccountInput = Console.ReadLine();
                
                if (int.TryParse(AccountInput, out AccountNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  Invalid amount. Please enter a valid number.");
                    Thread.Sleep(2000);
                }
            }

            if (PinCheck())
            {
                if (NonBankMemberTransactionFee())
                {
                    Console.WriteLine("  Transaction canceled.");
                    Thread.Sleep(2000);
                    EjectCard();
                    return;
                }
                else
                {
                    bool proceed = false;
                    do
                    {
                        ConsoleKeyInfo NavigationKey = Console.ReadKey(true);
                        switch (NavigationKey.Key)
                        {
                            case ConsoleKey.UpArrow:
                            case ConsoleKey.DownArrow:
                                proceed = !proceed;
                                Console.Clear();
                                Program.Logo();
                                Console.WriteLine("  A $18 transaction fee will apply. Proceed? (Use arrow keys to choose)");
                                if (proceed)
                                {
                                    Console.WriteLine("    Yes");
                                    Console.WriteLine("  > No");
                                }
                                else
                                {
                                    Console.WriteLine("  > Yes");
                                    Console.WriteLine("    No");
                                }
                                break;
                            case ConsoleKey.Enter:
                                proceed = !proceed;
                                break;
                        }
                    } while (!proceed);

                    if (User.Account.withdraw(Amount))
                    {
                        Console.Clear();
                        Program.Logo();
                        Console.WriteLine("  Successful withdrawal.");
                        Thread.Sleep(4000);
                        ATM_INITIATION.UpdateFile();
                        if (PrintOptions())
                        {
                            Console.Clear();
                            Program.Logo();
                            PrintPayBills(Amount, AccountNumber);
                            Thread.Sleep(5000);
                            EjectCard();
                        }
                        else
                        {
                            Console.Clear();
                            Program.Logo();
                            Console.WriteLine($"  You withdrew {Amount}. Your new balance is: {User.Account.Balance}");
                            Thread.Sleep(5000);
                            EjectCard();
                        }
                    }
                    else
                    {
                        Console.WriteLine("  Withdrawal failed. Insufficient Balance.");
                        Thread.Sleep(2000);
                        EjectCard();
                    }
                }
            }
        }

        public void ChangePin()
        {
            if (IsAccountLocked()) return;
            else
            {
                while (true)
                {
                    Console.Clear();
                    Program.Logo();
                    Console.Write("  Enter your current PIN: ");
                    string currentPin = Console.ReadLine();
                    if (currentPin is null || !int.TryParse(currentPin, out int pin) || !User.Account.pinCheck(pin))
                    {
                        Console.WriteLine("  Incorrect PIN. Please try again.");
                        continue;
                    }

                    string pinInput;
                    string confirmPinInput;

                    Console.Clear();
                    Program.Logo();
                    Console.Write("  Enter new 4-6 digit PIN: ");
                    Console.Write("  ");
                    pinInput = Console.ReadLine();

                    if (pinInput is null || !int.TryParse(pinInput, out pin) || pinInput.Length < 4 || pinInput.Length > 6)
                    {
                        Console.WriteLine("  Invalid PIN combination. Enter a 4-6 digit PIN.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    Console.Clear();
                    Program.Logo();
                    Console.Write("  Confirm PIN: ");
                    Console.Write("  ");
                    confirmPinInput = Console.ReadLine();

                    if (confirmPinInput is null || !int.TryParse(confirmPinInput, out pin) || confirmPinInput.Length < 4 || confirmPinInput.Length > 6 || pinInput != confirmPinInput)
                    {
                        Console.WriteLine("  Invalid PIN combination or PINs do not match. Enter a new 4-6 digit PIN.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    User.Account.changePin(pin);
                    Console.Clear();
                    Program.Logo();
                    Console.WriteLine("  PIN successfully changed.");
                    ATM_INITIATION.UpdateFile();
                    Thread.Sleep(3000);
                    EjectCard();
                }
            }
        }

        public void EjectCard()
        {
            Console.Clear();
            Program.Logo();
            Console.WriteLine("  Thank you for using our ATM. Please take your card.");
            Thread.Sleep(4000);
            Console.Clear();
            ATM_INITIATION.InsertCardScreen();
        }

        public void MenuScreen()
        {
            int SelectedOption = 1;
            UpdateMenu(SelectedOption);

            ConsoleKeyInfo navigationKey;

            do
            {
                navigationKey = Console.ReadKey(true);

                switch (navigationKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (SelectedOption - 1 == 0)
                        {
                            SelectedOption = 6;
                            UpdateMenu(SelectedOption);
                        }
                        else
                        {
                            SelectedOption--;
                            UpdateMenu(SelectedOption);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedOption + 1 == 7)
                        {
                            SelectedOption = 1;
                            UpdateMenu(SelectedOption);
                        }
                        else
                        {
                            SelectedOption++;
                            UpdateMenu(SelectedOption);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (IsAccountLocked())
                        {
                            IsAccountLocked();
                            Thread.Sleep(2000);
                            EjectCard();
                        }
                        else
                        {
                            if (SelectedOption == 1)
                                CheckBalance();
                            else if (SelectedOption == 2)
                                Withdraw();
                            else if (SelectedOption == 3)
                                Deposit();
                            else if (SelectedOption == 4)
                                PayBills();
                            else if (SelectedOption == 5)
                                ChangePin();
                            else
                                EjectCard();
                        }
                        break;
                    default:
                        break;
                }
            } while (navigationKey.Key != ConsoleKey.Enter);
        }
    }
}
