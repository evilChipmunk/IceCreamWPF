using System.Collections.Generic;
using System.Collections.ObjectModel;
using IceCreamApp.Models;

namespace IceCreamApp.ViewModels
{
    public static class Extensions
    {
        public static void AddRange<T>(this ObservableCollection<SimpleValueViewModel> list, IEnumerable<T> models) where T: Models.IceCream
        {
            foreach (var model in models)
            {
                list.Add(new SimpleValueViewModel(model));
            }
        } 
    }
}