using Dapper;
using DatabaseClasses.Interfaces;
using EmilsAuto.Classes;
using EmilsAuto.Helper;
using EmilsAuto.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmilsAuto.Components
{
    public class SqlProducts : IProducts
    {
        private readonly IDbHandler _dbHandler;

        public SqlProducts(IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }
        public List<Car> GetCars()
        {
            string sql = "EXEC procedures.getAvaibleCars";
            var tb = _dbHandler.ExecuteReader(sql);

            List<Car> Car = new List<Car>();
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow row in tb.Rows) 
                {
                    Car car = SqlLoader.MapDataRowToObject<Car>(row, new());
                    Model model = SqlLoader.MapDataRowToObject<Model>(row, new());
                    Brand brand = SqlLoader.MapDataRowToObject<Brand>(row, new());
                    model.Brand = brand;
                    car.Model = model;
                    Car.Add(car);
                }
            }

            return Car;
        }

        public Car GetCar(int productId)
        {
            string sql = "SELECT TOP 1 * FROM views.CarInformation WHERE productId = @productId";
            DataTable tb = _dbHandler.ExecuteReader(sql, new { productId = productId });

            Car car = new Car();
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                car = SqlLoader.MapDataRowToObject<Car>(row, new());
                Model model = SqlLoader.MapDataRowToObject<Model>(row, new());
                Brand brand = SqlLoader.MapDataRowToObject<Brand>(row, new());
                model.Brand = brand;
                car.Model = model;
            }

            return car;
        }
    }
}
