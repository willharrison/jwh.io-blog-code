using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            var shell = new Shell();
            shell.Run();
        }
    }

    public class Shell
    {
        private Dictionary<string, string> Aliases = new Dictionary<string, string>
        {
            { "ls", @".\ListDirectories.exe" },
            { "clear", @".\Clear.exe" }
        };

        public void Run()
        {
            string input = null;

            do
            {
                Console.Write("$ ");
                input = Console.ReadLine();
                Execute(input);
            } while (input != "exit");
        }

        public int Execute(string input)
        {
            if (Aliases.Keys.Contains(input))
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo(Aliases[input])
                {
                    UseShellExecute = false
                };

                process.Start();
                process.WaitForExit();

                return 0;
            }

            Console.WriteLine($"{input} not found");
            return 1;
        }
    }
}
