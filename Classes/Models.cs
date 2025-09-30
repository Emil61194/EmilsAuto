namespace EmilsAuto.Classes
{
    public class Models
    {
        public int ModelId { get; set; }
        //public Models(int modelId) { this.ModelId = modelId; }

        public Brands Brands { get; set; }
        public int? ModelYear { get; set; } 
        public int? FuelConsumption { get; set; }
        public string? FuelType { get; set; }
        public int? HorsePower { get; set; }

    }
}
