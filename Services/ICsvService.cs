using NetlandAPI.Entity;

namespace NetlandAPI.Services
{
    public interface ICsvService
    {
        IEnumerable<Order> ReadOrderCSV(string path);
    }
}
