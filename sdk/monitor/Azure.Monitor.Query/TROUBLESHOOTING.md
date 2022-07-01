# Troubleshooting Azure Monitor Query client library issues

This troubleshooting guide contains instructions to diagnose frequently encountered issues while using the Azure Monitor Query client library for .NET.

## Table of contents

* [General troubleshooting](#general-troubleshooting)
  * [Enable client logging](#enable-client-logging)
  * [Troubleshooting authentication issues with logs and metrics query requests](#authentication-errors)
  * [Troubleshooting running async APIs](#errors-with-running-async-apis)
* [Troubleshooting logs query](#troubleshooting-logs-query)
  * [Troubleshooting insufficient access error](#troubleshooting-insufficient-access-error-for-logs-query)
  * [Troubleshooting invalid Kusto query](#troubleshooting-invalid-kusto-query)
  * [Troubleshooting empty log query results](#troubleshooting-empty-log-query-results)
  * [Troubleshooting server timeouts when executing logs query request](#troubleshooting-server-timeouts-when-executing-logs-query-request)
  * [Troubleshooting partially successful logs query requests](#troubleshooting-partially-successful-logs-query-requests)
* [Troubleshooting metrics query](#troubleshooting-metrics-query)
  * [Troubleshooting insufficient access error](#troubleshooting-insufficient-access-error-for-metrics-query)
  * [Troubleshooting unsupported granularity](#troubleshooting-unsupported-granularity)
* [Additional Azure Core configurations](#additional-azure-core-configurations)

## General troubleshooting

The Azure Monitor Query library raises exceptions defined in the [Azure Core](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md) library. For example, [RequestFailedException](https://docs.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet).

When you interact with the library, errors returned by the service correspond to the same HTTP status codes returned for [REST API](https://docs.microsoft.com/rest/api/monitor/) requests. For example, if you submit an invalid logs query, an HTTP 400 error is returned, indicating "Bad Request".

```C# Snippet:BadRequest
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

try
{
    await client.QueryWorkspaceAsync(
        workspaceId, "My Not So Valid Query", new QueryTimeRange(TimeSpan.FromDays(1)));
}
catch (Exception e)
{
    Console.WriteLine(e);
}
```

The exception contains additional information about the error:

```
Azure.RequestFailedException : The request had some invalid properties
Status: 400 (Bad Request)
ErrorCode: BadArgumentError

Content:
{"error":{"message":"The request had some invalid properties","code":"BadArgumentError","correlationId":"34f5f93a-6007-48a4-904f-487ca4e62a82","innererror":{"code":"SyntaxError","message":"A recognition error occurred in the query.","innererror":{"code":"SYN0002","message":"Query could not be parsed at 'Not' on line [1,3]","line":1,"pos":3,"token":"Not"}}}}
```

### Enable client logging

To troubleshoot issues with the library, first enable logging to monitor the behavior of the application. The errors and warnings in the logs generally provide useful insights into what went wrong and sometimes include corrective actions to fix issues.

This library uses the standard [logging](https://docs.microsoft.com/dotnet/azure/sdk/logging) library. Basic information about HTTP sessions, such as URLs and headers, is logged at the `INFO` level.

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console, use the [AzureEventSourceListener.CreateConsoleLogger](https://docs.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener.createconsolelogger?view=azure-dotnet) method:

```csharp
using Azure.Core.Diagnostics;

// set up a listener to monitor logged events
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn about other logging mechanisms, see [Azure SDK diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

### Authentication errors

Azure Monitor Query supports Azure Active Directory authentication. Both `LogsQueryClient` and `MetricsQueryClient` have methods to set the credential. To provide a valid credential, you can use the `Azure.Identity` package. For more information on getting started, see the [Azure Monitor Query library's README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query/README.md#authenticate-the-client). For details on the credential types supported in `Azure.Identity`, see the [Azure Identity library's documentation](https://docs.microsoft.com/dotnet/api/overview/azure/Identity-readme).

For more help with troubleshooting authentication errors, see the Azure Identity client library [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

## Troubleshooting logs query

### Troubleshooting insufficient access error for logs query

If you get an HTTP error with status code 403 (Forbidden), it means the provided credentials lack sufficient permissions to query the workspace.

```text
"{"error":{"message":"The provided credentials have insufficient access to perform the requested operation","code":"InsufficientAccessError","correlationId":""}}"
```

Confirm that:

1. Sufficient permissions have been granted to the application or user making the request. For more information, see [manage access to workspaces](https://docs.microsoft.com/azure/azure-monitor/logs/manage-access#manage-access-using-workspace-permissions).
1. You're authenticating as that user or application if the user or application is granted sufficient privileges to query the workspace.  If you're authenticating using the [DefaultAzureCredential](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet), check the logs to verify the credential used is the one you expected. To enable logging, see the [Enable client logging](#enable-client-logging) section.

For more help on troubleshooting authentication errors, see the Azure Identity client library [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

### Troubleshooting invalid Kusto query

If you get an HTTP error with status code 400 (Bad Request), you may have an error in your Kusto query. You'll see an error message similar to the one below.

```text
(BadArgumentError) The request had some invalid properties
Code: BadArgumentError
Message: The request had some invalid properties
Inner error: {
    "code": "SemanticError",
    "message": "A semantic error occurred.",
    "innererror": {
        "code": "SEM0100",
        "message": "'take' operator: Failed to resolve table or column expression named 'Appquests'"
    }
}
```

The error message in `innererror` may include the location where the Kusto query has an error. You may also refer to the [Kusto Query Language](https://docs.microsoft.com/azure/data-explorer/kusto/query) (KQL) reference docs to learn more about querying logs using KQL.

### Troubleshooting empty log query results

If your Kusto query returns empty or has no logs, validate the following items:

* You have the right workspace ID
* You're setting the correct time interval for the query. Try expanding the time interval for your query to see if that returns any results.
* If your Kusto query also has a time interval, the query is evaluated for the intersection of the time interval in the query string and the time interval set in the `timeRange` parameter provided the query API. The intersection of these time intervals may not have any logs. To avoid any confusion, it's recommended to remove any time interval in the Kusto query string and use `timeRange` explicitly.

### Troubleshooting server timeouts when executing logs query request

Some complex Kusto queries can take a long time to complete. These queries are aborted by the service if they run for more than 3 minutes. For such scenarios, the query APIs on `LogsQueryClient`, provide options to configure the timeout on the server. The server timeout can be extended up to 10 minutes.

You may see an error as follows:

```text
Code: GatewayTimeout
Message: Gateway timeout
Inner error: {
    "code": "GatewayTimeout",
    "message": "Unable to unzip response"
}
```

The following code shows an example of setting the server timeout. By setting this server timeout, the Azure Monitor Query library will automatically extend the client timeout to wait for 10 minutes for the server to respond. You don't need to configure your HTTP client to extend the response timeout, as shown in the previous section.

```C# Snippet:QueryLogsWithTimeout
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
    workspaceId,
    @"AzureActivity
        | summarize Count = count() by ResourceGroup
        | top 10 by Count
        | project ResourceGroup",
    new QueryTimeRange(TimeSpan.FromDays(1)),
    new LogsQueryOptions
    {
        ServerTimeout = TimeSpan.FromMinutes(10)
    });

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

### Troubleshooting partially successful logs query requests

By default, if the execution of a Kusto query resulted in a partially successful response, the Azure Monitor Query client library will throw an exception. The exception indicates to the user that the query wasn't fully successful. The data and the error can be accessed using the `LogsQueryResultStatus` enum and `Error` fields.

```C# Snippet:QueryLogsWithPartialSuccess
Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
    TestEnvironment.WorkspaceId,
    "My Not So Valid Query",
    new QueryTimeRange(TimeSpan.FromDays(1)),
    new LogsQueryOptions
    {
        AllowPartialErrors = true
    });
LogsQueryResult result = response.Value;

if (result.Status == LogsQueryResultStatus.PartialFailure)
{
    var errorCode = result.Error.Code;
    var errorMessage = result.Error.Message;

    // code omitted for brevity
}
```

## Troubleshooting metrics query

### Troubleshooting insufficient access error for metrics query

If you get an HTTP error with status code 403 (Forbidden), it means the provided credentials lack sufficient permissions to query the workspace.

```text
"{"error":{"message":"The provided credentials have insufficient access to perform the requested operation","code":"InsufficientAccessError","correlationId":""}}"
```

Confirm that:

1. Sufficient permissions have been granted to the application or user making the request. For more information, see [manage access to workspaces](https://docs.microsoft.com/azure/azure-monitor/logs/manage-access#manage-access-using-workspace-permissions).
1. You're authenticating as that user or application if the user or application is granted sufficient privileges to query the workspace. If you're authenticating using the [DefaultAzureCredential](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet), check the logs to verify the credential used is the one you expected. To enable logging, see the [Enable client logging](#enable-client-logging) section.

For more help with troubleshooting authentication errors, see the Azure Identity client library [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

### Troubleshooting unsupported granularity for metrics query

The following exception is caused by an invalid time granularity in the metrics query request. Your query might have set the `MetricsQueryOptions.Granularity` property to an unsupported duration.

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
