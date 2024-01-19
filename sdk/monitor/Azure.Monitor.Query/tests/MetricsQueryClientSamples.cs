// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
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
            var client = new MetricsQueryClient(new DefaultAzureCredential());
            #endregion

            Response<MetricsQueryResult> results = await client.QueryResourceAsync(
                resourceId,
                new[] { "AvailabilityRate_Query", "Query Count" }
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
#else
            string resourceId = TestEnvironment.MetricsResource;
            string[] metricNames = new[] { "Heartbeat" };
#endif
            var client = new MetricsQueryClient(new DefaultAzureCredential());

            Response<MetricsQueryResult> result = await client.QueryResourceAsync(
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
#else
            string resourceId = TestEnvironment.MetricsResource;
            string[] metricNames = new[] { "Average_% Available Memory" };
            string filter = "Computer eq '*'";
#endif
            var client = new MetricsQueryClient(new DefaultAzureCredential());
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
#else
            string resourceId = TestEnvironment.MetricsResource;
#endif
            var client = new MetricsQueryClient(new DefaultAzureCredential());
            AsyncPageable<MetricNamespace> metricNamespaces = client.GetMetricNamespacesAsync(resourceId);

            await foreach (var metricNamespace in metricNamespaces)
            {
                Console.WriteLine($"Metric namespace = {metricNamespace.Name}");
            }
            #endregion
        }

        [Test]
        public async Task QueryBatchMetrics()
        {
            #region Snippet:QueryBatchMetrics
#if SNIPPET
            string resourceId =
                "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
#else
            string resourceId = TestEnvironment.StorageAccountId;
#endif
            MetricsClient client = new MetricsClient(new Uri("https://metrics.monitor.azure.com/.default"), new DefaultAzureCredential());

            MetricsQueryResourcesOptions options = new MetricsQueryResourcesOptions
            {
                // Set Granularity to 5 minutes.
                Granularity = new TimeSpan(0, 5, 0),
                // Set Aggregations to be Average and Count.
                Aggregations = new List<MetricAggregationType> { MetricAggregationType.Average, MetricAggregationType.Count },
                // Set Size to 10 for 10 data points.
                Size = 10
            };
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(resourceId);
            IEnumerable<ResourceIdentifier> resourceIdentifiers = new List<ResourceIdentifier> { resourceIdentifier };
            Response<MetricsQueryResourcesResult> metricsResultsResponse = await client.QueryResourcesAsync(
                resourceIds: resourceIdentifiers,
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options).ConfigureAwait(false);

            MetricsQueryResourcesResult metricsQueryResults = metricsResultsResponse.Value;
            foreach (MetricsQueryResult value in metricsQueryResults.Values)
            {
                foreach (MetricResult metric in value.Metrics)
                {
                    Console.WriteLine(metric.Id);
                    Console.WriteLine(metric.Name);
                    Console.WriteLine(metric.TimeSeries);
                }
                Console.WriteLine(value.Namespace);
                Console.WriteLine(value.Granularity);
                Console.WriteLine(value.ResourceRegion);
            }
            #endregion
        }
    }
}
