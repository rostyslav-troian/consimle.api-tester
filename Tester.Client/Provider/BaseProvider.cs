using Tester.Client.Interfaces;
using Tester.Client.Models;

namespace Tester.Client.Provider
{
    public abstract class BaseProvider<TProduct, TCategory> : IProvider<TProduct, TCategory>
        where TProduct : Product
        where TCategory : Category
    {
        public abstract IResponse<TProduct, TCategory> GetResponse();
    }
}
