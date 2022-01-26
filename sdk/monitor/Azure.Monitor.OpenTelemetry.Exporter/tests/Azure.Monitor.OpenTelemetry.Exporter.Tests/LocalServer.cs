// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class LocalServer : IDisposable
    {
        private readonly IWebHost host;

        public Func<HttpContext, Task> ServerLogic;

        public LocalServer(string url)
        {
            this.host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(url)
                .Configure((app) =>
                {
                    app.Run(Server);
                })
                .Build();

            Task.Run(() => this.host.Run());
        }

        private Task Server(HttpContext context)
        {
            return this.ServerLogic(context);
        }

        public void Dispose()
        {
            try
            {
                this.host.Dispose();
            }
            catch (Exception)
            {
                // ignored, see https://github.com/aspnet/KestrelHttpServer/issues/1513
                // Kestrel 2.0.0 should have fix it, but it does not seem important for our tests
            }
        }
    }
}
