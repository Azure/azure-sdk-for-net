# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: KeyVault
namespace: Azure.ResourceManager.KeyVault
require: https://github.com/Azure/azure-rest-api-specs/blob/402675202904b97229b067bf3b03ac8519de5125/specification/keyvault/resource-manager/readme.md
#tag: package-2023-07
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

override-operation-name:
  Vaults_CheckNameAvailability: CheckKeyVaultNameAvailability
  MHSMPrivateLinkResources_ListByMhsmResource: GetManagedHsmPrivateLinkResources
  ManagedHsms_CheckManagedHsmNameAvailability: CheckManagedHsmNameAvailability
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

acronym-mapping:
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

rename-mapping:
  CheckMhsmNameAvailabilityResult: ManagedHsmNameAvailabilityResult
  CheckMhsmNameAvailabilityResult.nameAvailable : IsNameAvailable
  CheckMhsmNameAvailabilityParameters: MhsmNameAvailabilityParameters
  Reason: ManagedHsmNameUnavailableReason
  ActivationStatus: ManagedHSMSecurityDomainActivationStatus
  Attributes: SecretBaseAttributes
  GeoReplicationRegionProvisioningState: ManagedHsmGeoReplicatedRegionProvisioningState
  ManagedHsmPrivateEndpointConnectionItemData.id: -|arm-id
  Secret: KeyVaultSecret
  MhsmPrivateEndpointConnectionItem: ManagedHsmPrivateEndpointConnectionItemData
  MhsmPrivateEndpointConnectionItem.id: -|arm-id
  MhsmPrivateLinkResource: ManagedHsmPrivateLinkResourceData
  ActionsRequired: ManagedHsmActionsRequiredMessage
  NetworkRuleAction: ManagedHsmNetworkRuleAction
  NetworkRuleBypassOptions: ManagedHsmNetworkRuleBypassOption
  MhsmVirtualNetworkRule.id: SubnetId|arm-id
  PublicNetworkAccess: ManagedHsmPublicNetworkAccess
  CreateMode: ManagedHsmCreateMode
  ManagedHsmProperties.networkAcls: NetworkRuleSet
  MhsmipRule: ManagedHsmIPRule
  DeletedManagedHsmProperties.mhsmId: -|arm-id
  DeletedVaultProperties: DeletedKeyVaultProperties
  DeletedVault: DeletedKeyVault
  MhsmipRule.value: AddressRange
  PrivateLinkResource: KeyVaultPrivateLinkResourceData
  AccessPolicyEntry: KeyVaultAccessPolicy
  NetworkRuleSet: KeyVaultNetworkRuleSet
  VaultCheckNameAvailabilityParameters: KeyVaultNameAvailabilityContent
  VaultAccessPolicyProperties: KeyVaultAccessPolicyProperties
  PrivateEndpointConnectionItem: KeyVaultPrivateEndpointConnectionItemData
  VaultCheckNameAvailabilityParameters.type: -|resource-type
  VaultPatchProperties: KeyVaultPatchProperties
  VaultAccessPolicyParameters: KeyVaultAccessPolicyParameters
  VaultPatchProperties.networkAcls: NetworkRuleSet
  VaultProperties: KeyVaultProperties
  VaultProperties.networkAcls: NetworkRuleSet
  Vault: KeyVault
  VirtualNetworkRule: KeyVaultVirtualNetworkRule
  DeletedVaultProperties.vaultId: -|arm-id
  Permissions: IdentityAccessPermissions
  IPRule: KeyVaultIPRule
  KeyPermissions: IdentityAccessKeyPermission
  SecretPermissions: IdentityAccessSecretPermission
  StoragePermissions: IdentityAccessStoragePermission
  CertificatePermissions: IdentityAccessCertificatePermission
  IPRule.value: AddressRange
  CheckNameAvailabilityResult: KeyVaultNameAvailabilityResult
  Trigger: KeyRotationTrigger
  Action: KeyRotationAction
  Key: KeyVaultKey
  Key.properties.kty: keyType
  KeyAttributes.enabled: isEnabled
  KeyAttributes.exportable: canExported
  KeyProperties.kty: keyType
  ManagedHsmKeyAttributes.enabled: isEnabled
  ManagedHsmKeyAttributes.exportable: canExported
  ManagedHsmKeyProperties.kty: keyType

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
    transform: > # these directives are here on purpose because we do not want them to merge with others otherwise we get breaking changes
      $.MHSMPrivateEndpointConnectionProvisioningState['x-ms-enum']['name'] = 'ManagedHsmPrivateEndpointConnectionProvisioningState';
      $.MHSMPrivateEndpointServiceConnectionStatus['x-ms-enum']['name'] = 'ManagedHsmPrivateEndpointServiceConnectionStatus';
      $.ManagedHsmProperties.properties.provisioningState['x-ms-enum']['name'] = 'ManagedHsmProvisioningState';
  - from: keyvault.json
    where: $.definitions
    transform: >
      $.VaultCheckNameAvailabilityParameters.properties.type['x-ms-constant'] = true;
      $.NetworkRuleSet.properties.bypass['x-ms-enum']['name'] = 'KeyVaultNetworkRuleBypassOption';
      $.NetworkRuleSet.properties.defaultAction['x-ms-enum']['name'] = 'KeyVaultNetworkRuleAction';
      $.PrivateLinkServiceConnectionState.properties.actionsRequired['x-ms-enum']['name'] = 'KeyVaultActionsRequiredMessage';
      $.VaultPatchProperties.properties.createMode['x-ms-enum']['name'] = 'KeyVaultPatchMode';
      $.VaultProperties.properties.createMode['x-ms-enum']['name'] = 'KeyVaultCreateMode';
      $.VaultProperties.properties.provisioningState['x-ms-enum']['name'] = 'KeyVaultProvisioningState';
      $.Vault['x-csharp-usage'] = 'model,input,output';
      $.CheckNameAvailabilityResult.properties.reason['x-ms-enum']['name'] = 'KeyVaultNameUnavailableReason';
  # Remove keysManagedHsm.json and keys.json since these 2 are part of data plane
  - from: keysManagedHsm.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  - from: keys.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
```
