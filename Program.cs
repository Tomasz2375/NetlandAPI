using NetlandAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddScoped<IAppsettingsDevelopment, AppsettingsDevelopment>();
builder.Services.AddScoped<ICsvService, CsvService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseAuthorization();

app.MapRazorPages();

app.Run();
