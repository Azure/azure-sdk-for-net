// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using global::Azure.Core.TestFramework;

    using global::OpenTelemetry;

    using Microsoft.Azure.ApplicationInsights.Query;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    /// <summary>
    /// Collection of tests to evaluate the <see cref="AzureMonitorLogExporter"/>.
    /// </summary>
    public class AzureMonitorLogExporterLiveTests : AzureMonitorTestBase
    {
        public AzureMonitorLogExporterLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        public async Task VerifyLogExporter()
        {
            // SETUP
            var exporter = this.GetAzureMonitorLogExporter();
            var processor = new BatchLogRecordExportProcessor(exporter);

            var serviceCollection = new ServiceCollection().AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace)
                    .AddOpenTelemetry(options => options
                        .AddProcessor(processor));
            });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<AzureMonitorLogExporterLiveTests>>();

            // ACT
            var testMessage = "Hello World";

            // TODO: For proper test isolation, we should include a CustomProperty on telemetry items.
            // CustomProperty should be unique per test method.
            // This would allow us to run tests in parallel.
            logger.Log(logLevel: LogLevel.Information, message: testMessage);

            var flushResult = processor.ForceFlush(this.FlushTimeoutMilliseconds);
            Assert.IsTrue(flushResult, "Processor failed to flush");

            // TODO: MAYBE WE COULD HAVE A SHORT WAIT, AND IF NO TELEMETRY IS FOUND, WAIT FOR A LONGER PERIOD.
            // THIS MIGHT MAKE TEST RUN FASTER, BUT PROVIDE A TRY-AGAIN MECHANIC FOR DAYS THAT INGESTION IS HAVING A BAD DAY.
            // DON'T KNOW IF THIS WOULD BE COMPATIBLE WITH THE RECORDED TESTS
            //await this.WaitForIgnestionAsync();

            //// VERIFY
            //var client = await this.GetApplicationInsightsDataClientAsync();

            //var telemetry = await client.Events.GetTraceEventsAsync(appId: TestEnvironment.ApplicationId, timespan: QueryDuration.TenMinutes);
            //Assert.AreEqual(testMessage, telemetry.Value[0].Trace.Message);
            //Assert.AreEqual(TestEnvironment.InstrumentationKey, telemetry.Value[0].Ai.IKey);

            var telemetry = await GetTelemetry();
            Assert.AreEqual(testMessage, telemetry[0].Trace.Message);
            Assert.AreEqual(TestEnvironment.InstrumentationKey, telemetry[0].Ai.IKey);
        }

        private async Task<System.Collections.Generic.IList<Microsoft.Azure.ApplicationInsights.Query.Models.EventsTraceResult>> GetTelemetry()
        {
            var timeoutDuration = TimeSpan.FromMinutes(5); // timeout after 5 minutes.
            //var period = TimeSpan.FromSeconds(30); // query once every 30 seconds.
            var period = GetWaitPeriod(); // query once every 30 seconds.

            System.Collections.Generic.IList<Microsoft.Azure.ApplicationInsights.Query.Models.EventsTraceResult> telemetry = null;

            for (double actualDuration = 0; actualDuration < timeoutDuration.TotalMilliseconds; actualDuration += period.TotalMilliseconds)
            {
                await Task.Delay(period);

                var client = await this.GetApplicationInsightsDataClientAsync();

                var queryResult = await client.Events.GetTraceEventsAsync(appId: TestEnvironment.ApplicationId, timespan: QueryDuration.TenMinutes);

                if (queryResult.Value.Any())
                {
                    telemetry = queryResult.Value;
                    break;
                }
            }

            if (telemetry == null)
            {
                Assert.Inconclusive("Failed to query telemetry from Kusto. This is not necessarily a test failure, this could be a result of an ingestion delay.");
            }

            return telemetry;
        }

        private TimeSpan GetWaitPeriod()
        {
            switch (this.Mode)
            {
                case RecordedTestMode.Live:
                case RecordedTestMode.Record:
                    return TimeSpan.FromSeconds(30);
                case RecordedTestMode.Playback:
                    return TimeSpan.FromSeconds(0);
                default:
                    throw new Exception($"Unknown RecordedTestMode '{this.Mode}'");
            }
        }
    }
}
