using EmilsAuto.Classes;

namespace EmilsAuto.Interfaces
{
    public interface IProducts
    {
        Car GetCar(int productId);
        List<Car> GetCars();
    }
}
