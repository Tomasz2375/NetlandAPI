using NetlandAPI.Entity;
using NetlandAPI.Models;

namespace NetlandAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICsvService _csvService;
        private readonly IAppsettingsDevelopment _appsettingsDevelopment;

        public OrderService(ICsvService csvService, IAppsettingsDevelopment appsettingsDevelopment)
        {
            _csvService = csvService;
            _appsettingsDevelopment = appsettingsDevelopment;
        }

        public IEnumerable<Order> GetOrder(SearchPhrasesDto dto)
        {
            var orders = _csvService.ReadOrderCSV(_appsettingsDevelopment.GetOrderFilePath());
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

        private IEnumerable<Order> SearchForClientNumber(IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            return orders.Where(o => o.Number == dto.Number);
        }
        private IEnumerable<Order> SearchForClientCode(IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            List<Order> results = new List<Order>();
            foreach (var clientCode in dto.ClientCode)
            {
                if (orders.Where(o => o.ClientCode == clientCode) != null)
                {
                    results.AddRange(orders.Where(o => o.ClientCode == clientCode));
                }
            }
            orders = results.Distinct();
            return orders;
        }
        private IEnumerable<Order> SearchForOrderPlacedAfterDate(IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            orders = orders.Where(o => o.OrderDate >= dto.DateFrom);
            return orders;
        }
        private IEnumerable<Order> SearchForOrderPlacedBeforeDate(IEnumerable<Order> orders, SearchPhrasesDto dto)
        {
            orders = orders.Where(o => o.OrderDate <= dto.DateTo);
            return orders;
        }

    }
}
