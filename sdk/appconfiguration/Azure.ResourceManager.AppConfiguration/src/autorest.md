# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: AppConfiguration
namespace: Azure.ResourceManager.AppConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/d0b5e9937f89a600dd25c1aa450b42fe911e067d/specification/appconfiguration/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
no-property-type-replacement: RegenerateKeyOptions

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
  - rename-model:
      from: ConfigurationStoreUpdateParameters
      to: ConfigurationStoreUpdateOptions
  - rename-model:
      from: ListKeyValueParameters
      to: ListKeyValueOptions
  - rename-model:
      from: RegenerateKeyParameters
      to: RegenerateKeyOptions
  - from: swagger-document
    where: $.definitions.EncryptionProperties
    transform: >
      $.properties.keyVaultProperties["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ConfigurationStoreProperties
    transform: >
      $.properties.privateEndpointConnections["x-nullable"] = true;
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}'].patch.parameters
    transform: >
        $[4] = {
            "name": "ConfigurationStoreUpdateOptions",
            "in": "body",
            "description": "The options for updating a configuration store.",
            "required": true,
            "schema": {
              "$ref": "#/definitions/ConfigurationStoreUpdateOptions"
            }
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/listKeyValue'].post.parameters
    transform: >
        $[4] = {
            "name": "listKeyValueOptions",
            "in": "body",
            "description": "The options for retrieving a key-value.",
            "required": true,
            "schema": {
              "$ref": "#/definitions/ListKeyValueOptions"
            }
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/RegenerateKey'].post.parameters
    transform: >
        $[4] = {
            "name": "regenerateKeyOptions",
            "in": "body",
            "description": "The options for regenerating an access key.",
            "required": true,
            "schema": {
              "$ref": "#/definitions/RegenerateKeyOptions"
            }
        }
  - from: swagger-document
    where: $.definitions.ResourceIdentity.properties.type["x-ms-enum"]["name"]
    transform: return "ResourceIdentityType"
  - rename-operation:
      from: Operations_CheckNameAvailability
      to: CheckAppConfigurationNameAvailability
````
