using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group2Intex.Infrastructure;
using Group2Intex.Models;

namespace Group2Intex.Pages
{
    public class CartModel : PageModel
    {
        private IIntexRepository _repo;

        public CartModel(IIntexRepository temp, Cart cartService)
        {
            _repo = temp;
            Cart = cartService;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int projectId, string returnUrl) 
        {
            Project proj = _repo.Projects
                .FirstOrDefault(x => x.ProjectId == projectId);

            if (proj != null) 
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(proj, 1);
                //HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int projectId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Project.ProjectId == projectId).Project);

            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }
}
