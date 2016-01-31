using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetLib.Console;
using System.IO;

namespace ConsoleApp
{
    class ConsoleMenu : ConsoleFunction
    {
        string _menu_header_text = "Generic Menu Text";

        List<ConsoleFunction> entries = new List<ConsoleFunction>();

        public void AddEntry(ConsoleFunction entry)
        {
            entries.Add(entry);
        }

        public override string Execute()
        {
            int x = 1;
            string input;
            int option = -1;

            while (true)
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("*\t" + _menu_header_text);
                Console.WriteLine("****************************************");
                Console.Write("\n\n");
                Console.WriteLine("0 - Return");
                foreach (var entry in entries)
                {
                    Console.WriteLine(x.ToString() + " - " + entry.menu_text);
                }

            
                while (option < 0)
                {
                    Console.Write("Enter Selection: ");
                    try
                    {
                        input = Console.ReadLine();
                    }
                    catch (IOException e)
                    {
                        input = null;
                    }
                    if (input != null)
                    {
                        if (int.TryParse(input, out x))
                        {
                            if ((x >= 0) && (x <= entries.Count()))
                            {
                                option = x;
                                break;
                            }
                        }
                    }
                    Console.WriteLine("\nInvalid selection");
                }

                if (option > 0)
                {
                    Console.Write(entries[option - 1].Execute());
                    option = -1;
                }
                else if (option == 0)
                    break;
            }
            return "";
        }

        public ConsoleMenu(string header_text)
        {
            _menu_header_text = header_text;
        }

        
    }
}
