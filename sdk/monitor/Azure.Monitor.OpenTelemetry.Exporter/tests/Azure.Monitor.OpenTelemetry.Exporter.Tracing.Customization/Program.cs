// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
            .SetResourceBuilder(resourceBuilder) // Sets ai.cloud.role as my-namespace.my-service and ai.cloud.roleinstance as my-instance.
            .AddSource("OTel.AzureMonitor.Demo")
            .AddProcessor(new ActivityEnrichingProcessor())
            .AddAzureMonitorTraceExporter(o =>
            {
                o.ConnectionString = "<Your Connection String>";
            })
            .AddOtlpExporter() // send data to otlp
            .Build();

            using (var foo = DemoSource.StartActivity("Foo"))
            {
                using (var bar = DemoSource.StartActivity("Bar"))
                {
                }
            }

            System.Console.WriteLine("Press Enter key to exit.");
            System.Console.ReadLine();
        }
    }
}
