using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;
using System.IO;
using SpreadsheetLib.Console;
using System.Collections.Generic;

namespace SpreadsheetTest
{
    [TestClass]
    public class ConsoleTest
    {
        public class TestConsole : IConsole
        {
            List<string> InputLines = new List<string>();
            List<string> OutputLines = new List<string>();

            public bool OutputContains(string search)
            {
                foreach (var s in OutputLines)
                {
                    if (s.Contains(search))
                        return true;
                }
                return false;
            }

            public void AddInputLine(string line)
            {
                InputLines.Add(line);
            }

            public string GetOutputLine()
            {
                if (OutputLines.Count <= 0)
                    return null;

                string retval = OutputLines[0];
                OutputLines.RemoveAt(0);
                return retval;
            }

            public TestConsole() { }

            public TestConsole(List<string> input)
            {
                InputLines = input;
            }

            public string ReadLine()
            {
                if (InputLines.Count <= 0)
                {
                    return "";
                }
                string retval = InputLines[0];
                InputLines.RemoveAt(0);
                return retval;
            }

            public void Write(string message)
            {
                WriteLine(message);
            }

            public void WriteLine(string message)
            {
                OutputLines.Add(message);
            }
        }

        [TestMethod]
        public void ConsoleMenu_WhenExecuted_ShouldDisplayHeaderText()
        {
            string header_text = "This is the test header text 123455543321";
            TestConsole console = new TestConsole();
            // Pass a 0 to make the execution stop
            console.AddInputLine("0");
            ConsoleMenu menu = new ConsoleMenu(header_text);
            menu.Execute(console);
            Assert.IsTrue(console.OutputContains(header_text));
        }
    }
}
