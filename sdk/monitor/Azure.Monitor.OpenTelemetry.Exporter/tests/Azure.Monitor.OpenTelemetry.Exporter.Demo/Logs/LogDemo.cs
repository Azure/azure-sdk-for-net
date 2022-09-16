// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Logs
{
    internal class LogDemo : IDisposable
    {
        private readonly ILoggerFactory loggerFactory;

        public LogDemo(string connectionString)
        {
            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddAzureMonitorLogExporter(o => o.ConnectionString = connectionString);
                });
            });
        }

        public void GenerateLogs()
        {
            var logger = this.loggerFactory.CreateLogger<LogDemo>();
            logger.LogInformation("Hello from {name} {price}.", "tomato", 2.99);
        }

        public void Dispose()
        {
            this.loggerFactory.Dispose();
        }
    }
}
