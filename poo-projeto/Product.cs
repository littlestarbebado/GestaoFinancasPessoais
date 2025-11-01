namespace MiniLojaOnline
{
    public class Product
    {
    
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public decimal Price { get; set; }

        
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }


#pragma warning disable CS8618
        public Product() { }
#pragma warning restore CS8618 
    }
}
