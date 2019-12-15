using System.Collections.Generic;
using System.Linq;
using Tester.Client.Interfaces;

namespace Tester.Client.Models
{
    public class Response : Response<Product, Category> {}
    public abstract class Response<TProduct, TCategory> : IResponse<TProduct, TCategory>
        where TProduct : Product
        where TCategory : Category
    {
        public IEnumerable<TProduct> Products { get; set; }
        public IEnumerable<TCategory> Categories { get; set; }

        public IEnumerable<Result> GetResult()
        {
            return from pr in Products
                   join ct in Categories on pr.CategoryId equals ct.Id
                   select new Result
                   {
                       Product = pr.Name,
                       Category = ct.Name                       
                   };
        }

        public void RemoveDuplicated()
        {
            Products = Products.Distinct();
            Categories = Categories.Distinct();
        }
    }
}
