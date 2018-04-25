using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using IceCreamApp.Commands;
using IceCreamApp.DataAccess;
using IceCreamApp.ViewModels.Events;
using IceCreamApp.ViewModels.Store;
using Prism.Events;

namespace IceCreamApp.ViewModels.IceCream
{
    public class IceCreamDetailViewModel : BaseViewModel
    {
        private readonly IDataService service;
        private readonly IEventAggregator eventAggregator;
        private SimpleValueViewModel selectedIceCream; 
        private List<Models.IceCream> iceCreamModels;

        public IceCreamDetailViewModel(IDataService service, IEventAggregator eventAggregator)
        {
            this.service = service;
            this.eventAggregator = eventAggregator;
            this.LoadCommand = new AsyncRelayCommand(ExecuteLoad);
            this.SaveCommand = new AsyncRelayCommand(ExecuteSave);
            IceCreams = new ObservableCollection<SimpleValueViewModel>();
             
        }

        private async Task ExecuteLoad(object arg)
        {
            await LoadData();
        }

        public ICommand LoadCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ObservableCollection<SimpleValueViewModel> IceCreams { get; set; }

        public SimpleValueViewModel SelectedIceCream
        {
            get => selectedIceCream;
            set
            {
                selectedIceCream = value;
                SetIceCreamDetails();
                OnPropertyChanged();
            }
        }


        //Note: Nuget package reference Fody is handling INotifyPropertyChange events
        //so that each property doesn't have to call OnPropertyChanged();
        public long Id { get; set; }

        public string Name { get; set; }

        public double CreationCost { get; set; }

        public StoreViewModel Store { get; set; }

        private void SetIceCreamDetails()
        {
            if (SelectedIceCream == null) return;

            //Note: for simplicity just getting the ice cream from the field iceCreamModels
            //but this might need to go to the database depending on app needs

            
            var iceCream = iceCreamModels.FirstOrDefault(x => x.Id == SelectedIceCream.Id);

            if (iceCream == null) return;

            Id = iceCream.Id;
            Name = iceCream.Name;
            CreationCost = iceCream.CreationCost; 
        }


        //Note: since this is being used for the async command version (see IceCreamDetail.xaml) 
        //the signature for LoadData is a Task. But if it were using the event version
        //this would be a void
        public async Task LoadData() 
        {
            this.iceCreamModels = new List<Models.IceCream>(await service.GetIceCreamsAsync());
            IceCreams.AddRange(iceCreamModels);
            SelectedIceCream = IceCreams.FirstOrDefault(); 
        }
         
        private async Task ExecuteSave(object arg)
        {
            //Note: using the immutable object pattern for ice cream
            //this should really be populated from the SelectedIceCream OR properties
            //but I started using the SimpleViewModel object without planning this all through
            var iceCream = service.GetIceCreamById(SelectedIceCream.Id);
            iceCream.Name = Name;
            iceCream.CreationCost = CreationCost;
            iceCream.ImageLink = SelectedIceCream.ImageLink; 

            await service.SaveIceCreamAsync(iceCream);

            eventAggregator.GetEvent<SaveEvent>().Publish();
            
        } 
    }
}