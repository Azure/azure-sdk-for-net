# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
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
  Vaults_CheckNameAvailability: CheckVaultNameAvailability
  MHSMPrivateLinkResources_ListByMhsmResource: GetMhsmPrivateLinkResources
list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}

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
      $.MHSMPrivateLinkServiceConnectionState.properties.actionsRequired['x-ms-enum']['name'] = 'ManagedHsmActionsRequiredMessage';
      $.MHSMPrivateLinkResource['x-ms-client-name'] = 'ManagedHsmPrivateLinkResourceData';
      $.MHSMPrivateEndpointConnectionItem['x-ms-client-name'] = 'ManagedHsmPrivateEndpointConnectionItemData';
  - from: keyvault.json
    where: $.definitions
    transform: >
      $.CheckNameAvailabilityResult.properties.reason['x-ms-enum']['name'] = 'NameAvailabilityReason';
      $.CheckNameAvailabilityResult['x-ms-client-name'] = 'VaultNameAvailabilityResult';
      $.Permissions.properties.keys.items['x-ms-enum']['name'] = 'IdentityAccessKeyPermission';
      $.Permissions.properties.secrets.items['x-ms-enum']['name'] = 'IdentityAccessSecretPermission';
      $.Permissions.properties.certificates.items['x-ms-enum']['name'] = 'IdentityAccessCertificatePermission';
      $.Permissions.properties.storage.items['x-ms-enum']['name'] = 'IdentityAccessStoragePermission';
      $.Permissions['x-ms-client-name'] = 'IdentityAccessPermissions';
      $.IPRule.properties.value['x-ms-client-name'] = 'AddressRange';
      $.IPRule['x-ms-client-name'] = 'VaultIPRule';
      $.VirtualNetworkRule['x-ms-client-name'] = 'VaultVirtualNetworkRule';
      $.DeletedVaultProperties.properties.vaultId['x-ms-format'] = 'arm-id';
      $.Vault['x-csharp-usage'] = 'model,input,output';
      $.VaultProperties.properties.createMode['x-ms-enum']['name'] = 'VaultCreateMode';
      $.VaultProperties.properties.networkAcls['x-ms-client-name'] = 'NetworkRuleSet';
      $.VaultPatchProperties.properties.createMode['x-ms-enum']['name'] = 'VaultPatchMode';
      $.VaultPatchProperties.properties.networkAcls['x-ms-client-name'] = 'NetworkRuleSet';
      $.PrivateEndpointConnectionItem['x-ms-client-name'] = 'VaultPrivateEndpointConnectionItemData';
      $.PrivateEndpointConnection['x-ms-client-name'] = 'VaultPrivateEndpointConnection';
      $.PrivateLinkServiceConnectionState.properties.actionsRequired['x-ms-enum']['name'] = 'VaultActionsRequiredMessage';
      $.VaultCheckNameAvailabilityParameters.properties.type['x-ms-format'] = 'resource-type';
      $.VaultCheckNameAvailabilityParameters['x-ms-client-name'] = 'VaultNameAvailabilityParameters';
      $.NetworkRuleSet.properties.bypass['x-ms-enum']['name'] = 'VaultNetworkRuleBypassOption';
      $.NetworkRuleSet['x-ms-client-name'] = 'VaultNetworkRuleSet';
      $.AccessPolicyEntry['x-ms-client-name'] = 'VaultAccessPolicy';
      $.PrivateEndpointConnectionProvisioningState['x-ms-enum']['name'] = 'VaultPrivateEndpointConnectionProvisioningState';
      $.PrivateEndpointServiceConnectionStatus['x-ms-enum']['name'] = 'VaultPrivateEndpointServiceConnectionStatus';
      $.PrivateLinkServiceConnectionState['x-ms-client-name'] = 'VaultPrivateLinkServiceConnectionState';
      $.PrivateLinkResource['x-ms-client-name'] = 'VaultPrivateLinkResourceData';
      $.Sku.properties.family['x-ms-enum']['name'] = 'VaultSkuFamily';
      $.Sku.properties.name['x-ms-enum']['name'] = 'VaultSkuName';
      $.Sku['x-ms-client-name'] = 'VaultSku';
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
