# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.DeviceUpdate
require: https://github.com/Azure/azure-rest-api-specs/blob/34018925632ef75ef5416e3add65324e0a12489f/specification/deviceupdate/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
output-folder: Generated/
no-property-type-replacement:
  - CheckNameAvailabilityRequest
directive:
  - from: swagger-document
    where: $.definitions.GroupInformation
    transform: $['x-ms-client-name'] = 'PrivateLink'
  - from: swagger-document
    where: $.definitions.Account
    transform: $['x-ms-client-name'] = 'DeviceUpdateAccount'
  - from: swagger-document
    where: $.definitions.Instance
    transform: $['x-ms-client-name'] = 'DeviceUpdateInstance'
  - rename-operation:
      from: Accounts_ListBySubscription
      to: DeviceUpdateAccounts_ListBySubscription
  - remove-operation: Accounts_Head
  - remove-operation: Instances_Head

```
