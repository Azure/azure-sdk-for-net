# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: WebPubSub
namespace: Azure.ResourceManager.WebPubSub
require: https://github.com/Azure/azure-rest-api-specs/blob/fbc92628addef99e9521296af3f877a1dffe9c17/specification/webpubsub/resource-manager/readme.md
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

# mgmt-debug:
#  show-serialized-names: true

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
  WebPubSubResource.properties.disableAadAuth: IsAadAuthDisabled
  WebPubSubResource.properties.disableLocalAuth: IsLocalAuthDisabled
  WebPubSubResource: WebPubSub
  SharedPrivateLinkResource.properties.privateLinkResourceId: -|arm-id
  SharedPrivateLinkResource: WebPubSubSharedPrivateLink
  PrivateLinkResource.properties.shareablePrivateLinkResourceTypes: ShareablePrivateLinkTypes
  PrivateLinkResource: WebPubSubPrivateLink
  NameAvailability: WebPubSubNameAvailability
  NameAvailabilityParameters: WebPubSubNameAvailabilityParameters
  ShareablePrivateLinkResourceType: ShareablePrivateLinkType
  ShareablePrivateLinkResourceProperties: ShareablePrivateLinkProperties
  ShareablePrivateLinkResourceProperties.type: shareablePrivateLinkPropertiesType
  Sku.resourceType: -|resource-type
  Sku: WebPubSubSku
  ResourceSku: BillingInfoSku
  SkuCapacity: WebPubSubSkuCapacity
  NetworkACL: PublicNetworkAcls
  EventHandler: WebPubSubEventHandler
  ScaleType: WebPubSubScaleType
  KeyType: WebPubSubKeyType
  PrivateEndpoint.id: -|arm-id
  SignalRServiceUsage.id: -|arm-id
  WebPubSubTlsSettings.clientCertEnabled: IsClientCertEnabled
  PrivateLinkServiceConnectionStatus: WebPubSubPrivateLinkServiceConnectionStatus
  ProvisioningState: WebPubSubProvisioningState
  SharedPrivateLinkResourceStatus: WebPubSubSharedPrivateLinkStatus
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
  ApplicationFirewallSettings: WebPubSubApplicationFirewallSettings

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkResourceName}: WebPubSubSharedPrivateLink
```
