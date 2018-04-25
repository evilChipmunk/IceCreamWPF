using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using IceCreamApp.Commands;
using IceCreamApp.DataAccess;

namespace IceCreamApp.ViewModels.IceCream
{
    public class IceCreamGridViewModel : BaseViewModel
    {
        private readonly IDataService dataService;

        public IceCreamGridViewModel(IDataService dataService)
        {
            this.dataService = dataService;
            
            LoadCommand = new AsyncRelayCommand(LoadData);
            IceCreams = new ObservableCollection<IceCreamViewModel>();
        }

        private async Task LoadData(object arg)
        {
            this.iceCreams = await dataService.GetIceCreamsAsync();
            foreach (var iceCream in iceCreams)
            {
                IceCreams.Add(new IceCreamViewModel(iceCream));
            }
        }

        private List<Models.IceCream> iceCreams { get; set; }

        public ObservableCollection<IceCreamViewModel> IceCreams { get; set; }

        public ICommand LoadCommand { get; set; }
    }
}