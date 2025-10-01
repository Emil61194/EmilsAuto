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
        public List<Car> GetCar()
        {
            string sql = "SELECT TOP 25 c.productId, c.listingPrice, c.listingDate, c.modelId, m.modelYear, b.\"name\", m.fuelType FROM products.Cars c\r\nINNER JOIN brand.Models m on m.modelId = c.modelId\r\nINNER JOIN brand.Brands b on b.brandId = m.brandId ORDER BY c.listingDate DESC";

            using IDbConnection db = dbConnection;
            var reader = db.ExecuteReader(sql);

            DataTable tb = new DataTable();
            tb.Load(reader);

            List<Car> Car = new List<Car>();
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow dr in tb.Rows) 
                {
                    Car car = SqlLoader.MapDataRowToObject<Car>(dr);
                    Model model = SqlLoader.MapDataRowToObject<Model>(dr);
                    Brand brand = SqlLoader.MapDataRowToObject<Brand>(dr);
                    model.Brand = brand;
                    car.Model = model;
                    Car.Add(car);
                }
            }

            return Car;
        }

        public Car GetCar(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
