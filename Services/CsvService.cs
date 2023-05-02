using CsvHelper;
using NetlandAPI.Entity;
using NetlandAPI.EntityMap;
using System.Globalization;

namespace NetlandAPI.Services
{
    public class CsvService : ICsvService
    {
        public IEnumerable<Order> ReadOrderCSV(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<OrderMap>();
                return csv.GetRecords<Order>().ToList();
            }
        }
    }
}
