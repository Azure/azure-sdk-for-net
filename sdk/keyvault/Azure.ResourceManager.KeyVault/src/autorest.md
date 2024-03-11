# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: KeyVault
namespace: Azure.ResourceManager.KeyVault
tag: package-2023-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

override-operation-name:
  Vaults_CheckNameAvailability: CheckKeyVaultNameAvailability
  MHSMPrivateLinkResources_ListByMhsmResource: GetManagedHsmPrivateLinkResources
  ManagedHsms_CheckMhsmNameAvailability: CheckManagedHsmNameAvailability
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
```

### Tag: package-2023-02

These settings apply only when `--tag=package-2023-02` is specified on the command line.

```yaml $(tag) == 'package-2023-02'
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/33f06ff82a4c751bcbc842b7ed4da2e81b0717b6/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-02-01/common.json
    - https://github.com/Azure/azure-rest-api-specs/blob/33f06ff82a4c751bcbc842b7ed4da2e81b0717b6/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-02-01/keyvault.json
    - https://github.com/Azure/azure-rest-api-specs/blob/33f06ff82a4c751bcbc842b7ed4da2e81b0717b6/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-02-01/managedHsm.json
    - https://github.com/Azure/azure-rest-api-specs/blob/33f06ff82a4c751bcbc842b7ed4da2e81b0717b6/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-02-01/providers.json
    - https://github.com/Azure/azure-rest-api-specs/blob/33f06ff82a4c751bcbc842b7ed4da2e81b0717b6/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2023-02-01/secrets.json
```
