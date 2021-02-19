// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using System.Threading.Tasks;

    using Azure.Core.TestFramework;

    using global::OpenTelemetry;

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
            // TODO: For proper test isolation, we should include a CustomProperty on telemetry items.
            // CustomProperty should be unique per test method.
            // This would allow us to run tests in parallel.
            var testMessage = "Hello World";
            logger.Log(logLevel: LogLevel.Information, message: testMessage);

            var flushResult = processor.ForceFlush(this.FlushTimeoutMilliseconds);
            Assert.IsTrue(flushResult, "Processor failed to flush");

            // VERIFY
            // TODO: Need to verify additional fields. The LogExporter is still in development.
            var telemetry = await FetchTelemetryAsync();
            Assert.AreEqual(testMessage, telemetry[0].Trace.Message);
        }
    }
}
