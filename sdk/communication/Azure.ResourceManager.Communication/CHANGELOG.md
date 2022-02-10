# Release History

## 1.1.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
This is the first stable release of the management library for Azure Communication Services. 

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

This is the first release of the management library for Azure Communication Services. For more information, please see the [README][read_me].

Use the management library for Azure Communication Services to:

- Create or update a resource
- Get the keys for that resource
- Delete a resource

For more information, please see the README.

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.ResourceManager.Communication/README.md

