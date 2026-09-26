# Azure Provisioning AlertsManagement client library for .NET

Azure.Provisioning.AlertsManagement simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.AlertsManagement --prerelease
```

### Prerequisites

* You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

ResourceManager-based provisioning libraries use `DefaultAzureCredential` for authentication. See the [Azure Identity README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md) for more details.

## Key concepts

This library allows you to specify infrastructure in a declarative style using .NET and then deploy it with azd without maintaining Bicep or ARM templates directly.

Service alerts are created by Azure services. Use `ServiceAlert.FromExisting` to reference an existing alert in a declarative model.

## Examples

### Reference an existing service alert

```C# Snippet:AlertsManagementBasic
Infrastructure infra = new();

ServiceAlert alert = ServiceAlert.FromExisting(nameof(alert), ServiceAlert.ResourceVersions.V2025_05_25_PREVIEW);
alert.Name = "existingAlert";
infra.Add(alert);
```

## Troubleshooting

* File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
* Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

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
