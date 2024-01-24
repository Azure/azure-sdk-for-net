# Release History

## 1.2.0-beta.5 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.4 (2023-11-16)

### Features Added

- Added support for Email Suppression List and Address resources.
- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.
- Upgraded api-version tag from 'package-preview-2023-04' to 'package-preview-2023-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/5775c90db370eb73a5cd7ccb36e16c34630a5c8c/specification/communication/resource-manager/readme.md#tag-package-preview-2023-06

## 1.2.0-beta.3 (2023-11-08)

### Features Added

- Added support for Email Suppression List and Address resources.

### Other Changes

- Upgraded Azure.Core from 1.35.0 to 1.36.0
- Upgraded Azure.ResourceManager from 1.7.0 to 1.9.0

## 1.2.0-beta.2 (2023-09-12)

### Features Added

- Added support for System Assigned, User Assigned and SystemAndUserAssigned Managed Identity

## 1.2.0-beta.1 (2023-05-29)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-03-31)

### Features Added

- Added SenderUsernameResource, SenderUsernameResourceCollection and SenderUsernameResourceData to support the new resource type.

### Breaking Changes

- This refresh updates `Azure.ResourceManager.Communication` library to the Azure resource management SDK standards and matches the patterns in the rest of the new Azure management libraries. [Resource management using the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/resource-management?tabs=PowerShell)
- Removed ValidSenderUsernames property from CommunicationServiceResourceData.
- CommunicationResource RegenerateKey and RegenerateKeyAsync are no longer marked as long running operations.
- CommunicationResource Update and UpdateAsync are no longer marked as long running operations.

## 1.1.0-beta.6 (2023-02-14)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0-beta.5 (2022-07-21)

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Communication` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.1.0-beta.4 (2022-06-10)

### Breaking Changes

- Rename plenty of classes and property names.

## 1.1.0-beta.3 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.1.0-beta.2 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously does not have one).
- waitForCompletion is now a required parameter and moved to the first parameter in LRO operations.
- Move optional body parameters right after required parameters.
- Location class from `Location` to `AzureLocation`.
- Removed `GetIfExists` methods from all the resource classes.
- All properties of the type `object` were changed to `BinaryData`.

## 1.1.0-beta.1 (2022-01-06)

### Features Added

- Added ArmClient extension methods to support [start from the middle scenario](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#managing-existing-resources-by-id).

### Breaking Changes

Guidance to migrate from previous version of Azure Management SDK

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

#### Management Client Changes

Example: Create A Communication Service Instance:

Before upgrade:
```C#
using Azure.Identity;
using Azure.ResourceManager.Communication;
using Azure.ResourceManager.Communication.Models;
using System;
using System.Threading.Tasks;

string subscriptionId = "_SUBSCRIPTION_ID_";
CommunicationManagementClient communicationServiceClient = new CommunicationManagementClient(subscriptionId, new InteractiveBrowserCredential());
var resourceGroupName = "myResourceGroupName";
var resourceName = "myResource";
var resource = new CommunicationServiceResource { Location = "Global", DataLocation = "UnitedStates" };
var operation = await communicationServiceClient.CommunicationService.StartCreateOrUpdateAsync(resourceGroupName, resourceName, resource);
await operation.WaitForCompletionAsync();
```

After upgrade:
```C#
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
var collection = resourceGroup.GetCommunicationServices();
string communicationServiceName = "myCommunicationService";
CommunicationServiceData data = new CommunicationServiceData()
{
    Location = "global",
    DataLocation = "UnitedStates",
};
var communicationServiceLro = await collection.CreateOrUpdateAsync(communicationServiceName, data);
CommunicationService communicationService = communicationServiceLro.Value;
```

## 1.0.0 (2021-03-29)

This release is the first stable release of the management library for Azure Communication Services.

Minor changes since the public preview release:
- CheckNameAvailability has been added
- CommunicationServiceResource Update now requires a CommunicationServiceResource parameter instead of a TaggedResource
- RegenerateKeyParameters is now a required parameter to RegenerateKey
- CommunicationServiceResource now includes the property SystemData
- OperationList has been changed to use the common type for its response
- ErrorResponse has been changed to use the common type for ErrorResponse

## 1.0.0-beta.3 (2020-11-16)

Updated `Azure.ResourceManager.Communication` version.

## 1.0.0-beta.2 (2020-10-06)

Updated `Azure.ResourceManager.Communication` version.

## 1.0.0-beta.1 (2020-09-22)

### Breaking Changes

New design of track 2 initial commit.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
