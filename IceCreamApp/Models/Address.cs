namespace IceCreamApp.Models
{
    public class Address : BaseEntity
    {
        public Country Country { get; set; }

        public long? CountryId { get; set; }
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public State State { get; set; }
        public long? StateId { get; set; }

        public string ZipCode { get; set; }
    }
}