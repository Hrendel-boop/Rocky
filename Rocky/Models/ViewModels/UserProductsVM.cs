namespace Rocky.Models.ViewModels
{
    public class UserProductsVM
    {
        public UserProductsVM() 
        {
            ProductList = new List<Product>();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Product> ProductList { get; set;}
    }
}
