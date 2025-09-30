using Dapper;
using EmilsAuto.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace EmilsAuto.Components
{
    public class SqlCustomer : ISqlCustomer
    {
        private readonly IConfiguration config;
        private readonly IDbConnection dbConnection;
        public SqlCustomer(IConfiguration config)
        {
            this.config = config;
            dbConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public void GetCustomer(string firstName, string lastName = "")
        {
            string sql = "SELECT customerId FROM customers.customers WHERE UPPER(CAST(name as varchar)) = @name OR UPPER(CAST(lastName as varchar)) = @lastName";
            
            
            using IDbConnection db = dbConnection;
            var reader = db.ExecuteReader(sql, new
            {
                name = firstName,
                lastName
            });

            DataTable tb = new DataTable();
            tb.Load(reader);

            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                string test = row["customerId"].ToString();
            }
        }
    }
}
