using CsvHelper;
using CsvHelper.Configuration;
using NetlandAPI.Entity;
using NetlandAPI.EntityMap;
using System;
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
                Mode = CsvMode.Escape,
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                csv.Context.RegisterClassMap<OrderMap>();
                var context = csv.GetRecords<Order>().ToList();
                foreach (var record in context)
                {
                    record.Number = record.Number.Replace("\"", "");
                    record.ClientName = record.ClientName.Replace("\"", "");
                    record.ClientCode = record.ClientCode.Replace("\"", "");
                }
                return context;
            }

        }
    }
}
