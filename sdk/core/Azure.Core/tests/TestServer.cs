// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Core.Tests
{
    public class TestServer : IStartup, IDisposable
    {
        private readonly RequestDelegate _app;
        private readonly IWebHost _host;

        public Uri Address => new Uri(_host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First());

        public TestServer(Action<HttpContext> app) : this(context => { app(context); return Task.CompletedTask;})
        {
        }

        public TestServer(RequestDelegate app)
        {
            _app = app;
            _host = new WebHostBuilder()
                .UseKestrel(options => options.Listen(new IPEndPoint(IPAddress.Loopback, 0)))
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IStartup>(this);
                })
                .UseSetting(WebHostDefaults.ApplicationKey, typeof(TestServer).GetTypeInfo().Assembly.FullName)
                .Build();

            _host.Start();
        }

        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }

        void IStartup.Configure(IApplicationBuilder app)
        {
            app.Run(_app);
        }

        public void Dispose()
        {
            _host?.Dispose();
        }
    }
}
