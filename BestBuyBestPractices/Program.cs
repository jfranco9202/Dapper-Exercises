﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperProductRepository(connection);
            var products = repo.GetAllProducts();

            foreach(var pro in products)
            {
                Console.WriteLine($"{pro.Name}{pro.onSale}{pro.price}{pro.ProductID}{pro.stockLevel}");
            }

        }
    }
}