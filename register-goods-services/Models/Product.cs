namespace registergoodsservices
{
    public class Product: Model
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public int Organisation_id { get; set; }
    }
}