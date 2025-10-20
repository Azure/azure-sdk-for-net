# Azure Provisioning client library for .NET

Azure.Provisioning makes it easy to declaratively specify Azure infrastructure natively in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using `dotnet`.  You can then use `azd` to deploy your infrastructure to Azure directly without needing to write or maintain `bicep` or arm templates.

### `ToBicepExpression` Method

The `ToBicepExpression()` extension method allows you to create references to resource properties and values for use in Bicep expressions. This is essential when you need to reference one resource's properties in another resource or build dynamic configuration strings.

#### Common use cases:

**Building connection strings and URLs:**
```csharp
// Create a storage account
StorageAccount storage = new("myStorage", StorageAccount.ResourceVersions.V2023_01_01)
{
    Name = "mystorageaccount",
    Kind = StorageKind.StorageV2
};

// Reference the storage account name in a connection string
BicepExpression connectionString = BicepFunction.Interpolate(
    $"DefaultEndpointsProtocol=https;AccountName={storage.Name.ToBicepExpression()};EndpointSuffix=core.windows.net"
);
```

**Referencing resource outputs:**
```csharp
// Reference a storage account's blob endpoint in an app service
AppService app = new("myApp")
{
    SiteConfig = new SiteConfig
    {
        AppSettings = new BicepList<NameValuePair>
        {
            new() { Name = "StorageBlobEndpoint", Value = storage.PrimaryEndpoints.BlobUri.ToBicepExpression() }
        }
    }
};
```

**Using with Bicep functions:**
```csharp
// Pass resource references to Bicep functions
BicepExpression uniqueStorageName = BicepFunction.Interpolate(
    $"st{BicepFunction.UniqueString(storage.Id.ToBicepExpression())}"
);
```

Use `ToBicepExpression()` whenever you need to reference a resource property or value in Bicep expressions, function calls, or when building dynamic configuration values.

## Examples

### Create Basic Infrastructure

This example demonstrates how to create basic Azure infrastructure using the Azure Provisioning framework, including a storage account with blob services and output values.

```C# Snippet:ProvisioningBasic
Infrastructure infra = new();

// Create a storage account and blob resources
StorageAccount storage =
    new(nameof(storage), StorageAccount.ResourceVersions.V2023_01_01)
    {
        Kind = StorageKind.StorageV2,
        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        IsHnsEnabled = true,
        AllowBlobPublicAccess = false
    };
infra.Add(storage);
BlobService blobs = new(nameof(blobs)) { Parent = storage };
infra.Add(blobs);

// Grab the endpoint
ProvisioningOutput endpoint = new ProvisioningOutput("blobs_endpoint", typeof(string)) { Value = storage.PrimaryEndpoints.BlobUri };
infra.Add(endpoint);
```

### Create A Container App Environment

This example shows how to create a complete container application environment with managed identity, container registry, log analytics workspace, and container app environment with the Aspire dashboard.

```C# Snippet:ProvisioningContainerApp
Infrastructure infra = new();

ProvisioningParameter principalId = new(nameof(principalId), typeof(string)) { Value = "" };
infra.Add(principalId);

ProvisioningParameter tags = new(nameof(tags), typeof(object)) { Value = new BicepDictionary<string>() };
infra.Add(tags);

UserAssignedIdentity mi =
    new(nameof(mi), UserAssignedIdentity.ResourceVersions.V2023_01_31)
    {
        Tags = tags,
    };
infra.Add(mi);

ContainerRegistryService acr =
    new(nameof(acr), ContainerRegistryService.ResourceVersions.V2023_07_01)
    {
        Sku = new ContainerRegistrySku() { Name = ContainerRegistrySkuName.Basic },
        Tags = tags,
        Identity =
            new ManagedServiceIdentity
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssignedUserAssigned,
                UserAssignedIdentities =
                {
                    // TODO: Decide if we want to invest in a less janky way to use expressions as keys
                    { BicepFunction.Interpolate($"{mi.Id}").Compile().ToString(), new UserAssignedIdentityDetails() }
                }
            }
    };
infra.Add(acr);

RoleAssignment pullAssignment = acr.CreateRoleAssignment(ContainerRegistryBuiltInRole.AcrPull, mi);
infra.Add(pullAssignment);

OperationalInsightsWorkspace law =
    new(nameof(law), OperationalInsightsWorkspace.ResourceVersions.V2023_09_01)
    {
        Sku = new OperationalInsightsWorkspaceSku() { Name = OperationalInsightsWorkspaceSkuName.PerGB2018 },
        Tags = tags,
    };
infra.Add(law);

ContainerAppManagedEnvironment cae =
    new(nameof(cae), ContainerAppManagedEnvironment.ResourceVersions.V2024_03_01)
    {
        WorkloadProfiles =
        {
            new ContainerAppWorkloadProfile()
            {
                Name = "consumption",
                WorkloadProfileType = "Consumption"
            }
        },
        AppLogsConfiguration =
            new ContainerAppLogsConfiguration()
            {
                Destination = "log-analytics",
                LogAnalyticsConfiguration = new ContainerAppLogAnalyticsConfiguration()
                {
                    CustomerId = law.CustomerId,
                    SharedKey = law.GetKeys().PrimarySharedKey,
                }
            },
        Tags = tags,
    };
infra.Add(cae);

RoleAssignment contribAssignment = cae.CreateRoleAssignment(AppContainersBuiltInRole.Contributor, mi);
infra.Add(contribAssignment);

// Hack in the Aspire Dashboard as a literal since there's no
// management plane library support for dotNetComponents yet
BicepLiteral aspireDashboard =
    new(
        new ResourceStatement(
            "aspireDashboard",
            new StringLiteralExpression("Microsoft.App/managedEnvironments/dotNetComponents@2024-02-02-preview"),
            new ObjectExpression(
                new PropertyExpression("name", "aspire-dashboard"),
                new PropertyExpression("parent", new IdentifierExpression(cae.BicepIdentifier)),
                new PropertyExpression("properties",
                    new ObjectExpression(
                        new PropertyExpression("componentType", new StringLiteralExpression("AspireDashboard")))))));
infra.Add(aspireDashboard);

infra.Add(new ProvisioningOutput("MANAGED_IDENTITY_CLIENT_ID", typeof(string)) { Value = mi.ClientId });
infra.Add(new ProvisioningOutput("MANAGED_IDENTITY_NAME", typeof(string)) { Value = mi.Name });
infra.Add(new ProvisioningOutput("MANAGED_IDENTITY_PRINCIPAL_ID", typeof(string)) { Value = mi.PrincipalId });
infra.Add(new ProvisioningOutput("LOG_ANALYTICS_WORKSPACE_NAME", typeof(string)) { Value = law.Name });
infra.Add(new ProvisioningOutput("LOG_ANALYTICS_WORKSPACE_ID", typeof(string)) { Value = law.Id });
infra.Add(new ProvisioningOutput("AZURE_CONTAINER_REGISTRY_ENDPOINT", typeof(string)) { Value = acr.LoginServer });
infra.Add(new ProvisioningOutput("AZURE_CONTAINER_REGISTRY_MANAGED_IDENTITY_ID", typeof(string)) { Value = mi.Id });
infra.Add(new ProvisioningOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_NAME", typeof(string)) { Value = cae.Name });
infra.Add(new ProvisioningOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_ID", typeof(string)) { Value = cae.Id });
infra.Add(new ProvisioningOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_DEFAULT_DOMAIN", typeof(string)) { Value = cae.DefaultDomain });
```

### Create A Resource Group At Subscription Scope

This example demonstrates creating a resource group at the subscription scope, which is useful when you need to manage resource groups themselves as part of your infrastructure.

```C# Snippet:ProvisioningResourceGroup
// Create a new infra group scoped to our subscription and add
// the resource group
Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };
ResourceGroup rg = new("rg_test", "2024-03-01");
infra.Add(rg);
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

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

