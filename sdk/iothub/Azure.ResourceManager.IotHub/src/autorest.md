# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: IotHub
namespace: Azure.ResourceManager.IotHub
require: https://github.com/Azure/azure-rest-api-specs/blob/0f9df940977c680c39938c8b8bd5baf893737ed0/specification/iothub/resource-manager/readme.md
tag: package-2021-07-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug: 
  show-serialized-names: true

override-operation-name:
  IotHubResource_CheckNameAvailability: CheckIotHubNameAvailability

rename-mapping:
  IotHubNameAvailabilityInfo: IotHubNameAvailabilityResponse
  OperationInputs: IotHubNameAvailabilityContent
  Capabilities: IotHubCapability
  CertificateProperties.created: CreatedOn
  CertificateProperties.updated: UpdatedOn
  CertificateProperties.expiry: ExpiryOn
  CertificatePropertiesWithNonce.created: CreatedOn
  CertificatePropertiesWithNonce.updated: UpdatedOn
  CertificatePropertiesWithNonce.expiry: ExpiryOn
  CertificateVerificationDescription: IotHubCertificateVerificationContent
  GroupIdInformation: IotHubPrivateEndpointGroupInformation
  GroupIdInformationProperties: IotHubPrivateEndpointGroupInformationProperties
  DefaultAction: IotHubNetworkRuleSetDefaultAction
  AccessRights: IotHubSharedAccessRight

prepend-rp-prefix:
  - AuthenticationType
  - TestAllRoutesResult
  - TestRouteInput
  - TestRouteResult
  - TestRouteResultDetails
  - TestResultStatus
  - CertificateProperties
  - CertificatePropertiesWithNonce
  - CertificateDescription
  - CertificateListDescription
  - CertificateWithNonceDescription
  - EndpointHealthData
  - EndpointHealthDataListResult
  - EndpointHealthStatus
  - EnrichmentProperties

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'thumbprint': 'any'
  'certificate': 'any'

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

```
