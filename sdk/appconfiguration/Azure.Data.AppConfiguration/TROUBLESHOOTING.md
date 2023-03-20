# Troubleshoot Azure App Configuration client library issues

This troubleshooting guide contains instructions to diagnose frequently encountered issues while using the Azure App Configuration client library for .NET.

## Table of contents

* [General troubleshooting](#general-troubleshooting)
  * [Enable client logging](#enable-client-logging)
* [Troubleshooting authentication issues](#troubleshooting-authentication-issues)
  * [AuthenticationFailedException](#authenticationfailedexception)
  * [CredentialUnavailableException](#credentialunavailableexception)
  * [Permission Issues](#permission-issues)

## General troubleshooting

All app configuration service operations will throw a [RequestFailedException](https://docs.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet) on failure.

When you interact with the library, errors returned by the service correspond to the same HTTP status codes returned for [REST API](https://learn.microsoft.com/en-us/azure/azure-app-configuration/rest-api/) requests. 

For example, if you try to retrieve a Configuration Setting that doesn't exist in your Configuration Store, a `404` error is returned, indicating `Not Found`.

Here's an example of how to catch an exception using synchronous method:

```C# Snippet:ThrowNotFoundErrorSync
string connectionString = "<connection_string>";
var client = new ConfigurationClient(connectionString);
try
{
    ConfigurationSetting setting = client.GetConfigurationSetting("nonexistent_key");
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Key wasn't found.");
}
```

Here's an example of how to catch an exception using asynchronous method:

```C# Snippet:ThrowNotFoundErrorAsync
string connectionString = "<connection_string>";
var client = new ConfigurationClient(connectionString);

try
{
    ConfigurationSetting setting = await client.GetConfigurationSettingAsync("nonexistent_key");
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Key wasn't found.");
}
```

You will notice that additional information is logged, like the Client Request ID of the operation.

```shell
Message: Azure.RequestFailedException : StatusCode: 404, ReasonPhrase: 'Not Found', Version: 1.1, Content: System.Net.Http.NoWriteNoSeekStreamContent, Headers:
{
  Connection: keep-alive
  Date: Thu, 11 Apr 2019 00:16:57 GMT
  Server: nginx/1.13.9
  x-ms-client-request-id: cc49570c-9143-411e-a6c8-3287dd114034
  x-ms-request-id: 2ad025f7-1fe8-4da0-8648-8290e774ed61
  x-ms-correlation-request-id: 2ad025f7-1fe8-4da0-8648-8290e774ed61
  Strict-Transport-Security: max-age=15724800; includeSubDomains;
  Content-Length: 0
}
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

#### Enable content logging

By default only URI and headers are logged. To enable content logging, set the `Diagnostics.IsLoggingContentEnabled` client option. 

``` c#
ConfigurationClientOptions options = new ConfigurationClientOptions()
{
    Diagnostics =
    {
        IsLoggingContentEnabled = true
    }
};
```
#### Logging redacted headers and query parameters

Some sensitive headers and query parameters are not logged by default and are displayed as "REDACTED", to include them in logs use the `Diagnostics.LoggedHeaderNames` and `Diagnostics.LoggedQueryParameters` client options.

``` c#
ConfigurationClientOptions options = new ConfigurationClientOptions()
{
    Diagnostics =
    {
        LoggedHeaderNames = { "x-ms-request-id" },
        LoggedQueryParameters = { "api-version" }
    }
};
```

You can also disable redaction completely by adding a "*" to collections mentioned above.

``` c#
ConfigurationClientOptions options = new ConfigurationClientOptions()
{
    Diagnostics =
    {
        LoggedHeaderNames = { "*" },
        LoggedQueryParameters = { "*" }
    }
};
```

To learn about other logging mechanisms, see [Azure SDK diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## Troubleshooting authentication issues

Azure App Configuration supports Azure Active Directory authentication. To provide a valid credential, you can use the `Azure.Identity` package. For more information on getting started, see the [Azure App Configuration library's README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/appconfiguration/Azure.Data.AppConfiguration#authenticate-the-client). For details on the credential types supported in `Azure.Identity`, see the [Azure Identity library's documentation](https://docs.microsoft.com/dotnet/api/overview/azure/Identity-readme).

Here are the authentication exceptions and ways to handle it:

### AuthenticationFailedException

Exceptions arising from authentication errors can be raised on any service client method that makes a request to the service. This is because the token is requested from the credential on the first call to the service and on any subsequent requests to the service that need to refresh the token. 

To distinguish these failures from failures in the service client, Azure Identity classes raise the `AuthenticationFailedException` with details describing the source of the error in the exception message and possibly the error message. Depending on the application, these errors may or may not be recoverable.

``` c#
using Azure.Identity;
using Azure.Data.AppConfiguration;

// Create a ConfigurationClient using the DefaultAzureCredential
string endpoint = "<endpoint>";
ConfigurationClient client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());

try
{
    client.GetConfigurationSetting("key");
}
catch (AuthenticationFailedException e)
{
    Console.WriteLine($"Authentication Failed. {e.Message}");
}
```

### CredentialUnavailableException

The `CredentialUnavailableExcpetion` is a special exception type derived from `AuthenticationFailedException`. This exception type is used to indicate that the credential can’t authenticate in the current environment, due to lack of required configuration or setup. This exception is also used as a signal to chained credential types, such as `DefaultAzureCredential` and `ChainedTokenCredential`, that the chained credential should continue to try other credential types later in the chain.

### Permission Issues

Calls to service clients resulting in `RequestFailedException` with a `StatusCode` of 401 or 403 often indicate the caller doesn't have sufficient permissions for the specified API. Check the service documentation to determine which RBAC roles are needed for the specific request, and ensure the authenticated user or service principal have been granted the appropriate roles on the resource.

For more help with troubleshooting authentication errors, see the Azure Identity client library [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).