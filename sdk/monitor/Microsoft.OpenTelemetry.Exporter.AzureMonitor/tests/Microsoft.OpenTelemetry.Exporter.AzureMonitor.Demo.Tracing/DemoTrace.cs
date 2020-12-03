// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Resources;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Demo.Tracing
{
    public static class DemoTrace
    {
        public static readonly ActivitySource source = new ActivitySource("DemoSource");

        public static void Main()
        {
            var resource = Resources.CreateServiceResource("my-service", "roleinstance1", "my-namespace");
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
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
