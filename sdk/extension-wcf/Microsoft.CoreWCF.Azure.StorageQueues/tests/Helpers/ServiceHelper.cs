// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers
{
    public static class ServiceHelper
    {
#if NET462
        public static IHost CreateHost<TStartup>() where TStartup : class
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 0);
                })
                .UseStartup<TStartup>()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
#if DEBUG
                    logging.AddFilter("Default", LogLevel.Debug);
                    logging.AddFilter("Microsoft", LogLevel.Debug);
                    logging.SetMinimumLevel(LogLevel.Debug);
                    logging.AddDebug();
#endif // DEBUG
                })
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .Build();

            return new WebHostWrapper(webHost);
        }

        private class WebHostWrapper : IHost
        {
            private readonly IWebHost _webHost;
            public WebHostWrapper(IWebHost webHost) => _webHost = webHost;
            public IServiceProvider Services => _webHost.Services;
            public Task StartAsync(CancellationToken cancellationToken = default) => _webHost.StartAsync(cancellationToken);
            public Task StopAsync(CancellationToken cancellationToken = default) => _webHost.StopAsync(cancellationToken);
            public void Dispose() => _webHost.Dispose();
        }
#else
        public static IHost CreateHost<TStartup>() where TStartup : class
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 0);
                    })
                    .UseStartup<TStartup>();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging(logging =>
                {
#if DEBUG
                    logging.AddFilter("Default", LogLevel.Debug);
                    logging.AddFilter("Microsoft", LogLevel.Debug);
                    logging.SetMinimumLevel(LogLevel.Debug);
                    logging.AddDebug();
#endif // DEBUG
                })
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .Build();
        }
#endif
    }
}
