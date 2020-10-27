// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework;

using OpenTelemetry;
using OpenTelemetry.Trace;

using Xunit;

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests
{
    /// <summary>
    /// The purpose of these tests are to verify various types of Telemetry.
    /// </summary>
    public class TelemetryTypeTests
    {
        private const string ActivitySourceName = "MyCompany.MyProduct.MyLibrary";
        private static readonly ActivitySource MyActivitySource = new ActivitySource(ActivitySourceName);
        private const string EmptyConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Consumer)]
        [InlineData(ActivityKind.Internal)]
        [InlineData(ActivityKind.Producer)]
        [InlineData(ActivityKind.Server)]
        public void VerifyActivityAsTelemetryItem(ActivityKind activityKind)
        {
            this.Setup(processor: out BatchExportProcessor<Activity> processor, transmitter: out MockTransmitter transmitter);

            using (var activity = MyActivitySource.StartActivity(name: "TestActivity", kind: activityKind))
            {
                activity.SetTag("integer", 1);
                activity.SetTag("message", "Hello World!");
                activity.SetTag("intArray", new int[] { 1, 2, 3 });
            }

            processor.ForceFlush();
            Task.Delay(100).Wait(); //TODO: HOW TO REMOVE THIS WAIT?

            Assert.True(transmitter.TelemetryItems.Any(), "test project did not capture telemetry");
            var telemetryItem = transmitter.TelemetryItems.First();

            VerifyTelemetryItem.Verify(
                telemetryItem: telemetryItem,
                activityKind: activityKind,
                expectedVars: new ExpectedTelemetryItemValues
                {
                    Name = "TestActivity",
                    CustomProperties = new Dictionary<string, string> {
                        {"integer", "1" },
                        {"message", "Hello World!" },
                        {"intArray", "1,2,3" } }
                });
        }

        private void Setup(out BatchExportProcessor<Activity> processor, out MockTransmitter transmitter )
        {
            transmitter = new MockTransmitter();
            processor = new BatchExportProcessor<Activity>(new AzureMonitorTraceExporter(
                options: new AzureMonitorExporterOptions
                {
                    ConnectionString = EmptyConnectionString,
                },
                transmitter: transmitter));

            Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(ActivitySourceName)
                .AddProcessor(processor)
                .Build();
        }
    }
}
