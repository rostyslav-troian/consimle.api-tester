using System.Collections;
using System.Collections.Generic;
using Tester.Client.Models;

namespace Tester.Client.Interfaces
{
    public interface IResponse<TProduct, TCategory>
        where TProduct : Product
        where TCategory : Category
    {
        IEnumerable<TProduct> Products { get; }
        IEnumerable<TCategory> Categories { get; }
        void RemoveDuplicated();

        IEnumerable<Result> GetResult();
    }
}
