using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBINDA_MAYO_PROJECT
{
    internal class Program
    {
        //METHOD USED IN DISPLAYING THE LOGO
        public static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("       &&&&&&&&&&&&&&   &&&&&&&&&&&&&   ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(",,,,,,,,,,,,,  ,,,,,        ,,,,,       \r\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("       &&&&       &&&&& &&&&      &&&&&");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(",,,,,           ,,,,,,,    ,,,,,,,       \r\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("       &&&&       &&&&  &&&&        *&&&");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(",,,,,,,,,,,,   ,, ,,,,,.,,,, ,,,,       \r\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("       &&&&*&&&&&&&&&&& &&&&         &&&&    ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(",,,,,,,,, ,,   ,,,,,,   ,,,,       \r\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("       &&&&         &&&&&&&&         &&&&         ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(",,,,,,,     ,,     ,,,,       \r\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("       &&&&         &&&&&&&&       &&&");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(",,,         ,,,,,,,            ,,,,       \r\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("       &&&&&&&&&&&&&&&& &&&&&&&&&&&&&& ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(",,,,,,,,,,,,,,  ,,            ,,,,       \r\n");
            Console.ResetColor();
            Console.WriteLine("           Property of Banco De Sentral Mindanao. All rights reserved.");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
        }

        //METHOD USED IN PROGRAM NAVIGATION
        public void DisplayOptions()
        {
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
                            ATM_INITIATION.ImportData();
                            ATM_INITIATION.InsertCardScreen();
                        }
                        else
                        {
                            Console.Clear();
                            Account_Creation.CreatorScreen();
                        }
                        break;
                }
            } while (navigationKey.Key != ConsoleKey.Enter);
        }

        //METHOD USED IN DISPLAYING PROGRAM NAVIGATION
        public static void UpdateOptions(int selectedOption)
        {
            if (selectedOption == 1)
            {
                Console.Clear();
                Logo();
                Console.WriteLine("  > Insert Card");
                Console.WriteLine("    Create Account");
            }
            else
            {
                Console.Clear();
                Logo();
                Console.WriteLine("    Insert Card");
                Console.WriteLine("  > Create Account");
            }
        }

        //MAIN METHOD
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "ATM";
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 30);
            Console.Clear();
            Logo();
            Console.WriteLine("  Welcome to ATM");
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Logo();
            Program program = new Program();
            program.DisplayOptions();
        }
    }
}