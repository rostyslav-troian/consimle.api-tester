using System;
using Tester.Client.Provider;

namespace Tester.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new RestProvider("https://tester.consimple.pro");
            while (DialogManager.ShowConsoleMenu())
            {
                Console.WriteLine("Process is started!");
                var response = provider.GetResponse();
                response.RemoveDuplicated();
                var result = response.GetResult();
                DialogManager.ShowData(result);
                Console.WriteLine("Process is finished!\n\n");
            }
        }        
    }
}
