// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Core.TestFramework
{
    public class TestServer : IStartup, IDisposable
    {
        private readonly RequestDelegate _app;
        private readonly IWebHost _host;

        public Uri Address => new Uri(_host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First());

        public TestServer(Action<HttpContext> app) : this(context => { app(context); return Task.CompletedTask; })
        {
        }

        public TestServer(RequestDelegate app, bool https = false)
        {
            _app = app;
            _host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.Limits.MaxRequestBodySize = null;
                    options.Listen(new IPEndPoint(IPAddress.Loopback, 0), listenOptions =>
                    {
                        if (https)
                        {
                            listenOptions.UseHttps(TestEnvironment.DevCertPath, TestEnvironment.DevCertPassword, config =>
                            {
                                config.ClientCertificateMode = Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.AllowCertificate;
                                config.ClientCertificateValidation = (_, _, _) => true;
                            });
                        }
                    });
                })
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
