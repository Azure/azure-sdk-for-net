# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: WebPubSub
namespace: Azure.ResourceManager.WebPubSub
require: https://github.com/Azure/azure-rest-api-specs/blob/f5b206304b14b34e13c06f6dbd5c4a10df3c1329/specification/webpubsub/resource-manager/readme.md
# tag: package-2025-01-01-preview
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

no-property-type-replacement: PrivateEndpoint

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
  ACL: Acl
  ACLs: Acls

override-operation-name:
  WebPubSub_CheckNameAvailability: CheckWebPubSubNameAvailability

rename-mapping:
  WebPubSubResource: WebPubSub
  SharedPrivateLinkResource: WebPubSubSharedPrivateLink
  RegenerateKeyParameters: WebPubSubRegenerateKeyContent
  ClientConnectionCountRule.type: ThrottleType
  ClientTrafficControlRule.type: TrafficThrottleType
  EventListenerFilter.type: EventListenerFilterType
  EventListenerEndpoint.type: EventListenerEndpointType
  CustomCertificate: WebPubSubCustomCertificate
  CustomDomain: WebPubSubCustomDomain
  Replica: WebPubSubReplica
  EventHubEndpoint: WebPubSubEventHubEndpoint
  EventListener: WebPubSubEventListener
  IPRule: PublicTrafficIPRule
  ServiceKind: WebPubSubServiceKind

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkResourceName}: WebPubSubSharedPrivateLink

directive:
  - rename-model:
      from: PrivateLinkResource
      to: WebPubSubPrivateLink
#   - rename-model:
#       from: SharedPrivateLinkResource
#       to: WebPubSubSharedPrivateLink
  - rename-model:
      from: NameAvailability
      to: WebPubSubNameAvailability
  - rename-model:
      from: NameAvailabilityParameters
      to: WebPubSubNameAvailabilityParameters
#   - rename-model:
#       from: WebPubSubResource
#       to: WebPubSub
  - rename-model:
      from: ShareablePrivateLinkResourceType
      to: ShareablePrivateLinkType
  - rename-model:
      from: ShareablePrivateLinkResourceProperties
      to: ShareablePrivateLinkProperties

  - from: webpubsub.json
    where: $.definitions.PrivateLinkResourceProperties.properties.shareablePrivateLinkResourceTypes
    transform: $["x-ms-client-name"] = "shareablePrivateLinkTypes"
  - from: webpubsub.json
    where: $.definitions.PrivateLinkServiceConnectionStatus
    transform: $["x-ms-enum"].name = "WebPubSubPrivateLinkServiceConnectionStatus"
  - from: webpubsub.json
    where: $.definitions.ProvisioningState
    transform: $["x-ms-enum"].name = "WebPubSubProvisioningState"
  - from: webpubsub.json
    where: $.definitions.SharedPrivateLinkResourceStatus
    transform: $["x-ms-enum"].name = "WebPubSubSharedPrivateLinkStatus"
  - from: webpubsub.json
    where: $.definitions.Sku.properties.resourceType
    transform: $['x-ms-format']= "resource-type"

  # rename classes with common names
  - rename-model:
      from: Sku
      to: WebPubSubSku
  - rename-model:
      from: ResourceSku
      to: BillingInfoSku
  - rename-model:
      from: SkuCapacity
      to: WebPubSubSkuCapacity
  - rename-model:
      from: NetworkACL
      to:  PublicNetworkAcls
  - rename-model:
      from: EventHandler
      to:  WebPubSubEventHandler
  - from: webpubsub.json
    where: $.definitions.ScaleType
    transform: $['x-ms-enum'].name = 'WebPubSubScaleType'
  - from: webpubsub.json
    where: $.definitions.KeyType
    transform: $['x-ms-enum'].name = 'WebPubSubKeyType'

  # Change type to ResourceIdentifier
  - from: webpubsub.json
    where: $.definitions.SharedPrivateLinkResourceProperties.properties.privateLinkResourceId
    transform: $['x-ms-format'] = 'arm-id'
  - from: webpubsub.json
    where: $.definitions.PrivateEndpoint.properties.id
    transform: $['x-ms-format'] = 'arm-id'
  - from: webpubsub.json
    where: $.definitions.SignalRServiceUsage.properties.id
    transform: $['x-ms-format'] = 'arm-id'

  # Rename some class names of boolean types
  - from: webpubsub.json
    where: $.definitions.WebPubSubTlsSettings.properties.clientCertEnabled
    transform: $["x-ms-client-name"] = 'isClientCertEnabled'
  - from: webpubsub.json
    where: $.definitions.WebPubSubProperties.properties.disableAadAuth
    transform: $["x-ms-client-name"] = 'isAadAuthDisabled'
  - from: webpubsub.json
    where: $.definitions.WebPubSubProperties.properties.disableLocalAuth
    transform: $["x-ms-client-name"] = 'isLocalAuthDisabled'
```
