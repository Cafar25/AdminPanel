using AdminPanel.Services;
using AdminPanel.ViewModels;

namespace AdminPanel.Services
{
    public class BasketService : IBasket
    {
        private IHttpContextAccessor _contextAccessor;
        private object products;

        public BasketService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetBasketCount()
        {
            throw new NotImplementedException();
        }
    }
}
