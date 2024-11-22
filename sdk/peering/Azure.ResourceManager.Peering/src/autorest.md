# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Peering
namespace: Azure.ResourceManager.Peering
require: https://github.com/Azure/azure-rest-api-specs/blob/5fc05d0f0b15cbf16de942cadce464b495c66a58/specification/peering/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
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
- ProvisioningState
- Family
- Size
- Tier
- Role

models-to-treat-empty-string-as-null:
  - PeeringBgpSession
  - ExchangePeeringFacility
additional-intrinsic-types-to-treat-empty-string-as-null:
  - IPAddress

override-operation-name:
  CheckServiceProviderAvailability: CheckPeeringServiceProviderAvailability
  PeeringServices_InitializeConnectionMonitor: InitializePeeringServiceConnectionMonitor
  LookingGlass_Invoke: InvokeLookingGlass

rename-mapping:
  ValidationState: PeerAsnValidationState
  ContactDetail: PeerAsnContactDetail
  PrefixValidationState: PeeringPrefixValidationState
  LearnedType: PeeringLearnedType
  CheckServiceProviderAvailabilityInput: CheckPeeringServiceProviderAvailabilityContent
  Command: LookingGlassCommand
  DirectConnection: PeeringDirectConnection
  ExchangeConnection: PeeringExchangeConnection
  PeeringPropertiesDirect: DirectPeeringProperties
  PeeringPropertiesExchange: ExchangePeeringProperties
  BgpSession: PeeringBgpSession
  ConnectionState: PeeringConnectionState
  SessionAddressProvider: PeeringSessionAddressProvider
  PeeringLocationPropertiesDirect: DirectPeeringLocationProperties
  ResourceTags: PeeringResourceTagsPatch
  SessionStateV4: PeeringSessionStateV4
  SessionStateV6: PeeringSessionStateV6
  LogAnalyticsWorkspaceProperties: PeeringLogAnalyticsWorkspaceProperties
  RpUnbilledPrefix: RoutingPreferenceUnbilledPrefix
  PeeringLocation.properties.azureRegion: -|azure-location
  ExchangeConnection.connectionIdentifier: -|uuid
  ExchangePeeringFacility.microsoftIPv4Address: -|ip-address
  ExchangePeeringFacility.microsoftIPv6Address: -|ip-address
  BgpSession.microsoftSessionIPv4Address: -|ip-address
  BgpSession.microsoftSessionIPv6Address: -|ip-address
  BgpSession.peerSessionIPv4Address: -|ip-address
  BgpSession.peerSessionIPv6Address: -|ip-address
  CdnPeeringPrefix.properties.azureRegion: -|azure-location
  PeeringServiceLocation.properties.azureRegion: -|azure-location
  RpUnbilledPrefix.azureRegion: -|azure-location

directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Peering/checkServiceProviderAvailability"].post.responses.200.schema
    transform: >
      $["x-ms-enum"] = {
        "name": "PeeringServiceProviderAvailability",
        "modelAsString": true
      }
# there are multiple patch operations using the same definition of body parameter schema. This is very likely to be a source of future breaking changes.
# here we add some directive to decouple them
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Peering/peerings/{peeringName}"].patch.parameters[2].schema
    transform: >
      return {
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/ResourceTags"
          }
        ]
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Peering/peeringServices/{peeringServiceName}"].patch.parameters[2].schema
    transform: >
      return {
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/ResourceTags"
          }
        ]
      }
```
