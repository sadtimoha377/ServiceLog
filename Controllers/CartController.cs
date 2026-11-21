using Microsoft.AspNetCore.Mvc;
using ServiceLog.Models;
using ServiceLog.Services.ShoppingCart;

namespace ServiceLog.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartService _cart1;
        private readonly IShoppingCartService _cart2;

        public CartController(IShoppingCartService cart1, IShoppingCartService cart2)
        {
            _cart1 = cart1;
            _cart2 = cart2;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _cart1.AddProduct(new ProductModel { Name = "LG Monitor", Price = 100 });
            _cart2.AddProduct(new ProductModel { Name = "Logitech Mouse", Price = 25 });

            ViewBag.Cart1 = _cart1.GetProducts();
            ViewBag.Cart2 = _cart2.GetProducts();
            return View();
        }
    }
}
