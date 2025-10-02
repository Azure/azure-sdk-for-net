# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.1 (2025-09-23)

### Features Added

- Make `Azure.ResourceManager.EventHubs` AOT-compatible

## 1.2.0 (2025-06-13)

### Features Added

- Updated dependencies.

## 1.2.0-beta.1 (2024-10-15)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0 (2024-06-14)

### Features Added

- Upgraded api-version tag from 'package-2023-01-preview' to 'package-2024-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/a8c212bc18177ac4891ec93aa7b4c5c834c156e4/specification/eventhub/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.25.0 to 1.40.0
- Upgraded Azure.ResourceManager from 1.2.0 to 1.12.0

## 1.1.0-beta.8 (2024-05-07)

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.1.0-beta.7 (2024-04-30)

### Features Added

- Upgraded api-version tag from 'package-2022-10-preview' to 'package-2023-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/01ae995b35fa5d29433d57bcc0ff508ae8f4bbcc/specification/eventhub/resource-manager/readme.md

## 1.1.0-beta.6 (2024-04-29)

### Features Added

- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.1.0-beta.5 (2024-03-26)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

## 1.1.0-beta.4 (2023-11-21)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.3 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0-beta.2 (2023-04-19)

### Other Changes

- Upgraded API version to 2022-10-01-preview
- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.1.0-beta.1 (2023-02-14)

### Features Added

- Added operation support to `EventHubsApplicationGroup` & `NetworkSecurityPerimeterConfiguration`.
- Supported EventHubsCluster creation with `SupportsScaling`.
- Supported EventHubsNamespace creation with `MinimumTlsVersion` and `PublicNetworkAccess`.

### Other Changes

- Upgraded API version to 2022-01-01-preview.
- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-07-21)

This release is the first stable release of the Azure Event Hubs management library.

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `EventHubs` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.4 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it's only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.3 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously doesn't have one).
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

This release is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).


#### Package Name
The package name has been changed from `Microsoft.Azure.Management.EventHub` to `Azure.ResourceManager.EventHubs`

#### Management Client Changes

Example: Create an EventHub:

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
