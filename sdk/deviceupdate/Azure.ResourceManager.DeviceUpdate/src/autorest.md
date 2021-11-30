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
  - rename-operation:
      from: Accounts_ListByResourceGroup
      to: DeviceUpdateAccounts_ListByResourceGroup
  - rename-operation:
      from: Accounts_Get
      to: DeviceUpdateAccounts_Get
  - rename-operation:
      from: Accounts_Create
      to: DeviceUpdateAccounts_Create
  - rename-operation:
      from: Accounts_Delete
      to: DeviceUpdateAccounts_Delete
  - rename-operation:
      from: Accounts_Update
      to: DeviceUpdateAccounts_Update
  - rename-operation:
      from: Instances_ListByAccount
      to: DeviceUpdateInstances_ListByAccount
  - rename-operation:
      from: Instances_Get
      to: DeviceUpdateInstances_Get
  - rename-operation:
      from: Instances_Create
      to: DeviceUpdateInstances_Create
  - rename-operation:
      from: Instances_Delete
      to: DeviceUpdateInstances_Delete
  - rename-operation:
      from: Instances_Update
      to: DeviceUpdateInstances_Update
  - remove-operation: Accounts_Head
  - remove-operation: Instances_Head
  - remove-operation: Operations_List
  - remove-operation: DeviceUpdateAccounts_Update
  - rename-model:
      from: AccountUpdate
      to: DeviceUpdateAccountUpdateOptions
  - rename-model:
      from: TagUpdate
      to: TagUpdateOptions
```
