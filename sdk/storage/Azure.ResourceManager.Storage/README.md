# Microsoft Azure Storage management client library for .NET

Microsoft Azure Storage is a Microsoft-managed service providing cloud storage that is highly available, secure, durable, scalable, and redundant. 

This library supports managing Microsoft Azure Storage resources, including the creation of new storage accounts.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started

### Install the package

Install the Microsoft Azure Storage management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.Storage
```

### Prerequisites

First, to install the [Microsoft Azure Identity](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet) package:

```dotnetcli
dotnet add package Azure.Identity
```

Set up a way to authenticate to Microsoft Azure with Azure Identity.

Some options are:
- Through the [Azure CLI Sign in](https://learn.microsoft.com/cli/azure/authenticate-azure-cli).
- Via [Visual Studio](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#authenticating-via-visual-studio).
- Setting [Environment Variables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/AuthUsingEnvironmentVariables.md).

More information and different authentication approaches using Microsoft Azure Identity can be found in [this document](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Microsoft Azure and create an `ArmClient`, do the following code:

```C# Snippet:Managing_StorageAccounts_AuthClient_Namespaces
using Azure.Identity;
using Azure.ResourceManager;
```
```C# Snippet:Managing_StorageAccounts_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

More documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)

## Examples

- [Managing Storage Accounts](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample1_ManagingStorageAccounts.md).

- [Managing Blob Containers](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample2_ManagingBlobContainers.md).
- [Managing File Shares](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample3_ManagingFileShares.md).

## Troubleshooting

-   If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues), and make sure you add the "Preview" label to the issue.
-   If you need help, check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using Azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).


## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
