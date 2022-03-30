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

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri

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
```
