using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using SpreadsheetLib.CREST;
using SpreadsheetLib.Console;

namespace ConsoleApp
{
    class Program
    {
        class MyConsole : IConsole
        {
            public void Write(string message)
            {
                Console.Write(message);
            }

            public void WriteLine(string message)
            {
                Console.WriteLine(message);
            }

            public string ReadLine()
            {
                return Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            ConsoleMenu main = new ConsoleMenu("Main Menu");
            Regions regions = new Regions();
            main.AddEntry(regions.ExecuteInConsole);

            main.Execute(new MyConsole());
        }
    }
}
