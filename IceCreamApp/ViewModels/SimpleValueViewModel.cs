using IceCreamApp.Models;

namespace IceCreamApp.ViewModels
{
    public class SimpleValueViewModel: IImageLink

    {
    public SimpleValueViewModel(Models.IceCream model)
    {
        Id = model.Id;
        Name = model.Name;
        ImageLink = model.ImageLink;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string ImageLink { get; set; }
    }
}