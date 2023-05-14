using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using NetlandAPI.Entity;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NetlandAPI.EntityMap
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(m => m.Number).Name(nameof(Order.Number));
            Map(m => m.ClientCode).Name(nameof(Order.ClientCode));
            Map(m => m.ClientName).Name(nameof(Order.ClientName)); 
            Map(m => m.OrderDate).Name(nameof(Order.OrderDate))
                .TypeConverterOption.Format("dd.MM.yyyy");
            Map(m => m.ShipmentDate).Name(nameof(Order.ShipmentDate))
                .TypeConverterOption.Format("dd.MM.yyyy");
            Map(m => m.Quantity).Name(nameof(Order.Quantity));
            Map(m => m.Confirmed).Name(nameof(Order.Confirmed));
            Map(m => m.Value).Name(nameof(Order.Value));
        }
    }
}
