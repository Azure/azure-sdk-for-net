// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsQueryClientSamples: SamplesBase<MonitorQueryTestEnvironment>
    {
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21657")]
        public async Task QueryMetrics()
        {
            #region Snippet:QueryMetrics
#if SNIPPET
            string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/<resource_provider>/<resource>";
#else
            string resourceId = TestEnvironment.MetricsResource;
#endif
            #region Snippet:CreateMetricsClient
            var client = new MetricsQueryClient(new DefaultAzureCredential());
            #endregion

            Response<MetricsQueryResult> results = await client.QueryResourceAsync(
                resourceId,
                new[] { "SuccessfulCalls", "TotalCalls" }
            );

            foreach (MetricResult metric in results.Value.Metrics)
            {
                Console.WriteLine(metric.Name);
                foreach (MetricTimeSeriesElement element in metric.TimeSeries)
                {
                    Console.WriteLine("Dimensions: " + string.Join(",", element.Metadata));

                    foreach (MetricValue value in element.Values)
                    {
                        Console.WriteLine(value);
                    }
                }
            }
            #endregion
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21657")]
        public async Task QueryMetricsWithAggregations()
        {
            #region Snippet:QueryMetricsWithAggregations
#if SNIPPET
            string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.KeyVault/vaults/TestVault";
#else
            string resourceId = TestEnvironment.MetricsResource;
#endif
            var client = new MetricsQueryClient(new DefaultAzureCredential());

            Response<MetricsQueryResult> result = await client.QueryResourceAsync(
                resourceId,
                new[] { "Availability" },
                new MetricsQueryOptions
                {
                    Aggregations =
                    {
                        MetricAggregationType.Average,
                    }
                });

            MetricResult metric = result.Value.Metrics[0];

            foreach (MetricTimeSeriesElement element in metric.TimeSeries)
            {
                foreach (MetricValue value in element.Values)
                {
                    // Prints a line that looks like the following:
                    // 6/21/2022 12:29:00 AM +00:00 : 100
                    Console.WriteLine($"{value.TimeStamp} : {value.Average}");
                }
            }
            #endregion
        }
    }
}
