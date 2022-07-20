# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: AppConfiguration
namespace: Azure.ResourceManager.AppConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/d0b5e9937f89a600dd25c1aa450b42fe911e067d/specification/appconfiguration/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

no-property-type-replacement: RegenerateKeyContent

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
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
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
  
request-path-to-parent:
  /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/deletedConfigurationStores: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}
directive:
  - from: swagger-document
    where: $.definitions.EncryptionProperties
    transform: >
      $.properties.keyVaultProperties["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ConfigurationStoreProperties
    transform: >
      $.properties.privateEndpointConnections["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ResourceIdentity.properties.type["x-ms-enum"]["name"]
    transform: return "ResourceIdentityType"
  - rename-operation:
      from: Operations_CheckNameAvailability
      to: CheckAppConfigurationNameAvailability
````
