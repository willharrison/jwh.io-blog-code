using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            var directories = Directory.GetDirectories(Directory.GetCurrentDirectory()); 
            
            foreach(var dir in directories)
            {
                Console.WriteLine(dir); //list the directories in the current directory
            }
            
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
