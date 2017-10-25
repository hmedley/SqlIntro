using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro.Dapper
{
    class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT * from products");
            }
        }
        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("delete from product where productid = @id" + new {id = productId});
            }
        }
        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("update product set name = @name where ProductID = @id", new {id = prod.ProductId, name = prod.Name});
            }
        }
        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cText = "INSERT into product (" + string.Join(", ", prod.Params.Keys) + ")";

                var valueKeys = prod.Params.Keys.Select(str => "@" + str);
                cText += " values (" + string.Join(", ", valueKeys) + ")";
            }
        }

    }
}
