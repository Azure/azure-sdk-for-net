# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: KeyVault
namespace: Azure.ResourceManager.KeyVault
tag: package-2021-10
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
override-operation-name:
  Vaults_CheckNameAvailability: CheckKeyVaultNameAvailability
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
    where: $.definitions.CheckNameAvailabilityResult.properties.reason
    transform: >
      $["x-ms-enum"] = {
        "modelAsString": false,
        "name": "NameAvailabilityReason"
      }
  - from: swagger-document
    where: $.definitions.Permissions.properties
    transform: >
      $.keys.items["x-ms-enum"]["name"] = "KeyPermission";
      $.secrets.items["x-ms-enum"]["name"] = "SecretPermission";
      $.certificates.items["x-ms-enum"]["name"] = "CertificatePermission";
      $.storage.items["x-ms-enum"]["name"] = "StoragePermission";
  - from: swagger-document
    where: "$.definitions.Resource"
    transform: >
      $["x-ms-client-name"] = "KeyVaultResourceData";
  - from: managedHsm.json
    where: "$.definitions"
    transform: >
      $.ManagedHsmResource["x-ms-client-name"] = "KeyVaultTrackedResourceData";
      $.MHSMIPRule.properties.value["x-ms-client-name"] = "AddressRange";
      $.ManagedHsmResource.properties.location["x-ms-format"] = "azure-location"; 
      $.DeletedManagedHsmProperties.properties.location["x-ms-format"] = "azure-location"; 
  - from: keyvault.json
    where: "$.definitions"
    transform: >
      $.IPRule.properties.value["x-ms-client-name"] = "AddressRange";
      $.DeletedVaultProperties.properties.location["x-ms-format"] = "azure-location";
      $.VaultCreateOrUpdateParameters.properties.location["x-ms-format"] = "azure-location"; 
      $.VaultAccessPolicyParameters.properties.location["x-ms-format"] = "azure-location"; 
      $.Vault.properties.location["x-ms-format"] = "azure-location"; 
      $.Resource.properties.location["x-ms-format"] = "azure-location"; 
  - rename-model:
      from: MHSMIPRule
      to: MhsmIPRule
  - rename-model:
      from: Attributes
      to: BaseAttributes
  - rename-model:
      from: Permissions
      to: AccessPermissions

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
