using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetLib.Console;
using System.IO;

namespace ConsoleApp
{
    public class ConsoleMenu : ConsoleFunction
    {
        string _menu_header_text = "Generic Menu Text";

        List<ConsoleFunction> entries = new List<ConsoleFunction>();

        public void AddEntry(ConsoleFunction entry)
        {
            entries.Add(entry);
        }

        public override string Execute(IConsole console)
        {
            int x = 1;
            string input;
            int option = -1;

            while (true)
            {
                console.WriteLine("****************************************");
                console.WriteLine("*\t" + _menu_header_text);
                console.WriteLine("****************************************");
                console.Write("\n\n");
                console.WriteLine("0 - Return");
                foreach (var entry in entries)
                {
                    console.WriteLine(x.ToString() + " - " + entry.menu_text);
                }

            
                while (option < 0)
                {
                    console.Write("Enter Selection: ");
                    try
                    {
                        input = console.ReadLine();
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
                    console.WriteLine("\nInvalid selection");
                }

                if (option > 0)
                {
                    console.Write(entries[option - 1].Execute(console));
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
