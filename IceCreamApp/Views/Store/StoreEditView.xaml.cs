using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IceCreamApp.ViewModels.Store;

namespace IceCreamApp.Views.Store
{
    /// <summary>
    /// Interaction logic for StoreEditView.xaml
    /// </summary>
    public partial class StoreEditView : UserControl
    {
        public StoreEditView()
        {
            InitializeComponent();

            
        }

            //Note: events and/or named objects still work similar to WinForms
            //in some cases, like checking for Visibility of a UI element (Visible, Collapsed, Hidden),
            //maybe a simple pop up, it can be easier or necessary to do this. The general recommendation
            //is to use the binding features of WPF though
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender == btnSave) //of course it does
            {
                //get the data context and call save manually
                StoreEditViewModel viewModel = this.DataContext as StoreEditViewModel;
               
                viewModel.Save();
            }
        }
    }
}
