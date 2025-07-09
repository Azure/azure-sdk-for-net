# Release History

## 1.2.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

- Fix `SystemData` deserialize method in custom code.

### Other Changes

## 1.2.0-beta.2 (2024-10-31)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

- Exposed 'DnsRecordType' property in DnsRecordData.cs and added factory method for DnsRecordData. Issue:https://github.com/Azure/azure-sdk-for-net/issues/45423
- Fixed the NAPTR record type serialization issue and added relevant tests and recordings.

## 1.2.0-beta.1 (2024-06-01)

### Features Added

- Added `trafficManagementProfile` property in some classes.
- Added `serializedAdditionalRawData` property in some classes
- Added resources: `DnsNaptrRecord`, `DnsTlsaRecord`, `DnsDSRecord`, and `DnssecConfig`.
- Added `SigningKeys` property in DnsZoneData

## 1.1.1 (2024-04-29)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added model factory for all `DnsRecordData`
- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.1.0 (2023-11-21)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-29)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-28)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-12-05)

This package is the first stable release of the Azure DNS management library.

### Breaking Changes

 - Added `Dns` prefix for some models
 - Renamed `RecordSet` to `Record`
 - Renamed some properties to more comprehensive names.

### Other Changes

 - Upgraded dependent `Azure.ResourceManager` to 1.3.2
 - Upgraded dependent `Azure.Core` to 1.26.0
 - Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Optimized the name of some resources, models and functions.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that don't follow [Microsoft .NET Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Dns` to `Azure.ResourceManager.Dns`

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Management Client Changes

Before upgrade:

``` c#
using Microsoft.Rest;
using Microsoft.Azure.Management.Dns;
using Microsoft.Azure.Management.Dns.Models;
```

``` c#
var tokenCredentials = new TokenCredentials("YOUR ACCESS TOKEN");
DnsManagementClient dnsManagementClient = new DnsManagementClient(credentials);
var dnsZone = await dnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroupName, dnsZoneName, zone);
```

After upgrade:

```C# Snippet:Manage_DnsZones_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
```

```C# Snippet:Managing_DnsZones_CreateADnsZones
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the DnsZone collection from the resource group
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
// Use the same location as the resource group
string dnsZoneName = "sample.com";
DnsZoneData data = new DnsZoneData("Global")
{
};
ArmOperation<DnsZoneResource> lro = await dnsZoneCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
DnsZoneResource dnsZone = lro.Value;
```
