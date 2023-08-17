# Microsoft Azure HDInsight Containers management client library for .NET

Microsoft Azure HDInsgiht Containers(HDInsight On AKS) simplifies deploying hdinsight cluster based the AKS.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:
    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package (Since now we are in private preview status, the bellow method doesn't work please send email to Askhilo@microsoft.com to install the nuget from our private nuget feed)

Install the Azure HDInsight On AKS management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.HDInsight.Containers
```

### Prerequisites

* You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/)

### Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following code:

```C# Snippet:Readme_AuthClient_Namespaces
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
```
```C# Snippet:Readme_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

More documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)

## Documentation

Documentation is available to help you learn how to use this package

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/mgmt_preview_quickstart.md)
- [API References](https://docs.microsoft.com/dotnet/api/?view=azure-dotnet)
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md)

## Examples

Code samples for using the management library for .NET can be found in the following locations
- [.NET Management Library Code Samples](https://docs.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK)

## Troubleshooting

-   File an issue via [Github
    Issues](https://github.com/Azure/azure-sdk-for-net/issues)
-   Check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on Stack Overflow using azure and .net tags.


## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

For details on contributing to this repository, see the contributing
guide.

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(e.g., label, comment). Simply follow the instructions provided by the
bot. You will only need to do this once across all repositories using
our CLA.

This project has adopted the Microsoft Open Source Code of Conduct. For
more information see the Code of Conduct FAQ or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
