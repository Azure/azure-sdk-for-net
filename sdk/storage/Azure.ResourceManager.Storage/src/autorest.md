# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.Storage
tag: package-2021-08
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/409af02e5ca217c7e7ec2acf50f4976c053496f8/specification/storage/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour: # we need to remove these two configurations
  lenient-model-deduplication: true
  seal-single-value-enum-by-default: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}

override-operation-name:
  StorageAccounts_CheckNameAvailability: CheckStorageAccountNameAvailability

request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}: managementPolicies/default

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
  SAS: Sas
  
directive:
  - rename-model:
      from: BlobServiceProperties
      to: BlobService
  - rename-model:
      from: QueueServiceProperties
      to: QueueService
  - rename-model:
      from: FileServiceProperties
      to: FileService
  - rename-model:
      from: TableServiceProperties
      to: TableService
  - from: swagger-document
    where: $.definitions.FileShareItems.properties.value.items["$ref"]
    transform: return "#/definitions/FileShare"
  - from: swagger-document
    where: $.definitions.ListContainerItems.properties.value.items["$ref"]
    transform: return "#/definitions/BlobContainer"
  - from: swagger-document
    where: $.definitions.ListQueueResource.properties.value.items["$ref"]
    transform: return "#/definitions/StorageQueue"
  - from: swagger-document
    where: $.definitions.Multichannel.properties.enabled
    transform: $['x-ms-client-name'] = 'IsMultiChannelEnabled'
```
