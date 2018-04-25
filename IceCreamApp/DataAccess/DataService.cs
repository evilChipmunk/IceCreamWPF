using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using IceCreamApp.Models;

namespace IceCreamApp.DataAccess
{
    public class DataService : IDataService
    {
        private readonly IceCreamDbContext context;

        public DataService(IceCreamDbContext context)
        {
            this.context = context;
        }

        public async Task<List<IceCream>> GetIceCreamsAsync()
        { 
            return await context.IceCreams.ToListAsync();
        }

        public async Task<IceCream> SaveIceCreamAsync(IceCream iceCream)
        {  
            await context.SaveChangesAsync();
            return iceCream;
        }

        public List<IceCream> GetIceCreams()
        {
            return context.IceCreams.ToList();
        }

        public List<Store> GetStores()
        {
            return context.Stores.ToList();
        }


        public async Task<List<Store>> GetStoresAsync()
        {
            return await context.Stores.ToListAsync();
        }

        public Store GetStoreById(long id)
        {
            return context.Stores.First(x => x.Id == id);
        }

        public Store SaveStore(Store store)
        { 
            context.SaveChanges();
            return store;
        }

        public IceCream GetIceCreamById(long id)
        {
            return context.IceCreams.First(x => x.Id == id);
        }
    }
}