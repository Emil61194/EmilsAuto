namespace EmilsAuto.Classes
{
    public class Model
    {
        public int ModelId { get; set; }
        //public Model(int modelId) { this.ModelId = modelId; }

        public Brand Brand { get; set; }
        public int ModelYear { get; set; } 
        public int FuelConsumption { get; set; }
        public string FuelType { get; set; }
        public int HorsePower { get; set; }

    }
}
