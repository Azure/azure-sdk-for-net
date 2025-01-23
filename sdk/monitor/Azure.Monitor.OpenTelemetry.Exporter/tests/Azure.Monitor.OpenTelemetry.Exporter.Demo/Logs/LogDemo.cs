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
                    options.IncludeScopes = true;
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

            // Option 1
            // This is the simplest way to create a Custom Event
            logger.LogInformation("{microsoft.custom_event.name}", "HelloWorld");

            // Option 2a
            // Problems start to arise when you want to add additional properties to the event.
            // This is because the ILogger api doesn't provide any mechanims to add additional properties.
            // This is not ideal and a little ugly, but it technically works.
            logger.LogInformation("{microsoft.custom_event.name} {key1} {key2}", "HelloWorld2", "value1", "value2");

            // Option 2b
            // There's another option using ILegger Scopes.
            // But we don't want to recommend this to our users because this might be deprecated and it's very ugly.
            using (logger.BeginScope(new List<KeyValuePair<string, object>>
                    {
                        new("microsoft.custom_event.name", "HelloWorld3"),
                        new("key1", "value1"),
                        new("key2", "value2"),
                    }))
            {
                logger.LogInformation("Some Message");
            }

            // Option 3
            // This is the largest problem.
            // What I'm showing here is called Compile-time logging source generation
            // This is the newest ILogger api and it's recommended because it's much more performant.
            // Unfortunately this is not compatible with the key word we want to use for Custom Events.
            //logger.SomeCustomEvent("HelloWorld");
        }

        public void Dispose()
        {
            this.loggerFactory.Dispose();
        }
    }

    //[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Demo")]
    //internal static partial class CustomEventExtensions
    //{
    //    [LoggerMessage(LogLevel.Information, "{microsoft.custom_event.name}, {key1}, {key2}")]
    //    public static partial void SomeCustomEvent(this ILogger logger, string microsoft.custom_event.name, string key1, string key2);
    //}
}
