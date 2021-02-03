// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.FunctionalTests
{
    using System.Threading.Tasks;

    using global::Azure.Core.TestFramework;

    using global::OpenTelemetry;
    using global::OpenTelemetry.Logs;

    using Microsoft.Azure.ApplicationInsights.Query;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

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
            var processor = new BatchExportProcessor<LogRecord>(exporter);

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

            processor.ForceFlush();

            await this.WaitForIgnestionAsync();

            // VERIFY
            // TODO: NEED TO WORK WITH PAVEL TO MAKE THIS STUBBABLE SO IT CAN BE USED IN RECORDED TESTS
            var client = await this.GetApplicationInsightsDataClientAsync();

            var telemetry = await client.Events.GetTraceEventsAsync(appId: TestEnvironment.ApplicationId, timespan: QueryDuration.TenMinutes);
            Assert.AreEqual(testMessage, telemetry.Value[0].Trace.Message);
        }
    }
}
