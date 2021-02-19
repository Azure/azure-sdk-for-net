// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Azure.Core.Pipeline;
    using Azure.Core.TestFramework;
    using Azure.Identity;

    using Microsoft.Azure.ApplicationInsights.Query;
    using Microsoft.Azure.ApplicationInsights.Query.Models;
    using Microsoft.Rest.Azure.Authentication;

    using NUnit.Framework;

    public abstract class AzureMonitorTestBase : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        public int FlushTimeoutMilliseconds = 1000;

        public AzureMonitorTestBase(bool isAsync) : base(isAsync) { }

        public AzureMonitorTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }

        [SetUp]
        public void SetUp()
        {
            /// <see cref="ApplicationInsightsDataClient"/> and <see cref="HttpClient"/> are not fully compatible with the Azure.Core.TestFramework.
            /// We must disable the Client validation for tests to run.
            this.ValidateClientInstrumentation = false;
        }

        /// <summary>
        /// We need to have one TEST for NUnit to discover this class.
        /// </summary>
        [Test]
        public void Dummy() { }

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
        /// Uses the TestEnvironment to log into Application Insights using a Service Principal.
        /// These values are created when running the New-TestResources.ps1 script.
        /// The code here comes from the sample provided in the Application Insights REST API doc.
        /// (https://dev.applicationinsights.io/documentation/Tools/CSharp-Sdk).
        /// </summary>
        /// <remarks>
        /// Alternatively for manual testing, can supply an Application Insights API Key.
        /// (https://dev.applicationinsights.io/documentation/Authorization/API-key-and-App-ID).
        /// <code>var creds = new ApiKeyClientCredentials("00000000-0000-0000-0000-000000000000");</code>
        /// </remarks>
        protected async Task<ApplicationInsightsDataClient> GetApplicationInsightsDataClientAsync()
        {
            var clientId = TestEnvironment.ClientId;
            var clientSecret = TestEnvironment.ClientSecret;
            var domain = TestEnvironment.TenantId;
            var authEndpoint = "https://login.microsoftonline.com";
            var tokenAudience = "https://api.applicationinsights.io/";
            var adSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(authEndpoint),
                TokenAudience = new Uri(tokenAudience),
                ValidateAuthority = true
            };

            var creds = await ApplicationTokenProvider.LoginSilentAsync(domain, clientId, clientSecret, adSettings);

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
            var period = GetWaitPeriod(); // query once every 30 seconds.

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

            if (telemetry == null)
            {
                Assert.Inconclusive("Failed to query telemetry from Kusto. This is not necessarily a test failure, this could be a result of an ingestion delay.");
            }

            return telemetry;
        }

        /// <summary>
        /// Application Insights ingestion is not immediate.
        /// Unit tests need to consider the <see cref="RecordedTestMode"/> and wait accordingly.
        /// </summary>
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
