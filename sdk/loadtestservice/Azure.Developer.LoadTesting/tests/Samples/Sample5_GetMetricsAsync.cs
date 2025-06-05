// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetMetricsAsync()
        {
#if SNIPPET
            // The data-plane endpoint is obtained from Control Plane APIs with "https://"
            // To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
            Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
            TokenCredential credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            Uri endpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;
#endif

            // creating LoadTesting TestRun Client
            LoadTestRunClient loadTestRunClient = new LoadTestRunClient(endpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_GetMetricsAsync

            string testId = "my-loadtest";
            string resourceId = TestEnvironment.ResourceId;
            string testRunId = "my-loadtest-run";

            // all other data to be sent to testRun
            var data = new
            {
                testid = testId,
                displayName = "My display name"
            };

            try
            {
                Response getTestRunResponse = await loadTestRunClient.GetTestRunAsync(testRunId);
                JsonDocument testRunJson = JsonDocument.Parse(getTestRunResponse.Content.ToString());

                Response getMetricNamespaces = await loadTestRunClient.GetMetricNamespacesAsync(testRunId);
                JsonDocument metricNamespacesJson = JsonDocument.Parse(getMetricNamespaces.Content.ToString());

                Response getMetricDefinitions = await loadTestRunClient.GetMetricDefinitionsAsync(
                    testRunId, metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").ToString()
                    );
                JsonDocument metricDefinitionsJson = JsonDocument.Parse(getMetricDefinitions.Content.ToString());

                AsyncPageable<BinaryData> metrics = loadTestRunClient.GetMetricsAsync(
                        testRunId,
                        metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                        metricDefinitionsJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                        testRunJson.RootElement.GetProperty("startDateTime").GetString() + "/" + testRunJson.RootElement.GetProperty("endDateTime")
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }
    }
}
