# Troubleshoot Azure Container Registry client library issues

This troubleshooting guide contains instructions to diagnose frequently encountered issues while using the Azure Container Registry client library for .NET.

## Table of contents

* [General troubleshooting](#general-troubleshooting)
  * [Enable client logging](#enable-client-logging)
* [Troubleshooting authentication issues](#troubleshooting-authentication-issues)
  * [AuthenticationFailedException](#authenticationfailedexception)
  * [CredentialUnavailableException](#credentialunavailableexception)
  * [Permission Issues](#permission-issues)

## General troubleshooting

All container registry service operations will throw a [RequestFailedException](https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet) on failure.

When you interact with the library, errors returned by the service correspond to the same HTTP status codes returned for [REST API](https://learn.microsoft.com/rest/api/containerregistry/) requests.

Here's an example of how to catch an exception using synchronous method

```C# Snippet:ContainerRegistry_Tests_Samples_HandleErrors
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a ContainerRepository class for an invalid repository
string fakeRepositoryName = "doesnotexist";
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
ContainerRepository repository = client.GetRepository(fakeRepositoryName);

try
{
    repository.GetProperties();
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Repository wasn't found.");
    Console.WriteLine($"Service error: {ex.Message}.");
}
```

Here's an example of how to catch an exception using asynchronous method:

```C# Snippet:ContainerRegistry_Tests_Samples_HandleErrorsAsync
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a ContainerRepository class for an invalid repository
string fakeRepositoryName = "doesnotexist";
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
ContainerRepository repository = client.GetRepository(fakeRepositoryName);

try
{
    await repository.GetPropertiesAsync();
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Repository wasn't found.");
    Console.WriteLine($"Service error: {ex.Message}.");
}
```

### Enable client logging

To troubleshoot issues with the library, first enable logging to monitor the behavior of the application. The errors and warnings in the logs generally provide useful insights into what went wrong and sometimes include corrective actions to fix issues.

This library uses the standard [logging](https://learn.microsoft.com/dotnet/azure/sdk/logging) library. Basic information about HTTP sessions, such as URLs and headers, is logged at the `INFO` level.

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console, use the [AzureEventSourceListener.CreateConsoleLogger](https://learn.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener.createconsolelogger?view=azure-dotnet) method:

```csharp
using Azure.Core.Diagnostics;

// set up a listener to monitor logged events
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

#### Enable content logging

By default only URI and headers are logged. To enable content logging, set the `Diagnostics.IsLoggingContentEnabled` client option.

``` c#
ContainerRegistryClientOptions options = new ContainerRegistryClientOptions()
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
ContainerRegistryClientOptions options = new ContainerRegistryClientOptions()
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
ContainerRegistryClientOptions options = new ContainerRegistryClientOptions()
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

Azure Container Registry supports Azure Active Directory authentication. To provide a valid credential, you can use the `Azure.Identity` package. For more information on getting started, see the [Azure Container Registry library's README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/containerregistry/Azure.Containers.ContainerRegistry#authenticate-the-client). For details on the credential types supported in `Azure.Identity`, see the [Azure Identity library's documentation](https://learn.microsoft.com/dotnet/api/overview/azure/Identity-readme).

Here are the authentication exceptions and ways to handle it:

### AuthenticationFailedException

Exceptions arising from authentication errors can be raised on any service client method that makes a request to the service. This is because the token is requested from the credential on the first call to the service and on any subsequent requests to the service that need to refresh the token.

To distinguish these failures from failures in the service client, Azure Identity classes raise the `AuthenticationFailedException` with details describing the source of the error in the exception message and possibly the error message. Depending on the application, these errors may or may not be recoverable.

``` c#
using Azure.Identity;
using Azure.Containers.ContainerRegistry;

// Create a ContainerRegistryClient using the DefaultAzureCredential
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

string repositoryName = "RepositoryName";
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential(),
    new ContainerRegistryClientOptions()
    {
        Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
    });
ContainerRepository repository = client.GetRepository(repositoryName);

try
{
    repository.GetProperties();
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

## Service errors

When working with `ContainerRegistryContentClient`, you may get an `RequestFailedException` exception with
message containing additional information and [Docker error code](https://docs.docker.com/registry/spec/api/#errors-2).

### Getting BLOB_UPLOAD_INVALID

In rare cases, a transient error (such as connection reset) can happen during blob upload which may lead to a `RequestFailedException` with a 404 status code being thrown with message similar to
`{"errors":[{"code":"BLOB_UPLOAD_INVALID","message":"blob upload invalid"}]}`, and resulting in a failed upload.  In this case, upload should to be restarted from the beginning.

The following code sample illustrates how you can catch this exception.

```C# Snippet:ContainerRegistry_Samples_CanCatchUploadFailure
try
{
    BinaryData blob = BinaryData.FromString("Sample blob.");
    UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(blob);
}
catch (RequestFailedException ex) when (ex.Status == 404 && ex.ErrorCode == "BLOB_UPLOAD_INVALID")
{
    Console.WriteLine("Blob upload failed. Please retry.");
    Console.WriteLine($"Service error: {ex.Message}");
}
```
