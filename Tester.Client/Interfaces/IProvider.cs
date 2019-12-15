using Tester.Client.Models;

namespace Tester.Client.Interfaces
{
    public interface IProvider<TProduct, TCategory>
        where TProduct : Product
        where TCategory : Category
    {
        IResponse<TProduct, TCategory> GetResponse();
    }
}
