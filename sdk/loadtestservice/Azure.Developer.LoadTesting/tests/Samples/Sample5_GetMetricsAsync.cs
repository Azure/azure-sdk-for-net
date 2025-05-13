﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

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
                var getTestRunResponse = await loadTestRunClient.GetTestRunAsync(testRunId);
                var testRun = getTestRunResponse.Value;

                var getMetricNamespaces = await loadTestRunClient.GetMetricNamespacesAsync(testRunId);
                var metricNamespaces = getMetricNamespaces.Value;

                var getMetricDefinitions = await loadTestRunClient.GetMetricDefinitionsAsync(
                    testRunId, metricNamespaces.Value.First().Name
                    );
                var metricDefinitions = getMetricDefinitions.Value;

                var metricsPagedResponse = loadTestRunClient.GetMetricsAsync(
                        testRunId,
                        metricNamespaces.Value.First().Name,
                        metricDefinitions.Value.First().Name,
                        testRun.StartDateTime.Value.ToString("o") + "/" + testRun.EndDateTime.Value.ToString("o")
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
