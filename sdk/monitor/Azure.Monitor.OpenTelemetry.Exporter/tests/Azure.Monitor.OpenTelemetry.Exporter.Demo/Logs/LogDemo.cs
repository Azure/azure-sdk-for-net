// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Logs
{
    internal class LogDemo : IDisposable
    {
        private readonly ILoggerFactory loggerFactory;

        public LogDemo(string connectionString, TokenCredential? credential = null)
        {
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", "my-service" },
                { "service.namespace", "my-namespace" },
                { "service.instance.id", "my-instance" },
                { "service.version", "1.0.0-demo" },
            };

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.SetResourceBuilder(resourceBuilder);
                    options.AddAzureMonitorLogExporter(o => o.ConnectionString = connectionString, credential);
                });
            });
        }

        /// <remarks>
        /// Logs will be ingested as an Application Insights trace.
        /// These can be differentiated by their severityLevel.
        /// </remarks>
        public void GenerateLogs()
        {
            var logger = this.loggerFactory.CreateLogger<LogDemo>();
            logger.LogInformation("Hello from {name} {price}.", "tomato", 2.99);
            logger.LogError("An error occurred.");
        }

        public void Dispose()
        {
            this.loggerFactory.Dispose();
        }
    }
}
