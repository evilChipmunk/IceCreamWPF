using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using IceCreamApp.DataAccess;

namespace IceCreamApp.ViewModels.IceCream
{
    public class IceCreamListViewModel : BaseViewModel
    {
        private readonly IDataService service;
        private IceCreamViewModel selectedIceCream; 
        private List<Models.IceCream> iceCreamModels;
          
        public IceCreamListViewModel(IDataService service)
        {
            this.service = service;  
            IceCreams = new ObservableCollection<IceCreamViewModel>();

        }  

        public ICommand ViewDetailCommand { get; set; }

        public ICommand EditCommand { get; set; }
         
        public ObservableCollection<IceCreamViewModel> IceCreams { get; set; }


        //Note: setting this property triggers other properties to be changed (Name, CreationCost)
        //so it can't be auto, and needs to call OnPropertyChanged
        public IceCreamViewModel SelectedIceCream
        {
            get => selectedIceCream;
            set
            {
                selectedIceCream = value;
                SetIceCreamDetails();
                OnPropertyChanged();
            }
        }

        public string Name { get; set; }

        public double CreationCost { get; set; }

        private void SetIceCreamDetails()
        {
            if (SelectedIceCream == null) return;

            //Note: for simplicity just getting the ice cream from the field iceCreamModels
            //but this might need to go to the database depending on app needs


            var iceCream = iceCreamModels.FirstOrDefault(x => x.Id == SelectedIceCream.Id);

            if (iceCream == null) return;

            Name = iceCream.Name;
            CreationCost = iceCream.CreationCost;
        }
         
        public void LoadData()
        {
            var iceCreams = service.GetIceCreams();
            this.iceCreamModels = new List<Models.IceCream>(iceCreams);

            foreach (var model in iceCreamModels)
            {
                IceCreams.Add(new IceCreamViewModel(model));
               
            } 
            SelectedIceCream = IceCreams.FirstOrDefault();
        } 
    }
}