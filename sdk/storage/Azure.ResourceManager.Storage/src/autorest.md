# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.Storage
tag: package-2021-09
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/4124b7c2773a714303299f0cfd742b0d26d3bb5d/specification/storage/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true

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
  - from: swagger-document
    where: $.definitions.BlobRestoreParameters
    transform: >
      $.required = ["timetoRestore", "blobRanges"];
      for (var key in $.properties) {
          var property = $.properties[key];
          delete $.properties[key];
          if (key === 'timeToRestore') {
              $.properties['timetoRestore'] = property;
              $.properties['timetoRestore']['x-ms-client-name'] = 'timeToRestore';
          }
          else{
              $.properties[key] = property;
          }
      }
  - from: swagger-document
    where: $.definitions.Encryption
    transform: $.required = undefined; # this is a fix for swagger issue, and it should be resolved in azure-rest-api-specs/pull/19357 
```
