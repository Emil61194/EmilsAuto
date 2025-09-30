namespace EmilsAuto.Classes
{
    public class Cars
    {
        public int ProductId { get; set; }
        //public Cars(int productId) { this.ProductId = productId; }
        public string? Vin { get; set; }
        public int? KmDriven { get; set; }
        public Models? Model { get; set; }
        public int ListingPrice { get; set; }
        public DateTime ListingDate {  get; set; }
    }
}
