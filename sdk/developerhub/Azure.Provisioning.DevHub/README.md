# Azure Provisioning DevHub client library for .NET

Azure.Provisioning.DevHub simplifies declarative resource provisioning for Azure DevHub in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.DevHub --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET. You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain Bicep or ARM templates.

## Examples

### Create an IaC profile

```C# Snippet:DevHubIacProfileBasic
Infrastructure infra = new();

IacProfile profile =
    new(nameof(profile), IacProfile.ResourceVersions.V2025_03_01_PREVIEW)
    {
        Tags = { ["environment"] = "test" },
        RepositoryName = "infrastructure",
        RepositoryMainBranch = "main",
        RepositoryOwner = "contoso",
    };
infra.Add(profile);

infra.Add(new ProvisioningOutput("profileName", typeof(string)) { Value = profile.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = profile.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
