using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib;

namespace SpreadsheetLib.Console
{
    public class ConsoleFunction
    {
        string _menu_text = "Undefined";
        public delegate string CallbackDelegate();

        CallbackDelegate callback = null;

        public virtual string menu_text
        {
            get { return _menu_text; }
            set { }
        }
        
        public virtual string Execute()
        {
            if (callback == null)
                throw new NotImplementedException("Callback delegate not defined for this entry");
            else
                return callback();
        }

        public ConsoleFunction(string menu_entry_text)
        {
            _menu_text = menu_entry_text;
        }

        public ConsoleFunction(string menu_entry_text, CallbackDelegate callback_delegate)
        {
            _menu_text = menu_entry_text;
            callback = callback_delegate;
        }

        public ConsoleFunction() { }
    }
}
