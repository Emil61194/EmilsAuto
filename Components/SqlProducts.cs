using Dapper;
using EmilsAuto.Classes;
using EmilsAuto.Helper;
using EmilsAuto.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace EmilsAuto.Components
{
    public class SqlProducts : IProducts
    {
        private readonly IConfiguration config;
        private readonly IDbConnection dbConnection;
        public SqlProducts(IConfiguration config)
        {
            this.config = config;
            dbConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }
        public List<Car> GetCars()
        {
            string sql = "SELECT TOP 25 c.productId, c.listingPrice, c.listingDate, c.modelId, m.modelYear, b.\"name\", m.fuelType FROM products.Cars c\r\nINNER JOIN brand.Models m on m.modelId = c.modelId\r\nINNER JOIN brand.Brands b on b.brandId = m.brandId ORDER BY c.listingDate DESC";

            using IDbConnection db = dbConnection;
            var reader = db.ExecuteReader(sql);

            DataTable tb = new DataTable();
            tb.Load(reader);

            List<Car> Car = new List<Car>();
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow row in tb.Rows) 
                {
                    Car car = SqlLoader.MapDataRowToObject<Car>(row);
                    Model model = SqlLoader.MapDataRowToObject<Model>(row);
                    Brand brand = SqlLoader.MapDataRowToObject<Brand>(row);
                    model.Brand = brand;
                    car.Model = model;
                    Car.Add(car);
                }
            }

            return Car;
        }

        public Car GetCar(int productId)
        {
            string sql = "SELECT TOP 1 * FROM products.Cars c\r\nINNER JOIN brand.Models m on m.modelId = c.modelId\r\nINNER JOIN brand.Brands b on b.brandId = m.brandId WHERE productId = @productId";

            using IDbConnection db = dbConnection;
            var reader = db.ExecuteReader(sql, new { productId = productId } );

            DataTable tb = new DataTable();
            tb.Load(reader);

            Car car = new Car();
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                car = SqlLoader.MapDataRowToObject<Car>(row);
                Model model = SqlLoader.MapDataRowToObject<Model>(row);
                Brand brand = SqlLoader.MapDataRowToObject<Brand>(row);
                model.Brand = brand;
                car.Model = model;
            }

            return car;
        }
    }
}
