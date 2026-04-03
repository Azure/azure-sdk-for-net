# Microsoft Azure Dev Center management client library for .NET

Azure Dev Center is a service that helps development teams centrally manage their developer environments. A dev center is a collection of projects that require similar settings, letting dev infra managers:

- Use **catalogs** to manage infrastructure-as-code (IaC) templates available to projects.
- Define **environment types** that development teams can use to create consistent deployment environments.
- Configure **dev box definitions** (VM image + SKU) and **pools** so developers can self-serve cloud workstations.
- Attach **network connections** for hybrid Azure AD join or native Azure AD join scenarios.

This library supports managing Microsoft Azure Dev Center resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

- Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
- Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
- HTTP pipeline with custom policies.
- Better error-handling.
- Support uniform telemetry across all languages.

## Getting started

### Install the package

Install the Microsoft Azure Dev Center management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.DevCenter
```

### Prerequisites

* You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

The following resources are the core building blocks of Azure Dev Center:

| Resource | Description |
|----------|-------------|
| **DevCenter** | Top-level container that groups related projects and shared infrastructure. |
| **Project** | An organizational unit within a DevCenter, scoped to a team or workload. |
| **DevBoxDefinition** | Defines the VM image and SKU combination used to create dev boxes. |
| **Pool** | Associates a DevBoxDefinition and a NetworkConnection with a project so developers can create dev boxes. |
| **NetworkConnection** | Connects dev boxes to a virtual network (Azure AD join or hybrid Azure AD join). |
| **Catalog** | Attaches an IaC template repository (GitHub or Azure DevOps) to a DevCenter or project. |
| **EnvironmentType** | Defines a category of deployment environment (e.g., Dev, Test, Staging). |

For general Azure SDK for .NET concepts, see the [Azure SDK introduction](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Documentation

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md)
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet)
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md)
- [Azure Dev Center product documentation](https://learn.microsoft.com/azure/dev-box/)

## Examples

### Create a new Azure Dev Center

```C# Snippet:DevCenter_CreateDevCenter
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

// Get (or create) a resource group to place the DevCenter in
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
ArmOperation<ResourceGroupResource> rgLro = await rgCollection.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "sample-rg",
    new ResourceGroupData(AzureLocation.EastUS));
ResourceGroupResource resourceGroup = rgLro.Value;

// Create the DevCenter resource
DevCenterCollection devCenterCollection = resourceGroup.GetDevCenters();
DevCenterData devCenterData = new DevCenterData(AzureLocation.EastUS)
{
    Tags = { ["Environment"] = "Dev" }
};
ArmOperation<DevCenterResource> devCenterLro = await devCenterCollection.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "Contoso",
    devCenterData);
DevCenterResource devCenter = devCenterLro.Value;
Console.WriteLine($"Created DevCenter with id: {devCenter.Data.Id}");
```

### Get an existing Dev Center

```C# Snippet:DevCenter_GetDevCenter
DevCenterCollection devCenterCollection = _resourceGroup.GetDevCenters();

Response<DevCenterResource> response = await devCenterCollection.GetAsync("Contoso");
DevCenterResource devCenter = response.Value;
Console.WriteLine($"DevCenter: {devCenter.Data.Name}, Location: {devCenter.Data.Location}");
```

### List all Dev Centers in a resource group

```C# Snippet:DevCenter_ListDevCenters
DevCenterCollection devCenterCollection = _resourceGroup.GetDevCenters();

await foreach (DevCenterResource devCenter in devCenterCollection.GetAllAsync())
{
    Console.WriteLine($"DevCenter: {devCenter.Data.Name}");
}
```

### Create a project

```C# Snippet:DevCenter_CreateProject
DevCenterProjectCollection projectCollection = _resourceGroup.GetDevCenterProjects();

DevCenterProjectData projectData = new DevCenterProjectData(AzureLocation.EastUS)
{
    DevCenterId = _devCenter.Id,
    Description = "My first Dev Center project.",
    Tags = { ["CostCenter"] = "R&D" }
};
ArmOperation<DevCenterProjectResource> projectLro = await projectCollection.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "DevProject",
    projectData);
DevCenterProjectResource project = projectLro.Value;
Console.WriteLine($"Created Project with id: {project.Data.Id}");
```

### Create a dev box definition

Dev box definitions specify the image and compute SKU that back a dev box pool.

```C# Snippet:DevCenter_CreateDevBoxDefinition
DevBoxDefinitionCollection devBoxDefinitionCollection = _devCenter.GetDevBoxDefinitions();

DevBoxDefinitionData data = new DevBoxDefinitionData(AzureLocation.EastUS)
{
    ImageReference = new DevCenterImageReference
    {
        Id = new ResourceIdentifier(
            $"{_devCenter.Id}/galleries/contosogallery/images/exampleImage/version/1.0.0")
    },
    Sku = new DevCenterSku("general_i_8c32gb256ssd_v2"),
    HibernateSupport = DevCenterHibernateSupport.IsEnabled,
};
ArmOperation<DevBoxDefinitionResource> devBoxDefinitionLro = await devBoxDefinitionCollection.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "WebDevBox",
    data);
DevBoxDefinitionResource devBoxDefinition = devBoxDefinitionLro.Value;
Console.WriteLine($"Created DevBox definition with id: {devBoxDefinition.Data.Id}");
```

### Create a pool

A pool links a dev box definition and a network connection, enabling developers to self-service dev boxes within a project.

```C# Snippet:DevCenter_CreatePool
// Get the project resource
DevCenterProjectCollection projectCollection = _resourceGroup.GetDevCenterProjects();
DevCenterProjectResource project = await projectCollection.GetAsync("DevProject");

// Create a pool in the project
DevCenterPoolCollection poolCollection = project.GetDevCenterPools();
DevCenterPoolData poolData = new DevCenterPoolData(AzureLocation.EastUS)
{
    DevBoxDefinitionName = "WebDevBox",
    NetworkConnectionName = "Network1-eastus",
    LicenseType = DevCenterLicenseType.WindowsClient,
    LocalAdministrator = LocalAdminStatus.IsEnabled,
    StopOnDisconnect = new StopOnDisconnectConfiguration
    {
        Status = StopOnDisconnectEnableStatus.IsEnabled,
        GracePeriodMinutes = 60,
    },
};
ArmOperation<DevCenterPoolResource> poolLro = await poolCollection.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "DevPool",
    poolData);
DevCenterPoolResource pool = poolLro.Value;
Console.WriteLine($"Created pool with id: {pool.Data.Id}");
```

### Create a network connection (Azure AD join)

Network connections allow dev boxes to join an Azure virtual network.

```C# Snippet:DevCenter_CreateNetworkConnection
DevCenterNetworkConnectionCollection networkConnectionCollection = _resourceGroup.GetDevCenterNetworkConnections();

DevCenterNetworkConnectionData networkData = new DevCenterNetworkConnectionData(AzureLocation.EastUS)
{
    SubnetId = new ResourceIdentifier(
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"),
    DomainJoinType = DomainJoinType.AzureADJoin,
};
ArmOperation<DevCenterNetworkConnectionResource> networkLro = await networkConnectionCollection.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "eastus-network",
    networkData);
DevCenterNetworkConnectionResource networkConnection = networkLro.Value;
Console.WriteLine($"Created network connection with id: {networkConnection.Data.Id}");
```

### Delete a Dev Center

```C# Snippet:DevCenter_DeleteDevCenter
DevCenterCollection devCenterCollection = _resourceGroup.GetDevCenters();

Response<DevCenterResource> response = await devCenterCollection.GetAsync("Contoso");
DevCenterResource devCenter = response.Value;

await devCenter.DeleteAsync(WaitUntil.Completed);
Console.WriteLine("DevCenter deleted successfully.");
```

For more code samples, see [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples).

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using the `azure` and `.net` tags.

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/