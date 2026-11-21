using ServiceLog.Models;

namespace ServiceLog.Services.ShoppingCart;

public class ShoppingCartService : IShoppingCartService
{
    private readonly List<ProductModel> _products = new();

    public void AddProduct(ProductModel product)
    {
        _products.Add(product);
    }

    public IReadOnlyList<ProductModel> GetProducts()
    {
        return _products;
    }
}
