using Dapper;
using IntroSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
        
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;


        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CatorgoryID) Value(@name, @price, @cate);",
                new { name = name, price = price, cate = categoryID });

        }

        internal object GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProductName(int productID, string UpdateName)
        {
            _connection.Execute("UPDATE products SET Name = @updateName WHERE ProductID = @productID );",
                new { UpdateName = UpdateName, productID = productID });
        }

        public void DeleteProduct (int ProductID)
        {
            _connection.Execute("DELETE FROM reviews Where ProductID = @productID );",
                new { productID = ProductID });
            _connection.Execute("DELETE FROM sales Where ProductID = @productID );",
               new { productID = ProductID });
            _connection.Execute("DELETE FROM products Where ProductID = @productID );",
               new { productID = ProductID });


        }
    }

}
