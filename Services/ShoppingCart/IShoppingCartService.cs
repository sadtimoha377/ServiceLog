using ServiceLog.Models;

namespace ServiceLog.Services.ShoppingCart;

public interface IShoppingCartService
{
    void AddProduct(ProductModel product);
    IReadOnlyList<ProductModel> GetProducts();
}
