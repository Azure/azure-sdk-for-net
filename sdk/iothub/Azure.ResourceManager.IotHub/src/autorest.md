# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: IotHub
namespace: Azure.ResourceManager.IotHub
require: https://github.com/Azure/azure-rest-api-specs/blob/72cee8dc40fe3bc4b7956c87f269f5a363411913/specification/iothub/resource-manager/Microsoft.Devices/IoTHub/readme.md
#tag: package-preview-2025-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

override-operation-name:
  IotHubResource_CheckNameAvailability: CheckIotHubNameAvailability
  ResourceProviderCommon_GetSubscriptionQuota: GetIotHubUserSubscriptionQuota

rename-mapping:
  AccessRights: IotHubSharedAccessRight
  Capabilities: IotHubCapability
  CertificateProperties.created: CreatedOn
  CertificateProperties.expiry: ExpireOn
  CertificateProperties.thumbprint: ThumbprintString
  CertificateProperties.updated: UpdatedOn
  CertificatePropertiesWithNonce.created: CreatedOn
  CertificatePropertiesWithNonce.expiry: ExpireOn
  CertificatePropertiesWithNonce.thumbprint: ThumbprintString
  CertificatePropertiesWithNonce.updated: UpdatedOn
  CertificateVerificationDescription: IotHubCertificateVerificationContent
  DefaultAction: IotHubNetworkRuleSetDefaultAction
  EncryptionPropertiesDescription: IotHubEncryptionProperties
  EndpointHealthData: IotHubEndpointHealthInfo
  EndpointHealthDataListResult: IotHubEndpointHealthInfoListResult
  EventHubProperties: EventHubCompatibleEndpointProperties
  EventHubProperties.path: EventHubCompatibleName
  FeedbackProperties: CloudToDeviceFeedbackQueueProperties
  GroupIdInformation: IotHubPrivateEndpointGroupInformation
  GroupIdInformationProperties: IotHubPrivateEndpointGroupInformationProperties
  GroupIdInformationProperties.requiredZoneNames: RequiredDnsZoneNames
  IotHubNameAvailabilityInfo: IotHubNameAvailabilityResponse
  IotHubNameAvailabilityInfo.nameAvailable: IsNameAvailable
  IotHubNameUnavailabilityReason: IotHubNameUnavailableReason
  IotHubProperties.allowedFqdnList: allowedFqdns
  IotHubSku.GEN2: Gen2
  IotHubSkuDescription.resourceType: -|resource-type
  JobResponse: IotHubJobInfo
  JobResponse.endTimeUtc: EndOn
  JobResponse.startTimeUtc: StartOn
  JobResponseListResult : IotHubJobInfoListResult
  Name: IotHubTypeName
  OperationInputs: IotHubNameAvailabilityContent
  RootCertificateProperties.enableRootCertificateV2: IsRootCertificateV2Enabled
  RootCertificateProperties.lastUpdatedTimeUtc: LastUpdatedOn
  RouteProperties: RoutingRuleProperties
  RoutingEventHubProperties.endpointUri: Endpoint
  RoutingServiceBusQueueEndpointProperties.endpointUri: Endpoint
  RoutingServiceBusTopicEndpointProperties.endpointUri: Endpoint
  RoutingStorageContainerProperties.endpointUri: Endpoint
  UserSubscriptionQuota.id: IotHubTypeId

prepend-rp-prefix:
  - AuthenticationType
  - CertificateDescription
  - CertificateListDescription
  - CertificateProperties
  - CertificatePropertiesWithNonce
  - CertificateWithNonceDescription
  - DeviceRegistry
  - EndpointHealthStatus
  - EnrichmentProperties
  - FailoverInput
  - FallbackRouteProperties
  - ImportDevicesRequest
  - IpFilterActionType
  - IpFilterRule
  - IpVersion
  - JobStatus
  - JobType
  - KeyVaultKeyProperties
  - MatchedRoute
  - NetworkRuleIPAction
  - NetworkRuleSetIpRule
  - NetworkRuleSetProperties
  - PrivateEndpointConnectionProperties
  - PrivateEndpointConnectionsList
  - PrivateLinkResources
  - PrivateLinkServiceConnectionStatus
  - PublicNetworkAccess
  - RegistryStatistics
  - RootCertificateProperties
  - RoutingProperties
  - RoutingSource
  - StorageEndpointProperties
  - TestAllRoutesInput
  - TestAllRoutesResult
  - TestResultStatus
  - TestRouteInput
  - TestRouteResult
  - TestRouteResultDetails
  - UserSubscriptionQuota
  - UserSubscriptionQuotaListResult

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'certificate': 'any'
  'UserAssignedIdentity': 'arm-id'

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
  SAS: Sas

directive:
  - from: iothub.json
    where: $.definitions
    transform: >
      $.EventHubConsumerGroupBodyDescription.properties.properties['x-ms-client-flatten'] = true;
      $.EventHubConsumerGroupBodyDescription['x-ms-client-name'] = 'ConsumerGroupEventHubContent';
      $.RoutingEventHubProperties.properties.id['format'] = 'uuid';
      $.RoutingServiceBusQueueEndpointProperties.properties.id['format'] = 'uuid';
      $.RoutingServiceBusTopicEndpointProperties.properties.id['format'] = 'uuid';
      $.RoutingStorageContainerProperties.properties.id['format'] = 'uuid';

  - from: iothub.json
    where: $.definitions.EventHubConsumerGroupInfo.properties.etag
    transform: $["x-nullable"] = true

  # Resolve service issue: Azure/azure-rest-api-specs issue #19827
  - from: iothub.json
    where: $.definitions.PrivateEndpointConnectionsList
    transform: >
      $.type = "object";
      $.items = {};
      $.properties = {
        "value": {
          "description": "The array of Private Endpoint Connections.",
          "type": "array",
          "items": {
            "$ref": "#/definitions/PrivateEndpointConnection"
          }
        }
      }

```
