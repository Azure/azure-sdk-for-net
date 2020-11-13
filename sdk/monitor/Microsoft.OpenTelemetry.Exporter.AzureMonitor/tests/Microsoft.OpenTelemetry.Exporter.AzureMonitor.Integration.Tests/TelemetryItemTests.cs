// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.TestFramework;

using OpenTelemetry;
using OpenTelemetry.Trace;

using Xunit;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests
{
    /// <summary>
    /// The purpose of these tests are to verify various types of Telemetry.
    /// </summary>
    public class TelemetryItemTests
    {
        private const string ActivitySourceName = "MyCompany.MyProduct.MyLibrary";
        private static readonly ActivitySource MyActivitySource = new ActivitySource(ActivitySourceName);
        private const string EmptyConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        /// <summary>
        /// This test creates an Activity that should pass through the OpenTelemetry pipeline.
        /// AzureMonitorExporter will convert this to a <see cref="TelemetryItem"/>.
        /// This test will validate the TelemetryItem against expected values.
        /// </summary>
        /// <param name="activityKind"></param>
        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Consumer)]
        [InlineData(ActivityKind.Internal)]
        [InlineData(ActivityKind.Producer)]
        [InlineData(ActivityKind.Server)]
        public void VerifyActivity(ActivityKind activityKind)
        {
            this.Setup(processor: out BatchExportProcessor<Activity> processor, transmitter: out MockTransmitter transmitter);

            var activityName = "TestActivity";
            using (var activity = MyActivitySource.StartActivity(name: activityName, kind: activityKind))
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
                    Name = activityName,
                    CustomProperties = new Dictionary<string, string> {
                        {"integer", "1" },
                        {"message", "Hello World!" },
                        {"intArray", "1,2,3" } }
                });
        }

        // TODO: ADD THIS TEST AFTER IMPLEMENTING ILOGGER EXPORTER
        //public void VerifyILoggerAsTelemetryItem

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
