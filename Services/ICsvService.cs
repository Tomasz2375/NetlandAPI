using NetlandAPI.Entity;

namespace NetlandAPI.Services
{
    public interface ICsvService
    {
        public IEnumerable<Order> ReadOrderCSV(string path);
    }
}
