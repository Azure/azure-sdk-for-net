# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: IoTHub
namespace: Azure.ResourceManager.IoTHub
require: https://github.com/Azure/azure-rest-api-specs/blob/0f9df940977c680c39938c8b8bd5baf893737ed0/specification/iothub/resource-manager/readme.md
tag: package-2021-07-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

override-operation-name:
  IoTHubResource_CheckNameAvailability: CheckIoTHubNameAvailability
  ResourceProviderCommon_GetSubscriptionQuota: GetIoTHubUserSubscriptionQuota

rename-mapping:
  IoTHubNameAvailabilityInfo: IoTHubNameAvailabilityResponse
  IoTHubNameAvailabilityInfo.nameAvailable: IsNameAvailable
  OperationInputs: IoTHubNameAvailabilityContent
  Capabilities: IoTHubCapability
  CertificateProperties.created: CreatedOn
  CertificateProperties.updated: UpdatedOn
  CertificateProperties.expiry: ExpireOn
  CertificatePropertiesWithNonce.created: CreatedOn
  CertificatePropertiesWithNonce.updated: UpdatedOn
  CertificatePropertiesWithNonce.expiry: ExpireOn
  CertificateVerificationDescription: IoTHubCertificateVerificationContent
  GroupIdInformation: IoTHubPrivateEndpointGroupInformation
  GroupIdInformationProperties: IoTHubPrivateEndpointGroupInformationProperties
  DefaultAction: IoTHubNetworkRuleSetDefaultAction
  AccessRights: IoTHubSharedAccessRight
  FeedbackProperties: CloudToDeviceFeedbackQueueProperties
  Name: IoTHubTypeName
  EventHubProperties.path: EventHubCompatibleName
  EventHubProperties: EventHubCompatibleEndpointProperties
  RouteProperties: RoutingRuleProperties
  JobResponse.startTimeUtc: StartOn
  JobResponse.endTimeUtc: EndOn
  JobResponse: IoTHubJobInfo
  JobResponseListResult : IoTHubJobInfoListResult
  EndpointHealthData: IoTHubEndpointHealthInfo
  EndpointHealthDataListResult: IoTHubEndpointHealthInfoListResult
  UserSubscriptionQuota.id: IoTHubTypeId
  IoTHubNameUnavailabilityReason: IoTHubNameUnavailableReason
  IoTHubProperties.allowedFqdnList: allowedFqdns
  GroupIdInformationProperties.requiredZoneNames: RequiredDnsZoneNames
  RoutingEventHubProperties.endpointUri: Endpoint
  RoutingServiceBusQueueEndpointProperties.endpointUri: Endpoint
  RoutingServiceBusTopicEndpointProperties.endpointUri: Endpoint
  RoutingStorageContainerProperties.endpointUri: Endpoint

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
  - JobStatus
  - JobType
  - PrivateLinkResources
  - PrivateEndpointConnectionsList
  - PrivateLinkServiceConnectionStatus
  - PrivateEndpointConnectionProperties
  - RegistryStatistics
  - MatchedRoute
  - NetworkRuleSetProperties
  - NetworkRuleSetIPRule
  - NetworkRuleIPAction
  - RoutingProperties
  - StorageEndpointProperties

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'thumbprint': 'any'
  'certificate': 'any'
  'UserAssignedIdentity': 'arm-id'

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
  Iot: IoT

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
