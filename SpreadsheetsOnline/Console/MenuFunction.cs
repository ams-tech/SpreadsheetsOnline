using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class MenuFunction
    {
        public virtual string MENU_TEXT
        {
            get { return "Undefined"; }
            set { }
        }

        public virtual void Execute()
        {
            Console.WriteLine("Not implemened");
        }
    }
}
