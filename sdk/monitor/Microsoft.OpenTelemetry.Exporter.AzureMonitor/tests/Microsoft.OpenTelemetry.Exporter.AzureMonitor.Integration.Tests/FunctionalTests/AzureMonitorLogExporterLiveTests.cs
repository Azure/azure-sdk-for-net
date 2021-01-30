// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.FunctionalTests
{
    using System;
    using System.Net.Http;
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

            // ACT
            logger.Log(logLevel: LogLevel.Information, message: "Hello World");

            processor.ForceFlush();

            await Task.Delay(0);

            // VERIFY
            // TODO: Query logs from Kusto https://dev.applicationinsights.io/quickstart
            // TODO: FETCH TELEMETRY FROM AZURE MONITOR

            // TODO: PROGRAMATICALLY FETCH API KEY
            // https://dev.applicationinsights.io/documentation/Authorization/API-key-and-App-ID
            // https://docs.microsoft.com/en-us/cli/azure/ext/application-insights/monitor/app-insights/api-key?view=azure-cli-latest

            // TODO: Might be able to use this instead
            // https://dev.applicationinsights.io/documentation/Tools/CSharp-Sdk
            // https://www.nuget.org/packages/Microsoft.Azure.ApplicationInsights.Query
            // https://github.com/Azure/azure-sdk-for-net/tree/Microsoft.Azure.ApplicationInsights.Query_1.0.0/sdk/applicationinsights/Microsoft.Azure.ApplicationInsights.Query

            client.DefaultRequestHeaders.Add("x-api-key", "");
            string appId = TestEnvironment.ApplicationId;
            var path = $"https://api.applicationinsights.io/v1/apps/{appId}/query?query=traces%7C%20where%20message%20%3D%3D%20%22Hello%20World!%22";
            HttpResponseMessage response = await client.GetAsync(path);
            Assert.IsTrue(response.IsSuccessStatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();

            //var product = await response.Content.ReadAsAsync<Product>();

            Assert.Inconclusive();
        }
    }
}
