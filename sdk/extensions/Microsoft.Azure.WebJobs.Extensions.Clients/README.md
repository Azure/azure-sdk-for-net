# Azure client library integration for WebJobs/Azure.Functions

Microsoft.Extensions.Azure.Core provides shared primitives to integrate Azure clients with ASP.NET Core [dependency injection][dependency_injection] and [configuration][configuration] systems.

[Source code][source_root] | [Package (NuGet)][package]

## Getting started

### Install the package

Install the ASP.NET Core integration library using [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.Clients --prerelease
```

### Reference the client from a function

Annotate a function parameter with an `AzureClient` attribute passing a connection name as a parameter.

```C# Snippet:AzureClientInFunction
public static class Function1
{
    [FunctionName("Function1")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [AzureClient("MyStorageConnection")] BlobServiceClient client)
    {
        return new OkObjectResult(client.GetBlobContainers().ToArray());
    }
}
```

The connection name should correspond to a configuration section with a connection string or a set of connection parameters that correspond to a client constructor.

For example to construct a `BlobServiceClient` using a connection string use the following configuration:

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "MyStorageConnection": "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
    }
}
```

To construct a client using a `serviceUri`:

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "MyStorageConnection__serviceUri": "http://127.0.0.1:10000/devstoreaccount1/container/blob",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
    }
}
```

You can do the same via [Azure.Function settings in the portal][azure_function_settings] by setting `StorageConnection` or `StorageConnection__blobUri` application settings (*NOTE* configuration format uses [ASP.NET Core environment variable provider][aspnet_core_env_vars] syntax).

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.


<!-- LINKS -->
[source_root]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/extensions/Microsoft.Azure.WebJobs.Extensions.Clients/
[nuget]: https://www.nuget.org/
[package]: https://www.nuget.org/packages/Microsoft.Extensions.Azure/
[azure_function_settings]: https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings
[aspnet_core_env_vars]: https://learn.microsoft.com/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1#environment-variables