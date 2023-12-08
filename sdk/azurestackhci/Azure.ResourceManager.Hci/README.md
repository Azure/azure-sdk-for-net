# Microsoft Azure Stack HCI management client library for .NET

Microsoft Azure VMware Solution is a VMware validated solution with ongoing validation and testing of enhancements and upgrades. Microsoft manages and maintains the private cloud infrastructure and software. It allows you to focus on developing and running workloads in your private clouds to deliver business value.

This library supports managing Microsoft Azure Stack HCI resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started

### Install the package

Install the Azure Stack HCI management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.Hci
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://docs.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples
#### Prerequisites

1. Get the Azure token

```C# Snippet:Readme_AuthClient
TokenCredential cred = new DefaultAzureCredential();
ArmClient client = new ArmClient(cred);
```
2. Update the parameters given below
```C# Snippet:Readme_DefineVars
public string subscriptionId = "00000000-0000-0000-0000-000000000000";  // Replace with your subscription ID
public string resourceGroupName = "hcicluster-rg";                      // Replace with your resource group name
```

### Extension Management  

##### Prerequisites

1. Update the parameters given below
```C# Snippet:Readme_DefineClusterName
public string clusterName = "HCICluster";                               // Replace with your cluster name
```

#### Installing Extensions as part of enabling capabilities

##### Install Azure Monitor Windows Agent Extension

```C# Snippet:Readme_InstallAMA
// Create the Payload and invoke the operation
string extensionName = "AzureMonitorWindowsAgent";
string publisherName = "Microsoft.Azure.Monitor";
string arcExtensionName = "AzureMonitorWindowsAgent";
string typeHandlerVersion = "1.10";
string workspaceId = "xx";  // workspace id for the log analytics workspace to be used with AMA extension
string workspaceKey = "xx"; // workspace key for the log analytics workspace to be used with AMA extension
bool enableAutomaticUpgrade = false;

ArcExtensionData data = new ArcExtensionData()
{
    Publisher = publisherName,
    ArcExtensionType = arcExtensionName,
    TypeHandlerVersion = typeHandlerVersion,
    Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
    {
        ["workspaceId"] = workspaceId
    }),
    ProtectedSettings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
    {
        ["workspaceKey"] = workspaceKey
    }),
    EnableAutomaticUpgrade = enableAutomaticUpgrade,
};

ResourceIdentifier arcSettingResourceId = ArcSettingResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default");
ArcSettingResource arcSetting = client.GetArcSettingResource(arcSettingResourceId);
ArcExtensionCollection collection = arcSetting.GetArcExtensions();

// Create the Extension
var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, extensionName, data);
ArcExtensionResource resource = lro.Value;
```

##### Install Windows Admin Centre Extension

```C# Snippet:Readme_InstallWAC
// Create the payload and invoke the operation
string extensionName = "AdminCenter";
string publisherName = "Microsoft.AdminCenter";
string arcExtensionType = "AdminCenter";
string typeHandlerVersion = "1.10";
string portNumber = "6516"; //port to be associated with WAC
bool enableAutoUpgrade = false; // change to true to enable automatic upgrade

ArcExtensionData data = new ArcExtensionData()
{
    Publisher = publisherName,
    ArcExtensionType = arcExtensionType,
    TypeHandlerVersion = typeHandlerVersion,
    Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
    {
        ["port"] = portNumber
    }),
    EnableAutomaticUpgrade = enableAutoUpgrade,
};
ResourceIdentifier arcSettingResourceId = ArcSettingResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default");
ArcSettingResource arcSetting = client.GetArcSettingResource(arcSettingResourceId);
ArcExtensionCollection collection = arcSetting.GetArcExtensions();

// Create the Extension
var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, extensionName, data);
ArcExtensionResource resource = lro.Value;
```
 
##### Install Azure Site Recovery Extension

```C# Snippet:Readme_InstallASR
string publisherName = "Microsoft.SiteRecovery.Dra";
string arcExtensionType = "Windows";
string extensionName = "AzureSiteRecovery";
ArcExtensionData data = new ArcExtensionData()
{
    Publisher = publisherName,
    ArcExtensionType = arcExtensionType,
    EnableAutomaticUpgrade = true,
    Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
    {
        { "SubscriptionId", "your SubscriptionId" },
        { "Environment", "AzureCloud" },
        { "ResourceGroup", "your ResourceGroup" },
        { "ResourceName", "your site recovery vault name" },
        { "Location", "your site recovery region" },
        { "SiteId", "Id for your recovery site" },
        { "SiteName", "your recovery site name" },
        { "PolicyId", "your resource id for recovery site policy" },
        { "PrivateEndpointStateForSiteRecovery", "None" },
    })
};

// Get Arc Extension Resource
ResourceIdentifier arcSettingResourceId = ArcSettingResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default");
ArcSettingResource arcSetting = client.GetArcSettingResource(arcSettingResourceId);
ArcExtensionCollection collection = arcSetting.GetArcExtensions();

// Create the Extension
var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, extensionName, data);
ArcExtensionResource resource = lro.Value;
```


#### Extension upgrade



```C# Snippet:Readme_ExtensionUpgrade
string extensionName = "AzureMonitorWindowsAgent"; // Replace with your extension name Some common examples are: AzureMonitorWindowsAgent, AzureSiteRecovery, AdminCenter
string targetVersion = "1.0.18062.0"; //replace with extension version you want to install
ResourceIdentifier arcExtensionResourceId = ArcExtensionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default", extensionName);
ArcExtensionResource arcExtension = client.GetArcExtensionResource(arcExtensionResourceId);
// Invoke Upgrade operation
ExtensionUpgradeContent content = new ExtensionUpgradeContent()
{
    TargetVersion = targetVersion,
};
await arcExtension.UpgradeAsync(WaitUntil.Completed, content);
```

#### Deleting an ARC Extension



```C# Snippet:Readme_DeleteExtension
string extensionName = "AzureMonitorWindowsAgent"; // Replace with your extension name Some common examples are: AzureMonitorWindowsAgent, AzureSiteRecovery, AdminCenter
ResourceIdentifier arcExtensionResourceId = ArcExtensionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default", extensionName);
ArcExtensionResource arcExtension = client.GetArcExtensionResource(arcExtensionResourceId);
// Invoke the delete operation
await arcExtension.DeleteAsync(WaitUntil.Completed);
```

### HCI Cluster Management  

#### View HCI Clusters

##### Get Single HCI Cluster using Cluster Name

```C# Snippet:Readme_ViewCluster
// Get the HCI Cluster
string clusterName = "HCICluster"; // Replace with your cluster name,
ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);

// Invoke get operation
HciClusterResource result = await hciCluster.GetAsync();
```

#### Delete Single HCI cluster 

```C# Snippet:Readme_DeleteCluster
// Get the HCI Cluster
ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);

// Invoke delete operation
await hciCluster.DeleteAsync(WaitUntil.Completed);
```

#### Delete all HCI Clusters in a Resource Group


```C# Snippet:Readme_DeleteAllClusters
ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

// Get the collection of this HciClusterResource
HciClusterCollection collection = resourceGroupResource.GetHciClusters();

// Calling the delete function for all Cluster Resources in the collection
await foreach (HciClusterResource item in collection.GetAllAsync())
{
    // delete the item

    await item.DeleteAsync(WaitUntil.Completed);
}
```

#### Update HCI Cluster Properties



```C# Snippet:Readme_UpdateClusterProps
// Get the HCI Cluster
ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);
HciClusterPatch patch = new HciClusterPatch()
{
    Tags =
    {
        { "key", "value" }
    },
    DesiredProperties = new HciClusterDesiredProperties()
    {
        WindowsServerSubscription = WindowsServerSubscription.Enabled,  // It can Enabled or Disabled
        DiagnosticLevel = HciClusterDiagnosticLevel.Basic,              // It can be Off, Basic or Enhanced
    },
};
HciClusterResource result = await hciCluster.UpdateAsync(patch);
```

#### Enable Azure Hybrid Benefits  

1. Invoke the Operation to Extend Azure Hybrid Benefit

```C# Snippet:Readme_EnableHybridBenefits
ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);
SoftwareAssuranceChangeContent content = new SoftwareAssuranceChangeContent()
{
    SoftwareAssuranceIntent = SoftwareAssuranceIntent.Enable,
};
HciClusterResource result = (hciCluster.ExtendSoftwareAssuranceBenefitAsync(WaitUntil.Completed, content).Result).Value;
```

Code samples for using the management library for .NET can be found in the following locations
- [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

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