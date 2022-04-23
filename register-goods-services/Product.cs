using System;
using System.IO;
using SQLite;

namespace registergoodsservices
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public int Organisation_id { get; set; }
    }
}