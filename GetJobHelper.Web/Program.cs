using GetJobHelper.Web;
using GetJobHelper.Web.Services;
using GetJobHelper.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7187/") });
builder.Services.AddScoped<IRecruiterService, RecruiterService>();

await builder.Build().RunAsync();
