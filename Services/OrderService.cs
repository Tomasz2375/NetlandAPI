using NetlandAPI.Entity;

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

        public IEnumerable<Order> GetOrder()
        {
            var orders = _csvService.ReadOrderCSV(_appsettingsDevelopment.GetOrderFilePath());
            return orders;
        }
    }
}
