using System;

namespace Tradusquare.Patcher.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string consoleVersion = typeof(Program).Assembly.GetName().Version.ToString();
            Console.WriteLine($"Console version: {consoleVersion}");

            string libVersion = Tradusquare.Patcher.LibVersion.GetVersion();
            Console.WriteLine($"Library version: {libVersion}");
        }
    }
}
