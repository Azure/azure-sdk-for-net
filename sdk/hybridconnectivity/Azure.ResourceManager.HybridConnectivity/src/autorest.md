# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridConnectivity
namespace: Azure.ResourceManager.HybridConnectivity
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/fe44d3261ff0ea816315126120672ccec78c3074/specification/hybridconnectivity/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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

prepend-rp-prefix:
  - InventoryResource
  - CloudNativeType
  - EndpointProperties
  - HostType
  - InventoryProperties
  - ProvisioningState
  - ResourceProvisioningState
  - ServiceName

rename-mapping:
  # IngressGatewayResource and ManagedProxyResource are not ARM resource but end with Resource suffix which is not allowed, so we need to rename them
  IngressGatewayResource: IngressGatewayAsset
  ManagedProxyResource: ManagedProxyAsset
  # format transform
  AADProfileProperties.serverId: -|uuid
  PublicCloudConnectorProperties.connectorPrimaryIdentifier: -|uuid

directive:
  - rename-model:
      from: EndpointAccessResource
      to: TargetResourceEndpointAccess
  - from: swagger-document
    where: $.definitions.EndpointProperties.properties.type
    transform: >
      $["x-ms-client-name"] = "EndpointType";
      $["x-ms-enum"]["name"] = "EndpointType"
  - from: swagger-document
    where: $.parameters.ResourceUriParameter
    transform: >
      $["x-ms-client-name"] = "scope"

    # To generate as Azure.Core.ResourceIdentifier
  - from: swagger-document
    where: $.definitions.ServiceConfigurationProperties.properties.resourceId
    transform: $['x-ms-format'] = 'arm-id'

  - from: swagger-document
    where: $.definitions.GenerateAwsTemplateRequest.properties.connectorId
    transform: $['x-ms-format'] = 'arm-id'

  - from: swagger-document
    where: $.definitions.InventoryProperties.properties.azureResourceId
    transform: $['x-ms-format'] = 'arm-id'

  - from: swagger-document
    where: $.definitions.EndpointProperties.properties.resourceId
    transform: $['x-ms-format'] = 'arm-id'

  - from: swagger-document
    where: $.definitions.AADProfileProperties.properties.serverId
    transform: $['x-ms-format'] = 'arm-id'

```
