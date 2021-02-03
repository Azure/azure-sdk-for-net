// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.FunctionalTests
{
    using System.Net.Http;
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

        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// We need to have one TEST in this class for NUnit to discover this class.
        /// </summary>
        [Test]
        public void Dummy() { }

        [RecordedTest]
        public async Task VerifyCanLog()
        {
            // SETUP
            var options = this.InstrumentClientOptions(new AzureMonitorExporterOptions
            {
                ConnectionString = TestEnvironment.ConnectionString,
            });

            var processor = new BatchExportProcessor<LogRecord>(new AzureMonitorLogExporter(options));

            var serviceCollection = new ServiceCollection().AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace)
                    .AddOpenTelemetry(options => options
                        .AddProcessor(processor));
            });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<AzureMonitorLogExporterLiveTests>>();

            var testMessage = "Hello World";

            // ACT
            logger.Log(logLevel: LogLevel.Information, message: testMessage);

            processor.ForceFlush();

            await this.WaitForIgnestionAsync();

            // VERIFY
            var client = await this.GetApplicationInsightsDataClientAsync();

            var test = await client.Events.GetTraceEventsAsync(appId: TestEnvironment.ApplicationId, timespan: QueryDuration.TenMinutes);
            Assert.AreEqual(testMessage, test.Value[0].Trace.Message);
        }
    }
}
