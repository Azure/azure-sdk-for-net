// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.FunctionalTests
{
    using System.Threading.Tasks;

    using Azure.Core.TestFramework;

    using global::OpenTelemetry;
    using global::OpenTelemetry.Logs;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    public class AzureMonitorLogExporterLiveTests : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        public AzureMonitorLogExporterLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

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

            // ACT
            logger.Log(logLevel: LogLevel.Information, message: "Hello World");

            processor.ForceFlush();

            await Task.Delay(0);

            // VERIFY
            // TODO: Query logs from Kusto https://dev.applicationinsights.io/quickstart
            // TODO: FETCH TELEMETRY FROM AZURE MONITOR
            Assert.Inconclusive();
        }
    }
}
