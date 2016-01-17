using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using SpreadsheetLib.CREST;

namespace ConsoleApp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            ConsoleMenu main = new ConsoleMenu("Main Menu");
            Regions regions = new Regions();
            main.AddEntry(regions.PrintAllRegions);

            main.Execute();
        }
    }
}
