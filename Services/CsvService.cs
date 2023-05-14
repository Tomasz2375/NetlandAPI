using CsvHelper;
using CsvHelper.Configuration;
using NetlandAPI.Entity;
using NetlandAPI.EntityMap;
using System.Globalization;

namespace NetlandAPI.Services
{
    public class CsvService : ICsvService
    {
        public IEnumerable<Order> ReadOrderCSV(string path)
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                Mode = CsvMode.RFC4180,
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                csv.Context.RegisterClassMap<OrderMap>();
                var context = csv.GetRecords<Order>().ToList();
                return context;
            }

        }
    }
}
