# Azure Batch client library for .NET

Azure Batch allows users to run large-scale parallel and high-performance computing (HPC) batch jobs efficiently in Azure.  

Use the client library for to:

* Create and manage Batch jobs and tasks
* View and perform operations on nodes in a Batch pool

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://learn.microsoft.com/dotnet/api/overview/azure/batch?view=azure-dotnet) | [Product documentation](https://learn.microsoft.com/azure/batch/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Compute.Batch --prerelease
```

### Prerequisites

- An Azure account with an active subscription. If you don't have one, [create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).

- A Batch account with a linked Azure Storage account. You can create the accounts by using any of the following methods: [Azure CLI](https://learn.microsoft.com/azure/batch/quick-create-cli) | [Azure portal](https://learn.microsoft.com/azure/batch/quick-create-portal) | [Bicep](https://learn.microsoft.com/azure/batch/quick-create-bicep) | [ARM template](https://learn.microsoft.com/azure/batch/quick-create-template) | [Terraform](https://learn.microsoft.com/azure/batch/quick-create-terraform).

- [Visual Studio 2019](https://www.visualstudio.com/vs) or later, or [.NET 6.0](https://dotnet.microsoft.com/download/dotnet) or later, for Linux or Windows.
### Authenticate the client

Batch account access supports two methods of authentication: Shared Key and Microsoft Entra ID.

We strongly recommend using Microsoft Entra ID for Batch account authentication. Some Batch capabilities require this method of authentication, including many of the security-related features discussed here. The service API authentication mechanism for a Batch account can be restricted to only Microsoft Entra ID using the [allowedAuthenticationModes](https://learn.microsoft.com/rest/api/batchmanagement/batch-account/create?view=rest-batchmanagement-2024-02-01&tabs=HTTP) property. When this property is set, API calls using Shared Key authentication will be rejected.

#### Authenticate using Microsoft Entra ID

Azure Batch provides integration with Microsoft Entra ID for identity-based authentication of requests. With Azure AD, you can use role-based access control (RBAC) to grant access to your Azure Batch resources to users, groups, or applications. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides easy Microsoft Entra ID support for authentication.


```C#
BatchClient client = new BatchClient(
    new Uri("https://examplebatchaccount.eastus.batch.azure.com"),
    new DefaultAzureCredential());
```

#### Authenticate using Shared Key

You can also use Shared Key authentication to sign into your Batch account. This method uses your Batch account access keys to authenticate Azure commands for the Batch service.  You can find your batch account shared keys in the portal under the "keys" section or you can run the following [CLI command](https://learn.microsoft.com/cli/azure/batch/account/keys?view=azure-cli-latest) 

```bash
az batch account keys list --name <your-batch-account> --resource-group <your-resource-group-name>
```

```C#
var credential = new AzureNamedKeyCredential("examplebatchaccount", "BatchAccountKey");
BatchClient client = new BatchClient(
    new Uri("https://examplebatchaccount.eastus.batch.azure.com"),
    new credential());
```

## Key concepts

[Azure Batch Overview](https://learn.microsoft.com/azure/batch/batch-technical-overview)

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking?tabs=csharp) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/batch/Azure.Compute.Batch/samples/README.md).
## Troubleshooting
## Next steps

View more https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/samples here for common usages of the Batch client library: [Batch Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/samples).

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit [Contributor License Agreements](https://opensource.microsoft.com/cla/).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.