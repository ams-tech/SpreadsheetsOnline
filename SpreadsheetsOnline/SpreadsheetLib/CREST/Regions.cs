using System.Linq;
using SpreadsheetLib.Console;
using eZet.EveLib.EveCrestModule;
using System;

namespace SpreadsheetLib.CREST
{
    public class Regions : CrestAction
    {
        protected override string menu_text
        {
            get
            {
                return "Print all regions";
            }
        }

        protected override void _ExecuteInConsole(IConsole console)
        {
            string retval = "";
            EveCrest crest = new EveCrest();

            var regions = crest.GetRoot().Query(r => r.Regions);
            var list = regions.Items.ToList();
            foreach (var region in list)
            {
                retval += region.Name;
                retval += "\n";
            }

            console.Write(retval);
        }
    }
}
