namespace IceCreamApp.ViewModels.IceCream
{
    public class IceCreamViewModel : BaseViewModel, IImageLink
    {
        public IceCreamViewModel(Models.IceCream model)
        {
            backingModel = model;
            Id = model.Id;
            Name = model.Name;
            CreationCost = model.CreationCost;
            ImageLink = model.ImageLink;
        }

        private Models.IceCream backingModel;

        public long Id { get; set; }

        public string Name { get; set; }

        public double CreationCost { get; set; }

        public string ImageLink { get; set; }
    }
}