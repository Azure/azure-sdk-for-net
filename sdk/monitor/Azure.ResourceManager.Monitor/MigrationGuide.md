# Guide for migrating from `Azure.Monitor.Query` to `Azure.ResourceManager.Monitor`

This guide assists in migrating metrics query operations in `Azure.Monitor.Query` to the `Azure.ResourceManager.Monitor` library.

## Table of contents

- [Migration benefits](#migration-benefits)
- [Important changes](#important-changes)
  - [Package names](#package-names)
  - [Namespaces](#namespaces)
  - [Client differences](#client-differences)
  - [API changes](#api-changes)
    - [Query metrics for a single resource](#query-metrics-for-a-single-resource)
    - [Get metric definitions for a single resource](#get-metric-definitions-for-a-single-resource)
    - [Get metric namespaces for a single resource](#get-metric-namespaces-for-a-single-resource)

## Migration benefits

The Azure Monitor Query library for .NET has been modularized to provide more focused functionality. The operations for querying metrics via `MetricsQueryClient` have moved from the combined `Azure.Monitor.Query` package to a dedicated `Azure.ResourceManager.Monitor` package. This separation offers several advantages:

- Smaller dependency footprint for applications that only need to query metrics for an Azure resource
- More focused API design specific to metrics query operations
- Independent versioning allowing metrics functionality to evolve separately
- Clearer separation of concerns between logs and metrics query operations

## Important changes

### Package names

- Previous package for querying metrics on an Azure resource: `Azure.Monitor.Query`
- New package: `Azure.ResourceManager.Monitor`

### Namespaces

The root namespace has changed to `Azure.ResourceManager.Monitor` in the new package.

### Client differences

In the `Azure.Monitor.Query` package, `MetricsQueryClient` was used for metrics query options on a single Azure resource. That same functionality can be found in `ArmClient` within the `Azure.ResourceManager.Monitor` package. See the [API changes](#api-changes) section for code samples demonstrating the changes.

### API changes

#### Query metrics for a single resource

**Previous code:**

```csharp
const string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Storage/storageAccounts/<resource_name>";

MetricsQueryClient client = new(new DefaultAzureCredential());
MetricsQueryResult result = await client.QueryResourceAsync(
    resourceId,
    ["Availability"]);

foreach (MetricResult metric in result.Metrics)
{
    // Process each metric as needed
    Console.WriteLine($"Metric Name: {metric.Name}, Unit: {metric.Unit}");
}
```

**New code:**

```C# Snippet:QueryResource
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
```

#### Get metric definitions for a single resource

**Previous code:**

```csharp
const string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Storage/storageAccounts/<resource_name>";
const string metricsNamespace = "Microsoft.Storage/storageAccounts";

MetricsQueryClient client = new(new DefaultAzureCredential());
AsyncPageable<MetricDefinition> definitions =
    client.GetMetricDefinitionsAsync(resourceId, metricsNamespace);

await foreach (MetricDefinition definition in definitions)
{
    // Process each definition as needed
    Console.WriteLine($"Metric Name: {definition.Name}, Unit: {definition.Unit}");
}
```

**New code:**

```C# Snippet:GetMetricDefinitions
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
```

#### Get metric namespaces for a single resource

**Previous code:**

```csharp
const string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Storage/storageAccounts/<resource_name>";

MetricsQueryClient client = new(new DefaultAzureCredential());
AsyncPageable<MetricNamespace> namespaces =
    client.GetMetricNamespacesAsync(resourceId);

await foreach (MetricNamespace ns in namespaces)
{
    // Process each namespace as needed
    Console.WriteLine($"Namespace Name: {ns.Name}, Type: {ns.FullyQualifiedName}");
}
```

**New code:**

```C# Snippet:GetMetricNamespaces
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
```
