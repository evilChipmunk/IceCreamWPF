using System;
using System.ComponentModel;
using IceCreamApp.DataAccess;
using IceCreamApp.ViewModels.Events;
using Prism.Events;

namespace IceCreamApp.ViewModels.Store
{
    public class StoreEditViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly IDataService service;
        private readonly IEventAggregator eventAggregator;

        public StoreEditViewModel(IDataService service, IEventAggregator eventAggregator)
        {
            this.service = service;
            this.eventAggregator = eventAggregator;
        }


        public long Id { get; set; }
        public string StoreName { get; set; }
        public string ManagerName { get; set; }

        public void Save()
        {
            Models.Store store = service.GetStoreById(Id);
            store.ManagerName = ManagerName;
            service.SaveStore(store);

            //Note: send a success save message - listened for at the MainViewModel
            eventAggregator.GetEvent<StoreEditSaved>().Publish(this);

        }

        public void LoadData(StoreViewModel viewModel)
        {
            Id = viewModel.Id;
            StoreName = viewModel.StoreName;
            ManagerName = viewModel.ManagerName;
        }

 

        public string Error { get; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "ManagerName":

                        if (string.IsNullOrEmpty(ManagerName))
                        {
                            return "Manager Name is required";
                        }

                        break;
                }

                return "";
            }
        }
    }
}