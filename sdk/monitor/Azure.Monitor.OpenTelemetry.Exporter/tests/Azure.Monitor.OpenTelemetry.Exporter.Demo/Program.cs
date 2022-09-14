// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo
{
    public class Program
    {
        private const string ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
        private static readonly ActivitySource source = new ActivitySource("MyCompany.MyProduct.MyLibrary");
        private static readonly Meter MyMeter = new("MyCompany.MyProduct.MyLibrary", "1.0");

        public static void Main()
        {
            GenerateTraces();
            GenerateLogs();
            GenerateMetrics();
        }

        private static void GenerateTraces()
        {
            var resourceAttributes = new Dictionary<string, object> { { "service.name", "my-service" }, { "service.namespace", "my-namespace" }, { "service.instance.id", "my-instance" } };
            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                            .SetResourceBuilder(resourceBuilder)
                            .AddSource("MyCompany.MyProduct.MyLibrary")
                            .AddAzureMonitorTraceExporter(o =>
                            {
                                o.ConnectionString = ConnectionString;
                            })
                            .Build();

            using (var activity = source.StartActivity("SayHello"))
            {
                activity?.SetTag("foo", 1);
                activity?.SetTag("baz", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);

                using (var nestedActivity = source.StartActivity("SayHelloAgain"))
                {
                    nestedActivity?.SetTag("bar", "Hello, World!");
                    nestedActivity?.SetStatus(ActivityStatusCode.Ok);
                }
            }
        }

        private static void GenerateLogs()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddAzureMonitorLogExporter(o => o.ConnectionString = ConnectionString);
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Hello from {name} {price}.", "tomato", 2.99);
        }

        private static void GenerateMetrics()
        {
            Counter<long> MyFruitCounter = MyMeter.CreateCounter<long>("MyFruitCounter");

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                                         .AddMeter("MyCompany.MyProduct.MyLibrary")
                                         .AddAzureMonitorMetricExporter(o => o.ConnectionString = ConnectionString)
                                         .Build();

            MyFruitCounter.Add(1, new("name", "apple"), new("color", "red"));
            MyFruitCounter.Add(2, new("name", "lemon"), new("color", "yellow"));
            MyFruitCounter.Add(1, new("name", "lemon"), new("color", "yellow"));
            MyFruitCounter.Add(2, new("name", "apple"), new("color", "green"));
            MyFruitCounter.Add(5, new("name", "apple"), new("color", "red"));
            MyFruitCounter.Add(4, new("name", "lemon"), new("color", "yellow"));
        }
    }
}
