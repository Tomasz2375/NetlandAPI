namespace NetlandAPI.Services
{
    public class AppsettingsDevelopment : IAppsettingsDevelopment
    {
        public string GetOrderFilePath()
        {
            return WebApplication.CreateBuilder().Configuration.GetConnectionString("OrderFilePath");
        }
    }
}
