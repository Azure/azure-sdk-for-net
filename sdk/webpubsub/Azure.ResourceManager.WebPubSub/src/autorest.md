# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: WebPubSub
namespace: Azure.ResourceManager.WebPubSub
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47b551f58ee1b24f4783c2e927b1673b39d87348/specification/webpubsub/resource-manager/readme.md
tag: package-2021-10-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

no-property-type-replacement: PrivateEndpoint

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
  ACL: Acl
  ACLs: Acls

override-operation-name:
  WebPubSub_CheckNameAvailability: CheckWebPubSubNameAvailability
directive:
  - rename-model:
      from: PrivateLinkResource
      to: WebPubSubPrivateLink
  - rename-model:
      from: SharedPrivateLinkResource
      to: WebPubSubSharedPrivateLink
  - rename-model:
      from: NameAvailability
      to: WebPubSubNameAvailability
  - rename-model:
      from: NameAvailabilityParameters
      to: WebPubSubNameAvailabilityParameters
  - rename-model:
      from: WebPubSubResource
      to: WebPubSub
  - rename-model:
      from: ShareablePrivateLinkResourceType
      to: ShareablePrivateLinkType
  - rename-model:
      from: ShareablePrivateLinkResourceProperties
      to: ShareablePrivateLinkProperties

  - from: webpubsub.json
    where: $.definitions.SharedPrivateLinkResourceStatus
    transform: >
        $["x-ms-enum"] = {
            "name": "SharedPrivateLinkStatus",
            "modelAsString": true
        }
  - from: webpubsub.json
    where: $.definitions.PrivateLinkResourceProperties.properties.shareablePrivateLinkResourceTypes
    transform: $["x-ms-client-name"] = "shareablePrivateLinkTypes"
  - from: webpubsub.json
    where: $.definitions.PrivateLinkServiceConnectionStatus
    transform: $["x-ms-enum"].name = "WebPubSubPrivateLinkServiceConnectionStatus"
  - from: webpubsub.json
    where: $.definitions.ProvisioningState
    transform: $["x-ms-enum"].name = "WebPubSubProvisioningState"

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
  - from: webpubsub.json
    where: $.definitions.ScaleType
    transform: $['x-ms-enum'].name = 'WebPubSubScaleType'

  # Change type to ResourceIdentifier
  - from: webpubsub.json
    where: $.definitions.SharedPrivateLinkResourceProperties.properties.privateLinkResourceId
    transform: $['x-ms-format'] = 'arm-id'
```
