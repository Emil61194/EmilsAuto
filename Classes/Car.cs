namespace EmilsAuto.Classes
{
    public class Car
    {
        public int ProductId { get; set; }
        //public Car(int productId) { this.ProductId = productId; }
        public string Vin { get; set; }
        public int KmDriven { get; set; }
        public Model Model { get; set; }
        public int ListingPrice { get; set; }
        public DateTime ListingDate {  get; set; }
    }
}
