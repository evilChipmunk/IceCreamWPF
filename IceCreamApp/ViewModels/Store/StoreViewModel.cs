using System.Collections.ObjectModel;
using IceCreamApp.ViewModels.IceCream;

namespace IceCreamApp.ViewModels.Store
{
    public class StoreViewModel : BaseViewModel
    {
        private readonly Models.Store backingModel;

        public StoreViewModel(Models.Store model)
        {
            backingModel = model;
            Id = model.Id;
            ManagerName = model.ManagerName;
            Phone = model.Phone;
            StoreName = model.StoreName;
            OperationalStatus = model.OperationalStatus; 

            IceCreams = new ObservableCollection<IceCreamViewModel>();

            foreach (var iceCream in model.IceCreams)
            {
                IceCreams.Add(new IceCreamViewModel(iceCream));
            }
        }

        public long Id { get; set; }
        public string ManagerName { get; set; }

        public string Phone { get; set; }

        public string StoreName { get; set; }

        public string OperationalStatus { get; set; }

        public ObservableCollection<IceCreamViewModel> IceCreams { get; set; }
         
    }
}