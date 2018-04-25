using IceCreamApp.ViewModels.Store;
using Prism.Events;

namespace IceCreamApp.ViewModels.Events
{
    public class StoreEditNeeded : PubSubEvent<StoreEditViewModel>
    {
        
    } 

    public class StoreEditSaved : PubSubEvent<StoreEditViewModel>
    {

    }


    public class SaveEvent : PubSubEvent
    {

    }
}