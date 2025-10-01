using Dapper;
using DatabaseClasses.Data;
using DatabaseClasses.Interfaces;
using EmilsAuto.Helper;
using EmilsAuto.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmilsAuto.Components
{
    public class SqlCustomer : ISqlCustomer
    {
        private readonly IDbHandler _dbHandler;

        public SqlCustomer(IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public void GetCustomer(string firstName, string lastName = "")
        {
            string sql = "SELECT customerId FROM customers.customers WHERE UPPER(CAST(name as varchar)) = @name OR UPPER(CAST(lastName as varchar)) = @lastName";

            DataTable tb = _dbHandler.ExecuteReader(sql, new { name = firstName, lastName = lastName});       

            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                string test = row["customerId"].ToString();
            }
        }
    }
}
