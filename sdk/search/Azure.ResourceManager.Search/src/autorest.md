# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Search
namespace: Azure.ResourceManager.Search
require: https://github.com/Azure/azure-rest-api-specs/blob/90f40429fa528a79c0641b0bb743eb95bc151ec8/specification/search/resource-manager/readme.md
#tag: package-preview-2025-10-01
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

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  AadAuthFailureMode: SearchAadAuthFailureMode
  AccessRule: SearchServiceNetworkSecurityPerimeterAccessRule
  AccessRuleDirection: SearchServiceNetworkSecurityPerimeterAccessRuleDirection
  AccessRuleProperties: SearchServiceNetworkSecurityPerimeterAccessRuleProperties
  AdminKeyKind: SearchServiceAdminKeyKind
  AdminKeyResult: SearchServiceAdminKeyResult
  CheckNameAvailabilityInput: SearchServiceNameAvailabilityContent
  CheckNameAvailabilityOutput: SearchServiceNameAvailabilityResult
  ComputeType: SearchServiceComputeType
  DataPlaneAuthOptions: SearchAadAuthDataPlaneAuthOptions
  EncryptionWithCmk: SearchEncryptionWithCmk
  HostingMode: SearchServiceHostingMode
  IpRule: SearchServiceIPRule
  IssueType: SearchServiceNetworkSecurityPerimeterProvisioningIssueType
  NetworkRuleSet: SearchServiceNetworkRuleSet
  NetworkSecurityPerimeter: SearchServiceNetworkSecurityPerimeter
  NetworkSecurityPerimeterConfiguration: SearchServiceNetworkSecurityPerimeterConfiguration
  NetworkSecurityPerimeterConfigurationProperties: SearchServiceNetworkSecurityPerimeterConfigurationProperties
  NetworkSecurityPerimeterConfigurationProvisioningState: SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState
  NetworkSecurityProfile: SearchNetworkSecurityProfile
  PrivateEndpointConnectionProperties: SearchServicePrivateEndpointConnectionProperties
  PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState: SearchServicePrivateLinkServiceConnectionState
  PrivateLinkServiceConnectionStatus: SearchServicePrivateLinkServiceConnectionStatus
  PrivateLinkServiceConnectionProvisioningState: SearchPrivateLinkServiceConnectionProvisioningState
  ProvisioningIssue: SearchServiceNetworkSecurityPerimeterProvisioningIssue
  ProvisioningIssueProperties: SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties
  ProvisioningState: SearchServiceProvisioningState
  PublicNetworkAccess: SearchServicePublicInternetAccess
  QueryKey: SearchServiceQueryKey
  ResourceAssociation: SearchServiceNetworkSecurityPerimeterResourceAssociation
  ResourceAssociationAccessMode: SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode
  ResourceType: SearchServiceResourceType
  SearchEncryptionWithCmk: SearchEncryptionWithCmkEnforcement
  SearchService.properties.disableLocalAuth: isLocalAuthDisabled
  SearchService.properties.publicNetworkAccess: PublicInternetAccess
  SearchService.properties.upgradeAvailable: IsUpgradeAvailable
  SearchService.sku: SearchSku
  SearchServiceUpdate.properties.disableLocalAuth: isLocalAuthDisabled
  SearchServiceUpdate.properties.publicNetworkAccess: PublicInternetAccess
  SearchServiceUpdate.properties.upgradeAvailable: IsUpgradeAvailable
  SearchServiceUpdate.sku: SearchSku
  Severity: SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity
  ShareablePrivateLinkResourceProperties: ShareableSearchServicePrivateLinkResourceProperties
  ShareablePrivateLinkResourceType: ShareableSearchServicePrivateLinkResourceType
  SharedPrivateLinkResource: SharedSearchServicePrivateLinkResource
  SharedPrivateLinkResourceProperties: SharedSearchServicePrivateLinkResourceProperties
  SharedPrivateLinkResourceProperties.privateLinkResourceId: -|arm-id
  SharedPrivateLinkResourceProperties.resourceRegion: -|azure-location
  SharedPrivateLinkResourceProperties.status: SharedPrivateLinkResourceStatus
  SharedPrivateLinkResourceProperties.provisioningState: SharedPrivateLinkResourceProvisioningState
  SharedPrivateLinkResourceProvisioningState: SearchServiceSharedPrivateLinkResourceProvisioningState
  SharedPrivateLinkResourceStatus: SearchServiceSharedPrivateLinkResourceStatus
  SkuName: SearchServiceSkuName
  UnavailableNameReason: SearchServiceNameUnavailableReason
  UpgradeAvailable: SearchServiceUpgradeAvailable

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
  ETag: ETag|eTag
  NSP: Nsp|nsp

override-operation-name:
  Services_CheckNameAvailability: CheckSearchServiceNameAvailability

# Remove "stopped" enum from SearchServiceStatus
directive:
  - from: search.json
    where: $.definitions.SearchServiceProperties.properties.status
    transform: >
      $.enum.includes('stopped') ? $.enum.splice($.enum.indexOf('stopped'), 1) : undefined;
      $['x-ms-enum'].values.map(e => e.value).includes('stopped') ? $['x-ms-enum'].values.splice($['x-ms-enum'].values.map(e => e.value).indexOf('stopped'), 1) : undefined;
  - from: search.json
    where: $.definitions
    transform: >
      $.QuotaUsageResult.properties.id['x-ms-format'] = 'arm-id';
```
