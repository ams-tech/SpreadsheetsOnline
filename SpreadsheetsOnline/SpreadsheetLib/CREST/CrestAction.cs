using SpreadsheetLib.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetLib.CREST
{
    public abstract class CrestAction
    {
        public ConsoleFunction ExecuteInConsole;
        protected abstract string menu_text
        {
            get;
        }

        protected abstract void _ExecuteInConsole(IConsole console);

        public CrestAction()
        {
            ConsoleFunction.CallbackDelegate cb = new ConsoleFunction.CallbackDelegate(_ExecuteInConsole);
            ExecuteInConsole = new ConsoleFunction(menu_text, cb);
        }
    }
}
