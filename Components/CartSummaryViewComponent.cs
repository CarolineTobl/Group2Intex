using Microsoft.AspNetCore.Mvc;
using Group2Intex.Models;

namespace Group2Intex.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        
        public CartSummaryViewComponent(Cart cartService)
        {
            this.cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
