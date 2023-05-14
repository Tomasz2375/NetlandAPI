using NetlandAPI.Entity;
using NetlandAPI.Models;

namespace NetlandAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICsvService _csvService;
        private readonly IConfiguration _configuration;

        public OrderService(ICsvService csvService, IConfiguration configuration)
        {
            _csvService = csvService;
            _configuration = configuration;
        }

        public IEnumerable<Order> GetOrder(SearchPhrasesDto dto)
        {
            var orders = _csvService
                .ReadOrderCSV(_configuration.GetConnectionString("OrderFilePath"));

            if (!string.IsNullOrEmpty(dto.Number))
            {
                orders = SearchForClientNumber(orders, dto);
            }
            if (dto.ClientCode.Count > 0)
            {
                orders = SearchForClientCode(orders, dto);
            }
            if (dto.DateFrom != null)
            {
                orders = SearchForOrderPlacedAfterDate(orders, dto);
            }
            if (dto.DateTo != null)
            {
                orders = SearchForOrderPlacedBeforeDate(orders, dto);
            }
            return orders;
        }

        private IEnumerable<Order> SearchForClientNumber
            (IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            return orders.Where(o => o.Number == dto.Number);
        }
        private IEnumerable<Order> SearchForClientCode
            (IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            List<Order> results = new List<Order>();
            foreach (var clientCode in dto.ClientCode)
            {
                if (orders.Where(o => o.ClientCode == clientCode) != null)
                {
                    results.AddRange(orders
                        .Where(o => o.ClientCode == clientCode));
                }
            }
            return results.Distinct();
        }
        private IEnumerable<Order> SearchForOrderPlacedAfterDate
            (IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            return orders.Where(o => o.OrderDate >= dto.DateFrom);
        }
        private IEnumerable<Order> SearchForOrderPlacedBeforeDate
            (IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            return orders.Where(o => o.OrderDate <= dto.DateTo);
        }

    }
}
