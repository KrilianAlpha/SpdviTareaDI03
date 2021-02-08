using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerEntry
{
    class DataAccess
    {
        public static ProductModel GetProductModel(int productModelId)
        {
            string connectionString = "Server = tcp:spdvi2021justojavier.database.windows.net,1433; Initial Catalog = AdventureWorks2016; Persist Security Info = False; User ID = krilian; Password = milu2000A; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "dbo.getRandomProduct '" + productModelId.ToString() + "'";
                var productModel = conn.Query<ProductModel>(sql).FirstOrDefault();
                return productModel;
            }
        }
        public static List<Product> GetProducts(int productModelId)
        {
            string connectionString = "Server = tcp:spdvi2021justojavier.database.windows.net,1433; Initial Catalog = AdventureWorks2016; Persist Security Info = False; User ID = krilian; Password = milu2000A; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "dbo.getRandomProductPrice '" + productModelId.ToString() + "'";
                var products = conn.Query<Product>(sql).ToList();
                return products;
            }
        }

        internal static ProductModel GetProductBySize(string size)
        {
            string connectionString = "Server = tcp:spdvi2021justojavier.database.windows.net,1433; Initial Catalog = AdventureWorks2016; Persist Security Info = False; User ID = krilian; Password = milu2000A; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "dbo.getRandomProductBySize '" + size + "'";
                var productModel = conn.Query<ProductModel>(sql).FirstOrDefault();
                return productModel;
            }
        }
    }
}
