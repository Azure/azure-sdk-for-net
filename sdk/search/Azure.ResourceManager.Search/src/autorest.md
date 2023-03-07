# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: Search
namespace: Azure.ResourceManager.Search
require: https://github.com/Azure/azure-rest-api-specs/blob/20450db14856ccac2af2c28de56fd436c63bb726/specification/search/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  AadAuthFailureMode: SearchAadAuthFailureMode
  AdminKeyKind: SearchServiceAdminKeyKind
  AdminKeyResult: SearchServiceAdminKeyResult
  CheckNameAvailabilityInput: SearchServiceNameAvailabilityContent
  CheckNameAvailabilityOutput: SearchServiceNameAvailabilityResult
  DataPlaneAuthOptions: SearchAadAuthDataPlaneAuthOptions
  EncryptionWithCmk: SearchEncryptionWithCmk
  HostingMode: SearchServiceHostingMode
  IpRule: SearchServiceIPRule
  PrivateEndpointConnectionProperties: SearchServicePrivateEndpointConnectionProperties
  PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState: SearchServicePrivateLinkServiceConnectionState
  PrivateLinkServiceConnectionStatus: SearchServicePrivateLinkServiceConnectionStatus
  PrivateLinkServiceConnectionProvisioningState: SearchPrivateLinkServiceConnectionProvisioningState
  ProvisioningState: SearchServiceProvisioningState
  PublicNetworkAccess: SearchServicePublicNetworkAccess
  QueryKey: SearchServiceQueryKey
  ResourceType: SearchServiceResourceType
  SearchEncryptionWithCmk: SearchEncryptionWithCmkEnforcement
  SearchServiceData.DisableLocalAuth: IsLocalAuthDisabled
  ShareablePrivateLinkResourceProperties: ShareableSearchServicePrivateLinkResourceProperties
  ShareablePrivateLinkResourceType: ShareableSearchServicePrivateLinkResourceType
  SharedPrivateLinkResource: SharedSearchServicePrivateLinkResource
  SharedPrivateLinkResourceProperties: SharedSearchServicePrivateLinkResourceProperties
  SharedPrivateLinkResourceProperties.privateLinkResourceId: -|arm-id
  SharedPrivateLinkResourceProperties.resourceRegion: -|azure-location
  SharedPrivateLinkResourceProvisioningState: SharedSearchServicePrivateLinkResourceProvisioningState
  SharedPrivateLinkResourceStatus: SharedSearchServicePrivateLinkResourceStatus
  UnavailableNameReason: SearchServiceNameUnavailableReason
  

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
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

override-operation-name:
  Services_CheckNameAvailability: CheckSearchServiceNameAvailability

# Remove "stopped" enum from SearchServiceStatus

directive:
  - from: search.json
    where: $.definitions.SearchServiceProperties.properties.status
    transform: >
      $.enum.includes('stopped') ? $.enum.splice($.enum.indexOf('stopped'), 1) : undefined;
      $['x-ms-enum'].values.map(e => e.value).includes('stopped') ? $['x-ms-enum'].values.splice($['x-ms-enum'].values.map(e => e.value).indexOf('stopped'), 1) : undefined;

```
