// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AppSecretsConfig
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        var settings = config.Build();
                        var connectionString = settings.GetConnectionString("AppConfig");

                        config.AddAzureAppConfiguration(options =>
                        {
                            options.Connect(connectionString);
                            options.ConfigureKeyVault(options =>
                            {
                                options.SetCredential(new DefaultAzureCredential());
                            });
                        });
                    })
                    .UseStartup<Startup>();
                });
    }
}
