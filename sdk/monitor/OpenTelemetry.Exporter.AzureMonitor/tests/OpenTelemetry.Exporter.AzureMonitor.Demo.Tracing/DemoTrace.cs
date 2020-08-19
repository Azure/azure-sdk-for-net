// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace OpenTelemetry.Exporter.AzureMonitor.Demo.Tracing
{
    public static class DemoTrace
    {
        public static readonly ActivitySource source = new ActivitySource("DemoSource");

        public static void Main()
        {
            OpenTelemetry.Sdk.CreateTracerProvider(builder => builder
                                .AddActivitySource("Samples.SampleServer")
                                .AddActivitySource("Samples.SampleClient")
                                .UseAzureMonitorTraceExporter(o => {
                                    o.ConnectionString = "ConnectionString";
                                }));

            using (var sample = new InstrumentationWithActivitySource())
            {
                sample.Start();

                System.Console.WriteLine("Press ENTER to stop.");
                System.Console.ReadLine();
            }
        }
    }
}
