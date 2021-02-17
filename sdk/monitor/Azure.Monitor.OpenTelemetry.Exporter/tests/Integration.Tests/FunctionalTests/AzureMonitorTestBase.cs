// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using System;
    using System.Threading.Tasks;

    using global::Azure.Core.TestFramework;

    using Microsoft.Azure.ApplicationInsights.Query;
    using Microsoft.Rest.Azure.Authentication;

    using NUnit.Framework;

    public abstract class AzureMonitorTestBase : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        public int FlushTimeoutMilliseconds = 1000;

        public AzureMonitorTestBase(bool isAsync) : base(isAsync) { }

        public AzureMonitorTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }

        /// <summary>
        /// We need to have one TEST in this class for NUnit to discover this class.
        /// </summary>
        [Test]
        public void Dummy() { }

        /// <remarks>
        /// TODO: The <see cref="AzureMonitorLogExporter" /> is currently INTERNAL while under development.
        /// When this Exporter is finished, this method can be changed to PUBLIC.
        /// </remarks>
        internal AzureMonitorLogExporter GetAzureMonitorLogExporter()
        {
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

            var client = new ApplicationInsightsDataClient(creds);
            return client;
        }

        /// <summary>
        /// Application Insights ingestion is not immediate.
        /// On a good day, this can take a few minutes.
        /// Unit tests need to consider the <see cref="RecordedTestMode"/> and wait accordingly.
        /// </summary>
        protected async Task WaitForIgnestionAsync()
        {
            TimeSpan timeSpan;

            switch (this.Mode)
            {
                case RecordedTestMode.Live:
                case RecordedTestMode.Record:
                    timeSpan = TimeSpan.FromMinutes(5);
                    break;
                case RecordedTestMode.Playback:
                    timeSpan = TimeSpan.FromSeconds(0);
                    break;
                default:
                    throw new Exception($"Unknown RecordedTestMode '{this.Mode}'");
            }

            await Task.Delay(timeSpan);
        }

        /// <summary>
        /// <see cref="ApplicationInsightsDataClient"/> uses ISO 8601 Format for Durations.
        /// (https://en.wikipedia.org/wiki/ISO_8601?oldformat=true#Durations).
        /// </summary>
        protected static class QueryDuration
        {
            public static string TenMinutes = "PT10M";
        }
    }
}
