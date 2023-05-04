using NetlandAPI.Entity;
using NetlandAPI.Models;

namespace NetlandAPI.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrder(SearchPhrasesDto dto);
    }
}
