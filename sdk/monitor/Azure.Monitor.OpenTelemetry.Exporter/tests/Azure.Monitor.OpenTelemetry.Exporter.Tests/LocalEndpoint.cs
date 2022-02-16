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
    internal class LocalEndpoint : IDisposable
    {
        private readonly IWebHost host;

        public Func<HttpContext, Task> ServerLogic;

        public LocalEndpoint(string url)
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
                // https://github.com/aspnet/KestrelHttpServer/issues/1513
            }
        }
    }
}
