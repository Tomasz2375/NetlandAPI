using CsvHelper.Configuration;
using NetlandAPI.Entity;

namespace NetlandAPI.EntityMap
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(m => m.Number).Name(nameof(Order.Number));
            Map(m => m.ClientCode).Name(nameof(Order.ClientCode));
            Map(m => m.ClientName).Name(nameof(Order.ClientName));
            Map(m => m.OrderDate).TypeConverterOption.Format("dd.MM.yyyy");
            Map(m => m.ShipmentDate).TypeConverterOption.Format("dd.MM.yyyy");
            Map(m => m.Quantity).Name(nameof(Order.Quantity));
            Map(m => m.Confirmed).Name(nameof(Order.Confirmed));
            Map(m => m.Value).Name(nameof(Order.Value));
        }
    }
}
