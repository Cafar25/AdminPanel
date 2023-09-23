using AdminPanel.DAL;
using AdminPanel.Entities.ProductsSection;
using AdminPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Controllers
{
    public class BasketController : Controller
    {
        private readonly AdminPanelDbContext _context;

        public BasketController(AdminPanelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBasket(int? id)
        {
            if (id == null) return NotFound();
            var existProduct = _context.Products
                .Include(p=> p.ProductImages)
                .FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return NotFound();

            List<BasketVM> list = CheckBasket();

            CheckBasketItemCount(list, existProduct.Id);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(list), new CookieOptions { MaxAge = TimeSpan.FromMinutes(30)});
            return RedirectToAction("index","home");



        }

        public IActionResult ShowBasket()
        {
            string basket = Request.Cookies["basket"];
            List<BasketVM> products = new();
            if (basket!= null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                products = UpdateBasket(products);
            }
            return View(products);
        }

        private List<BasketVM> UpdateBasket(List<BasketVM> products)
        {
            foreach (var basketProduct in products)
            {
                var existProduct = _context.Products
                    .Include(p => p.ProductImages)
                    .FirstOrDefault(p => p.Id == basketProduct.Id);
                basketProduct.Name = existProduct.Name;
                basketProduct.Price = existProduct.Price;
                basketProduct.ImagePath = existProduct.ProductImages
                    .FirstOrDefault(p => p.IsMain).ImagePath;
            }
            return products;
        }

        private List<BasketVM> CheckBasket()
        {
            List<BasketVM> list;
            string basket = Request.Cookies["basket"];
            if (basket == null)
            {
                list = new();
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            return list;
        }

        private void CheckBasketItemCount(List<BasketVM> list, int id)
        {
            var existProductInBasket = list.FirstOrDefault(p => p.Id == id);
            if (existProductInBasket is null)
            {
                BasketVM basketVM = new();

                basketVM.Id = id;
                basketVM.BasketCount = 1;

                list.Add(basketVM);

            }
            else
            {
                existProductInBasket.BasketCount++;
            }
        }

        public IActionResult Remove(int? id)
        {
            string basket = Request.Cookies["basket"];
            var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var basketItem = products.FirstOrDefault(p => p.Id == id);
            if (basketItem != null)
            {
                products.Remove(basketItem);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(15)});
            return RedirectToAction("ShowBasket");

        }

        public IActionResult Increase(int? id)
        {
            string basket = Request.Cookies["basket"];
            var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var increaseProduct = products.FirstOrDefault(p => p.Id == id);

            if (increaseProduct != null)
            {
                if (increaseProduct.BasketCount < 10)
                {
                    increaseProduct.BasketCount++;
                    Response.Cookies.Append("basket", JsonConvert.SerializeObject(products),
                    new CookieOptions { MaxAge = TimeSpan.FromMinutes(15) });
                }
                else
                {
                    return RedirectToAction("ShowBasket");
                }
            }
            
            return RedirectToAction("ShowBasket");
        }

        public IActionResult Decrease(int? id)
        {

            string basket = Request.Cookies["basket"];
            var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var decreaseProduct = products.FirstOrDefault(p => p.Id == id);

            if (decreaseProduct != null)
            {
                if (decreaseProduct.BasketCount > 1)
                {
                    decreaseProduct.BasketCount--;
                }
                else
                {
                    products.Remove(decreaseProduct);
                }
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(15) });
            return RedirectToAction("ShowBasket");
        }


    }
}
