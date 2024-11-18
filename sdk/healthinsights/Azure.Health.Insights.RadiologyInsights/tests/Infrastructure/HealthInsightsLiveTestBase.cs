// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights;
using Azure.Identity;

namespace Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure
{
    public class HealthInsightsLiveTestBase : RecordedTestBase<HealthInsightsTestEnvironment>
    {
        public HealthInsightsLiveTestBase(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..source");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
            IgnoredHeaders.Add("Repeatability-Request-ID");
            IgnoredHeaders.Add("Repeatability-First-Sent");
        }

        /// <summary>
        /// Creates a <see cref="RadiologyInsightsClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="HealthInsightsTestEnvironment.ApiKey"/>.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="RadiologyInsightsClient" />.</returns>
        public RadiologyInsightsClient CreateRadiologyInsightsClient(bool useTokenCredential = false, string apiKey = default, bool skipInstrumenting = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new RadiologyInsightsClientOptions());
            RadiologyInsightsClient client;
            TokenCredential credential;

            if (Mode == RecordedTestMode.Playback)
            {
                credential = new MockCredential();
            }
            else
            {
                credential = new DefaultAzureCredential();
            }
            client = new RadiologyInsightsClient(endpoint, credential, options);
            return skipInstrumenting ? client : InstrumentClient(client);
        }
    }
}
