# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SignalR
namespace: Azure.ResourceManager.SignalR
require: https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/signalr/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  SignalRResource: SignalR
  CustomCertificateList: SignalRCustomCertificateListResult
  CustomDomainList: SignalRCustomDomainListResult
  NameAvailability: SignalRNameAvailabilityResult
  NameAvailabilityParameters: SignalRNameAvailabilityContent
  NameAvailabilityParameters.type: -|resource-type
  ACLAction: SignalRNetworkAclAction
  SignalRNetworkACLs: SignalRNetworkAcls
  NetworkACL: SignalRNetworkAcl
  PrivateEndpointACL: SignalRPrivateEndpointAcl
  PrivateEndpointConnectionList: SignalRPrivateEndpointConnectionListResult
  PrivateLinkResourceList: SignalRPrivateLinkResourceListResult
  ResourceLogConfiguration: SignalRResourceLogCategoryListResult
  SharedPrivateLinkResourceList: SignalRSharedPrivateLinkResourceListResult
  SkuList: SignalRSkuListResult
  SignalRTlsSettings.clientCertEnabled: IsClientCertEnabled
  NameAvailability.nameAvailable: IsNameAvailable
  SignalRRequestType.RESTAPI: RestApi
  Sku.resourceType: -|resource-type
  SignalRUsage.id: -|arm-id
  SharedPrivateLinkResource.properties.privateLinkResourceId: -|arm-id

prepend-rp-prefix:
  - CustomDomain
  - CustomCertificate
  - SharedPrivateLinkResource
  - FeatureFlags
  - KeyType
  - LiveTraceCategory
  - LiveTraceConfiguration
  - ProvisioningState
  - RegenerateKeyParameters
  - ResourceLogCategory
  - ResourceSku
  - ScaleType
  - ServiceKind
  - SharedPrivateLinkResourceStatus
  - SkuCapacity
  - UpstreamAuthSettings
  - UpstreamAuthType
  - UpstreamTemplate

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

override-operation-name:
  SignalR_CheckNameAvailability: CheckSignalRNameAvailability

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

```
