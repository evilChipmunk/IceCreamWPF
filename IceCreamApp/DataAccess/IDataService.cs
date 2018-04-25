using System.Collections.Generic;
using System.Threading.Tasks;
using IceCreamApp.Models;

namespace IceCreamApp.DataAccess
{
    public interface IDataService
    {
        Task<List<IceCream>> GetIceCreamsAsync();
        Task<IceCream> SaveIceCreamAsync(IceCream iceCream);


        List<IceCream> GetIceCreams();

        List<Store> GetStores();
        Task<List<Store>> GetStoresAsync();
        Store GetStoreById(long id);
        Store SaveStore(Store store);
        IceCream GetIceCreamById(long id);
    }
}