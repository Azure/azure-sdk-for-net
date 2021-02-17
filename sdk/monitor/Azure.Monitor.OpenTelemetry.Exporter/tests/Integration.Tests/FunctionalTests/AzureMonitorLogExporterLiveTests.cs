// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using System.Threading.Tasks;

    using global::Azure.Core.TestFramework;

    using global::OpenTelemetry;
    using global::OpenTelemetry.Logs;

    using Microsoft.Azure.ApplicationInsights.Query;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    /// <summary>
    /// Collection of tests to evaluate the <see cref="AzureMonitorLogExporter"/>.
    /// </summary>
    public class AzureMonitorLogExporterLiveTests : AzureMonitorTestBase
    {
        public AzureMonitorLogExporterLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

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
            await this.WaitForIgnestionAsync();

            // VERIFY
            // TODO: NEED TO WORK WITH PAVEL TO MAKE THIS STUBBABLE SO IT CAN BE USED IN RECORDED TESTS
            var client = await this.GetApplicationInsightsDataClientAsync();

            var telemetry = await client.Events.GetTraceEventsAsync(appId: TestEnvironment.ApplicationId, timespan: QueryDuration.TenMinutes);
            Assert.AreEqual(testMessage, telemetry.Value[0].Trace.Message);
            Assert.AreEqual(TestEnvironment.InstrumentationKey, telemetry.Value[0].Ai.IKey);
        }
    }
}
