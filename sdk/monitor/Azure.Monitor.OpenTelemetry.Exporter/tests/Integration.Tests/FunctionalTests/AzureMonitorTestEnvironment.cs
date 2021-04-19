// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.FunctionalTests
{
    using System;
    using System.Threading.Tasks;

    using Azure.Core.TestFramework;

    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;

    public class AzureMonitorTestEnvironment : TestEnvironment
    {
        public AzureMonitorTestEnvironment() : base() { }

        /// <summary>
        /// Connection String is used to connect to an Application Insights resource.
        /// This value comes from the ARM Template.
        /// </summary>
        public string ConnectionString => GetRecordedVariable(EnvironmentVariableNames.ConnectionString);

        /// <summary>
        /// Application ID is used to identify an Application Insights resource when querying telemetry from the REST API.
        /// This value comes from the ARM Template.
        /// </summary>
        public string ApplicationId => GetRecordedVariable(EnvironmentVariableNames.ApplicationId);

        public bool IsTestModeLive => this.Mode != RecordedTestMode.Playback;

        /// <summary>
        /// Get a <see cref="ServiceClientCredentials"/> needed by <see cref="ApplicationInsightsDataClient"/> to query Kusto.
        /// - IN LIVE OR RECORD TEST MODE
        /// Uses the TestEnvironment to log into Application Insights using a Service Principal.
        /// These values are created when running the New-TestResources.ps1 script.
        /// - IN PLAYBACK TEST MODE
        /// Return an instance of <see cref="TokenCredentials"/>.
        /// </summary>
        public async Task<ServiceClientCredentials> GetServiceClientCredentialsAsync()
        {
            if (this.IsTestModeLive)
            {
                var authEndpoint = "https://login.microsoftonline.com";
                var tokenAudience = "https://api.applicationinsights.io/";
                var adSettings = new ActiveDirectoryServiceSettings
                {
                    AuthenticationEndpoint = new Uri(authEndpoint),
                    TokenAudience = new Uri(tokenAudience),
                    ValidateAuthority = true
                };

                return await ApplicationTokenProvider.LoginSilentAsync(
                    domain: this.TenantId,
                    clientId: this.ClientId,
                    secret: this.ClientSecret,
                    settings: adSettings);
            }
            else
            {
                return new TokenCredentials("testValue");
            }
        }

        internal static class EnvironmentVariableNames
        {
            public const string ConnectionString = "CONNECTION_STRING";
            public const string ApplicationId = "APPLICATION_ID";
        }
    }
}
