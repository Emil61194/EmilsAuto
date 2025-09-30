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
        public List<Cars> GetCars()
        {
            string sql = "SELECT TOP 25 c.productId, c.listingPrice, c.listingDate, c.modelId, m.modelYear, b.\"name\", m.fuelType FROM products.cars c\r\nINNER JOIN brand.models m on m.modelId = c.modelId\r\nINNER JOIN brand.brands b on b.brandId = m.brandId";

            using IDbConnection db = dbConnection;
            var reader = db.ExecuteReader(sql);

            DataTable tb = new DataTable();
            tb.Load(reader);

            List<Cars> cars = new List<Cars>();
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow dr in tb.Rows) 
                {
                    Cars car = SqlLoader.MapDataRowToObject<Cars>(dr);
                    Models model = SqlLoader.MapDataRowToObject<Models>(dr);
                    Brands brand = SqlLoader.MapDataRowToObject<Brands>(dr);
                    model.Brands = brand;
                    car.Model = model;
                    cars.Add(car);
                }
            }

            return cars;
        }
    }
}
