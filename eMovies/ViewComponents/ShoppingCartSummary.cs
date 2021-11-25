using eMovies.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCartService _shoppingCart;
        public ShoppingCartSummary(ShoppingCartService shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
