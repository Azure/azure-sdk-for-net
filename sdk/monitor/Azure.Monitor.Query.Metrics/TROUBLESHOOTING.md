# Troubleshooting Azure Monitor Query Metrics client library issues

This troubleshooting guide contains instructions to diagnose frequently encountered issues while using the Azure Monitor Query Metrics client library for .NET.

## Table of contents

* [General troubleshooting](#general-troubleshooting)
  * [Enable client logging](#enable-client-logging)
  * [Troubleshooting authentication issues with metrics query requests](#authentication-errors)
* [Troubleshooting metrics query](#troubleshooting-metrics-query)
  * [Troubleshooting insufficient access error](#troubleshooting-insufficient-access-error-for-metrics-query)
  * [Troubleshooting unsupported granularity](#troubleshooting-unsupported-granularity)
* [Additional Azure Core configurations](#additional-azure-core-configurations)

## General troubleshooting

The Azure Monitor Query Metrics library raises exceptions defined in the [Azure Core](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md) library. For example, [RequestFailedException](https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet).

When you interact with the library, errors returned by the service correspond to the same HTTP status codes returned for [REST API](https://learn.microsoft.com/rest/api/monitor/) requests.

### Enable client logging

To troubleshoot issues with the library, first enable logging to monitor the behavior of the application. The errors and warnings in the logs generally provide useful insights into what went wrong and sometimes include corrective actions to fix issues.

This library uses the standard [logging](https://learn.microsoft.com/dotnet/azure/sdk/logging) library. Basic information about HTTP sessions, such as URLs and headers, is logged at the `INFO` level.

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console, use the [AzureEventSourceListener.CreateConsoleLogger](https://learn.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener.createconsolelogger?view=azure-dotnet) method:

```csharp
using Azure.Core.Diagnostics;

// set up a listener to monitor logged events
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn about other logging mechanisms, see [Azure SDK diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

### Authentication errors

Azure Monitor Query Metrics supports Microsoft Entra authentication. The `MetricsClient` has methods to set the credential. To provide a valid credential, you can use the `Azure.Identity` package. For more information on getting started, see the [Azure Monitor Query Metrics library's README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Metrics/README.md#authenticate-the-client). For details on the credential types supported in `Azure.Identity`, see the [Azure Identity library's documentation](https://learn.microsoft.com/dotnet/api/overview/azure/Identity-readme).

For more help with troubleshooting authentication errors, see the Azure Identity client library [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

If you get an HTTP error with status code 401 (Unauthorized) ErrorCode: InvalidAuthenticationTokenTenant, confirm your `Audience` parameter is set correctly. If your resource isn't located in the Azure Public Cloud, the `Audience` parameter must be set in the `MetricsClientOptions` parameter while constructing the client. For an example, see [Configure client for Azure sovereign cloud](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/monitor/Azure.Monitor.Query.Metrics#configure-client-for-azure-sovereign-cloud).

## Troubleshooting metrics query

### Troubleshooting insufficient access error for metrics query

If you get an HTTP error with status code 403 (Forbidden), it means the provided credentials lack sufficient permissions to query metrics.

```text
"{"error":{"message":"The provided credentials have insufficient access to perform the requested operation","code":"InsufficientAccessError","correlationId":""}}"
```

Confirm that:

1. Sufficient permissions have been granted to the application or user making the request. The user must be authorized to read monitoring data at the Azure subscription level. For example, the [Monitoring Reader role](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles/monitor#monitoring-reader) on the subscription to be queried.
2. You're authenticating as that user or application if the user or application is granted sufficient privileges to query metrics. If you're authenticating using the [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet), check the logs to verify the credential used is the one you expected. To enable logging, see the [Enable client logging](#enable-client-logging) section.

For more help with troubleshooting authentication errors, see the Azure Identity client library [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

### Troubleshooting unsupported granularity

The following exception is caused by an invalid time granularity in the metrics query request. Your query might have set the `MetricsQueryResourcesOptions.Granularity` property to an unsupported duration.

```text
"{"code":"BadRequest","message":"Invalid time grain duration: PT10M, supported ones are: 00:01:00,00:05:00,00:15:00,00:30:00,01:00:00,06:00:00,12:00:00,1.00:00:00"}"
```

As documented in the error message, the supported granularity values for metrics queries are:

* 1 minute
* 5 minutes
* 15 minutes
* 30 minutes
* 1 hour
* 6 hours
* 12 hours
* 1 day

## Additional Azure Core configurations

For information about additional configurations that can be applied to the client, see the [Azure Core documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md).
