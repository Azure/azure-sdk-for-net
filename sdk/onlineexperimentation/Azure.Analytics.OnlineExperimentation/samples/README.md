---
page_type: sample
languages:
- csharp
products:
- azure
name: Azure.Analytics.OnlineExperimentation samples for .NET
description: Samples for the Azure.Analytics.OnlineExperimentation client library
---

# Azure Online Experimentation client library samples for .NET

Azure Online Experimentation is a service that helps you manage and analyze experiments in your online applications. The service provides capabilities for defining and tracking metrics, setting up experiments, and analyzing results.

## Getting started

### Install the package

Install the Azure Online Experimentation client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Analytics.OnlineExperimentation
```

### Initialize the client

The Azure Online Experimentation client library initialization requires two parameters:

- The `endpoint` property value from the [`Microsoft.OnlineExperimentation/workspaces`](https://learn.microsoft.com/azure/templates/microsoft.onlineexperimentation/workspaces) resource.
- A `TokenCredential` for authentication, the simplest approach is to use [`DefaultAzureCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

```C# Snippet:OnlineExperimentation_InitializeClient
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());
```

## Samples

These code samples show common scenarios with the Azure Online Experimentation client library.

| Sample | Description |
|--------|-------------|
| [Initializing the Client](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample1_InitializeClient.md) | Initialize the client with different options. |
| [Creating Experiment Metrics](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample2_CreateExperimentMetricsAsync.md) | Create various types of metrics synchronously. |
| [Creating Experiment Metrics Asynchronously](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample2_CreateExperimentMetricsAsync.md) | Create various types of metrics asynchronously. |
| [Validating Experiment Metrics](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample3_ValidateExperimentMetrics.md) | Validate metric definitions before creating them. |
| [Validating Experiment Metrics Asynchronously](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample3_ValidateExperimentMetricsAsync.md) | Validate metric definitions asynchronously. |
| [Retrieving and Listing Metrics](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample4_RetrieveAndListMetrics.md) | Retrieve a specific metric or list all metrics. |
| [Retrieving and Listing Metrics Asynchronously](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample4_RetrieveAndListMetricsAsync.md) | Retrieve or list metrics asynchronously. |
| [Updating an Experiment Metric](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample5_UpdateExperimentMetrics.md) | Update properties of an existing metric. |
| [Updating an Experiment Metric Asynchronously](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample5_UpdateExperimentMetricsAsync.md) | Update properties of an existing metric asynchronously. |
| [Deleting an Experiment Metric](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample6_DeleteExperimentMetric.md) | Delete a metric when it's no longer needed. |
| [Deleting an Experiment Metric Asynchronously](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample6_DeleteExperimentMetricAsync.md) | Delete a metric asynchronously. |
