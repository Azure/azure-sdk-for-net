// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Resources;
using System.Diagnostics;

// This alias is necessary because it will otherwise try to default to "Microsoft.Azure.Monitor.OpenTelemetry.Sdk" which doesn't exist.
using OpenTelemetrySdk = OpenTelemetry.Sdk;

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
{
    public static class DemoTrace
    {
        public static readonly ActivitySource source = new ActivitySource("DemoSource");

        public static void Main()
        {
            var resource = Resources.CreateServiceResource("my-service", "roleinstance1", "my-namespace");
            using var tracerProvider = OpenTelemetrySdk.CreateTracerProviderBuilder()
                .SetResource(resource)
                .AddSource("Demo.DemoServer")
                .AddSource("Demo.DemoClient")
                .AddAzureMonitorTraceExporter(o => {
                    o.ConnectionString = $"InstrumentationKey=Ikey;";
                })
                .Build();

            using (var sample = new InstrumentationWithActivitySource())
            {
                sample.Start();

                System.Console.WriteLine("Press ENTER to stop.");
                System.Console.ReadLine();
            }
        }
    }
}
