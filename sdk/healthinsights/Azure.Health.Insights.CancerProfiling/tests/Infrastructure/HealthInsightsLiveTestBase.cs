// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Health.Insights.CancerProfiling;

namespace Azure.Health.Insights.CancerProfiling.Tests.Infrastructure
{
    public class HealthInsightsLiveTestBase : RecordedTestBase<HealthInsightsTestEnvironment>
    {
        public HealthInsightsLiveTestBase(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..source");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }

        /// <summary>
        /// Creates a <see cref="CancerProfilingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="HealthInsightsTestEnvironment.ApiKey"/>.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="CancerProfilingClient" />.</returns>
        public CancerProfilingClient CreateCancerProfilingClient(bool useTokenCredential = false, string apiKey = default, bool skipInstrumenting = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new CancerProfilingClientOptions());
            CancerProfilingClient client;

            if (useTokenCredential)
            {
                AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.Credential.ToString());
                client = new CancerProfilingClient(endpoint, credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                client = new CancerProfilingClient(endpoint, credential, options);
            }

            return skipInstrumenting ? client : InstrumentClient(client);
        }
    }
}
