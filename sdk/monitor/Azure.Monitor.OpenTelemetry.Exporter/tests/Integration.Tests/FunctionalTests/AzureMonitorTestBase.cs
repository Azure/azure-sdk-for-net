// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Azure.Core;
    using Azure.Core.Pipeline;
    using Azure.Core.TestFramework;

    using Microsoft.Azure.ApplicationInsights.Query;
    using Microsoft.Azure.ApplicationInsights.Query.Models;

    using NUnit.Framework;

    public abstract class AzureMonitorTestBase : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        public int FlushTimeoutMilliseconds = 15000;

        public AzureMonitorTestBase(bool isAsync) : base(isAsync) { }

        public AzureMonitorTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }

        [SetUp]
        public void SetUp()
        {
            /// <see cref="ApplicationInsightsDataClient"/> and <see cref="HttpClient"/> are not fully compatible with the Azure.Core.TestFramework.
            /// We must disable the Client validation for tests to run.
            this.ValidateClientInstrumentation = false;
        }

        /// <remarks>
        /// TODO: The <see cref="AzureMonitorLogExporter" /> is currently INTERNAL while under development.
        /// When this Exporter is finished, this method can be changed to PUBLIC.
        /// </remarks>
        internal AzureMonitorLogExporter GetAzureMonitorLogExporter()
        {
            // TODO: I WOULD LIKE TO TAKE ADVANTAGE OF THIS: https://github.com/open-telemetry/opentelemetry-dotnet/pull/1837
            // In these tests we have to manually build the Exporter and processor so we can call ForceFlush in the tests.
            // But we would expect customers to use the Extension method.

            var exporterOptions = new AzureMonitorExporterOptions
            {
                ConnectionString = TestEnvironment.ConnectionString,
            };

            var clientOptions = this.InstrumentClientOptions(exporterOptions);

            return new AzureMonitorLogExporter(clientOptions);
        }

        /// <summary>
        /// Get an instance of <see cref="ApplicationInsightsDataClient"/> which can be used to query telemetry.
        /// See also: (https://dev.applicationinsights.io/documentation/Tools/CSharp-Sdk).
        /// </summary>
        /// <remarks>
        /// Alternatively for manual testing, can supply an Application Insights API Key.
        /// (https://dev.applicationinsights.io/documentation/Authorization/API-key-and-App-ID).
        /// <code>var creds = new ApiKeyClientCredentials("00000000-0000-0000-0000-000000000000");</code>
        /// </remarks>
        protected async Task<ApplicationInsightsDataClient> GetApplicationInsightsDataClientAsync()
        {
            var creds = await TestEnvironment.GetServiceClientCredentialsAsync();
            var handler = new HttpPipelineMessageHandler(new HttpPipeline(Recording.CreateTransport(new HttpClientTransport())));
            var httpClient = new HttpClient(handler);

            var client = new ApplicationInsightsDataClient(credentials: creds, httpClient: httpClient, disposeHttpClient: true);
            return client;
        }

        /// <summary>
        /// Application Insights Ingestion is not immediate.
        /// On a good day this can still take a few minutes.
        /// - IN LIVE OR RECORD TEST MODE
        /// Tests must wait before querying for telemetry.
        /// This test will wait for a short period, up to a timeout duration.
        /// - IN PLAYBACK TEST MODE
        /// Test must repeat the same behavior of the recording.
        /// In this scenario there is a negligible delay.
        /// </summary>
        /// <remarks>
        /// TODO: WHEN WE INTRODUCE MORE TESTS, WILL NEED TO ADD PARAMETERS HERE TO CUSTOMIZE THE QUERY.
        /// </remarks>
        protected async Task<IList<EventsTraceResult>> FetchTelemetryAsync()
        {
            var timeoutDuration = TimeSpan.FromMinutes(5); // timeout after 5 minutes.
            var period = TestEnvironment.IsTestModeLive ? TimeSpan.FromSeconds(10) : TimeSpan.FromSeconds(0); // query once every 10 seconds.

            var client = await this.GetApplicationInsightsDataClientAsync();
            IList<EventsTraceResult> telemetry = null;

            for (double actualDuration = 0; actualDuration <= timeoutDuration.TotalMilliseconds; actualDuration += period.TotalMilliseconds)
            {
                await Task.Delay(period);

                var queryResult = await client.Events.GetTraceEventsAsync(appId: TestEnvironment.ApplicationId, timespan: QueryDuration.TenMinutes);

                if (queryResult.Value.Any())
                {
                    telemetry = queryResult.Value;
                    break;
                }
            }

            Assert.IsNotNull(telemetry, "Failed to query telemetry. This is not necessarily a test failure and could be a result of an ingestion delay.");

            return telemetry;
        }

        /// <summary>
        /// <see cref="ApplicationInsightsDataClient"/> uses ISO 8601 Format for Durations.
        /// (https://en.wikipedia.org/wiki/ISO_8601?oldformat=true#Durations).
        /// </summary>
        protected static class QueryDuration
        {
            public const string TenMinutes = "PT10M";
        }
    }
}
