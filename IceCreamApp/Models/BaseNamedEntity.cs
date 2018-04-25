namespace IceCreamApp.Models
{
    public abstract class BaseNamedEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}