# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataProtectionBackup
namespace: Azure.ResourceManager.DataProtectionBackup
require: https://github.com/Azure/azure-rest-api-specs/blob/33d5054122e52490eef9925d6cbe801f28b88e18/specification/dataprotection/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
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

rename-mapping:
  AzureBackupJob.duration: -|duration-constant

directive:
# Correct the type of properties
  - from: dataprotection.json
    where: $.definitions
    transform: >
      $.AzureBackupRehydrationRequest.properties.rehydrationRetentionDuration['format'] = 'duration';
      $.AzureBackupRestoreWithRehydrationRequest.properties.rehydrationRetentionDuration['format'] = 'duration';
      $.DeleteOption.properties.duration['format'] = 'duration';
      $.CustomCopyOption.properties.duration['format'] = 'duration';
      $.ClientDiscoveryForLogSpecification.properties.blobDuration['format'] = 'duration';
# Remove all the operation related methods
  - remove-operation: OperationResult_Get
  - remove-operation: OperationStatus_Get
  - remove-operation: OperationStatusBackupVaultContext_Get
  - remove-operation: OperationStatusResourceGroupContext_Get
  - remove-operation: BackupVaultOperationResults_Get
  - remove-operation: DataProtectionOperations_List
  - remove-operation: BackupInstances_GetBackupInstanceOperationResult
  - remove-operation: ExportJobsOperationResult_Get
# Enable the x-ms-skip-url-encoding extension for {resourceId}
  - from: dataprotection.json
    where: $.parameters
    transform: >
      $.ResourceId['x-ms-skip-url-encoding'] = true;
# Work around the issue https://github.com/Azure/autorest.csharp/issues/2740
  - from: dataprotection.json
    where: $.definitions
    transform: >
      delete $.BackupVaultResourceList.allOf;
      $.BackupVaultResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.ResourceGuardProxyBaseResourceList.allOf;
      $.ResourceGuardProxyBaseResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.AzureBackupJobResourceList.allOf;
      $.AzureBackupJobResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.AzureBackupRecoveryPointResourceList.allOf;
      $.AzureBackupRecoveryPointResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.BackupInstanceResourceList.allOf;
      $.BackupInstanceResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.BaseBackupPolicyResourceList.allOf;
      $.BaseBackupPolicyResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.DeletedBackupInstanceResourceList.allOf;
      $.DeletedBackupInstanceResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.ResourceGuardResourceList.allOf;
      $.ResourceGuardResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
```
