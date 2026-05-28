# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: KeyVault
namespace: Azure.ResourceManager.KeyVault
require: https://github.com/Azure/azure-rest-api-specs/blob/ec840ab32b39f029da1021637090cfc24b7429a8/specification/keyvault/resource-manager/readme.md
#tag: package-2025-05
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

#mgmt-debug:
#  show-serialized-names: true

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
  ActivationStatus: ManagedHSMSecurityDomainActivationStatus
  Attributes: SecretBaseAttributes
  GeoReplicationRegionProvisioningState: ManagedHsmGeoReplicatedRegionProvisioningState
  ManagedHsmPrivateEndpointConnectionItemData.id: -|arm-id
  Secret: KeyVaultSecret
  MhsmPrivateEndpointConnectionItem: ManagedHsmPrivateEndpointConnectionItemData
  MhsmPrivateEndpointConnectionItem.id: -|arm-id
  MhsmPrivateLinkResource: ManagedHsmPrivateLinkResourceData
  MhsmVirtualNetworkRule.id: SubnetId|arm-id
  PublicNetworkAccess: ManagedHsmPublicNetworkAccess
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
  VaultProvisioningState: KeyVaultProvisioningState
  ProvisioningState: ManagedHsmProvisioningState
  CreateMode: KeyVaultCreateMode
  PrivateEndpointServiceConnectionStatus: KeyVaultPrivateEndpointServiceConnectionStatus
  NetworkRuleBypassOptions: KeyVaultNetworkRuleBypassOption
  ActionsRequired: KeyVaultActionsRequiredMessage
  NetworkRuleAction: KeyVaultNetworkRuleAction
  Reason: KeyVaultNameUnavailableReason

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
  # Delete according to the paths deleted in the keysManagedHsm.json and keys.json files above.
  - from: openapi.json
    where: $.paths
    transform: >
      var pathsToDelete = [
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys',
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys/{keyName}',
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys/{keyName}/versions/{keyVersion}',
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys/{keyName}/versions',
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}',
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys',
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}',
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions'
      ];
      for (var i = 0; i < pathsToDelete.length; i++) {
        delete $[pathsToDelete[i]];
      }
  # The following content was originally in the managedHsm.json file,
  # but is not present in the new file, and the references have also changed.
  - from: openapi.json
    where: $.definitions
    transform: >
      $.MHSMPrivateEndpointConnectionProvisioningState = {
            "type": "string",
            "readOnly": true,
            "description": "The current provisioning state.",
            "enum": [
              "Succeeded",
              "Creating",
              "Updating",
              "Deleting",
              "Failed",
              "Disconnected"
            ],
            "x-ms-enum": {
              "name": "ManagedHsmPrivateEndpointConnectionProvisioningState",
              "modelAsString": true,
              "values": [
                {
                  "name": "Succeeded",
                  "value": "Succeeded"
                },
                {
                  "name": "Creating",
                  "value": "Creating"
                },
                {
                  "name": "Updating",
                  "value": "Updating"
                },
                {
                  "name": "Deleting",
                  "value": "Deleting"
                },
                {
                  "name": "Failed",
                  "value": "Failed"
                },
                {
                  "name": "Disconnected",
                  "value": "Disconnected"
                }
              ]
            }
      };
      $.MHSMPrivateEndpointConnectionProperties.properties.provisioningState['$ref'] = '#/definitions/MHSMPrivateEndpointConnectionProvisioningState';
  # The directive processing in the above managedHsm.json and keyvault.json files is similar.
  - from: openapi.json
    where: $.definitions.VaultCheckNameAvailabilityParameters.properties
    transform: >
      $.type['x-ms-constant'] = true;
  # The following are all merged from multiple JSON files into one JSON file,
  # where multiple nodes in the definitions reference the same node (with different original names, but currently the same).
  - from: openapi.json
    where: $.definitions
    transform: >
      $.PatchMode = {
          "type": "string",
          "description": "The vault's create mode to indicate whether the vault need to be recovered or not.",
          "enum": [
            "recover",
            "default"
          ],
          "x-ms-enum": {
            "name": "KeyVaultPatchMode",
            "modelAsString": false
          }
      };
      $.VaultPatchProperties.properties.createMode['$ref'] = '#/definitions/PatchMode';
      $.MHSMCreateMode = {
          "type": "string",
          "description": "The create mode to indicate whether the resource is being created or is being recovered from a deleted resource.",
          "enum": [
            "recover",
            "default"
          ],
          "x-ms-enum": {
            "name": "ManagedHsmCreateMode",
            "modelAsString": false,
            "values": [
              {
                "value": "recover",
                "description": "Recover the managed HSM pool from a soft-deleted resource."
              },
              {
                "value": "default",
                "description": "Create a new managed HSM pool. This is the default option."
              }
            ]
          },
          "x-ms-mutability": [
            "create",
            "update"
          ]
      };
      $.ManagedHsmProperties.properties.createMode['$ref'] = '#/definitions/MHSMCreateMode';
  - from: openapi.json
    where: $.definitions
    transform: >
      $.MHSMPrivateEndpointServiceConnectionStatus = {
          "type": "string",
          "description": "The private endpoint connection status.",
          "enum": [
            "Pending",
            "Approved",
            "Rejected",
            "Disconnected"
          ],
          "x-ms-enum": {
            "name": "ManagedHsmPrivateEndpointServiceConnectionStatus",
            "modelAsString": true
          }
      };
      $.MHSMPrivateLinkServiceConnectionState.properties.status['$ref'] = '#/definitions/MHSMPrivateEndpointServiceConnectionStatus';
  - from: openapi.json
    where: $.definitions
    transform: >
      $.MHSMReason = {
          "readOnly": true,
          "type": "string",
          "description": "The reason that a managed hsm name could not be used. The reason element is only returned if NameAvailable is false.",
          "enum": [
            "AccountNameInvalid",
            "AlreadyExists"
          ],
          "x-ms-enum": {
            "name": "ManagedHsmNameUnavailableReason",
            "modelAsString": true
          }
      };
      $.CheckMhsmNameAvailabilityResult.properties.reason['$ref'] = '#/definitions/MHSMReason';
      $.Reason['x-ms-enum']['modelAsString'] = false;
  - from: openapi.json
    where: $.definitions
    transform: >
      $.MHSMNetworkRuleBypassOptions = {
          "type": "string",
          "description": "Tells what traffic can bypass network rules. This can be 'AzureServices' or 'None'.  If not specified the default is 'AzureServices'.",
          "enum": [
            "AzureServices",
            "None"
          ],
          "x-ms-enum": {
            "name": "ManagedHsmNetworkRuleBypassOption",
            "modelAsString": true
          }
      };
      $.MHSMNetworkRuleSet.properties.bypass['$ref'] = '#/definitions/MHSMNetworkRuleBypassOptions';
      $.MHSMNetworkRuleAction = {
          "type": "string",
          "description": "The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated.",
          "enum": [
            "Allow",
            "Deny"
          ],
          "x-ms-enum": {
            "name": "ManagedHsmNetworkRuleAction",
            "modelAsString": true
          }
      };
      $.MHSMNetworkRuleSet.properties.defaultAction['$ref'] = '#/definitions/MHSMNetworkRuleAction';
  - from: openapi.json
    where: $.definitions
    transform: >
      $.MHSMActionsRequired = {
          "type": "string",
          "description": "A message indicating if changes on the service provider require any updates on the consumer.",
          "enum": [
            "None"
          ],
          "x-ms-enum": {
            "name": "ManagedHsmActionsRequiredMessage",
            "modelAsString": true
          }
      };
      $.MHSMPrivateLinkServiceConnectionState.properties.actionsRequired['$ref'] = '#/definitions/MHSMActionsRequired';
  # this directive is here to workaround a usage issue. Now all the resources in this swagger shares the same base type, and in swagger generator the usage of base type is not properly propagated to the derived types.
  # therefore a `input` usage in one of the derived types will polute the other output only derived types with `input` usage, which is not correct.
  # so here is a workaround that we made up a new base type that is only used as output, and let all the output only resources to derive from it.
  # this would not affect the generated code because we recognize the base type from the shape - any model with the 3 properties of id, name and type as read-only is a resource.
  - from: openapi.json
    where: $.definitions
    transform: >
      $.OutputOnlyResource = {
          "type": "object",
          "description": "A resource model that is only used as output.",
          "properties": {
            "id": {
              "type": "string",
              "format": "arm-id",
              "description": "Fully qualified resource ID for the resource. E.g. \"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}\"",
              "readOnly": true
            },
            "name": {
              "type": "string",
              "description": "The name of the resource",
              "readOnly": true
            },
            "type": {
              "type": "string",
              "description": "The type of the resource. E.g. \"Microsoft.Compute/virtualMachines\" or \"Microsoft.Storage/storageAccounts\"",
              "readOnly": true,
              "x-ms-client-name": "resourceType"
            }
          }
      };
      $.DeletedVault.allOf[0]['$ref'] = '#/definitions/OutputOnlyResource';
      $.DeletedManagedHsm.allOf[0]['$ref'] = '#/definitions/OutputOnlyResource';
```
