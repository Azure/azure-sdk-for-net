# Azure Provisioning ResourceHealth client library for .NET

Azure.Provisioning.ResourceHealth simplifies declarative resource provisioning for Azure Resource Health in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.ResourceHealth --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET. You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain Bicep or ARM templates.

## Examples

### Reference a Resource Health event

This example references an existing Resource Health event by its event tracking ID.

```C# Snippet:ResourceHealthEventBasic
Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };

ResourceHealthEvent healthEvent = ResourceHealthEvent.FromExisting(nameof(healthEvent), ResourceHealthEvent.ResourceVersions.V2025_05_01);
healthEvent.Name = "eventTrackingId";
infra.Add(healthEvent);

infra.Add(new ProvisioningOutput("eventId", typeof(string)) { Value = healthEvent.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any questions or comments.

<!-- LINKS -->

[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
