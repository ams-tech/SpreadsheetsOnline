using System.Linq;
using SpreadsheetLib.Console;
using eZet.EveLib.EveCrestModule;

namespace SpreadsheetLib.CREST
{
    public class Regions
    {
        public ConsoleFunction PrintAllRegions;

        public string GetAllRegions(IConsole console)
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

            return retval;
        }

        public Regions()
        {
            ConsoleFunction.CallbackDelegate cb = new ConsoleFunction.CallbackDelegate(GetAllRegions);
            PrintAllRegions = new ConsoleFunction("Print all regions", cb);
        }

    }
}
