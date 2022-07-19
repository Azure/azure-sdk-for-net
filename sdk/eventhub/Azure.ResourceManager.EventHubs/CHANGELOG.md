# Release History

## 1.0.0 (2022-07-18)

This is the first stable release of the Azure Event Hubs management library.

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `EventHubs` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properteis / parameters.
- Corrected the format of all `ResouceType` type properteis / parameters.
- Corrected the format of all `ETag` type properteis / parameters.
- Corrected the format of all `AzureLocation` type properteis / parameters.
- Corrected the format of all binary type properteis / parameters.
- Corrected all acronyms which not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters which end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.4 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.3 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously does not have one).
- Renamed some models and methods to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- All properties of the type `object` were changed to `BinaryData`.
- Removed `GetIfExists` methods from all the resource classes.

## 1.0.0-beta.2 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResources` in `SubscriptionExtensions`

## 1.0.0-beta.1 (2021-12-01)

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)


#### Package Name
The package name has been changed from `Microsoft.Azure.Management.EventHub` to `Azure.ResourceManager.EventHubs`

#### Management Client Changes

Example: Create an Event Hub:

Before upgrade:
```csharp
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
```
```csharp
var tokenCredentials = new TokenCredentials("YOUR ACCESS TOKEN");
var eventHubManagementClient = new EventHubManagementClient(tokenCredentials);
eventHubManagementClient.SubscriptionId = subscriptionId;

var createNamespaceResponse = eventHubManagementClient.Namespaces.CreateOrUpdate(
    resourceGroup,
    namespaceName,
    new EHNamespace()
    {
        Location = "westus",
        Sku = new Sku
        {
            Name = SkuName.Standard,
            Tier = SkuTier.Standard
        },
        Tags = new Dictionary<string, string>()
        {
            {"tag1", "value1"},
            {"tag2", "value2"}
        }
    });

var createEventHubResponse = this.EventHubManagementClient.EventHubs.CreateOrUpdate(
    resourceGroup,
    namespaceName,
    eventhubName,
    new Eventhub()
    {
        MessageRetentionInDays = 4,
        PartitionCount = 4,
        Status = EntityStatus.Active,
        CaptureDescription = new CaptureDescription()
        {
            Enabled = true,
            Encoding = EncodingCaptureDescription.Avro,
            IntervalInSeconds = 120,
            SizeLimitInBytes = 10485763,
            Destination = new Destination()
            {
                Name = "EventHubArchive.AzureBlockBlob",
                BlobContainer = "container",
                ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                StorageAccountResourceId = "/subscriptions/" + ResourceManagementClient.SubscriptionId.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew"
            },
            SkipEmptyArchives = true
        }
    });
```

After upgrade:
```C# Snippet:ChangeLog_Sample_Usings
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs.Models;
using Azure.Core;
```
```C# Snippet:ChangeLog_Sample
string namespaceName = "myNamespace";
string eventhubName = "myEventhub";
string resourceGroupName = "myResourceGroup";
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupResource resourceGroup = subscription.GetResourceGroups().Get(resourceGroupName);
//create namespace
EventHubsNamespaceData parameters = new EventHubsNamespaceData(AzureLocation.WestUS)
{
    Sku = new EventHubsSku(EventHubsSkuName.Standard)
    {
        Tier = EventHubsSkuTier.Standard,
    }
};
parameters.Tags.Add("tag1", "value1");
parameters.Tags.Add("tag2", "value2");
EventHubsNamespaceCollection eHNamespaceCollection = resourceGroup.GetEventHubsNamespaces();
EventHubsNamespaceResource eventHubNamespace = eHNamespaceCollection.CreateOrUpdate(WaitUntil.Completed, namespaceName, parameters).Value;

//create eventhub
EventHubCollection eventHubCollection = eventHubNamespace.GetEventHubs();
EventHubData eventHubData = new EventHubData()
{
    MessageRetentionInDays = 4,
    PartitionCount = 4,
    Status = EventHubEntityStatus.Active,
    CaptureDescription = new CaptureDescription()
    {
        Enabled = true,
        Encoding = EncodingCaptureDescription.Avro,
        IntervalInSeconds = 120,
        SizeLimitInBytes = 10485763,
        Destination = new EventHubDestination()
        {
            Name = "EventHubArchive.AzureBlockBlob",
            BlobContainer = "Container",
            ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
            StorageAccountResourceId = new ResourceIdentifier(subscription.Id.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew")
        },
        SkipEmptyArchives = true
    }
};
EventHubResource eventHub = eventHubCollection.CreateOrUpdate(WaitUntil.Completed, eventhubName, eventHubData).Value;
```

#### Object Model Changes

Example: Create an AuthorizationRule Model

Before upgrade:
```csharp
var createAuthorizationRuleParameter = new AuthorizationRule()
    {
        Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
    };
```

After upgrade:
```csharp
var createAuthorizationRuleParameter = new AuthorizationRuleData();
createAuthorizationRuleParameter.Rights.Add(AccessRights.Listen);
createAuthorizationRuleParameter.Rights.Add(AccessRights.Send);
```
