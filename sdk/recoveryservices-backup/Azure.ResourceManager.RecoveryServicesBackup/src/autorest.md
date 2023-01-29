# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RecoveryServicesBackup
namespace: Azure.ResourceManager.RecoveryServicesBackup
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/2d9846d81852452cf10270b18329ac382a881bf7/specification/recoveryservicesbackup/resource-manager/readme.md
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
  'SubscriptionIdParameter': 'object'

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
  IaaSVM: IaasVm
  Iaasvm: IaasVm
  Sqldb: SqlDB
  SQLAG: SqlAG
  Sqlag: SqlAG
  MAB: Mab
  DPM: Dpm
  Issqlcompression: IsSqlCompression

override-operation-name:
  BackupStatus_Get: GetBackupStatus

list-exception:
  - /Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig
  - /Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/backupProtectionIntent/{intentObjectName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupconfig/vaultconfig
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/privateEndpointConnections/{privateEndpointConnectionName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}

directive:
  - remove-operation: ProtectedItemOperationResults_Get
  - remove-operation: ProtectionPolicyOperationResults_Get
  - remove-operation: ProtectionContainerOperationResults_Get
  - from: bms.json
    where: $.definitions
    transform: >
      $.TieringPolicy.properties.duration['x-ms-client-name'] = 'durationValue';
      $.AzureIaaSVMJobExtendedInfo.properties.estimatedRemainingDuration['x-ms-client-name'] = 'estimatedRemainingDurationValue';
      $.BMSBackupSummariesQueryObject.properties.type['x-ms-client-name'] = 'BackupManagementType';
      $.BMSBackupSummariesQueryObject.properties.type['x-ms-enum']['name'] = 'BackupManagementType';
      $.RecoveryPointRehydrationInfo.properties.rehydrationRetentionDuration['format'] = 'duration';
  # Autorest.CSharp can't find `nextLink` from parent (allOf), so here workaround.
  # Issues filed here: https://github.com/Azure/autorest.csharp/issues/2740.
  - from: bms.json
    where: $.definitions
    transform: >
      delete $.ProtectionIntentResourceList.allOf;
      $.ProtectionIntentResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.RecoveryPointResourceList.allOf;
      $.RecoveryPointResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectionPolicyResourceList.allOf;
      $.ProtectionPolicyResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.JobResourceList.allOf;
      $.JobResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectedItemResourceList.allOf;
      $.ProtectedItemResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.BackupEngineBaseResourceList.allOf;
      $.BackupEngineBaseResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectableContainerResourceList.allOf;
      $.ProtectableContainerResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.WorkloadItemResourceList.allOf;
      $.WorkloadItemResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.WorkloadProtectableItemResourceList.allOf;
      $.WorkloadProtectableItemResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ProtectionContainerResourceList.allOf;
      $.ProtectionContainerResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.RecoveryPointResourceList.allOf;
      $.RecoveryPointResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
      delete $.ResourceGuardProxyBaseResourceList.allOf;
      $.ResourceGuardProxyBaseResourceList.properties['nextLink'] = {
              'description': 'The uri to fetch the next page of resources.',
              'type': 'string'
            };
  # Here the PATCH operation doesn't return the resource data, so the generated code of `AddTag` operation is not correct.
  # Issue filed here: https://github.com/Azure/autorest.csharp/issues/2741.
  # This directive just pass the build, but the operation may still not work.
  - from: bms.json
    where: $.paths['/Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig']
    transform: >
      $.patch.responses['200'] = {
            'description': 'OK',
            'schema': {
              '$ref': '#/definitions/BackupResourceConfigResource'
            }
          };
  # Here the format date-time isn't specified in swagger, hence adding it explicitly 
  - from: bms.json
    where: $.definitions.RecoveryPointProperties.properties.expiryTime
    transform: >
      $["format"] = "date-time";
```
