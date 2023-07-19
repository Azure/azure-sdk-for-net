// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.AnomalyDetector.Tests
{
    public class AnomalyDetectorLiveTestBase : RecordedTestBase<AnomalyDetectorTestEnvironment>
    {
        public AnomalyDetectorLiveTestBase(bool isAsync) : base(isAsync)
        {
            {
                JsonPathSanitizers.Add("$..accessToken");
                JsonPathSanitizers.Add("$..source");
                SanitizedHeaders.Add(Constants.AuthorizationHeader);
            };
        }

        /// <summary>
        /// Creates a <see cref="AnomalyDetectorClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="AnomalyDetectorTestEnvironment.ApiKey"/>.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="AnomalyDetectorClient" />.</returns>
        protected AnomalyDetectorClient CreateAnomalyDetectorClient(bool useTokenCredential = false, string apiKey = default, bool skipInstrumenting = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new AnomalyDetectorClientOptions());
            AnomalyDetectorClient client;

            if (useTokenCredential)
            {
                AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.Credential.ToString());
                client = new AnomalyDetectorClient(endpoint, credential, options: options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                client = new AnomalyDetectorClient(endpoint, credential, options: options);
            }

            return skipInstrumenting ? client : InstrumentClient(client);
        }
    }
}
