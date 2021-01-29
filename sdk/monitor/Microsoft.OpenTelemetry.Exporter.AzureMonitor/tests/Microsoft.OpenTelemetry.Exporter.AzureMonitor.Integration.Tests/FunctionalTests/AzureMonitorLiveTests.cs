// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.FunctionalTests
{
    using System;
    using System.Threading.Tasks;

    using Azure.Core.TestFramework;

    using global::OpenTelemetry;
    using global::OpenTelemetry.Logs;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    public class AzureMonitorLiveTests : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        public AzureMonitorLiveTests(bool isAsync) :
            base(isAsync, RecordedTestMode.Record)
        {
            //...
        }

        [Test]
        public void Dummy() { }

        [RecordedTest]
        public async Task VerifyCanLog()
        {
            var logger = GetLogger();
            logger.Log(logLevel: LogLevel.Information, message: "Hello World");

            // VERIFY
            // TODO: Query logs from Kusto https://dev.applicationinsights.io/quickstart

            //await Task.Run(() => Guid.NewGuid());
            await Task.Delay(10000);
        }

        [RecordedTest]
        public void WillFail()
        {
            throw new NotImplementedException("hello");
        }

        private ILogger<AzureMonitorLiveTests> GetLogger()
        {
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
            var logger = serviceProvider.GetRequiredService<ILogger<AzureMonitorLiveTests>>();
            return logger;
        }
    }
}
