// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Resources;

using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tracing.Customization
{
    public static class Program
    {
        private static readonly ActivitySource DemoSource = new ActivitySource("OTel.AzureMonitor.Demo");
        public static void Main()
        {
            var resourceAttributes = new Dictionary<string, object> { { "service.name", "my-service" }, { "service.namespace", "my-namespace" }, { "service.instance.id", "my-instance" } };
            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(resourceBuilder) // Sets cloud_RoleName as "my-namespace.my-service" and cloud_RoleInstance as "my-instance"
                .AddProcessor(new ActivityFilteringProcessor())
                .AddProcessor(new ActivityEnrichingProcessor())
                .AddAzureMonitorTraceExporter(o =>
                {
                    o.ConnectionString = "<Your Connection String>";
                })
                .Build();

            using (var sampleActivity = DemoSource.StartActivity("TestActivity"))
            {
                sampleActivity?.AddTag("Foo", "1");
                sampleActivity?.AddTag("Bar", "Hello");
            }

            System.Console.WriteLine("Press Enter key to exit.");
            System.Console.ReadLine();
        }
    }
}
