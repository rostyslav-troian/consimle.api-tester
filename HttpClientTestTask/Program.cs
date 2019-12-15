using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;


namespace HttpClientTestTask
{
    class Program
    {
        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string CategoryId { get; set; }

            public override bool Equals(object _obj)
            {
                var obj = _obj as Product;
                return obj != null && Id == obj.Id;
            }

            public override int GetHashCode() => Id == null ? 0 : Id.GetHashCode() + Name.GetHashCode() + CategoryId.GetHashCode();
        }
        public class Category
        {
            public string Id { get; set; }
            public string Name { get; set; }

            public override bool Equals(object _obj)
            {
                var obj = _obj as Category;
                return obj != null && Id == obj.Id;
            }
            public override int GetHashCode() => Id == null ? 0 : Id.GetHashCode() + Name.GetHashCode();
        }
        public class Model
        {
            public List<Product> Products = new List<Product>();
            public List<Category> Categories = new List<Category>();

            internal void DeleteDuplicateData()
            {
                Products = Products.Distinct().ToList();
                Categories = Categories.Distinct().ToList();
            }
        }

        static void Main(string[] args)
        {         
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://tester.consimple.pro");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                while (ShowConsoleMenu()) 
                {
                    Console.WriteLine("Process is started!");
                    //Task task = Task.Run(() => RunAsync(client));
                    RunQueryAsync(client).GetAwaiter().GetResult();
                    Console.WriteLine("Process is finished!\n\n");
                }
            }
        }

        static void ShowData(Model model)
        {            
            Console.WriteLine("\n-----------------------------------------------------");
            Console.WriteLine("|{0,-30}|{1,-20}|", "Product name", "Category name");
            Console.WriteLine("-----------------------------------------------------");
            foreach (var value in model.Products)
            {
                Console.WriteLine("|{0,-30}|{1,-20}|", value.Name, model.Categories.Find(x => x.Id == value.CategoryId).Name);
            }
            Console.WriteLine("-----------------------------------------------------\n");
        }
        static async Task RunQueryAsync(HttpClient client)
        {
            try
            {
                Model model = await GetDataAsync("", client);
                model.DeleteDuplicateData();
                ShowData(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static async Task<Model> GetDataAsync(string path, HttpClient client)
        {
            Model model = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<Model>();  
            }
            return model;
        }
        static bool ShowConsoleMenu()
        {
            Console.WriteLine("To send a 'GET' request press [any key] \nPress [esc] to exit");
            var key = Console.ReadKey();
            return (key.Key == ConsoleKey.Escape)? false : true;
        }
    }
}
