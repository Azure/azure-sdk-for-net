// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using OpenTelemetry;
using OpenTelemetry.Resources;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
{
    public class Program
    {
        public static void Main()
        {
            GenerateTraces();
            GenerateLogs();
            GenerateMetrics();
        }

        private static void GenerateTraces()
        {
            ActivitySource source = new ActivitySource("MyCompany.MyProduct.MyLibrary");

            var resourceAttributes = new Dictionary<string, object> { { "service.name", "my-service" }, { "service.namespace", "my-namespace" }, { "service.instance.id", "my-instance" } };
            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                            .SetResourceBuilder(resourceBuilder)
                            .AddSource("MyCompany.MyProduct.MyLibrary")
                            .AddAzureMonitorTraceExporter(o =>
                            {
                                o.ConnectionString = $"InstrumentationKey=Ikey;";
                            })
                            .Build();

            using (var activity = source.StartActivity("SayHello"))
            {
                activity?.SetTag("foo", 1);
                activity?.SetTag("bar", "Hello, World!");
                activity?.SetTag("baz", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }
        }

        private static void GenerateLogs()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddAzureMonitorLogExporter(o => o.ConnectionString = $"InstrumentationKey=Ikey;");
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Hello from {name} {price}.", "tomato", 2.99);
        }

        private static void GenerateMetrics()
        {
            Meter MyMeter = new("MyCompany.MyProduct.MyLibrary", "1.0");
            Counter<long> MyFruitCounter = MyMeter.CreateCounter<long>("MyFruitCounter");

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
           .AddMeter("MyCompany.MyProduct.MyLibrary")
           .AddAzureMonitorMetricExporter(o => o.ConnectionString = $"InstrumentationKey=Ikey;")
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
