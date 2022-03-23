# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: WebPubSub
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47b551f58ee1b24f4783c2e927b1673b39d87348/specification/webpubsub/resource-manager/readme.md
tag: package-2021-10-01
clear-output-folder: true
skip-csproj: true
namespace: Azure.ResourceManager.WebPubSub
no-property-type-replacement: PrivateEndpoint

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
  # Change SharedPrivateLinkResource to SharedPrivateLink
  ## rename models
  - rename-model:
      from: PrivateLinkResource
      to: PrivateLink
  - rename-model:
      from: Sku
      to: WebPubSubResourceSku
  - rename-model:
      from: SharedPrivateLinkResource
      to: SharedPrivateLink
  - rename-model:
      from: SharedPrivateLinkResourceProperties
      to: SharedPrivateLinkProperties 
  - from: webpubsub.json
    where: $.definitions.SharedPrivateLinkResourceStatus
    transform: >
        $["x-ms-enum"] = {
            "name": "SharedPrivateLinkStatus",
            "modelAsString": true
        }
  - rename-model:
      from: sharedPrivateLinkResources
      to: SharedPrivateLinks 
  - from: webpubsub.json
    where: $.definitions.PrivateLinkResourceProperties.properties.shareablePrivateLinkResourceTypes
    transform: $["x-ms-client-name"] = "shareablePrivateLinkTypes"
  - rename-model:
      from: ShareablePrivateLinkResourceType
      to: ShareablePrivateLinkType
  - rename-model:
      from: ShareablePrivateLinkResourceProperties
      to: ShareablePrivateLinkProperties
  - rename-model:
      from: ResourceSku
      to: WebPubSubSku
  # Change WebPubSubResource to WebPubSub
  - rename-model:
      from: WebPubSubResource
      to: WebPubSub
```
