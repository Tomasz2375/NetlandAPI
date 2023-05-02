using NetlandAPI.Entity;

namespace NetlandAPI.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrder();
    }
}
