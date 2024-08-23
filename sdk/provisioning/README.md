# Azure Provisioning libraries for .NET

The Azure Provisioning libraries are a cloud development kit that allow you to declaratively specify your Azure infrastructure natively in dotnet.
Azure.Provisioning contains the core functionality for the Azure Provisioning libraries. Azure.Provisioning.{ServiceName} contains the resources specific to a particular service.

## Getting started

### Install the package

Install the specific service libraries for .NET with [NuGet](https://www.nuget.org/) required for your application.

```dotnetcli
dotnet add package Azure.Provisioning.KeyVault
```

Note that `Azure.Provisioning` will be pulled in as a transitive dependency
of any of the service libraries. All other service libraries will follow the
pattern of `Azure.Provisioning.{ServiceName}`.

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Creating a KeyVault

Here is a simple example which creates a KeyVault.

First create your Infrastructure class.

```C# Snippet:SampleInfrastructure
public class SampleInfrastructure : Infrastructure
{
    public SampleInfrastructure() : base(envName: "Sample", tenantId: Guid.Empty, subscriptionId: Guid.Empty, configuration: new Configuration { UseInteractiveMode = true })
    {
    }
}
```

Next add your resources into your infrastructure and then Build.

```C# Snippet:KeyVaultOnly
// Create a new infrastructure
var infrastructure = new SampleInfrastructure();

// Add a new key vault
var keyVault = infrastructure.AddKeyVault();

// You can call Build to convert the infrastructure into bicep files.
infrastructure.Build();
```

Here is the resulting bicep:

```bicep
targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource keyVault_7LloDNJK5 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableRbacAuthorization: true
  }
}
```

Because our infrastructure was configured to use interactive mode, the bicep
is scoped to the resource group. This means that a resource group must be
specified when deploying the bicep.

### Using parameters

It is possible to flow parameters to your bicep resources. Here is a simple
example where a parameter is used to enable soft delete on the key vault.

```C# Snippet:KeyVaultOnlyWithParameter
var infrastructure = new SampleInfrastructure();

var keyVault = infrastructure.AddKeyVault();

keyVault.AssignProperty(
    data => data.Properties.EnableSoftDelete,
    new Parameter("enableSoftDelete", defaultValue: true, parameterType: BicepType.Bool, description: "Enable soft delete for the key vault."));

infrastructure.Build();
```

Here is the resulting bicep:

```bicep
targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('Enable soft delete for the key vault.')
param enableSoftDelete bool = true


resource keyVault_7LloDNJK5 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableSoftDelete: enableSoftDelete
    enableRbacAuthorization: true
  }
}
```

### Adding outputs

It is possible to add outputs to your bicep. Here is a simple example where an output is added to the key vault.

```C# Snippet:KeyVaultOnlyAddingOutput
var infrastructure = new SampleInfrastructure();

var keyVault = infrastructure.AddKeyVault();

keyVault.AssignProperty(
    data => data.Properties.EnableSoftDelete,
    new Parameter("enableSoftDelete", defaultValue: true, parameterType: BicepType.Bool, description: "Enable soft delete for the key vault."));

keyVault.AddOutput("VAULT_URI", data => data.Properties.VaultUri);

infrastructure.Build();
```

Here is the resulting bicep:

```bicep
targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('Enable soft delete for the key vault.')
param enableSoftDelete bool = true


resource keyVault_7LloDNJK5 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableSoftDelete: enableSoftDelete
    enableRbacAuthorization: true
  }
}

output VAULT_URI string = keyVault_7LloDNJK5.properties.vaultUri
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

Learn more about deploying bicep using the Azure Developer CLI [here](https://learn.microsoft.com/azure/developer/azure-developer-cli/get-started?tabs=localinstall&pivots=programming-language-csharp).

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

