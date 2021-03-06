using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazingChat.ViewModels;

namespace BlazingChat.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            // builder.RootComponents.Add<App>("customTag");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IProfileViewModel,ProfileViewModel>();

            var host = builder.Build(); 
            var profileViewModel = host.Services.GetRequiredService<IProfileViewModel>();
            profileViewModel.getProfile();

            await host.RunAsync();
        }
    }
}
