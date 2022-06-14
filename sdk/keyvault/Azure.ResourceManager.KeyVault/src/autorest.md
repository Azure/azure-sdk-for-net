# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
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
  Listissuers: Listissuers
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
  - from: swagger-document
    where: $.paths..parameters[?(@.name === 'location')]
    transform: >
      $['x-ms-format'] = 'azure-location';
  - from: managedHsm.json
    where: '$.definitions'
    transform: >
      $.ManagedHsmResource['x-ms-client-name'] = 'ManagedHsmTrackedResourceData';
      $.ManagedHsmResource.properties.location['x-ms-format'] = 'azure-location';
      $.MHSMIPRule.properties.value['x-ms-client-name'] = 'AddressRange';
      $.DeletedManagedHsmProperties.properties.location['x-ms-format'] = 'azure-location';
      $.DeletedManagedHsmProperties.properties.mhsmId['x-ms-format'] = 'arm-id';
      $.MHSMPrivateEndpointConnection.properties.etag['x-ms-format'] = 'etag';
      $.ManagedHsmProperties.properties.networkAcls['x-ms-client-name'] = 'NetworkRuleSet';
      $.ManagedHsmProperties.properties.provisioningState['x-ms-enum']['name'] = 'HsmProvisioningState';
      $.MHSMVirtualNetworkRule.properties.id['x-ms-client-name'] = 'SubnetId';
      $.MHSMVirtualNetworkRule.properties.id['x-ms-format'] = 'arm-id';
      $.MHSMNetworkRuleSet.properties.bypass['x-ms-enum']['name'] = 'NetworkRuleBypassOption';
  - from: keyvault.json
    where: '$.definitions'
    transform: >
      $.CheckNameAvailabilityResult.properties.reason['x-ms-enum']['name'] = 'NameAvailabilityReason';
      $.CheckNameAvailabilityResult['x-ms-client-name'] = 'VaultNameAvailabilityResult';
      $.Permissions.properties.keys.items['x-ms-enum']['name'] = 'KeyPermission';
      $.Permissions.properties.secrets.items['x-ms-enum']['name'] = 'SecretPermission';
      $.Permissions.properties.certificates.items['x-ms-enum']['name'] = 'CertificatePermission';
      $.Permissions.properties.storage.items['x-ms-enum']['name'] = 'StoragePermission';
      $.Resource['x-ms-client-name'] = 'KeyVaultResourceData';
      $.IPRule.properties.value['x-ms-client-name'] = 'AddressRange';
      $.DeletedVaultProperties.properties.location['x-ms-format'] = 'azure-location';
      $.DeletedVaultProperties.properties.vaultId['x-ms-format'] = 'arm-id';
      $.VaultCreateOrUpdateParameters.properties.location['x-ms-format'] = 'azure-location';
      $.VaultAccessPolicyParameters.properties.location['x-ms-format'] = 'azure-location';
      $.Vault.properties.location['x-ms-format'] = 'azure-location';
      $.Vault['x-csharp-usage'] = 'model,input,output';
      $.VaultProperties.properties.createMode['x-ms-enum']['name'] = 'VaultCreateMode';
      $.Resource.properties.location['x-ms-format'] = 'azure-location';
      $.PrivateEndpointConnectionItem.properties.etag['x-ms-format'] = 'etag';
      $.PrivateEndpointConnection.properties.etag['x-ms-format'] = 'etag';
      $.PrivateLinkServiceConnectionState.properties.actionsRequired['x-ms-enum']['name'] = 'ActionsRequiredMessage';
      $.VaultCheckNameAvailabilityParameters.properties.type['x-ms-format'] = 'resource-type';
      $.VaultCheckNameAvailabilityParameters['x-ms-client-name'] = 'VaultNameAvailabilityParameters';
      $.NetworkRuleSet.properties.bypass['x-ms-enum']['name'] = 'NetworkRuleBypassOption';
  - rename-model:
      from: MHSMIPRule
      to: MhsmIPRule
  - rename-model:
      from: Attributes
      to: BaseAttributes
  - rename-model:
      from: Permissions
      to: IdentityAccessPermissions
  - rename-model:
      from: MHSMPrivateLinkResource
      to: MHSMPrivateLinkResourceData
  - rename-model:
      from: PrivateLinkResource
      to: PrivateLinkResourceData
  - rename-model:
      from: MHSMPrivateEndpointConnectionItem
      to: MHSMPrivateEndpointConnectionItemData
  - rename-model:
      from: PrivateEndpointConnectionItem
      to: PrivateEndpointConnectionItemData
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
