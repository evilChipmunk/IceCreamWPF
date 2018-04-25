using System;
using System.Threading.Tasks;
using System.Windows.Input;
using IceCreamApp.Commands;
using IceCreamApp.ViewModels.Events;
using IceCreamApp.ViewModels.IceCream;
using IceCreamApp.ViewModels.Store;
using Prism.Events;

namespace IceCreamApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Lazy<StoreListViewModel> listModel;
        private readonly Lazy<IceCreamGridViewModel> gridModel;
        private readonly Lazy<IceCreamDetailViewModel> detailModel;
        private readonly Lazy<StoreEditViewModel> storeEditViewModel;
        private readonly IEventAggregator eventAggregator;

        public MainViewModel(Lazy<StoreListViewModel> listModel
            , Lazy<IceCreamGridViewModel> gridModel
            , Lazy<IceCreamDetailViewModel> detailModel
            , Lazy<StoreEditViewModel> storeEditViewModel
            , IEventAggregator eventAggregator
            )
        {
            this.listModel = listModel;
            this.gridModel = gridModel;
            this.detailModel = detailModel;
            this.storeEditViewModel = storeEditViewModel;
            this.eventAggregator = eventAggregator;

            AListCommand = new AsyncRelayCommand(ExecuteAList, CanExecuteAList);
            AGridCommand = new AsyncRelayCommand(ExecuteAGrid, CanExecuteAGrid);
            ADetailCommand = new AsyncRelayCommand(ExecuteADetail, CanExecuteADetail);

            eventAggregator.GetEvent<StoreEditNeeded>().Subscribe(ShowStoreEdit);
            eventAggregator.GetEvent<StoreEditSaved>().Subscribe(ShowSavedMessage);
            eventAggregator.GetEvent<SaveEvent>().Subscribe(ShowMessage);

        }

        private void ShowMessage()
        {
            Message = "Saved";
        }


        public ICommand AListCommand { get; set; }
        public ICommand AGridCommand { get; set; }
        public ICommand ADetailCommand { get; set; }
        public BaseViewModel MainWindowView { get; set; }
        public string Message { get; set; }

        public bool IsTableSelected { get; set; }

        public bool IsDetailSelected { get; set; }

        public bool IsListSelected { get; set; }



        private bool CanExecuteAList(object arg)
        {
            return !(MainWindowView is StoreListViewModel);
        }

        private async Task ExecuteAList(object arg)
        {
            IsListSelected = true;
            IsTableSelected = false;
            IsDetailSelected = false;
            await Task.Run(() => { MainWindowView =  listModel.Value; }); 
        }


        private bool CanExecuteAGrid(object arg)
        {
            return !(MainWindowView is IceCreamGridViewModel);
        }

        private async Task ExecuteAGrid(object arg)
        {
            IsListSelected = false;
            IsTableSelected = true;
            IsDetailSelected = false;
            await Task.Run(() =>
            {
                MainWindowView = gridModel.Value;
            });
        }


        private bool CanExecuteADetail(object arg)
        {
            return !(MainWindowView is IceCreamDetailViewModel);
        }

        private async Task ExecuteADetail(object arg)
        {
            IsListSelected = false;
            IsTableSelected = false;
            IsDetailSelected = true;

            await Task.Run(() =>
            {
                MainWindowView = detailModel.Value;
            });
        } 



        private void ShowSavedMessage(StoreEditViewModel obj)
        {
            Message = $"Saved store {obj.StoreName}";
        }

        private void ShowStoreEdit(StoreEditViewModel obj)
        {
            MainWindowView = obj;
        }
    }
}