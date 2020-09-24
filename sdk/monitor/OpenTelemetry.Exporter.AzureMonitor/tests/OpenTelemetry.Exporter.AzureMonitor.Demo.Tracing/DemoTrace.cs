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
            using var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
                .AddSource("Samples.SampleServer")
                .AddSource("Samples.SampleClient")
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
