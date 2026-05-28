# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridConnectivity
namespace: Azure.ResourceManager.HybridConnectivity
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/5f869da70574588b5af7c46a20de802cb8edc093/specification/hybridconnectivity/resource-manager/readme.md
#tag: package-2023-03
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

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
  # - CloudNativeType
  - EndpointProperties
  # - HostType
  # - InventoryProperties
  - ProvisioningState
  # - ResourceProvisioningState
  - ServiceName
  # - SolutionConfiguration
  # - PublicCloudConnector
  # - OperationStatusResult
  # - SolutionTypeProperties

rename-mapping:
  EndpointResource: HybridConnectivityEndpoint
  # InventoryResource: HybridConnectivityInventory
  ServiceConfigurationResource: HybridConnectivityServiceConfiguration
  # SolutionTypeResource: HybridConnectivitySolutionType
  IngressGatewayResource: IngressGatewayAsset
  ManagedProxyResource: ManagedProxyAsset
  IngressGatewayResource.ingress.aadProfile.serverId: -|uuid
  # PublicCloudConnectorProperties.connectorPrimaryIdentifier: -|uuid
  EndpointProperties.resourceId: -|arm-id
  # InventoryProperties.azureResourceId: -|arm-id
  ServiceConfigurationResource.properties.resourceId: -|arm-id
  # GenerateAwsTemplateRequest.connectorId: -|arm-id
  EndpointAccessResource: TargetResourceEndpointAccess

directive:
  - from: swagger-document
    where: $.definitions.EndpointProperties.properties.type
    transform: >
      $["x-ms-enum"]["name"] = "HybridConnectivityEndpointType"

```
