# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.DeviceUpdate
require: https://github.com/Azure/azure-rest-api-specs/blob/a1081882ea6ae33e65da9b86f6a031175c1f8fda/specification/deviceupdate/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

override-operation-name:
  CheckNameAvailability: CheckDeviceUpdateNameAvailability

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag

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
  - from: swagger-document
    where: $.definitions.AccountUpdate
    transform: delete $['allOf']
  - from: swagger-document
    where: $.definitions.AccountUpdate.properties
    transform: >
      $['tags'] = {
        "type": "object",
        "description": "List of key value pairs that describe the resource. This will overwrite the existing tags.",
        "additionalProperties": {
          "type": "string"
        }
      }
  - from: deviceupdate.json
    where: $.definitions
    transform: >
      $.Location['x-ms-client-name'] = 'DeviceUpdateAccountLocationDetail';
      $.Location.properties.role['x-ms-enum'].name = 'DeviceUpdateAccountLocationRole';
      $.Account.properties.properties.properties.sku['x-ms-enum'].name = 'Sku';
```
