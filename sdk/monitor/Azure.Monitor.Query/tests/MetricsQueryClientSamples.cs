// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsQueryClientSamples: SamplesBase<MonitorQueryTestEnvironment>
    {
        [Test]
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
#if SNIPPET
            var client = new MetricsQueryClient(new DefaultAzureCredential());
#else
            var client = new MetricsQueryClient(
                new Uri(TestEnvironment.GetMetricsAudience()),
                TestEnvironment.Credential,
                new MetricsQueryClientOptions()
                {
                    Audience = TestEnvironment.GetMetricsAudience()
                });
#endif
            #endregion

            Response<MetricsQueryResult> results = await client.QueryResourceAsync(
                resourceId,
                new[] { "Average_% Free Space", "Average_% Used Space" }
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
        public async Task QueryMetricsWithAggregations()
        {
            #region Snippet:QueryMetricsWithAggregations
#if SNIPPET
            string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.KeyVault/vaults/TestVault";
            string[] metricNames = new[] { "Availability" };
            var client = new MetricsQueryClient(new DefaultAzureCredential());
#else
            string resourceId = TestEnvironment.MetricsResource;
            string[] metricNames = new[] { "Heartbeat" };
            var client = new MetricsQueryClient(
                new Uri(TestEnvironment.GetMetricsAudience()),
                TestEnvironment.Credential,
                new MetricsQueryClientOptions()
                {
                    Audience = TestEnvironment.GetMetricsAudience()
                });
#endif
            Response <MetricsQueryResult> result = await client.QueryResourceAsync(
                resourceId,
                metricNames,
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

        [Test]
        public async Task QueryMetricsWithSplitting()
        {
            #region Snippet:QueryMetricsWithSplitting
#if SNIPPET
            string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Web/sites/TestWebApp";
            string[] metricNames = new[] { "Http2xx" };
            // Use of asterisk in filter value enables splitting on Instance dimension.
            string filter = "Instance eq '*'";
            var client = new MetricsQueryClient(new DefaultAzureCredential());
#else
            string resourceId = TestEnvironment.MetricsResource;
            string[] metricNames = new[] { "Average_% Available Memory" };
            string filter = "Computer eq '*'";
            var client = new MetricsQueryClient(
                new Uri(TestEnvironment.GetMetricsAudience()),
                TestEnvironment.Credential,
                new MetricsQueryClientOptions()
                {
                    Audience = TestEnvironment.GetMetricsAudience()
                });
#endif

            var options = new MetricsQueryOptions
            {
                Aggregations =
                {
                    MetricAggregationType.Average,
                },
                Filter = filter,
                TimeRange = TimeSpan.FromDays(2),
            };
            Response<MetricsQueryResult> result = await client.QueryResourceAsync(
                resourceId,
                metricNames,
                options);

            foreach (MetricResult metric in result.Value.Metrics)
            {
                foreach (MetricTimeSeriesElement element in metric.TimeSeries)
                {
                    foreach (MetricValue value in element.Values)
                    {
                        // Prints a line that looks like the following:
                        // Thursday, May 4, 2023 9:42:00 PM, webwk000002, Http2xx, 1
                        Console.WriteLine(
                            $"{value.TimeStamp:F}, {element.Metadata["Instance"]}, {metric.Name}, {value.Average}");
                    }
                }
            }
            #endregion
        }

        [Test]
        public async Task GetMetricsNamespaces()
        {
            #region Snippet:GetMetricsNamespaces
#if SNIPPET
            string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Web/sites/TestWebApp";
            var client = new MetricsQueryClient(new DefaultAzureCredential());
#else
            string resourceId = TestEnvironment.MetricsResource;
            var client = new MetricsQueryClient(
                new Uri(TestEnvironment.GetMetricsAudience()),
                TestEnvironment.Credential,
                new MetricsQueryClientOptions()
                {
                    Audience = TestEnvironment.GetMetricsAudience()
                });
#endif

            AsyncPageable<MetricNamespace> metricNamespaces = client.GetMetricNamespacesAsync(resourceId);

            await foreach (var metricNamespace in metricNamespaces)
            {
                Console.WriteLine($"Metric namespace = {metricNamespace.Name}");
            }
            #endregion
        }

//        [Test]
//        public async Task QueryBatchMetrics()
//        {
//            #region Snippet:QueryBatchMetrics
//#if SNIPPET
//            string resourceId =
//                "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
//#else
//            string resourceId = TestEnvironment.StorageAccountId;
//#endif
//            MetricsBatchQueryClient client = new MetricsBatchQueryClient(new Uri("https://metrics.monitor.azure.com/.default"), new DefaultAzureCredential());
//            Response<MetricsBatchResult> metricsResultsResponse = await client.QueryBatchAsync(
//                resourceIds: new List<string> { resourceId },
//                metricNames: new List<string> { "Ingress" },
//                metricNamespace: "Microsoft.Storage/storageAccounts").ConfigureAwait(false);

//            MetricsBatchResult metricsQueryResults = metricsResultsResponse.Value;
//            foreach (var value in metricsQueryResults.Values)
//            {
//                Console.WriteLine(value.Interval);
//            }
//            #endregion
//        }
    }
}
