# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
generate-model-factory: false
csharp: true
library-name: KeyVault
namespace: Azure.ResourceManager.KeyVault
tag: package-2021-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

override-operation-name:
  Vaults_CheckNameAvailability: CheckKeyVaultNameAvailability
  MHSMPrivateLinkResources_ListByMhsmResource: GetManagedHsmPrivateLinkResources
list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

no-property-type-replacement:
- ManagedHsmVirtualNetworkRule

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
  Managecontacts: ManageContacts
  Getissuers: GetIssuers
  Listissuers: ListIssuers
  Setissuers: SetIssuers
  Deleteissuers: DeleteIssuers
  Manageissuers: ManageIssuers
  Regeneratekey: RegenerateKey
  Deletesas: DeleteSas
  Getsas: GetSas
  Listsas: ListSas
  Setsas: SetSas
  Mhsm: ManagedHsm

prompted-enum-values: Default

directive:
  - from: swagger-document
    where: $.paths
    transform: delete $['/subscriptions/{subscriptionId}/resources']
  - from: swagger-document
    where: $.definitions.Sku.properties.family
    transform: delete $['x-ms-client-default']
  - from: swagger-document
    where: $.definitions.ManagedHsmSku.properties.family
    transform: delete $['x-ms-client-default']
  - from: managedHsm.json
    where: $.definitions
    transform: >
      $.ManagedHsmResource['x-ms-client-name'] = 'ManagedHsmTrackedResourceData';
      $.MHSMIPRule.properties.value['x-ms-client-name'] = 'AddressRange';
      $.MHSMIPRule['x-ms-client-name'] = 'ManagedHsmIPRule';
      $.DeletedManagedHsmProperties.properties.mhsmId['x-ms-format'] = 'arm-id';
      $.ManagedHsmProperties.properties.networkAcls['x-ms-client-name'] = 'NetworkRuleSet';
      $.ManagedHsmProperties.properties.provisioningState['x-ms-enum']['name'] = 'ManagedHsmProvisioningState';
      $.ManagedHsmProperties.properties.createMode['x-ms-enum']['name'] = 'ManagedHsmCreateMode';
      $.ManagedHsmProperties.properties.publicNetworkAccess['x-ms-enum']['name'] = 'ManagedHsmPublicNetworkAccess';
      $.MHSMVirtualNetworkRule.properties.id['x-ms-client-name'] = 'SubnetId';
      $.MHSMVirtualNetworkRule.properties.id['x-ms-format'] = 'arm-id';
      $.MHSMNetworkRuleSet.properties.bypass['x-ms-enum']['name'] = 'ManagedHsmNetworkRuleBypassOption';
      $.MHSMNetworkRuleSet.properties.defaultAction['x-ms-enum']['name'] = 'ManagedHsmNetworkRuleAction';
      $.MHSMPrivateLinkServiceConnectionState.properties.actionsRequired['x-ms-enum']['name'] = 'ManagedHsmActionsRequiredMessage';
      $.MHSMPrivateLinkResource['x-ms-client-name'] = 'ManagedHsmPrivateLinkResourceData';
      $.MHSMPrivateEndpointConnectionItem['x-ms-client-name'] = 'ManagedHsmPrivateEndpointConnectionItemData';
      $.MHSMPrivateEndpointConnectionProvisioningState['x-ms-enum']['name'] = 'ManagedHsmPrivateEndpointConnectionProvisioningState';
      $.MHSMPrivateEndpointServiceConnectionStatus['x-ms-enum']['name'] = 'ManagedHsmPrivateEndpointServiceConnectionStatus';
      $.MHSMPrivateLinkServiceConnectionState['x-ms-client-name'] = 'ManagedHsmPrivateLinkServiceConnectionState';
  - from: keyvault.json
    where: $.definitions
    transform: >
      $.CheckNameAvailabilityResult.properties.reason['x-ms-enum']['name'] = 'KeyVaultNameUnavailableReason';
      $.CheckNameAvailabilityResult['x-ms-client-name'] = 'KeyVaultNameAvailabilityResult';
      $.Permissions.properties.keys.items['x-ms-enum']['name'] = 'IdentityAccessKeyPermission';
      $.Permissions.properties.secrets.items['x-ms-enum']['name'] = 'IdentityAccessSecretPermission';
      $.Permissions.properties.certificates.items['x-ms-enum']['name'] = 'IdentityAccessCertificatePermission';
      $.Permissions.properties.storage.items['x-ms-enum']['name'] = 'IdentityAccessStoragePermission';
      $.Permissions['x-ms-client-name'] = 'IdentityAccessPermissions';
      $.IPRule.properties.value['x-ms-client-name'] = 'AddressRange';
      $.IPRule['x-ms-client-name'] = 'KeyVaultIPRule';
      $.VirtualNetworkRule['x-ms-client-name'] = 'KeyVaultVirtualNetworkRule';
      $.DeletedVaultProperties.properties.vaultId['x-ms-format'] = 'arm-id';
      $.Vault['x-ms-client-name'] = 'KeyVault';
      $.Vault['x-csharp-usage'] = 'model,input,output';
      $.VaultProperties['x-ms-client-name'] = 'KeyVaultProperties';
      $.VaultProperties.properties.createMode['x-ms-enum']['name'] = 'KeyVaultCreateMode';
      $.VaultProperties.properties.provisioningState['x-ms-enum']['name'] = 'KeyVaultProvisioningState';
      $.VaultProperties.properties.networkAcls['x-ms-client-name'] = 'NetworkRuleSet';
      $.VaultPatchProperties['x-ms-client-name'] = 'KeyVaultPatchProperties';
      $.VaultPatchProperties.properties.createMode['x-ms-enum']['name'] = 'KeyVaultPatchMode';
      $.VaultPatchProperties.properties.networkAcls['x-ms-client-name'] = 'NetworkRuleSet';
      $.VaultAccessPolicyParameters['x-ms-client-name'] = 'KeyVaultAccessPolicyParameters';
      $.PrivateEndpointConnectionItem['x-ms-client-name'] = 'KeyVaultPrivateEndpointConnectionItemData';
      $.PrivateEndpointConnection['x-ms-client-name'] = 'KeyVaultPrivateEndpointConnection';
      $.PrivateLinkServiceConnectionState.properties.actionsRequired['x-ms-enum']['name'] = 'KeyVaultActionsRequiredMessage';
      $.VaultCheckNameAvailabilityParameters.properties.type['x-ms-format'] = 'resource-type';
      $.VaultCheckNameAvailabilityParameters['x-ms-client-name'] = 'KeyVaultNameAvailabilityParameters';
      $.VaultAccessPolicyProperties['x-ms-client-name'] = 'KeyVaultAccessPolicyProperties';
      $.VaultListResult['x-ms-client-name'] = 'KeyVaultListResult';
      $.NetworkRuleSet.properties.bypass['x-ms-enum']['name'] = 'KeyVaultNetworkRuleBypassOption';
      $.NetworkRuleSet.properties.defaultAction['x-ms-enum']['name'] = 'KeyVaultNetworkRuleAction';
      $.NetworkRuleSet['x-ms-client-name'] = 'KeyVaultNetworkRuleSet';
      $.AccessPolicyEntry['x-ms-client-name'] = 'KeyVaultAccessPolicy';
      $.PrivateEndpointConnectionProvisioningState['x-ms-enum']['name'] = 'KeyVaultPrivateEndpointConnectionProvisioningState';
      $.PrivateEndpointServiceConnectionStatus['x-ms-enum']['name'] = 'KeyVaultPrivateEndpointServiceConnectionStatus';
      $.PrivateLinkServiceConnectionState['x-ms-client-name'] = 'KeyVaultPrivateLinkServiceConnectionState';
      $.PrivateLinkResource['x-ms-client-name'] = 'KeyVaultPrivateLinkResourceData';
      $.Sku.properties.family['x-ms-enum']['name'] = 'KeyVaultSkuFamily';
      $.Sku.properties.name['x-ms-enum']['name'] = 'KeyVaultSkuName';
      $.Sku['x-ms-client-name'] = 'KeyVaultSku';
      $.DeletedVaultProperties['x-ms-client-name'] = 'DeletedKeyVaultProperties';
      $.DeletedVault['x-ms-client-name'] = 'DeletedKeyVault';
      $.DeletedVaultListResult['x-ms-client-name'] = 'DeletedKeyVaultListResult';
```

### Tag: package-2021-10

These settings apply only when `--tag=package-2021-10` is specified on the command line.

```yaml $(tag) == 'package-2021-10'
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/8b871ca35a08c43293fcbb2926e6062db4f6d85c/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2021-10-01/common.json
    - https://github.com/Azure/azure-rest-api-specs/blob/8b871ca35a08c43293fcbb2926e6062db4f6d85c/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2021-10-01/keyvault.json
    - https://github.com/Azure/azure-rest-api-specs/blob/8b871ca35a08c43293fcbb2926e6062db4f6d85c/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2021-10-01/managedHsm.json
    - https://github.com/Azure/azure-rest-api-specs/blob/8b871ca35a08c43293fcbb2926e6062db4f6d85c/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2021-10-01/providers.json
```
