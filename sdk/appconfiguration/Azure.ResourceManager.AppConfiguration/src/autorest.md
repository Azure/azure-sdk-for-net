# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: AppConfiguration
namespace: Azure.ResourceManager.AppConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/4716fb039c67e1bee1d5448af9ce57e4942832fe/specification/appconfiguration/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
no-property-type-replacement: RegenerateKeyContent

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
