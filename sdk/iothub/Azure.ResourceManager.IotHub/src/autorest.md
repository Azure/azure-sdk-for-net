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
  IotHubNameAvailabilityInfo.nameAvailable: IsNameAvailable
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
  FeedbackProperties: CloudToDeviceFeedbackQueueProperties
  Name: IotHubTypeName

prepend-rp-prefix:
  - AuthenticationType
  - TestAllRoutesResult
  - TestAllRoutesInput
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
  - FailoverInput
  - FallbackRouteProperties
  - ImportDevicesRequest
  - PublicNetworkAccess
  - UserSubscriptionQuota
  - UserSubscriptionQuotaListResult
  - IPFilterRule
  - IPFilterActionType
  - RoutingSource
  - JobResponse
  - JobResponseListResult
  - JobStatus
  - JobType
  - PrivateLinkResources
  - PrivateLinkServiceConnectionStatus
  - PrivateEndpointConnectionProperties
  - RegistryStatistics

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
  SAS: Sas

directive:
  - from: iothub.json
    where: $.definitions
    transform: >
      $.EventHubConsumerGroupBodyDescription.properties.properties['x-ms-client-flatten'] = true;
      $.EventHubConsumerGroupBodyDescription['x-ms-client-name'] = 'EventHubConsumerGroupContent';

```
