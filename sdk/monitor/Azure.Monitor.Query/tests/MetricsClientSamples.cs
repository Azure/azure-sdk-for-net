// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsClientSamples: SamplesBase<MonitorQueryClientTestEnvironment>
    {
        [Test]
        public async Task QueryMetrics()
        {
            #region Snippet:QueryMetrics

#if SNIPPET
            Uri endpoint = new Uri("https://management.azure.com");
            string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.OperationalInsights/workspaces/<workspace_name>";
#else
            Uri endpoint = TestEnvironment.LogsEndpoint;
            string resourceId = TestEnvironment.MetricsResource;
#endif

            var metricsClient = new MetricsClient(endpoint, new DefaultAzureCredential());

            Response<MetricQueryResult> results = await metricsClient.QueryAsync(
                resourceId,
                new[] {"Microsoft.OperationalInsights/workspaces"}
            );

            foreach (var metric in results.Value.Metrics)
            {
                Console.WriteLine(metric.Name);
                foreach (var element in metric.TimeSeries)
                {
                    Console.WriteLine("Dimensions: " + string.Join(",", element.Metadata));

                    foreach (var metricValue in element.Data)
                    {
                        Console.WriteLine(metricValue);
                    }
                }
            }
            #endregion
        }
    }
}