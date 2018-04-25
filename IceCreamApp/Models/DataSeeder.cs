 
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using IceCreamApp.DataAccess;
using IceCreamApp.Models; 

namespace IceCreamShop.Repositories
{
    public class DataSeeder
    {
        public async Task EnsureSeedData(IceCreamDbContext context)
        {
    

            context.IceCreams.RemoveRange(context.IceCreams); 
            context.Stores.RemoveRange(context.Stores);
            context.Addresses.RemoveRange(context.Addresses);
            context.States.RemoveRange(context.States);
            context.Countries.RemoveRange(context.Countries);

            context.SaveChanges();
 
            CreateStates(context);
            CreateCountries(context);
            await context.SaveChangesAsync();


            var iceCreams =  CreateIceCreams(context);
            await CreateStores(context, iceCreams);

            await context.SaveChangesAsync();

        }

        private void CreateStates(IceCreamDbContext context)
        {

            context.States.Add(CreateState("AL", "Alabama"));
            context.States.Add(CreateState("AK", "Alaska"));
            context.States.Add(CreateState("AZ", "Arizona"));
            context.States.Add(CreateState("AR", "Arkansas"));
            context.States.Add(CreateState("CA", "California"));
            context.States.Add(CreateState("CO", "Colorado"));
            context.States.Add(CreateState("CT", "Connecticut"));
            context.States.Add(CreateState("DE", "Delaware"));
            context.States.Add(CreateState("DC", "District Of Columbia"));
            context.States.Add(CreateState("FL", "Florida"));
            context.States.Add(CreateState("GA", "Georgia"));
            context.States.Add(CreateState("HI", "Hawaii"));
            context.States.Add(CreateState("ID", "Idaho"));
            context.States.Add(CreateState("IL", "Illinois"));
            context.States.Add(CreateState("IN", "Indiana"));
            context.States.Add(CreateState("IA", "Iowa"));
            context.States.Add(CreateState("KS", "Kansas"));
            context.States.Add(CreateState("KY", "Kentucky"));
            context.States.Add(CreateState("LA", "Louisiana"));
            context.States.Add(CreateState("ME", "Maine"));
            context.States.Add(CreateState("MD", "Maryland"));
            context.States.Add(CreateState("MA", "Massachusetts"));
            context.States.Add(CreateState("MI", "Michigan"));
            context.States.Add(CreateState("MN", "Minnesota"));
            context.States.Add(CreateState("MS", "Mississippi"));
            context.States.Add(CreateState("MO", "Missouri"));
            context.States.Add(CreateState("MT", "Montana"));
            context.States.Add(CreateState("NE", "Nebraska"));
            context.States.Add(CreateState("NV", "Nevada"));
            context.States.Add(CreateState("NH", "New Hampshire"));
            context.States.Add(CreateState("NJ", "New Jersey"));
            context.States.Add(CreateState("NM", "New Mexico"));
            context.States.Add(CreateState("NY", "New York"));
            context.States.Add(CreateState("NC", "North Carolina"));
            context.States.Add(CreateState("ND", "North Dakota"));
            context.States.Add(CreateState("OH", "Ohio"));
            context.States.Add(CreateState("OK", "Oklahoma"));
            context.States.Add(CreateState("OR", "Oregon"));
            context.States.Add(CreateState("PA", "Pennsylvania"));
            context.States.Add(CreateState("RI", "Rhode Island"));
            context.States.Add(CreateState("SC", "South Carolina"));
            context.States.Add(CreateState("SD", "South Dakota"));
            context.States.Add(CreateState("TN", "Tennessee"));
            context.States.Add(CreateState("TX", "Texas"));
            context.States.Add(CreateState("UT", "Utah"));
            context.States.Add(CreateState("VT", "Vermont"));
            context.States.Add(CreateState("VA", "Virginia"));
            context.States.Add(CreateState("WA", "Washington"));
            context.States.Add(CreateState("WV", "West Virginia"));
            context.States.Add(CreateState("WI", "Wisconsin"));
            context.States.Add(CreateState("WY", "Wyoming"));

        }
        private State CreateState(string abbreviation, string name)
        {
            State state = new State();
            state.Name = name;
            state.Abbreviation = abbreviation;
            return state;
        }

        private void CreateCountries(IceCreamDbContext context)
        {
            context.Countries.Add(new Country { Name = "United States", Code = "US" });
            context.Countries.Add(new Country { Name = "Canada", Code = "CA" });
            context.Countries.Add(new Country { Name = "Mexico", Code = "MX" });
        }

        private List<IceCream> CreateIceCreams(IceCreamDbContext context)
        {
            var list = new List<IceCream>();
          
            list.Add(CreateIceCream("Chocolate", "chocolate.jpg", .5));
            list.Add(CreateIceCream("Vanilla", "vanilla.jpg", .5));
            list.Add(CreateIceCream("Strawberry", "strawberry.png", .75));
            list.Add(CreateIceCream("Neapolitan", "neapolitan.png", 1));
            list.Add(CreateIceCream("Cherry Amaretto", "Cherry_Amaretto.png", .5));

            context.IceCreams.AddRange(list);

            return list;
        }

        private IceCream CreateIceCream(string name, string link, double creationCost)
        {
            IceCream cream = new IceCream();
            cream.Name = name;
            cream.CreationCost = creationCost;
            cream.ImageLink = link;
            return cream;
        }

        private async Task CreateStores(IceCreamDbContext context, List<IceCream> iceCreams)
        {
            Store store = new Store();
            store.Address = await CreateAddress("123 Easy Street", "75240", "TX", "US", context);
            store.StoreName = "Bert's Easy Shop";
            store.ManagerName = "Big Bert";
            store.Phone = "214-222-4239";
            store.OperationalStatus = "OFFLINE";

            context.Stores.Add(store);


            Store store2 = new Store();
            store2.Address = await CreateAddress("456 Periwinkle Ave", "75240", "TX", "US", context);
            store2.StoreName = "Yummy Treats";
            store2.ManagerName = "Mrs. Jones";
            store2.Phone = "214-241-7568";
            store2.OperationalStatus = "Online";

            context.Stores.Add(store2);


            Store store3 = new Store();
            store3.Address = await CreateAddress("4020 Apple Pie Way", "75240", "TX", "US", context);
            store3.StoreName = "Grannies Corner";
            store3.ManagerName = "Gran Baker";
            store3.Phone = "972-226-2139";
            store3.OperationalStatus = "Online";

            context.Stores.Add(store3);


            Store store4 = new Store();
            store4.Address = await CreateAddress("100 6th Street", "75240", "TX", "US", context);
            store4.StoreName = "Swirly Q";
            store4.ManagerName = "Sam Adams";
            store4.Phone = "817-321-9962";
            store4.OperationalStatus = "Online";

            context.Stores.Add(store4);



            Store store5 = new Store();

            store5.Address = await CreateAddress("989 City Dump way", "75240", "TX", "US", context);
            store5.StoreName = "Chocolate Cow Pies";
            store5.ManagerName = "Count Olaf";
            store5.Phone = "214-310-6000";
            store5.OperationalStatus = "Online";

            context.Stores.Add(store5);

            context.SaveChanges();

            await CreateStock(store, iceCreams);
            await CreateStock(store2, iceCreams);
            await CreateStock(store3, iceCreams);
            await CreateStock(store4, iceCreams);
            await CreateStock(store5, iceCreams);

        }

        private async Task CreateStock(Store store, List<IceCream> iceCreams)
        { 

          
//            store.InStock = new Stock();
//            store.InStock.Store = store;
//            store.InStock.StoreId = store.Id;

            foreach (var iceCream in iceCreams)
            {
                store.IceCreams.Add(iceCream);
            } 
        }

        private async Task<Address> CreateAddress(string line1, string zip, string state, string country, IceCreamDbContext context)
        {
            Address address = new Address();
            address.Line1 = line1;
            address.ZipCode = zip;
            address.State = await context.States.FirstOrDefaultAsync(x => x.Abbreviation == state);
            address.Country = await context.Countries.FirstOrDefaultAsync(x => x.Code == country);

            return address;
        }

    }
}