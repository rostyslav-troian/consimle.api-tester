using System;
using System.Collections.Generic;
using Tester.Client.Models;

namespace Tester.UI
{
    public static class DialogManager
    {
        public static void ShowData(IEnumerable<Result> result)
        {
            var line = new string('-', 63);

            Console.WriteLine(line);
            Console.WriteLine($"|{"Product name",-30}|{"Category name",-30}|");
            Console.WriteLine(line);
            foreach (var value in result)
            {
                Console.WriteLine($"|{value.Product,-30}|{value.Category,-30}|");
            }
            Console.WriteLine(line);
        }

        public static bool ShowConsoleMenu()
        {
            Console.WriteLine("To send a 'GET' request press [any key] \nPress [esc] to exit");
            var key = Console.ReadKey();
            return (key.Key == ConsoleKey.Escape) ? false : true;
        }
    }
}
