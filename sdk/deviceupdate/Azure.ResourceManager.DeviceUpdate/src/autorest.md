# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.DeviceUpdate
require: https://github.com/Azure/azure-rest-api-specs/blob/34018925632ef75ef5416e3add65324e0a12489f/specification/deviceupdate/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
output-folder: Generated/
override-operation-name:
  CheckNameAvailability: CheckDeviceUpdateNameAvailability
mgmt-debug:
  show-request-path: true
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
  - from: swagger-document
    where: $.definitions.ConnectionDetails.properties.privateIpAddress
    transform: $['x-ms-client-name'] = 'privateIPAddress'
  - remove-operation: Accounts_Head  # Not supported yet
  - remove-operation: Instances_Head # Not supported yet
  - rename-model:
      from: AccountUpdate
      to: DeviceUpdateAccountUpdateOptions
  - rename-model:
      from: TagUpdate
      to: TagUpdateOptions
```
