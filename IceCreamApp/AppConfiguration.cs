using System.Configuration;

namespace IceCreamShop.Entities
{
    public interface IAppConfiguration
    {
        string DefaultConnectionString { get;  }
    }
    public class AppConfiguration : IAppConfiguration
    {
        public AppConfiguration()
        {
            DefaultConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        public string DefaultConnectionString { get; private set; }
    }
}