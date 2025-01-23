# Troubleshoot Azure App Configuration client library issues

This troubleshooting guide contains instructions to diagnose issues encountered while using the Azure App Configuration client library for .NET.

## Table of contents

* [General troubleshooting](#general-troubleshooting)
  * [Enable client logging](#enable-client-logging)
  * [Limit issues](#limit-issues)
* [Troubleshooting authentication issues](#troubleshooting-authentication-issues)
  * [AuthenticationFailedException](#authenticationfailedexception)
  * [CredentialUnavailableException](#credentialunavailableexception)
  * [Permission issues](#permission-issues)
* [Get additional help](#get-additional-help)

## General troubleshooting

All app configuration service operations will throw a [RequestFailedException](https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet) on failure. When you interact with the library, errors returned by the service correspond to the same HTTP status codes returned for [REST API](https://learn.microsoft.com/azure/azure-app-configuration/rest-api/) requests. For example, if you try to retrieve a Configuration Setting that doesn't exist in your Configuration Store, an HTTP `404` status is returned, indicating `Not Found`.

Here's an example of how to catch an exception:

```C# Snippet:ThrowNotFoundError
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

Calling `ToString` on the exception will provide additional information, such as the Client Request Identifier of the operation, which is useful when requesting support.

```text
Azure.RequestFailedException: Service request failed.
Status: 404 (Not Found)

Headers:
Server: openresty/1.21.4.1
Date: Tue, 21 Mar 2023 19:04:22 GMT
Connection: keep-alive
Sync-Token: zAJw6V16=NTo1IzIyNjUyMDYx;sn=22652061
x-ms-request-id: f14a1cb0-018a-4ab5-9ace-9d4917c4e913
x-ms-client-request-id: 68a07c4e-15a6-4b72-bbf7-cbe00c453eb0
x-ms-correlation-request-id: f14a1cb0-018a-4ab5-9ace-9d4917c4e913
Access-Control-Allow-Origin: *
Access-Control-Allow-Credentials: true
Access-Control-Expose-Headers: REDACTED
Strict-Transport-Security: max-age=15724800; includeSubDomains
Content-Length: 0
```

### Enable client logging

To troubleshoot issues with the library, first enable logging to monitor the behavior of the application. The errors and warnings in the logs generally provide useful insights into what went wrong and sometimes include corrective actions to fix issues. To learn more about the approach used for logging, see [Logging with the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/logging).

Basic information about HTTP sessions, such as URLs and headers, is logged at the `INFO` level. The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console, use the [AzureEventSourceListener.CreateConsoleLogger](https://learn.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener.createconsolelogger?view=azure-dotnet) method:

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

For more detail on capturing Azure SDK logs and additional examples, please see the [Azure SDK diagnostics sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

### Limit Issues

The error thrown by the App Configuration client library includes a detailed response error object that provides specific useful insights into what went wrong and includes corrective actions to fix common issues. Refer to [the limits on the number of requests made to App Configuration](https://learn.microsoft.com/azure/azure-app-configuration/faq#are-there-any-limits-on-the-number-of-requests-made-to-app-configuration). A common error encountered is [HTTP status code 429](https://learn.microsoft.com/azure/azure-app-configuration/rest-api-throttling) for exceeding the limit. Refer to the body of the 429 response for the specific reason why the request failed. The failures often happen under these circumstances:

* Exceeding the daily request limit for a store in the Free tier.
* Exceeding the hourly request limit for a store in the standard tier.
* Momentary throttling due to a large burst of requests.
* Excessive bandwidth usage.
* Attempting to create or modify a key when the storage quota is exceeded.

To reduce number of requests made to App Configuration service, please check out [this guide](https://learn.microsoft.com/azure/azure-app-configuration/howto-best-practices#reduce-requests-made-to-app-configuration).

## Troubleshooting authentication issues

In addition to connection strings, Azure App Configuration supports [role-based access control](https://learn.microsoft.com/azure/role-based-access-control/overview) (RBAC) using Azure Active Directory authentication. The `Azure.Identity` package is used to obtain credentials for RBAC. For more information on getting started, see the [Azure App Configuration library's README](https://learn.microsoft.com/dotnet/api/overview/azure/data.appconfiguration-readme?view=azure-dotnet#authenticate-the-client). For details on the credential types supported in `Azure.Identity`, see the [Azure Identity documentation](https://learn.microsoft.com/dotnet/api/overview/azure/Identity-readme).

When authentication or authorization fail, you're most likely to see one of the following errors:

### AuthenticationFailedException

Exceptions arising from authentication errors can be raised on any service client method that makes a request to the service. This is because the token is requested from the credential on the first call to the service and on any subsequent requests to the service that need to refresh the token. 

To distinguish these failures from failures in the service client, Azure Identity classes raise the `AuthenticationFailedException` with details describing the source of the error in the exception message and possibly the error message. Depending on the application, these errors may or may not be recoverable.

```C# Snippet:ThrowAuthenticationError
// Create a ConfigurationClient using the DefaultAzureCredential
string endpoint = "<endpoint>";
var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());

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

### Permission issues

Calls to service clients resulting in `RequestFailedException` with a `StatusCode` of 401 or 403 often indicate the caller doesn't have sufficient permissions for the specified API. Check the service documentation to determine which RBAC roles are needed for the specific request, and ensure the authenticated user or service principal have been granted the appropriate roles on the resource.

For more help with troubleshooting authentication errors, see the Azure Identity client library [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

## Get additional help

For more information on ways to request support, please see: [Support](https://github.com/Azure/azure-sdk-for-net/blob/main/SUPPORT.md).