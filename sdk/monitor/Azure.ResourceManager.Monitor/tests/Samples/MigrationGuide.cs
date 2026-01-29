// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Monitor.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests.Samples
{
    internal class MigrationGuide
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task QueryResource()
        {
            #region Snippet:QueryResource
            const string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Storage/storageAccounts/<resource_name>";

            ArmClient client = new(new DefaultAzureCredential());
            ArmResourceGetMonitorMetricsOptions options = new()
            {
                Metricnames = "Availability",
            };
            AsyncPageable<MonitorMetric> metrics = client.GetMonitorMetricsAsync(
                new ResourceIdentifier(resourceId),
                options);

            await foreach (MonitorMetric metric in metrics)
            {
                // Process each metric as needed
                Console.WriteLine($"Metric Name: {metric.Name?.Value}, Unit: {metric.Unit}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetMetricDefinitions()
        {
            #region Snippet:GetMetricDefinitions
            const string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Storage/storageAccounts/<resource_name>";
            const string metricsNamespace = "Microsoft.Storage/storageAccounts";

            ArmClient client = new(new DefaultAzureCredential());
            AsyncPageable<MonitorMetricDefinition> definitions =
                client.GetMonitorMetricDefinitionsAsync(new ResourceIdentifier(resourceId), metricsNamespace);

            await foreach (MonitorMetricDefinition definition in definitions)
            {
                // Process each definition as needed
                Console.WriteLine($"Metric Name: {definition.Name?.Value}, Unit: {definition.Unit}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetMetricNamespaces()
        {
            #region Snippet:GetMetricNamespaces
            const string resourceId =
                "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Storage/storageAccounts/<resource_name>";

            ArmClient client = new(new DefaultAzureCredential());
            AsyncPageable<MonitorMetricNamespace> namespaces =
                client.GetMonitorMetricNamespacesAsync(new ResourceIdentifier(resourceId));

            await foreach (MonitorMetricNamespace ns in namespaces)
            {
                // Process each namespace as needed
                Console.WriteLine($"Namespace Name: {ns.Name}, Type: {ns.MetricNamespaceNameValue}");
            }
            #endregion
        }
    }
}
