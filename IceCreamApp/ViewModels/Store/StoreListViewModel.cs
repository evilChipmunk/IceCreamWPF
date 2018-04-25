using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using IceCreamApp.Commands;
using IceCreamApp.DataAccess;
using IceCreamApp.ViewModels.Events;
using Prism.Events;

namespace IceCreamApp.ViewModels.Store
{
    public class StoreListViewModel : BaseViewModel
    {
        private readonly IDataService service;
        private readonly IEventAggregator eventAggregator;
        private readonly Lazy<StoreEditViewModel> editViewModel;
        private List<Models.Store> storeModels;

        public StoreListViewModel(IDataService service, IEventAggregator eventAggregator, Lazy<StoreEditViewModel> editViewModel)
        {
            this.service = service;
            this.eventAggregator = eventAggregator;
            this.editViewModel = editViewModel;
            Stores = new ObservableCollection<StoreViewModel>();

            LoadCommand = new AsyncRelayCommand(ExecuteLoad); 
            EditCommand = new RelayParameterCommand(ExecuteEdit); 
        }

        private async Task ExecuteLoad(object arg)
        {
            await LoadData();
        }

        public ICommand LoadCommand { get; set; } 
        public ICommand EditCommand { get; set; }

        private void ExecuteEdit(object arg)
        {
            //Note: this event is listened for in the MainViewModel
            //it sets the MainWindowView object that is bound to the main ContentPresenter
            //this will display the StoreEditView.xaml in a disconnected way

            StoreViewModel viewModel = arg as StoreViewModel;
            StoreEditViewModel editModel = editViewModel.Value;
            editModel.LoadData(viewModel);
            eventAggregator.GetEvent<StoreEditNeeded>().Publish(editModel); 
        }
         

        public ObservableCollection<StoreViewModel> Stores { get; set; }
        
        public StoreViewModel SelectedStore { get; set; }

        public async Task LoadData()
        {
            storeModels = await service.GetStoresAsync();
             
            foreach (var model in storeModels)
            {
                Stores.Add(new StoreViewModel(model));

            }
            SelectedStore = Stores.FirstOrDefault();
        }
    }
}