using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Repository;
using Domain;
using MudBlazor.Services;

namespace eWallet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddDbContextFactory<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("eWallet");
            });
            builder.Services.AddSingleton<DailyTransactionRegisterService>();
            builder.Services.AddSingleton<TransactionRepository>();
            await builder.Build().RunAsync();
        }
    }
}