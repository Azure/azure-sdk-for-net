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
            var resourceAttributes = new Dictionary<string, object> {
                                        { "service.name", "my-service" },
                                        { "service.namespace", "my-namespace" },
                                        { "service.instance.id", "my-instance" }};

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);

            // For otlp: OpenTelemetry Collector with an OTLP receiver should be running.
            // For details refer to https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/examples/Console/TestOtlpExporter.cs
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("OTel.AzureMonitor.Demo")
                .SetResourceBuilder(resourceBuilder) // Sets cloud_RoleName as "my-namespace.my-service" and cloud_RoleInstance as "my-instance"
                .AddProcessor(new ActivityFilteringProcessor())
                .AddProcessor(new ActivityEnrichingProcessor())
                .AddAzureMonitorTraceExporter(o =>
                {
                    o.ConnectionString = "<Your Connection String>";
                })
                .AddOtlpExporter()
                .Build();

            using (var testActivity1 = DemoSource.StartActivity("TestInternalActivity", ActivityKind.Internal))
            {
                testActivity1?.SetTag("CustomTag1", "Value1");
                testActivity1?.SetTag("CustomTag2", "Value2");
            }

            using (var testActivity2 = DemoSource.StartActivity("TestServerActivity", ActivityKind.Server))
            {
                testActivity2?.SetTag("CustomTag1", "Value1");
                testActivity2?.SetTag("CustomTag2", "Value2");
            }

            System.Console.WriteLine("Press Enter key to exit.");
            System.Console.ReadLine();
        }
    }
}
