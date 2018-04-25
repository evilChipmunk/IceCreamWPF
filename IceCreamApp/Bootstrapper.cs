using System;
using IceCreamApp.DataAccess;
using IceCreamApp.ViewModels;
using IceCreamApp.ViewModels.IceCream;
using IceCreamApp.ViewModels.Store;
using IceCreamShop.Entities;
using IceCreamShop.Repositories;
using Prism.Events;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Lifestyles;

namespace IceCreamApp
{
    public class Bootstrapper
    {

        public static IEventAggregator EventAggregator { get; set; }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container.Register<IEventAggregator, EventAggregator>(Lifestyle.Singleton);


            // Register your types, for instance:
            container.Register<IDataService, DataService>(Lifestyle.Transient);

            // Register your windows and view models:
            container.Register<MainWindow>();
            container.Register<MainViewModel>();


            container.Register(
                () => new Lazy<StoreListViewModel>(container.GetInstance<StoreListViewModel>)
            );

            container.Register(
                () => new Lazy<StoreEditViewModel>(container.GetInstance<StoreEditViewModel>)
            );


            container.Register(
                () => new Lazy<IceCreamListViewModel>(container.GetInstance<IceCreamListViewModel>)
            );

            container.Register(
                () => new Lazy<IceCreamGridViewModel>(container.GetInstance<IceCreamGridViewModel>)
                , Lifestyle.Transient
            );


            container.Register(
                () => new Lazy<IceCreamDetailViewModel>(container.GetInstance<IceCreamDetailViewModel>)
            );

            container.Register<IAppConfiguration, AppConfiguration>();
             
//            container.Register(() => 
//                new IceCreamDbContext( container.GetInstance<IAppConfiguration>())  
//                , Lifestyle.Transient);

            container.Register(() => new IceCreamDbContext(), Lifestyle.Transient);
            Registration registration = container.GetRegistration(typeof(IceCreamDbContext)).Registration;

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "non production");

            //this ensures that all dependencies can be created
            container.Verify();

            return container;
        }

        public static Container RunApplication( )
        {
            try
            { 
                var container = Bootstrap(); 

                //this is a single event listener for the app
                EventAggregator = container.GetInstance<IEventAggregator>();

                var mainWindow = container.GetInstance<MainWindow>();
                mainWindow.Closed += (sender, args) => { System.Windows.Application.Current.Shutdown(); };
                mainWindow.Show();
                return container;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}