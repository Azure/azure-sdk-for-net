// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Monitor.Query.Metrics.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Metrics.Tests.Samples
{
    /// <summary>
    /// Samples for the Azure Monitor Query Metrics client library README.
    /// </summary>
    public class ReadmeSamples
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void CreateMetricsClient()
        {
            #region Snippet:Query_Metrics_CreateMetricsClient
            var client = new MetricsClient(
                new Uri("https://<region>.metrics.monitor.azure.com"),
                new DefaultAzureCredential());
            #endregion
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void CreateClientsWithOptions()
        {
            #region Snippet:Query_Metrics_CreateClientsWithOptions
            // MetricsClient
            var metricsClientOptions = new MetricsClientOptions
            {
                Audience = MetricsClientAudience.AzureGovernment
            };
            var metricsClient = new MetricsClient(
                new Uri("https://usgovvirginia.metrics.monitor.azure.us"),
                new DefaultAzureCredential(),
                metricsClientOptions);
            #endregion
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task QueryResourcesMetrics()
        {
            #region Snippet:Query_Metrics_QueryResourcesMetrics
            string resourceId =
                "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
            var client = new MetricsClient(
                new Uri("https://<region>.metrics.monitor.azure.com"),
                new DefaultAzureCredential());
            Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts").ConfigureAwait(false);

            MetricsQueryResourcesResult metricsQueryResults = result.Value;
            foreach (MetricsQueryResult value in metricsQueryResults.Values)
            {
                Console.WriteLine(value.Metrics.Count);
            }
            #endregion
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task QueryResourcesMetricsWithOptions()
        {
            #region Snippet:Query_Metrics_QueryResourcesMetricsWithOptions
            string resourceId =
                "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
            var client = new MetricsClient(
                new Uri("https://<region>.metrics.monitor.azure.com"),
                new DefaultAzureCredential());
            var options = new MetricsQueryResourcesOptions
            {
                OrderBy = "sum asc",
                Size = 10
            };

            Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options).ConfigureAwait(false);

            MetricsQueryResourcesResult metricsQueryResults = result.Value;
            foreach (MetricsQueryResult value in metricsQueryResults.Values)
            {
                Console.WriteLine(value.Metrics.Count);
            }
            #endregion
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task QueryResourcesMetricsWithOptionsStartTimeEndTime()
        {
            #region Snippet:Query_Metrics_QueryResourcesMetricsWithOptionsStartTimeEndTime
            string resourceId =
                "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
            var client = new MetricsClient(
                new Uri("https://<region>.metrics.monitor.azure.com"),
                new DefaultAzureCredential());
            var options = new MetricsQueryResourcesOptions
            {
                StartTime = DateTimeOffset.Now.AddHours(-4),
                EndTime = DateTimeOffset.Now.AddHours(-1),
                OrderBy = "sum asc",
                Size = 10
            };

            Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options).ConfigureAwait(false);

            MetricsQueryResourcesResult metricsQueryResults = result.Value;
            foreach (MetricsQueryResult value in metricsQueryResults.Values)
            {
                Console.WriteLine(value.Metrics.Count);
            }
            #endregion
        }
    }
}
